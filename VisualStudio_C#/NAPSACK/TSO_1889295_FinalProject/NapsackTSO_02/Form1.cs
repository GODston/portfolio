using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace NapsackTSO_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_File_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txt_File.Text = openFileDialog1.FileName;
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            try
            {
                int Err = 0;
                Stopwatch timelog = new Stopwatch();
                timelog.Start();
                double A = 0.25;
                Log.Text = "Iniciando proceso...";
                //lectura de archivo
                Log.Text = "Leyendo Archivo...";
                string cadena;
                StreamReader ArchivoL;
                ArchivoL = File.OpenText(txt_File.Text);
                string[] coordbenef = new string[3]; // 0 = X, 1 = Y, 2 = Benef
                                                     //obtener cap y cant de obj
                cadena = ArchivoL.ReadLine();
                coordbenef = cadena.Split(new string[] { "\t" }, StringSplitOptions.None); // 0 = cant, 1 = cap
                int paths = int.Parse(coordbenef[1]);
                double TL = double.Parse(coordbenef[0]);
                List<double> CX = new List<double>();
                List<double> CY = new List<double>();
                List<double> B = new List<double>();
                //leer numeros 
                cadena = ArchivoL.ReadLine();
                while (cadena != null)
                {
                    coordbenef = cadena.Split(new string[] { "\t" }, StringSplitOptions.None);
                    CX.Add(double.Parse(coordbenef[0]));
                    CY.Add(double.Parse(coordbenef[1]));
                    B.Add(double.Parse(coordbenef[2]));
                    cadena = ArchivoL.ReadLine();
                }
                ArchivoL.Close();
                //Se crea array de distancias
                double[,] D = new double[CX.Count, CY.Count];
                for (int i = 0; i < CX.Count; i++)
                {
                    for (int j = 0; j < CY.Count; j++)
                    {
                        D[i, j] = Math.Abs(Math.Sqrt(Math.Pow(CX[i] - CX[j], 2) + Math.Pow(CY[i] - CY[j], 2)));
                    }
                }
                List<int> solTemp = new List<int>();
                double benefTemp = 0;
                double timeTemp = 0;
                List<int> bestSol = new List<int>();
                double bestBenef = 0;
                double bestTime = 0;
                List<int> solVecindario = new List<int>();
                double benefVecin = 0;
                double timeVecin = 0;
                List<int> OBestS = new List<int>();
                double OBestB = 0;
                //Sol temp inicia en (0 -> 1)
                solTemp.Add(0);
                solTemp.Add(1);
                timeTemp = D[0, 1];
                double benefConst = 0;
                for (int t = 0; t < int.Parse(comboBox1.Text.ToString()); t++)
                {
                    double BC = 0;
                    for (int it = 0; it < int.Parse(comboBox1.Text.ToString()); it++)
                    {
                        if (it == 0) // ---------------------------------------------------------------------CONSTRUCTIVE
                        {
                            solTemp = FillSol(solTemp, B, D, TL, A);//llama funcion que regresa solucion llena
                            timeTemp = 0;
                            benefTemp = 0;
                            for (int i = 0; i < solTemp.Count; i++)
                            {
                                if (i != 0)
                                {
                                    timeTemp += D[solTemp[i - 1], solTemp[i]];
                                }
                                benefTemp += B[solTemp[i]];
                            }
							//comprobacion de que cumple con el budget
                            if (TL >= timeTemp)
                            {
                                solVecindario = solTemp;
                                bestSol = solTemp;
                                timeVecin = timeTemp;
                                bestTime = timeTemp;
                                benefVecin = benefTemp;
                                bestBenef = benefTemp;
                                BC = bestBenef;
                            }
                            else
                            {
                                Err = 1;
                                break;
                            }
                        }
                        else if (Err != 1) // -------------------------------------------------------------------------- LOCAL SEARCH
                        {
                            solTemp = solVecindario;
                            timeTemp = timeVecin;
                            benefTemp = benefVecin;
							//se hace movimiento
                            solTemp = switchSol(solTemp, B, D, TL, A);
                            timeTemp = 0;
                            benefTemp = 0;
                            for (int i = 0; i < solTemp.Count; i++)
                            {
                                if (i != 0)
                                {
                                    timeTemp += D[solTemp[i - 1], solTemp[i]];
                                }
                                benefTemp += B[solTemp[i]];
                            }
                            if (TL >= timeTemp)
                            {
                                solVecindario = solTemp;
                                timeVecin = timeTemp;
                                benefVecin = benefTemp;
                                if (benefTemp > bestBenef)
                                {
                                    it = 1;
                                    bestSol = solTemp;
                                    bestTime = timeTemp;
                                    bestBenef = benefTemp;
                                }
                            }
                            else
                            {
                                Err = 1;
                                break;
                            }
                        }
                    }
                    if (t == 0 || bestBenef > OBestB)
                    {
                        OBestS = bestSol;
                        OBestB = bestBenef;
                        t = 0;
                        benefConst = BC;
                    }
                }
                String stringsol = "Solucion obtenida = ";
                Log.Text = "Terminao, Error => " + Err;
                double timecheck = 0;
                foreach (int node in bestSol)
                {
                    stringsol += node + ", ";
                }
                for (int i = 0; i < bestSol.Count - 1; i++)
                {
                    timecheck += D[bestSol[i], bestSol[i + 1]];
                }
                timelog.Stop();
                stringsol += " ---   Limite de tiempo: " + TL + ", Tiempo de solucion: " + bestTime + ", beneficio de solucion inicial: " + benefConst + ", beneficio de solucion final: " + bestBenef + ".   ---- Tiempo de ejecucion: " + timelog.Elapsed;
                //stringsol += "  -- Beneficio: " + bestbenef + ", Peso: " + (timelimit - besttime) + ", Tiempo: " + timelog.Elapsed + " ---- beneficio constuct = " + benefconstuct;
                MessageBox.Show("" + stringsol);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message.ToString());
            }
        }

        public List<int> FillSol(List<int> solTemp, List<double> B, double[,] D, double TL, double A)
        {
            List<int> solFilled = solTemp;
            List<int> BestSol = solTemp;
            List<int> solDo = new List<int>();
            double Bestbenef, benef;
            do
            {
                solDo = BestSol;
				//recorre las posiciones de la solucion actual y evalua los nodos que pueden caber ahi
                for (int i = 1; i < solFilled.Count; i++)
                {
                    solFilled = FillWithPos(solFilled, B, D, TL, i, A);//llama funcion que inserta nodo en posicion
                    benef = 0; Bestbenef = 0;
                    foreach (int node in solFilled)
                    {
                        benef += B[node];
                    }
                    if (benef >= Bestbenef)
                    {
                        BestSol = solFilled;
                        Bestbenef = benef;
                    }
                }
            } while (BestSol != solDo);
			//hasta que no quepa otro nodo
            return BestSol;
        }

        public List<int> switchSol(List<int> solTemp, List<double> B, double[,] D, double TL, double A)
        {
            List<int> solFilled = solTemp;
            List<int> BestSol = solTemp;
            List<int> solDo = new List<int>();
            double[] PosW = new double[solFilled.Count];
            int[] priorW = new int[solFilled.Count];
            double Bestbenef, benef;
            solDo = BestSol;
			//se evalua en todas las posiciones cual se debe quitar y cual agregar
            for (int i = 1; i < solFilled.Count - 1; i++)
            {
                solFilled = solTemp;
                solFilled.RemoveAt(i);
                do
                {
                    solDo = BestSol;
                    for (int j = 1; j < solFilled.Count; j++)
                    {
                        solFilled = FillWithPos(solFilled, B, D, TL, j, A);
                        benef = 0; Bestbenef = 0;
                        foreach (int node in solFilled)
                        {
                            benef += B[node];
                        }
                        if (benef >= Bestbenef)
                        {
                            BestSol = solFilled;
                            Bestbenef = benef;
                        }
                    }
                } while (BestSol != solDo);
            }
            //------------------------------------------
            return BestSol;
        }

        public List<int> FillWithPos(List<int> solTemp, List<double> B, double[,] D, double TL, int P, double A)
        {
            List<int> solFilled = solTemp;
            List<int> cand = new List<int>();
            List<int> restCand = new List<int>();
            double bestB = 0; double worstB = 9999;
            double Time = 0;
            Random rnd = new Random();
			//obtiene el tiempo que toma la solucion actual
            for (int i = 0; i < solFilled.Count - 1; i++)
            {
                Time += D[solFilled[i], solFilled[i + 1]];
            }
			//quita el tiempo de la posicion donde se insertará
            Time -= D[solFilled[P], solFilled[P - 1]];
            for (int i = 0; i < B.Count; i++)
            {
                if (!solFilled.Contains(i) && i != 0 && i != 1)
                {
                    if (TL > Time + D[solFilled[P - 1], i] + D[i, solFilled[P]])
                    {
						//crea lista de candidatos
                        cand.Add(i);
                        if (cand.Count == 1)
                        {
                            bestB = B[i];
                            worstB = B[i];
                        }
                        else if (bestB < B[i])
                        {
                            bestB = B[i];
                        }
                        else if (worstB > B[i])
                        {
                            worstB = B[i];
                        }
                    }
                }
            }
            //restringir candidatos
            double bottomRange = bestB - (A * (bestB - worstB));
            foreach (int node in cand)
            {
                if (B[node] >= bottomRange)
                {
                    restCand.Add(node);
                }
            }
            //seleccionar uno al azar
            if (restCand.Count > 0)
            {
                int rndSel = rnd.Next(restCand.Count);
                solFilled.Insert(P, restCand[rndSel]);
            }
            return solFilled;
        }

        private void Log_Click(object sender, EventArgs e)
        {
			//useless
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
			//codigo del dropdown
            if (comboBox1.Text != "")
            {
                if (int.Parse(comboBox1.Text.ToString()) == 5)
                {
                    labelTime.Text = "Max. Run Time: 1s";
                }
                else if (int.Parse(comboBox1.Text.ToString()) == 10)
                {
                    labelTime.Text = "Max. Run Time: 2s";
                }
                else if (int.Parse(comboBox1.Text.ToString()) == 15)
                {
                    labelTime.Text = "Max. Run Time: 5s";
                }
                else if (int.Parse(comboBox1.Text.ToString()) == 20)
                {
                    labelTime.Text = "Max. Run Time: 10s";
                }
                else if (int.Parse(comboBox1.Text.ToString()) == 25)
                {
                    labelTime.Text = "Max. Run Time: 15s";
                }
                else if (int.Parse(comboBox1.Text.ToString()) == 55)
                {
                    labelTime.Text = "Max. Run Time: 20s";
                }
            }
        }
    }
}
