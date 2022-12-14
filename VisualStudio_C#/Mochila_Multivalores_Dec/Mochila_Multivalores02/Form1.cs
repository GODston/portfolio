using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Mochila_Multivalores02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txt_cap_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txt_file.Text = openFileDialog1.FileName;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            
            bool roto = false;
            if (double.Parse(txt_cap.Text) <= 0)
            {
                roto = true;
                MessageBox.Show("La capacidad de la mochila debe ser un nùmero mayor a 0");
            }
            if (!roto)
            {
                try
                {
                    int cant = int.Parse(txtcant.Text);
                    double[] bestsol = new double[cant];
                    double bestbenf = 0;
                    double[,] objeto = new double[cant, 2]; // 0 = peso, 1 = beneficio
                    double[,] limob = new double[cant, 2];
                    int cont = 0;
                    //------------------------------------------------------------------------------------------------------------------------------------------------------------
                    if (txt.Checked)//Entrada por archivo .txt
                    {
                        //lectura de archivo
                        StreamReader ArchivoL;
                        ArchivoL = File.OpenText(txt_file.Text);
                        string cadena;
                        string[] pesobenef = new string[2];
                        cadena = ArchivoL.ReadLine();
                        while (cadena != null)
                        {
                            pesobenef = cadena.Split(',');
                            objeto[cont, 0] = double.Parse(pesobenef[0]);
                            objeto[cont, 1] = double.Parse(pesobenef[1]);
                            limob[cont, 0] = 0; //limite inferior
                            limob[cont, 1] = double.Parse(txt_cap.Text) / objeto[cont, 0]; //limite superior
                            cadena = ArchivoL.ReadLine();
                            cont++;
                        }
                        ArchivoL.Close();
                    }
                    else if(manual.Checked)//Entrada Manual
                    {
                        TextWriter ArchivoM;
                        ArchivoM = new StreamWriter("DtaM.txt");
                        ArchivoM.WriteLine(Manualtxt.Text);
                        ArchivoM.Close();
                        //lectura de archivo
                        StreamReader ArchivoL;
                        ArchivoL = File.OpenText("DtaM.txt");
                        string cadena;
                        string[] pesobenef = new string[2];
                        cadena = ArchivoL.ReadLine();
                        while (cadena != null)
                        {
                            pesobenef = cadena.Split(',');
                            objeto[cont, 0] = double.Parse(pesobenef[0]);
                            objeto[cont, 1] = double.Parse(pesobenef[1]);
                            limob[cont, 0] = 0; //limite inferior
                            limob[cont, 1] = double.Parse(txt_cap.Text) / objeto[cont, 0]; //limite superior
                            cadena = ArchivoL.ReadLine();
                            cont++;
                        }
                        ArchivoL.Close();
                    }
                    else if(aleat.Checked)//Entrada aleatoria
                    {
                        Manualtxt.Text = "";
                        DateTime hoy = DateTime.Now;
                        double[] x = new double[cant * 2];
                        double[] r = new double[cant * 2];
                        double s = hoy.Day + hoy.Month + hoy.Year + hoy.Hour + hoy.Minute + hoy.Second;
                        int k = hoy.Second;
                        int a = 1 + (4 * k);
                        int c = 8 * a + 3;
                        if (c % 2 == 0)
                        {
                            c++;
                        }
                        int g = 8 * c - 3;
                        int m = 2 ^ g;
                        x[0] = (a * s * c) % m;
                        r[0] = x[0] / m;
                        for (int i = 1; i < cant * 2; i++)
                        {
                            x[i] = (a * x[i - 1] * c) % m;
                            r[i] = x[i] / m;
                        }

                        for (int i = 0; i < cant * 2; i++)
                        {
                            if ((r[i] * s / 45) < 0.01)
                            {
                                Manualtxt.Text += 1 + ",";
                            }
                            else
                            {
                                Manualtxt.Text += String.Format("{0:0.00}", (float)(r[i] * s / 45)) + ",";
                            }
                            i++;
                            if ((r[i] * s / 45) < 0.01)
                            {
                                Manualtxt.Text += 1 + "\r\n";
                            }
                            else
                            {
                                Manualtxt.Text += String.Format("{0:0.00}", (float)(r[i] * s / 45)) + "\r\n";
                            }
                        }
                        TextWriter ArchivoM;
                        ArchivoM = new StreamWriter("DtaM.txt");

                        for (int i = 0; i < cant * 2; i++)
                        {
                            if ((r[i] * s / 45) < 0.01)
                            {
                                ArchivoM.Write("1,");
                            }
                            else
                            {
                                ArchivoM.Write(String.Format("{0:0.00}", (float)(r[i] * s / 45)) + ",");
                            }
                            i++;
                            if ((r[i] * s / 45) < 0.01)
                            {
                                ArchivoM.WriteLine("1");
                            }
                            else
                            {
                                ArchivoM.WriteLine(String.Format("{0:0.00}", (float)(r[i] * s / 45)));
                            }
                        }
                        ArchivoM.Close();
                        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        //lectura de archivo
                        StreamReader ArchivoL;
                        ArchivoL = File.OpenText("DtaM.txt");
                        string cadena;
                        string[] pesobenef = new string[2];
                        cadena = ArchivoL.ReadLine();
                        while (cadena != null)
                        {
                            pesobenef = cadena.Split(',');
                            objeto[cont, 0] = double.Parse(pesobenef[0]);
                            objeto[cont, 1] = double.Parse(pesobenef[1]);
                            limob[cont, 0] = 0; //limite inferior
                            limob[cont, 1] = double.Parse(txt_cap.Text) / objeto[cont, 0]; //limite superior
                            cadena = ArchivoL.ReadLine();
                            cont++;
                        }
                        ArchivoL.Close();
                    }
                    else
                    {
                        MessageBox.Show("Favor de seleccionar un metodo de entrada de datos. ");
                        return;
                    }
                    //-----------------------------------------------------------------------------------------------------------------------------------------------------------
                    if (cont == cant)
                    {
                        //comienzo
                        double[] benefunit = new double[cant];
                        int[] prior = new int[cant];
                        double[] sol = new double[cant];
                        //al inicio la solucion es 0,0,0,0,...
                        for (int i = 0; i < cant; i++)
                        {
                            sol[i] = 0;
                        }
                        //se obtiene beneficio unitario
                        for (int i = 0; i < cant; i++)
                        {
                            benefunit[i] = objeto[i, 1] / objeto[i, 0];
                        }
                        //se obtienen prioridades
                        for (int i = 0; i < cant; i++)
                        {
                            bool first = true;
                            double[] temp = new double[2]; //0=benef, 1=objeto
                            for (int j = 0; j < cant; j++)
                            {
                                if (i == 0)
                                {
                                    if (j == 0)
                                    {
                                        temp[0] = benefunit[j];
                                        temp[1] = j;
                                    }
                                    else
                                    {
                                        if (temp[0] < benefunit[j])
                                        {
                                            temp[0] = benefunit[j];
                                            temp[1] = j;
                                        }
                                    }
                                }
                                else
                                {
                                    bool ncarma = false;
                                    for (int k = 0; k < i; k++)
                                    {
                                        if(prior[k] == j)
                                        {
                                            ncarma = true;
                                        }
                                    }
                                    if(!ncarma)
                                    {
                                        if(first)
                                        {
                                            temp[0] = benefunit[j];
                                            temp[1] = j;
                                            first = false;
                                        }
                                        else
                                        {
                                            if(temp[0] < benefunit[j])
                                            {
                                                temp[0] = benefunit[j];
                                                temp[1] = j;
                                            }
                                        }
                                    }
                                }
                            }
                            prior[i] = (int)temp[1];
                        }
                        //nuevos limites SOLO SI ESTAN ACTIVADAS RESTRICCIONES
                        if(restricciones.Checked)
                        {
                            //al menor que se le cambia el inferior
                            if (double.Parse(r1.Text) < limob[int.Parse(rmen.Text) - 1, 1] && double.Parse(r1.Text) > 0)
                            {
                                limob[int.Parse(rmen.Text) - 1, 1] = double.Parse(r1.Text);
                            }
                            //al mayor que se le cambia solo el limite superior
                            if (double.Parse(r2.Text) > 0 && double.Parse(r2.Text) < limob[int.Parse(rmay.Text)-1, 1])
                            {
                                limob[int.Parse(rmay.Text) - 1, 0] = double.Parse(r2.Text);
                            }
                            if(benefunit[int.Parse(rmas.Text)-1] > benefunit[int.Parse(rigual.Text) - 1])
                            {
                                if (limob[int.Parse(rmas.Text) - 1, 1] >= double.Parse(r3.Text))
                                {
                                    limob[int.Parse(rmas.Text) - 1, 0] = double.Parse(r3.Text);
                                    limob[int.Parse(rmas.Text) - 1, 1] = double.Parse(r3.Text);
                                    limob[int.Parse(rigual.Text) - 1, 0] = 0;
                                    limob[int.Parse(rigual.Text) - 1, 1] = 0;
                                }
                                else
                                {
                                    limob[int.Parse(rmas.Text) - 1, 0] = limob[int.Parse(rmas.Text) - 1, 1];
                                    limob[int.Parse(rigual.Text) - 1, 0] = double.Parse(r3.Text) - limob[int.Parse(rmas.Text) - 1, 0];
                                    limob[int.Parse(rigual.Text) - 1, 1] = limob[int.Parse(rigual.Text) - 1, 0];
                                }
                            }
                            else
                            {
                                if (limob[int.Parse(rigual.Text) - 1, 1] >= double.Parse(r3.Text))
                                {
                                    limob[int.Parse(rigual.Text) - 1, 0] = double.Parse(r3.Text);
                                    limob[int.Parse(rigual.Text) - 1, 1] = double.Parse(r3.Text);
                                    limob[int.Parse(rmas.Text) - 1, 0] = 0;
                                    limob[int.Parse(rmas.Text) - 1, 1] = 0;
                                }
                                else
                                {
                                    limob[int.Parse(rigual.Text) - 1, 0] = limob[int.Parse(rigual.Text) - 1, 1];
                                    limob[int.Parse(rmas.Text) - 1, 0] = double.Parse(r3.Text) - limob[int.Parse(rigual.Text) - 1, 0];
                                    limob[int.Parse(rmas.Text) - 1, 1] = limob[int.Parse(rmas.Text) - 1, 0];
                                }
                            }
                        }
                        //Comenzamos con iteraciones --------------------------------------------------------------------->
                        int vecindario = 0;
                        String solucion = "";
                        TextWriter ArchivoE;
                        ArchivoE = new StreamWriter("Log.txt");
                        for (int it = 0; it < 10001; it++)
                        {
                            if(it == 0)
                            {
                               if(restricciones.Checked)
                                {
                                    //entonces encontramos valores fijos y creamos el primer vecindario
                                    double temp = 0;
                                    double restocap = 0;
                                    bool[] viable = new bool[2];
                                    for (int i = 0; i < cant / 2; i++)
                                    {
                                        if(prior[i] == int.Parse(rmen.Text) - 1)
                                        {
                                            viable[0] = true;
                                        }
                                        
                                        if (prior[i] == int.Parse(rmay.Text) - 1)
                                        {
                                            viable[1] = true;
                                        }
                                        
                                    }
                                    //restriccion mas igual solo se dan los valores, no dependen.
                                    sol[int.Parse(rmas.Text) - 1] = limob[int.Parse(rmas.Text) - 1, 0];
                                    sol[int.Parse(rigual.Text) - 1] = limob[int.Parse(rigual.Text) - 1, 0];
                                    temp += (sol[int.Parse(rmas.Text) - 1] * objeto[int.Parse(rmas.Text) - 1, 0]) + (sol[int.Parse(rigual.Text) - 1] * objeto[int.Parse(rigual.Text) - 1, 0]);
                                    restocap = double.Parse(txt_cap.Text) - temp;
                                    // ahora a ajustar los demas
                                    if (viable[0])
                                    {
                                        if (limob[int.Parse(rmen.Text) - 1, 1] < restocap / objeto[int.Parse(rmen.Text) - 1, 0])
                                        {
                                            sol[int.Parse(rmen.Text) - 1] = limob[int.Parse(rmen.Text) - 1, 1];
                                        }
                                        else
                                        {
                                            sol[int.Parse(rmen.Text) - 1] = restocap / objeto[int.Parse(rmen.Text) - 1, 0];
                                        }
                                    }
                                    else
                                    {
                                        sol[int.Parse(rmen.Text) - 1] = limob[int.Parse(rmen.Text) - 1, 0];
                                    }
                                    temp +=  (sol[int.Parse(rmen.Text) - 1] * objeto[int.Parse(rmen.Text) - 1, 0]);
                                    restocap = double.Parse(txt_cap.Text) - temp;
                                    if (viable[0])
                                    {
                                        sol[int.Parse(rmay.Text) - 1] = restocap / objeto[int.Parse(rmay.Text) - 1, 0];
                                    }
                                    else
                                    {
                                        sol[int.Parse(rmay.Text) - 1] = limob[int.Parse(rmay.Text) - 1, 0];
                                    }
                                    //ya se tienen valores fijos, ahora a encontrar el vecindario 0
                                    temp = 0;
                                    for (int i = 0; i < cant; i++)
                                    {
                                        bestsol[i] = sol[i];
                                        bestbenf = bestsol[i] * objeto[i, 1];
                                        temp += sol[i] * objeto[i, 0];
                                    }
                                    restocap = double.Parse(txt_cap.Text) - temp;
                                    int tmp = 0;
                                    bool encontro = false;
                                    for(int i = 0; i < cant; i++)
                                    {
                                        if(prior[i] != int.Parse(rmen.Text) - 1 && prior[i] != int.Parse(rmay.Text) - 1  && prior[i] != int.Parse(rmas.Text) - 1 && prior[i] != int.Parse(rigual.Text) - 1)
                                        {
                                            tmp = prior[i];
                                            encontro = true;
                                            break;
                                        }
                                    }
                                    if(encontro)
                                    {
                                        sol[tmp] = restocap / objeto[tmp, 0];
                                        vecindario = tmp;
                                    }
                                    else
                                    {
                                        for (int i = 0; i < cant; i++)
                                        {
                                            if ((prior[i] == int.Parse(rmen.Text) - 1 || prior[i] == int.Parse(rmay.Text) - 1) && prior[i] != int.Parse(rmas.Text) - 1 && prior[i] != int.Parse(rigual.Text) - 1)
                                            {
                                                if(sol[prior[i]] > limob[prior[i], 0])
                                                {
                                                    temp = i;
                                                    encontro = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if(encontro)
                                        {
                                            if(restocap > objeto[tmp, 0])
                                            {
                                                if(sol[tmp] + (restocap / objeto[tmp, 0]) < limob[tmp, 1])
                                                {
                                                    sol[tmp] += restocap / objeto[tmp, 0];
                                                }
                                            }
                                            vecindario = tmp;
                                        }
                                        else //si no encontro vecindarios viables da -1, al tiro, debera buscar vecindario desde 0
                                        {
                                            vecindario = -1;
                                        }
                                        //se guarda solucion obtenida como la mejor
                                        bestbenf = 0;
                                        for(int i = 0; i < cant; i++)
                                        {
                                            bestsol[i] = sol[i];
                                            bestbenf += bestsol[i] * objeto[i, 1];
                                        }
                                    }
                                //ya tenemos solucion
                                }
                                else//sin restricciones
                                {
                                    //entonces solo buscamos los mas convenientes y vamos creando vecindarios lalalala
                                    double restocap = double.Parse(txt_cap.Text);
                                    for(int i = 0; i < cant; i++)
                                    {
                                        if(limob[prior[i], 1] < (restocap / objeto[prior[i], 0]))
                                        {
                                            sol[prior[i]] = limob[prior[i], 1];
                                        }
                                        else
                                        {
                                            sol[prior[i]] = restocap / objeto[prior[i], 0];
                                        }
                                        restocap -= (sol[prior[i]] * objeto[prior[i], 0]);
                                    }
                                    //aqui busca el vecindario (mayor cantidad)
                                    int temp = 0;
                                    for(int i = 0; i < cant; i++)
                                    {
                                        if (i != 0)
                                        {
                                            if(sol[i] > sol[temp])
                                            {
                                                temp = i;
                                            }
                                        }
                                    }
                                    vecindario = temp;
                                    //se guarda solucion obtenida como la mejor
                                    bestbenf = 0;
                                    for (int i = 0; i < cant; i++)
                                    {
                                        bestsol[i] = sol[i];
                                        bestbenf += bestsol[i] * objeto[i, 1];
                                    }
                                }
                                //Imprimir datos
                                solucion = "";
                                double benef = 0;
                                double pso = 0;
                                for (int j = 0; j < cant; j++)
                                {
                                    benef += sol[j] * objeto[j, 1];
                                    pso += sol[j] * objeto[j, 0];
                                    if (j != cant - 1)
                                    {
                                        solucion += (String.Format("{0:0.00}", sol[j]) + ", ");
                                    }
                                    else
                                    {
                                        solucion += String.Format("{0:0.00}", sol[j]);
                                    }
                                }
                                if(penalizacion.Checked)
                                {
                                    if (txtpen.Text != null)
                                    {
                                        benef += double.Parse(txtpen.Text) * -1 * (double.Parse(txt_cap.Text) - pso);
                                    }
                                    else
                                    {
                                        MessageBox.Show("El valor de la penalizaciòn no puede ser nulo");
                                    }
                                }
                                ArchivoE.WriteLine(it + ".- (" + solucion + ")  Beneficio = " + String.Format("{0:0.00}", benef) + ", Peso: " + String.Format("{0:0.00}", pso) + ", espacio libre: " + String.Format("{0:0.00}", (double.Parse(txt_cap.Text) - pso)));
                            }
                            else//desarrollo (it != 0)
                            {
                                double[] soltemp = new double[cant];
                                if (vecindario != -1)
                                {
                                    for (double i = (sol[vecindario] - .01); i > limob[vecindario, 0]; i = (i - (.01)))
                                    {
                                        //creamos la solucion temporal que compararemos con la base para ver si se sigue restando al vecindario y canalizando todo a otro objeto o si se conservan cambios al volver a restar
                                        for(int j = 0; j < cant; j++)
                                        {
                                            soltemp[j] = sol[j];
                                        }
                                        soltemp[vecindario] = i;
                                        double tmp = 0;
                                        for (int j = 0; j < cant; j++)
                                        {
                                            double restocap = 0;
                                            double temp = 0;
                                            for (int k = 0; k < cant; k++)
                                            {
                                                temp += objeto[k, 0] * soltemp[k];
                                            }
                                            restocap = double.Parse(txt_cap.Text) - temp;
                                            if (soltemp[j] < limob[j, 1] && j != vecindario)
                                            {
                                                if(soltemp[j] + (restocap / objeto[j, 0]) < limob[j, 1])
                                                {
                                                    soltemp[j] += restocap / objeto[j, 0];
                                                }
                                                else
                                                {
                                                    soltemp[j] = limob[j, 1];
                                                }
                                                tmp = objeto[j, 1] * soltemp[j];
                                            }
                                        }
                                        //Imprimir datos
                                        solucion = "";
                                        double benef = 0;
                                        double pso = 0;
                                        for (int j = 0; j < cant; j++)
                                        {
                                            benef += soltemp[j] * objeto[j, 1];
                                            pso += soltemp[j] * objeto[j, 0];
                                            if (j != cant - 1)
                                            {
                                                solucion += (String.Format("{0:0.00}", soltemp[j]) + ", ");
                                            }
                                            else
                                            {
                                                solucion += String.Format("{0:0.00}", soltemp[j]);
                                            }
                                        }
                                        if (penalizacion.Checked)
                                        {
                                            if (txtpen.Text != null)
                                            {
                                                benef += double.Parse(txtpen.Text) * -1 * (double.Parse(txt_cap.Text) - pso);
                                            }
                                            else
                                            {
                                                MessageBox.Show("El valor de la penalizaciòn no puede ser nulo");
                                            }
                                        }
                                        ArchivoE.WriteLine(it + ".- (" + solucion + ")  Beneficio = " + String.Format("{0:0.00}", benef) + ", Peso: " + String.Format("{0:0.00}", pso) + ", espacio libre: " + String.Format("{0:0.00}", (double.Parse(txt_cap.Text) - pso)));
                                        //verificar bestsol
                                        if (benef > bestbenf)
                                        {
                                            bestbenf = benef;
                                            for (int j = 0; j < cant; j++)
                                            {
                                                sol[j] = soltemp[j];
                                                bestsol[j] = sol[j];
                                                bestbenf += objeto[j, 1] * bestsol[j];
                                            }
                                        }
                                        it++;
                                    }
                                //al final debe buscar el sig vecindario
                                    vecindario = 0;
                                    for (int i = 0; i < cant; i++)
                                    {
                                        if (i != 0)
                                        {
                                            if (sol[i] > sol[vecindario])
                                            {
                                                vecindario = i;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Las restricciones dificultan la obtencion de obtener vecindarios, llegando a imposibilitarla.");
                                }
                            }
                        }
                        solucion = "";
                        double peso = 0;
                        for (int i = 0; i < cant; i++)
                        {
                            peso += objeto[i, 0] * bestsol[i];
                            bestbenf += bestsol[i] * objeto[i, 1];
                            if (i != cant - 1)
                            {
                                solucion += (String.Format("{0:0.00}", bestsol[i]) + ", ");
                            }
                            else
                            {
                                solucion += String.Format("{0:0.00}", bestsol[i]);
                            }
                        }
                        if (penalizacion.Checked)
                        {
                            if (txtpen.Text != null)
                            {
                                bestbenf += double.Parse(txtpen.Text) * -1 * (double.Parse(txt_cap.Text) - peso);
                            }
                            else
                            {
                                MessageBox.Show("El valor de la penalizaciòn no puede ser nulo");
                            }
                        }
                        txt_sol.Text = "(" + solucion + "), Beneficio = " + String.Format("{0:0.00}", bestbenf);
                        ArchivoE.Close();
                    }
                    else
                    {
                        MessageBox.Show("La cantidad de objetos en el archivo de datos no coincide con los ingresados en la interface.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(txt.Checked)
            {
                if(manual.Checked)
                {
                    manual.Checked = false;
                }
                if(aleat.Checked)
                {
                    aleat.Checked = false;
                }
            }
        }

        private void manual_CheckedChanged(object sender, EventArgs e)
        {
            if(manual.Checked)
            {
                if(txt.Checked)
                {
                    txt.Checked = false;
                }
                if(aleat.Checked)
                {
                    aleat.Checked = false;
                }
            }
        }

        private void aleat_CheckedChanged(object sender, EventArgs e)
        {
            if(aleat.Checked)
            {
                if(txt.Checked)
                {
                    txt.Checked = false;
                }
                if(manual.Checked)
                {
                    manual.Checked = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
