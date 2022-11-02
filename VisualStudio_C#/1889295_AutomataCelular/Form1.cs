using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _1889295_AutomataCelular
{
    public partial class Form1 : Form
    {
        int it = 0;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            int x = 1;

            int[,] cel = new int[7,8];
            int[,] cel2 = new int[7,8];


            cel[0,0] = x;
            cel[0,1] = x;
            cel[0,2] = x;
            cel[0,3] = x;
            cel[0,4] = x;
            cel[0,5] = x;
            cel[0,6] = x;
            cel[1,0] = x;
            cel[1,6] = x;
            cel[2,0] = x;
            cel[2,6] = x;
            cel[3,0] = x;
            cel[3,6] = x;
            cel[4,0] = x;
            cel[4,6] = x;
            cel[5,0] = x;
            cel[5,1] = x;
            cel[5,2] = x;
            cel[5,3] = x;
            cel[5,4] = x;
            cel[5,5] = x;
            cel[5,6] = x;


            if (cb00.CheckState == CheckState.Checked)
            {
                cel[1, 1] = 1;
            }
            else
            {
                cel[1, 1] = 0;
            }

            if (cb01.CheckState == CheckState.Checked)
            {
                cel[1, 2] = 1;
            }
            else
            {
                cel[1, 2] = 0;
            }

            if (cb02.CheckState == CheckState.Checked)
            {
                cel[1, 3] = 1;
            }
            else
            {
                cel[1, 3] = 0;
            }

            if (cb03.CheckState == CheckState.Checked)
            {
                cel[1, 4] = 1;
            }
            else
            {
                cel[1, 4] = 0;
            }

            if (cb04.CheckState == CheckState.Checked)
            {
                cel[1, 5] = 1;
            }
            else
            {
                cel[1, 5] = 0;
            }




            if (cb10.CheckState == CheckState.Checked)
            {
                cel[2, 1] = 1;
            }
            else
            {
                cel[2, 1] = 0;
            }

            if (cb11.CheckState == CheckState.Checked)
            {
                cel[2, 2] = 1;
            }
            else
            {
                cel[2, 2] = 0;
            }

            if (cb12.CheckState == CheckState.Checked)
            {
                cel[2, 3] = 1;
            }
            else
            {
                cel[2, 3] = 0;
            }

            if (cb13.CheckState == CheckState.Checked)
            {
                cel[2, 4] = 1;
            }
            else
            {
                cel[2, 4] = 0;
            }

            if (cb14.CheckState == CheckState.Checked)
            {
                cel[2, 5] = 1;
            }
            else
            {
                cel[2, 5] = 0;
            }


            if (cb20.CheckState == CheckState.Checked)
            {
                cel[3, 1] = 1;
            }
            else
            {
                cel[3, 1] = 0;
            }

            if (cb21.CheckState == CheckState.Checked)
            {
                cel[3, 2] = 1;
            }
            else
            {
                cel[3, 2] = 0;
            }

            if (cb22.CheckState == CheckState.Checked)
            {
                cel[3, 3] = 1;
            }
            else
            {
                cel[3, 3] = 0;
            }

            if (cb23.CheckState == CheckState.Checked)
            {
                cel[3, 4] = 1;
            }
            else
            {
                cel[3, 4] = 0;
            }

            if (cb04.CheckState == CheckState.Checked)
            { 
                cel[3, 5] = 1;
            }
            else
            {
                cel[3, 5] = 0;
            }



            if (cb30.CheckState == CheckState.Checked)
            {
                cel[4, 1] = 1;
            }
            else
            {
                cel[4, 1] = 0;
            }

            if (cb31.CheckState == CheckState.Checked)
            {
                cel[4, 2] = 1;
            }
            else
            {
                cel[4, 2] = 0;
            }

            if (cb32.CheckState == CheckState.Checked)
            {
                cel[4, 3] = 1;
            }
            else
            {
                cel[4, 3] = 0;
            }

            if (cb33.CheckState == CheckState.Checked)
            {
                cel[4, 4] = 1;
            }
            else
            {
                cel[4, 4] = 0;
            }

            if (cb34.CheckState == CheckState.Checked)
            {
                cel[4, 5] = 1;
            }
            else
            {
                cel[4, 5] = 0;
            }












            for (int i=1; i<5; i++)
            {
                for(int j=1; j<6; j++)
                {
                    int on = 0;
                    if (cel[i - 1, j - 1] == 1)
                    {
                        on++;
                    }
                    if (cel[i, j - 1] == 1)
                    {
                        on++;
                    }
                    if (cel[i + 1, j - 1] == 1)
                    {
                        on++;
                    }


                    if (cel[i - 1, j] == 1)
                    {
                        on++;
                    }
                    if (cel[i + 1, j] == 1)
                    {
                        on++;
                    }


                    if (cel[i - 1, j + 1] == 1)
                    {
                        on++;
                    }
                    if (cel[i, j + 1] == 1)
                    {
                        on++;
                    }
                    if (cel[i + 1, j + 1] == 1)
                    {
                        on++;
                    }


                    if (cel[i, j] == 1)
                    {
                        if (on == 2 || on == 3 || on == 7)
                        {
                            cel2[i, j] = 1;
                        }
                        else
                        {
                            cel2[i, j] = 0;
                        }
                    }
                    else
                    {
                        if (on == 5 || on == 4 || on == 7 || on==2)
                        {
                            cel2[i, j] = 1;
                        }
                        else
                        {
                            cel2[i, j] = 0;
                        }
                    }






                    if (cel2[1, 1] == 1)
                    {
                        cb00.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb00.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[1, 2] == 1)
                    {
                        cb01.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb01.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[1, 3] == 1)
                    {
                        cb02.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb02.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[1, 4] == 1)
                    {
                        cb03.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb03.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[1, 5] == 1)
                    {
                        cb04.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb04.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[2, 1] == 1)
                    {
                        cb10.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb10.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[2, 2] == 1)
                    {
                        cb11.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb11.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[2, 3] == 1)
                    {
                        cb12.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb12.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[2, 4] == 1)
                    {
                        cb13.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb13.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[2, 5] == 1)
                    {
                        cb14.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb14.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[3, 1] == 1)
                    {
                        cb20.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb20.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[3, 2] == 1)
                    {
                        cb21.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb21.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[3, 3] == 1)
                    {
                        cb22.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb22.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[3, 4] == 1)
                    {
                        cb23.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb23.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[3, 5] == 1)
                    {
                        cb24.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb24.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[4, 1] == 1)
                    {
                        cb30.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb30.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[4, 2] == 1)
                    {
                        cb31.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb31.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[4, 3] == 1)
                    {
                        cb32.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb32.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[4, 4] == 1)
                    {
                        cb33.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb33.CheckState = CheckState.Unchecked;
                    }
                    if (cel2[4, 5] == 1)
                    {
                        cb34.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        cb34.CheckState = CheckState.Unchecked;
                    }


                }
            }

            it++;
            label1.Text = "Iteración " + it;
        }

        private void CheckBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            cb00.CheckState = CheckState.Unchecked;
            cb01.CheckState = CheckState.Unchecked;
            cb02.CheckState = CheckState.Unchecked;
            cb03.CheckState = CheckState.Unchecked;
            cb04.CheckState = CheckState.Unchecked;

            cb20.CheckState = CheckState.Unchecked;
            cb21.CheckState = CheckState.Unchecked;
            cb22.CheckState = CheckState.Unchecked;
            cb23.CheckState = CheckState.Unchecked;
            cb24.CheckState = CheckState.Unchecked;

            cb30.CheckState = CheckState.Unchecked;
            cb31.CheckState = CheckState.Unchecked;
            cb32.CheckState = CheckState.Unchecked;
            cb33.CheckState = CheckState.Unchecked;
            cb34.CheckState = CheckState.Unchecked;

            cb10.CheckState = CheckState.Unchecked;
            cb11.CheckState = CheckState.Unchecked;
            cb12.CheckState = CheckState.Unchecked;
            cb13.CheckState = CheckState.Unchecked;
            cb14.CheckState = CheckState.Unchecked;
            it = 0;
            label1.Text = "Iteración 0";
        }
    }
}
