
import pandas as pd
import tkinter
from tkinter import END, TOP, filedialog
import csv
from tkinter import messagebox
import math
import copy
from itertools import combinations

# Definicion de funciones
def fnExaminar():
    # Abre el explorador de archivos de windows e inserta la direccion del archivo seleccionado en el campo de texto
    # PARAMETROS DE -> filedialog.askopenfilename(title= 'titulo de la ventana de explorador de archivos', filetypes= 'los tipos de archivo que se podran seleccionar en la ventana ('descripcion', 'tipo de dato')')
    ventana.filePath = filedialog.askopenfilename(title="Selecciona el Dataset en formato csv",
        filetypes=[("csv files", "*.csv")])
    #PARAMETROS DE -> txtFilePath.delete('coordenada de inicio', 'coordenada de fin')
    txtFilePath.delete(1.0, END)
    txtFilePath.insert(1.0, ventana.filePath)

def fnClear():
    # Limpia los elementos de la ventana
    for elem in dataFrame.winfo_children():
        elem.destroy()
    ventana.Parameters = []

def fnSumCenter(cent, am):
    newCent = cent
    aum = False
    for i in reversed(range(0, len(newCent))):
        if newCent[i] < 1:
            x = [newCent[i] * 100, am * 100]
            new = math.fsum(x) / 100
            newCent[i] = new
            aum = True
            break
        else:
            newCent[i] = 0
    return newCent, aum

def fnAddCenter(centros):
    best = [-1, copy.deepcopy(centros[0])]
    newCentros = copy.deepcopy(centros)
    n = len(centros.keys())
    newCentros[n] = best[1]
    testCentro = copy.deepcopy(centros[0])
    testCentro, aum = fnSumCenter(testCentro, 0.05)
    lCentros = []
    for c in centros.keys():
        lCentros.append(centros[c])
    while aum:
        dist = 0
        diferential = []
        for c in centros.keys():
            cDist = 0
            v = 0
            for var in testCentro:
                cDist = cDist + math.pow((var - centros[c][v]), 2)
                v = v + 1
            x = math.sqrt(cDist)
            diferential.append(x)
            dist = dist + x
        combDif = list(combinations(diferential, 2))
        # Se le resta a la distancia, la diferencia de todas las distancias a los centros, 
        # para obtener un valor mas centrado y que se diferencie mas de los dejas centros
        for x in combDif:
            dist = dist - abs(x[0] - x[1])
        if (best[0] < dist or best[0] == -1) and testCentro not in lCentros:
            best = [dist, copy.deepcopy(testCentro)]
        testCentro, aum = fnSumCenter(testCentro, 0.05)
    newCentros[n] = best[1]
    return newCentros

def fnMoveCenters(_centros, _vNormalizadas, _owners, _reg):
    cent = copy.deepcopy(_centros)
    vNorm = copy.deepcopy(_vNormalizadas)
    newCenters = dict()
    for c in cent.keys():
        newCenters[c] = []
        m = 0
        for v in vNorm.keys():
            nv = 0 # Valor acumulado de las instancias en la variable que pertenecen al centro
            vo = 1 # Cantidad de instancias en el centro, empieza en 1 porque se cuenta el centro
            for r in range(0, _reg - 1):
                if _owners[r] == c:
                    nv = nv + vNorm[v][r]
                    vo = vo + 1
            # Se calcula la nueva coordenada
            centCoord = (cent[c][m] + nv) / vo
            newCenters[c].append(centCoord)
            m = m + 1
    return newCenters

def fnCluster(dCentros, dVarN, reg):
    _f = open('log_KMeans.txt', 'a')
    # No se por que, abrir el archivo en modo append ignora las primeras lineas ya escritas, 
    # es por ello que se deben escribir estos saltos vacios
    _f.write('\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n')
    _f.write('\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n')
    _f.write('\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n')
    _f.write('\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n')
    _f.write('\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n')
    it = dict()
    bestDistance = dict()
    centrosIt = dict()
    cnt = copy.deepcopy(dCentros)
    centros = dCentros
    bestDistAmCent = -1
    mejoroAddCent = True
    bestCentros = dict()
    # Repetimos hasta que ya no mejore al agregar centros
    while mejoroAddCent:
        _f.write( '\n-------------\n\nCentros origen: \n' )
        for k in centros.keys():
            _f.write( 'Centro ' + str(k + 1) + ': ' + str([round(key, 2) for key in centros[k]]) + '\n' )
        mejoroMovCent = True
        bestDist = -1
        it[len(centros.keys())] = 0
        bestDistance[len(centros.keys())] = 0
        centrosIt[len(centros.keys())] = []
        # Repetimos hasta que ya no mejore al mover los centros
        while mejoroMovCent:
            distCentro= dict()
            owner = dict()
            for c in centros.keys():
                _f.write('\nDistancia de la instancia al centro ' + str(c) + ': ')
                distCentro[c] = []
                # Se recorre cada instancia
                for r in range(0, reg - 1):
                    # Se calcula la distancia entre la variable de la instancia y la del centro
                    dist = 0
                    m = 0
                    for l in dVarN.keys():
                        dist = dist + math.pow((dVarN[l][r] - centros[c][m]), 2)
                        m = m + 1
                    dcc = math.sqrt(dist)
                    distCentro[c].append(dcc)
                    _f.write('\n' + str(r) + ') [' + str(round(dcc,2)) + ']')
            # Se asignan las instancias a los clusters y se guarda la distancia minima para evaluar los centros
            minDist = 0
            for r in range(0, reg - 1):
                best = (-1, -1)
                for c in distCentro.keys():
                    if best[1] >= distCentro[c][r] or best[0] == -1:
                        best = (c, distCentro[c][r])
                owner[r] = best[0]
                minDist = minDist + best[1]
            ownd = dict()
            for r in owner.keys():
                if owner[r] not in ownd.keys():
                    ownd[owner[r]] = [r]
                else:
                    ownd[owner[r]].append(r)
            for o in ownd.keys():
                _f.write('\nInstancias que pertenecen al centro ' + str(o) + ':\n' + str(ownd[o]))
            _f.write('\n\nDistancia total de instancias a sus respectivos clusters: ' + str(round(minDist, 2)))
            # Se evaluan los centros
            if bestDist > minDist or bestDist == -1:
                mejoroMovCent = True
                bestDist = minDist
                # Mover Centros
                _f.write('\n\nLa distancia Mejoro moviendo los centros.\nSe mueven los centros. Nuevos centros -->\n')
                nCenters = fnMoveCenters(centros, dVarN, owner, reg)
                centros = copy.deepcopy(nCenters)
                for k in centros.keys():
                    s = str([round(key, 2) for key in centros[k]])
                    _f.write( 'Centro ' + str(k + 1) + ': ' + s + '\n' )
            else:
                _f.write('\n\nLa distancia no mejoro moviendo los centros.')
                mejoroMovCent = False
            centrosIt[len(centros.keys())] = centros
            it[len(centros.keys())] = it[len(centros.keys())] + 1
        bestDistance[len(centros.keys())] = bestDist
        if bestDistAmCent == -1 or bestDistAmCent > bestDist:
            for k in centrosIt[len(centros.keys())].keys():
                bestCentros[k] = []
                for v in centrosIt[len(centros.keys())][k]:
                    bestCentros[k].append(round(v,2))
            _f.write('\n\nLa distancia Mejoro agregando un centro. Nuevos centros -->\n')
            mejoroAddCent = True
            bestDistAmCent = bestDist
            # Agregar centro
            cnt = fnAddCenter(cnt)
            centros = cnt
            for k in centros.keys():
                s = str([round(key, 2) for key in centros[k]])
                _f.write( 'Centro ' + str(k + 1) + ': ' + s + '\n' )
        else:
            _f.write('\n\nLa distancia no mejoro agregando un centro.')
            mejoroAddCent = False
        # ------------------------ Resultados de por cada centro agregado
    _f.write('\n\n----------------------\nLos Mejores centros son:\n')
    for k in bestCentros.keys():
        _f.write( 'Centro ' + str(k + 1) + ': ' + str(bestCentros[k]) + '\n' )
    _f.write('\nCon distancia de: ' + str(bestDistance[len(bestDistance)]))
    _f.write('\nDespues de mover sus centros [' + str(it[len(it.keys())]) + '] veces.')
    messagebox.showinfo('Proceso Terminado', 'El proceso termino con exito, revise el log para ver los resultados.')
    _f.close()

def fnCalcCentros(keys):
    c1 = []
    c2 = []
    for k in keys:
        c1.append(0)
        c2.append(1)
    centros = {0:c1, 1:c2}
    return centros

def fnReadDS():
    f = open('log_KMeans.txt', 'w+')
    ventana.n = 0
    # Lee los datos del archivo en la direccion ingresada en el campo de texto de la ventana y los guarda en DS, luego llama a fnCreateParameters() para crear parametros y refresca la tabla de datos
    try:
        ventana.txtOutput = 0
        fnClear()
        # Abrimos el archivo
        with open(ventana.filePath, mode='r') as file:
            # Leemos el CSV
            csvFile = csv.reader(file)
            # Creamos diccionarios
            dictVar = dict()
            dictVarMax = dict()
            dictVarMin = dict()
            dictVarNorm = dict()
            i = 0
            f.write('Valores Reales -->\n')
            for row in csvFile:
                strWrite = str(i) + ') ' + str(row)
                if i == 0: 
                    for var in row:
                        dictVar[var] = []
                        dictVarNorm[var] = []
                        dictVarMax[var] = 0
                        dictVarMin[var] = 0
                    # Calcular Centros
                    dictCentros = fnCalcCentros(dictVar.keys())
                elif i == 1:
                    j = 0
                    for var in dictVar.keys():
                        dictVarMax[var] = float(row[j])
                        dictVarMin[var] = float(row[j])
                        dictVar[var].append(float(row[j]))
                        j = j + 1
                else:
                    j = 0
                    for var in dictVar.keys():
                        if float(row[j]) > dictVarMax[var]:
                            dictVarMax[var] = float(row[j])
                        if float(row[j]) < dictVarMin[var]:
                            dictVarMin[var] = float(row[j])
                        dictVar[var].append(float(row[j]))
                        j = j + 1
                i = i + 1
                f.write(strWrite + '\n')
            f.write('\nValores Normalizados -->\n')
            ventana.n = i
            # Obtenemos valores normalizados
            for var in dictVar.keys():
                m = float(1 / (dictVarMax[var] - dictVarMin[var]))
                b = float(-1 * (m * dictVarMin[var]))
                for r in range(0, i - 1):
                    dictVarNorm[var].append((m * dictVar[var][r]) + b)
            # Escribimos valores normalizados
            strWrite = ''
            for r in range(0, i - 1):
                ks = list(dictVar.keys())
                for var in ks:
                    if var == ks[0]:
                        strWrite = strWrite + str(r + 1) + ') ['
                    strWrite = strWrite + "'" +str(round(dictVarNorm[var][r], 2)) + "'"
                    if var == ks[len(ks) - 1]:
                        strWrite = strWrite + ']'
                    else:
                        strWrite = strWrite + ','
                strWrite = strWrite + '\n'
            f.write(strWrite)
    except:
        messagebox.showerror("Error al intentar leer los datos", "Hubo un error al tratar de leer el archivo seleccionado.\nPor favor, recuerde que el dataset ingresado debe contener solamente los encabezados de la comlumna y valores numericos\n")
    ventana.mnDistACent = dict()
    fnCluster(dictCentros, dictVarNorm, ventana.n)
    f.close()

# Se crea el objeto ventana
ventana = tkinter.Tk()
ventana.title("K-means Clustering no Supervisado")
ventana.geometry("1250x750")
ventana.filePath = ""

# Frame de datos
dataFrame = tkinter.Frame(ventana)

# Botones de ejecucion
execFrame = tkinter.Frame(ventana)

btnReadDS = tkinter.Button(execFrame, text="Leer Dataset", command=fnReadDS)
btnReadDS.grid(row=0, column=0)

btnClear = tkinter.Button(execFrame, text="Limpiar", command= fnClear)
btnClear.grid(row=0, column=1)

# Se crean elementos del buscador de archivos
fileFrame = tkinter.Frame(ventana)

strPedirArchivo = tkinter.Label(fileFrame, text = "Dataset: ")
strPedirArchivo.grid(row=0, column=0)

txtFilePath = tkinter.Text(fileFrame, width=70, height=1)
txtFilePath.grid(row=0, column=1)

btnExaminar = tkinter.Button(fileFrame, text = "Examinar", command = fnExaminar)
btnExaminar.grid(row=0, column=2)

# Se empacan los objetos
fileFrame.pack(side=TOP)
execFrame.pack(side=tkinter.BOTTOM)
dataFrame.pack()


# Se llama la ventana
ventana.mainloop()