from typing import Any
import cv2
import numpy as np

def processPupil(_Detector, _img, _B, _GlareDir, _CCont):
    Height, Width = _img.shape[:2]
    tWidth = Width /5

    # Verificamos que se haya tomado una buena muestra
    if _B and Height > 0 and Width > 0: 
        # Buscamos la pupila
        keyPoint = _Detector.detect(_img)

        # Dibujamos circulo rojo en la pupila
        _img = cv2.drawKeypoints(_img, keyPoint, _img, (0, 0, 255), cv2.DRAW_MATCHES_FLAGS_DRAW_RICH_KEYPOINTS)

        # Verificamos su direccion
        for kp in keyPoint:
            # kp.pt[0] regresa el la coordenada x de la pupila
            if(int(kp.pt[0]) < int((Width/2) - tWidth)):
                # Esta en el lado izquierdo
                _GlareDir = "<- Izquierda <-"
                _CCont = 3
            elif(int(kp.pt[0]) > int((Width/2) + tWidth)):
                # Esta en el lado derecho
                _GlareDir = "-> Derecha ->"
                _CCont = 3
            elif _CCont <= 0:
                # Esta en el centro
                _GlareDir = "<- Centro ->"
            else:
                _CCont = _CCont - 1

            break

        # Mostramos el ojo recortado y filtrado para debugging
        cv2.imshow('Eye',_img)
    else: 
        print(str(Height) + ' - ' + str(Width))
    return _GlareDir, _CCont

def cropBrows(_Aux):
    # Agrandamos el ojo y lo encuadramos
    _Aux = cv2.resize(_Aux, (100,100), interpolation=cv2.INTER_CUBIC)

    # Guardamos sus dimensiones
    height, width = _Aux.shape[:2]

    # browH guarda los pixeles en eje Y en que se guarda la ceja
    browH = int(height/4)
    widthTrim = int(width/8)

    # Recortamos la ceja
    _Aux = _Aux[browH : height, widthTrim : width]
    return _Aux

def readEyes(_eClass, _aux, _frame, _x, _y):
    # Detectamos ojos
    eye = _eClass.detectMultiScale(_aux)

    # Por cada ojo obtenemos sus coordenadas (Xini, Yini, Xfin, Yfin)
    for (i,j,m,n) in eye:

        # Verificamos que el objeto detectado esta en la parte superior del rostro
        height = np.size(_aux, 0)
        if j+n <= height/2:
            # Pintamos un recuadro en el frame sobre el ojo y recortamos el auxiliar
            cv2.rectangle(_frame, (i + _x, j + _y), (i + m + _x, j + n + _y), (255,0,0), 2)
            
            # Recortamos el ojo en el auxiliar y luego cortamos las cejas
            _aux = _aux[j : j + n, i : i + m]
            _aux = cropBrows(_aux)

            # Binarizamos la imagen con un threshold 
            _, _aux = cv2.threshold(_aux, thresh=47, maxval=255,  type=cv2.THRESH_BINARY)
            _aux = cv2.erode(_aux, None, iterations=2)
            _aux = cv2.dilate(_aux, None, iterations=5)
            _aux = cv2.medianBlur(_aux, 5)

            # Un break para solo detectar 1 ojo
            return _frame, _aux, _
    return _frame, _aux, False

def readFaces(fClass, frame):
    # Creamos frame auxiliar en blanco y negro y lo suavisamos
    aux = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    aux = cv2.GaussianBlur(aux, (7, 7), 0)

    # Usamos el clasificador para detectar rostros en el frame auxiliar
    Face = fClass.detectMultiScale(aux, 1.3, 5)

    # Por cada rostro encontrado obtenemos sus coordenadas (Xini, Yini, Xfin, Yfin)
    for (x,y,w,h) in Face:

        # Pintar recuadro al rededor del rostro en el frame
        cv2.rectangle(frame, (x,y),(x+w,y+h), (0,255,0), 2)

        # Recortamos el frame auxiliar para solo tener el rostro y buscamos ojos con el clasidicador
        aux = aux[y:y+h, x:x+w]

        return frame, aux, x, y
    return frame, aux, 0, 0

# Importing camera
cam = cv2.VideoCapture(0) # 0 = default camera

# Declaring Classifiers (face and eyes)
eyeCalssif = cv2.CascadeClassifier('./haarcascade_eye.xml')
faceCalssif = cv2.CascadeClassifier('./haarcascade_frontalface_default.xml')

# Blob detector parammeters
detector_params = cv2.SimpleBlobDetector_Params()
detector_params.filterByArea = True
detector_params.maxArea = 1500
detector = cv2.SimpleBlobDetector_create(detector_params)

glareDir = "Pendiente..."
cCont = 0
x = 0
y = 0

# Leemos cada frame de la webcam hasta que se presione esc_key
while True:
    # Guardamos el frame
    check, Frame = cam.read()
    # La camara web tomma la imagen con el eje x invertido, lo invertimos
    Frame = cv2.flip(Frame, 1)
    # Si se pudo obtener el frame...
    if check: 
        # Leemos los rostros, regresamos el frame de output, el frame recortado y las coordenadas del rostro
        Frame, aux, x, y = readFaces(faceCalssif, Frame)

        # Leemos el primer ojo en la imagen, regresamos el frame de output, el frame recortado y filtrado del ojo y una variable booleana que indica si se puso filtrar el ojo
        Frame, aux, bAux = readEyes(eyeCalssif, aux, Frame, x, y)

        # Procesamos las pupilas, regresa string de direccion de mirada y un contador auxiliar
        glareDir, cCont = processPupil(detector, aux, bAux, glareDir, cCont)

        cv2.putText(Frame, glareDir, (x, y-10), cv2.FONT_HERSHEY_SIMPLEX, 0.9, (36,255,12), 2)
        
        cv2.imshow("EyeTracking", Frame) 

    # Si se presiona esc salimos 
    key = cv2.waitKey(1)
    if key == 27 or not check:
        break
cam.release()
cv2.destroyAllWindows()