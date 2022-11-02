using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;



namespace _1889295_Genetico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Ex_Click(object sender, EventArgs e)
        {
            //PADRE

            try
            { 
                Random ran = new Random();
                int rand, i, j, gan, cap;
                int[] car = new int[5];
                TextWriter doc;
                doc = new StreamWriter("Padres.txt");
            
                for (i = 0; i < 4; i++)
                {
                    for (j = 0; j < 4; j++)
                    {
                        rand = ran.Next(0, 2);
                        if (rand == 1)
                        {
                            car[j] = rand;
                        }
                        else
                        {
                            rand = 0;
                            car[j] = rand;
                        }
                    }
                    gan = (car[0] * int.Parse(tb_1_Gan.Text)) + (car[1] * int.Parse(tb_2_Gan.Text)) + (car[2] * int.Parse(tb_3_Gan.Text)) + (car[3] * int.Parse(tb_4_Gan.Text));
                    cap = (car[0] * int.Parse(tb_1_Cap.Text)) + (car[1] * int.Parse(tb_2_Cap.Text)) + (car[2] * int.Parse(tb_3_Cap.Text)) + (car[3] * int.Parse(tb_4_Cap.Text));
                    doc.WriteLine(car[0] + "," + car[1] + "," + car[2] + "," + car[3] + "," + cap + "," + gan);
                    
                }
                doc.Close();

                //HIJOS

                StreamReader lect;
                String cad;
                int[,] paps = new int[5,7];
                String[] cadtemp = new String[7];
                int[,] sons = new int[5,7];
                int[] son = new int[7];
                int cont = 0,temp, best=0, sec=0, temp2=999999999, te=-999999, te2=-9999999,te3=-99999999, temp3 = 999999999, may=0, temp4=0;
                try
                {
                    try
                    {
                        lect = File.OpenText("Padres.txt");
                        cad = lect.ReadLine();
                        for (i = 0; i < 4; i++)
                        {
                            cadtemp = cad.Split(',');
                            for (j = 0; j < 6; j++)
                            {
                                paps[i, j] = int.Parse(cadtemp[j]);
                            }
                            paps[i, 6] = int.Parse(tb_M_Cap.Text) - paps[i, 4];
                            cad = lect.ReadLine();
                            


                            if (i != 0)
                            {
                                //if (temp2 > paps[i, 6] && paps[i,6]>0)
                                //{
                                //    temp3 = temp2;
                                //    temp2 = paps[i, 6];
                                //    sec = best;
                                //    best = i;
                                //}
                                //else
                                //{
                                //    if (temp3 > paps[i, 6] )
                                //    {
                                //        temp3 = paps[i, 6];
                                //        sec = i;
                                //    }
                                //    else if (temp4 < paps[i, 6])
                                //    {
                                //        temp4 = paps[i, 6];
                                //        may = i;
                                //    }
                                //}

                                if (paps[i, 6] <= 0)
                                {
                                    if (temp2 <= 0)
                                    {
                                        if (temp2 > paps[i, 6])
                                        {
                                            temp2 = paps[i, 6];
                                            best = i;
                                        }
                                        else
                                        {
                                            if (temp4 < 0)
                                            {
                                                if (temp4 < paps[i, 6])
                                                {
                                                    temp4 = paps[i, 6];
                                                    may = i;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        temp2 = paps[i, 6];
                                        best = i;
                                    }
                                }
                                else
                                {
                                    if (temp2 <= 0)
                                    {
                                        if (temp4 > 0)
                                        {
                                            if (temp4 < paps[i, 6])
                                            {
                                                temp4 = paps[i, 6];
                                                may = i;
                                            }
                                        }
                                        else
                                        {
                                            temp4 = paps[i, 6];
                                            may = i;
                                        }
                                    }
                                    else
                                    {
                                        if (temp2 > paps[i, 6])
                                        {
                                            temp2 = paps[i, 6];
                                            best = i;
                                        }
                                        else
                                        {
                                            if (temp4 > 0)
                                            {
                                                if (temp4 < paps[i, 6])
                                                {
                                                    temp4 = paps[i, 6];
                                                    may = i;
                                                }
                                            }
                                            else
                                            {
                                                temp4 = paps[i, 6];
                                                may = i;
                                            }
                                        }
                                    }
                                }

                            }
                            else
                            {
                                temp2 = paps[i, 6];
                                best = i;
                                may = i;
                                temp4 = temp2;
                            }
                        }
                        lect.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message + "5");
                    }


                    int cont2 = 0;
                    String mess = "Ejecución exitosa. Favor de actualizar el Grid.";



                    //HIJOS


                    //rand = ran.Next(0,5);
                    while (cont < 25)
                    {
                        int sn = 1;
                        for (j = 3; j >= 0; j--)
                        {
                            sons[0, j] = paps[best, j];
                            sons[2, j] = paps[best, j];
                        }
                        for (i = 0; i < 4; i++)
                        {
                            
                            if (may != i && best != i)
                            {
                                for (j = 3; j >= 0; j--)
                                {
                                    sons[sn, j] = paps[i, j];
                                    
                                }
                                sn = sn + 2;

                            }

                        }
                        for(i=0;i<2;i++)
                        {
                            if(i==0)
                            {
                                rand = ran.Next(0, 4);
                                for (j = 4; j >= rand; j--)
                                {
                                    son[j] = sons[0, j];
                                    sons[0, j] = sons[1, j];
                                    sons[1, j] = son[j];
                                }
                            }
                            else
                            {
                                rand = ran.Next(0, 4);
                                for (j = 3; j >= rand; j--)
                                {
                                    son[j] = sons[2, j];
                                    sons[2, j] = sons[3, j];
                                    sons[3, j] = son[j];
                                }
                            }
                        }
                        doc = new StreamWriter("Hijos.txt");
                        
                        for (i=0;i<4;i++)
                        {

                            sons[i, 4] = sons[i, 0] *int.Parse(tb_1_Cap.Text) + sons[i, 1] *int.Parse(tb_2_Cap.Text) + sons[i, 2] *int.Parse(tb_3_Cap.Text) + sons[i, 3] *int.Parse(tb_4_Cap.Text);
                            sons[i, 5] = sons[i, 0] *int.Parse(tb_1_Gan.Text) + sons[i, 1] *int.Parse(tb_2_Gan.Text) + sons[i, 2] *int.Parse(tb_3_Gan.Text) + sons[i, 3] *int.Parse(tb_4_Gan.Text);
                            sons[i, 6] = sons[i, 4] - int.Parse(tb_M_Cap.Text) ;
                            for(j=0;j<6;j++)
                            {
                                paps[i, j] = sons[i, j];
                                
                            }
                            if (paps[i,4]<=int.Parse(tb_M_Cap.Text))
                            {
                                cont++;
                                temp = paps[i, 6];
                                temp = paps[i, 6] * paps[i, 6];
                                double x = Math.Sqrt(temp);
                                double y = x / int.Parse(tb_M_Cap.Text) * 100;
                                doc.WriteLine(paps[i, 0] + "," + paps[i, 1] + "," + paps[i, 2] + "," + paps[i, 3] + "," + paps[i, 4] + "," + paps[i, 5] + ","+ y);
                            }
                            cont2++;
                            if(cont2==10000)
                            {
                                cont = 25;
                                mess = " Lamentablemente se crearon mas de 50000 generaciones de opciones y no se encontro la cantidad de opciones optimas minimas deseadas (4), puede actualizar el grid pero probablemente los resultados sean de 0 a 3. favor de volver a intentarlo.";
                            }
                           
                        }

                        doc.Close();
                    }
                    
                    MessageBox.Show(mess);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + "1");
                }




                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "2");
            }


        }

        private void Btn_Act_Click(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader("Hijos.txt");
            String leer;
            String mess = "Error desconocido, favor de contactar al desarrollador.";
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = false;
            try
            {
               
                leer = read.ReadLine();
                
                if(leer==null)
                {
                    mess = "El archivo Hijos.txt esta vacio :(. Favor de ejecutar el programa.";
                    
                }
                String[] titles = { "Objeto1", "Objeto2", "Objeto3", "Objeto4", "Capacidad Total", "Ganancia Total", "Valor Genetico" };
                dataGridView1.ColumnCount = leer.Split(',').Length;
                dataGridView1.Rows.Add(titles);
                while (leer!=null)
                {
                    String[] arr = leer.Split(',');
                    
                    dataGridView1.Rows.Add(arr);
                    
                    leer = read.ReadLine();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" +mess);
            }
            read.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Padres.txt");
        }
    }
}
