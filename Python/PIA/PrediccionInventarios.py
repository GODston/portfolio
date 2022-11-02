from sklearn.neural_network import MLPRegressor
from sklearn.metrics import mean_squared_error
import pandas as pd
import numpy as np
import pickle
import matplotlib.pyplot as plt

def corrPlot(dt):
    corr = dt.corr()
    plt.figure(num=None, figsize=(13, 13), dpi=80, facecolor='w', edgecolor='k')  
    corrMat = plt.matshow(corr, fignum = 1)
    plt.xticks(range(len(corr.columns)), corr.columns, rotation=90)
    plt.yticks(range(len(corr.columns)), corr.columns)
    plt.colorbar(corrMat)
    plt.title(f'Correlation Matrix for PIA', fontsize=15)
    plt.show()



if __name__ == '__main__':
	#Leer csv's
    dTrain = pd.read_csv(r'C:\Users\gasto\Documents\UANL\7mo_Semestre_Strong\RedesNeuronales\PIA\train_data.csv')
    dTest = pd.read_csv(r'C:\Users\gasto\Documents\UANL\7mo_Semestre_Strong\RedesNeuronales\PIA\test_data.csv')

    #Separar Valores Binarios
    dTest = pd.concat([dTest, pd.get_dummies(dTest['state'], prefix='dt')], axis=1)
    dTest.drop(['state'], axis=1, inplace=True)
    dTest.drop(['id'], axis=1, inplace=True)
    dTrain = pd.concat([dTrain, pd.get_dummies(dTrain['state'], prefix='dt')], axis=1)
    dTrain.drop(['state'], axis=1, inplace=True)

    dTest = pd.concat([dTest.drop('date', axis = 1), 
          (dTest.date.str.split("-").str[:3].apply(pd.Series)
          .rename(columns={0:'year', 1:'month', 2:'day'}))], axis = 1)
    dTrain = pd.concat([dTrain.drop('date', axis = 1), 
          (dTrain.date.str.split("-").str[:3].apply(pd.Series)
          .rename(columns={0:'year', 1:'month', 2:'day'}))], axis = 1)

    dTest = pd.concat([dTest, pd.get_dummies(dTest['category_of_product'], prefix='dt')], axis=1)
    dTest.drop(['category_of_product'], axis=1, inplace=True)
    dTrain = pd.concat([dTrain, pd.get_dummies(dTrain['category_of_product'], prefix='dt')], axis=1)
    dTrain.drop(['category_of_product'], axis=1, inplace=True)

    corrPlot(dTrain)

    yTrain = dTrain['sales']
    xTrain = dTrain.copy()
    xTrain.drop(['sales'], axis=1, inplace=True)

	#Se entrena el clasificador
    clf = MLPRegressor(solver='lbfgs', tol=1e-100, hidden_layer_sizes=(3,), max_iter=500)
    clf.fit(xTrain, yTrain)

	#se usa el modelo entrenado para 
    predicted = clf.predict(dTest)
    dTest = pd.concat([dTest, pd.DataFrame(np.rint(predicted))], axis=1)
    pickle.dump(clf, open("ModeloPIA_v01.sav", 'wb'))