
import pandas as pd
import tkinter
from tkinter import BOTTOM, END, HORIZONTAL, RIGHT, TOP, VERTICAL, filedialog, ttk
import csv
from tkinter import messagebox
import math

# Declaracion de Constantes
COLNAMES = []
DS = []
POINTS = []
DF = pd.DataFrame()
PF = []
CONST = 0

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

def fnPlot(_df):
    # Grafica los datos proporcionados en df
    if ventana.txtOutput != 0:
        ventana.txtOutput.destroy()
        ventana.sBY.destroy()
        ventana.sBX.destroy()
    # PARAMETROS DE -> ttk.Treeview('Frame padre', columns= 'nombres de las columnas (se envian [+1:] porque tambien hay una columna de registro en #0)')
    ventana.txtOutput = ttk.Treeview(dataFrame, columns=(COLNAMES[0][+1:]))
    # PARAMETROS DE -> ventana.txtOutput.column('nombre de columna columna', width= 'ancho de la columna')
    ventana.txtOutput.column("#0", width=250)
    # PARAMETROS DE -> ventana.txtOutput.heading('nombre de columna columna', text= 'titulo de la columna')
    ventana.txtOutput.heading("#0", text="name")
    d = 0
    for col in COLNAMES[0][+1:]:
        ventana.txtOutput.column(col, width=75)
        ventana.txtOutput.heading(col, text= col)
        d = d + 1

    for rows in _df.to_numpy().tolist():
        # PARAMETROS DE -> ventana.txtOutput.insert('padre (para crear submenus o listas), en este caso, no tiene', 'donde se va a insertar, en este caso, al final',
        # text= 'nombre del registro, valor de columna #0', values= 'valores del registro, lista de valores en las columnas')
        ventana.txtOutput.insert("", END, text=rows[0], values=rows[+1:-1])

    # PARAMETROS DE -> ttk.Scrollbar('Frame padre', orient= 'orientacion del objeto, donde estara anclado', command= 'funcion o comando, en este caso, manupula el yview de otro widget')
    ventana.sBY = ttk.Scrollbar(dataFrame, orient=VERTICAL, command=ventana.txtOutput.yview)
    # PARAMETROS DE -> ventana.sBY.pack(side= 'donde estara anclado', fill= 'vector que queremos que llene dentro de su frame padre')
    ventana.sBY.pack(side=RIGHT, fill='y')
    ventana.sBX = ttk.Scrollbar(dataFrame, orient=HORIZONTAL, command=ventana.txtOutput.xview)
    ventana.sBX.pack(side=BOTTOM, fill='x')

    ventana.txtOutput.pack(side=RIGHT, fill='y')

def fnCheckString(_s1, _s2):
    # Valida si _s2 es contenido en el strin _s1, y en caso de ser verdad regresa 100, si no, regresa 0
    if str(_s2).lower() in str(_s1).lower() and _s2 != '':
        return 100
    return 0

def fnGetEuclDist(_r):
    # Obtiene la distancia euclideana de un registro proporcionado en _r y los datos en la columna de parametros
    eucDist = 0
    d = 0
    for data in _r:
        if PF[0][d] != 'Int' and PF[0][d] != 'Float' and ventana.Parameters[d].children['!scale'].get() > 0:
            eucDist = eucDist + ((100 - int(fnCheckString(data, ventana.Parameters[d].children['!text'].get(1.0, END)[:-1]))) ** 2)
        elif ventana.Parameters[d].children['!scale'].get() > 0 and len(ventana.Parameters[d].children['!text'].get(1.0, END)[:-1]) > 0:
            eucDist = eucDist + (((float(ventana.Parameters[d].children['!text'].get(1.0, END)[:-1]) / ventana.parMax[d]) - (float(data) / ventana.parMax[d])) ** 2)
        d = d + 1

    return math.sqrt(eucDist)

def fnRefreshData():
    # Transforma los datos en DS a dataframe, los ordena por distancia euclideana contra la columna de parametros y llama a fnPlot() para mostrarlos
    # PARAMETROS DE -> pd.DataFrame('estructura de datos multidimensional a convertir', columns= 'nombres de las columnas')
    DF = pd.DataFrame(DS, columns=COLNAMES[0])
    POINTS = []
    for r in DS:
        POINTS.append(fnGetEuclDist(r))
    DF['Points'] = POINTS

    # PARAMETROS DE -> DF.sort_values(by= 'nombre de columnas objetivo', ascending= 'indica si el orden sera ascendente o no mediante true o false')
    DF = DF.sort_values(by=['Points'], ascending=True)
    fnPlot(DF)

def fnUpdateParamValues(_i):
    # Actualiza los valores de los sliders en ventana.parVal[] y llama a fnRefreshData()
    try:
        k = 0
        for param in ventana.Parameters:
            ventana.parVal[k] = param.children['!scale'].get()
            k = k + 1
        fnRefreshData()
    except:
        messagebox.showerror("Error al intentar procesar los datos", "Hubo un error al tratar de procesar los datos.\nPor favor, recuerde que el dataset ingresado debe tener las columnas:\n'name, mfr, type, calories, protein, fat, sodium, fiber, carbo, sugars, potass, vitamins, shelf, weight, cups, rating'\ncon los tipos de dato:\n'String, String, String, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float'\n respectivamente.")

def fnRefreshButton():
    # Metodo alternativo para llamar a fnUpdateParamValues() sin parametros
    fnUpdateParamValues(0)

def fnCreateParameters(_parameters):
    # Crea la columna de parametros a partir de los proporcionados en _parameters y llama a fnRefreshButton()
    ventana.Parameters = []
    ventana.chkVr = []
    ventana.parVal = []
    ventana.parCal = []
    j = 0
    # PARAMETROS DE -> tkinter.Frame('frame o ventana padre')
    ventana.paramColFrame = tkinter.Frame(dataFrame)
    # Set Parameters ->
    for par in _parameters:
        parameterFrame = tkinter.Frame(ventana.paramColFrame)

        ventana.chkVr.append(0)
        ventana.chkVr[j] = tkinter.IntVar()

        ventana.parVal.append(0)
        ventana.parVal[j] = 0

        ventana.parCal.append(0)
        ventana.parCal[j] = 0

        if j != 0:
            # PARAMETROS DE -> tkinter.Label('frame o ventana padre', text= 'texto contenido en el label')
            lbl = tkinter.Label(parameterFrame, text=str(par))
            lbl.grid(row=0, column=0)

            # PARAMETROS DE -> tkinter.Scale('frame o ventana padre', from= 'valor minimo', to= 'valor maximo', orient= 'orientacion del slider',
            # command= 'comando o funcion a llamar cuando se interactue con el slider')
            sldr = tkinter.Scale(parameterFrame, from_=0, to=1, orient=HORIZONTAL, command=fnUpdateParamValues)
            # PARAMETROS DE -> sldr.grid(row= 'valor de fila en que se ordenara en su padre', column= 'valor de columna en que se ordenara en su padre')
            sldr.grid(row=0, column=1)

            # PARAMETROS DE -> tkinter.Text('frame o ventana padre', width= 'ancho de campo de texto en caracteres', height= 'alto de campo de texto en caracteres')
            txtB = tkinter.Text(parameterFrame, width=15, height=1)
            txtB.grid(row=0, column=2)
        else:
            lbl_Nam = tkinter.Label(parameterFrame, text='Parametro')
            lbl_Nam.grid(row=0, column=0)
            lbl_Actv = tkinter.Label(parameterFrame, text='Activo')
            lbl_Actv.grid(row=0, column=1)
            lbl_Val = tkinter.Label(parameterFrame, text='Valor')
            lbl_Val.grid(row=0, column=2)

            lbl = tkinter.Label(parameterFrame, text=str(par))
            lbl.grid(row=1, column=0)

            sldr = tkinter.Scale(parameterFrame, from_=0, to=1, orient=HORIZONTAL, command=fnUpdateParamValues)
            sldr.grid(row=1, column=1)

            txtB = tkinter.Text(parameterFrame, width=15, height=1)
            txtB.grid(row=1, column=2)

        parameterFrame.grid(row=j)
        ventana.Parameters.append(parameterFrame)

        j = j + 1
    ventana.paramColFrame.pack(side=tkinter.LEFT)

    # PARAMETROS DE -> tkinter.Button('frame padre', text= 'texto que mostrara sobre el boton', command= 'funcion que llamara el boton')
    btnRefresh = tkinter.Button(dataFrame, text='Refresh', command=fnRefreshButton)
    btnRefresh.pack(side=BOTTOM)

    fnRefreshButton()

def fnReadDS():
    # Lee los datos del archivo en la direccion ingresada en el campo de texto de la ventana y los guarda en DS, luego llama a fnCreateParameters() para crear parametros y refresca la tabla de datos
    try:
        ventana.txtOutput = 0
        ventana.parMax = []
        fnClear()
        # Abrimos el archivo
        with open(ventana.filePath, mode='r')as file:
            # Leemos el CSV
            csvFile = csv.reader(file)

            # Guardamos los datos
            ventana.paramFormat = []
            i = 0
            for row in csvFile:

                lRow = row[0].split(';')
                if i == 0: 
                    COLNAMES.append(lRow)
                elif i == 1:
                    PF.append(lRow)
                else:
                    DS.append(lRow)
                    s = 0
                    for par in lRow:
                        if i == 2:
                            ventana.parMax.append(0)
                            ventana.parMax[s] = 0
                        if s > 2 and float(par) > float(ventana.parMax[s]):
                            ventana.parMax[s] = float(par)
                        s = s + 1
                i = i + 1
            fnCreateParameters(COLNAMES[0])
            fnRefreshData()
    except:
        messagebox.showerror("Error al intentar leer los datos", "Hubo un error al tratar de leer el archivo seleccionado.\nPor favor, recuerde que el dataset ingresado debe tener las columnas:\n'name, mfr, type, calories, protein, fat, sodium, fiber, carbo, sugars, potass, vitamins, shelf, weight, cups, rating'\ncon los tipos de dato:\n'String, String, String, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float, Int/Float'\n respectivamente.")

# Se crea el objeto ventana
ventana = tkinter.Tk()
ventana.title("Busqueda en dataset")
ventana.geometry("1750x750")
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