using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Brute_Force___5_Queens_Problem
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            Set_Buttons();

            //FLAG = false;

            int count = 0;

            for (int i = 0; i < 5; i++)
            {
                Move_Queen(list_A, i);
                for (int j = 0; j < 5; j++)
                {
                    Move_Queen(list_B, j);
                    for (int k = 0; k < 5; k++)
                    {
                        Move_Queen(list_C, k);
                        for (int m = 0; m < 5; m++)
                        {
                            Move_Queen(list_D, m);

                            for (int n = 0; n < 5; n++)
                            {
                                Move_Queen(list_E,n);

                                //if (FLAG) { break; };
                                int[] index = { i, j, k, m, n };

                                if (Valid_Position(index))
                                {
                                    //FLAG = true;
                                    if(Pos_Used(index))
                                    {
                                        btn_inicio.Text = "Si charcha";
                                        //FLAG = false;
                                        break;
                                    }
                                    else
                                    {
                                        count++;
                                        // Add label to display "1 Solution has been found!"

                                        // Total number of solutions found
                                        lbl_num_posiciones.Text = "Posiciones Válidas: " + count;

                                        // The actual positions found
                                        lbl_posiciones.Text = lbl_posiciones.Text + "Posicion #" + count + "(" + i + ", " + j + ", " + k + ", " + m + ", " + n+ ") \n";

                                        list_valid_position.Add(index);

                                        MessageBox.Show("Se ha encontrado una posición válida: ","POSICIÓN VÁlIDA",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        public bool Valid_Position(int[] index)
        {
            // If there are repeated values on the array, returns false as Valid_Position
            if (Repeated_Value(index))
            {
                return false;
            }
            
            if (Repeated_Diagonal(index))
            {
                return false;
            }

            return true;
        }

        
        public bool Pos_Used(int[] index)
        {
            for(int i = 0; i < list_valid_position.Count(); i++)
            {
                if(index == list_valid_position[i])
                {
                    return true;
                }
            }

            return false;
        }
        

        public bool Repeated_Diagonal(int[] index)
        {
            for (int i = 0; i < index.Length; i++)
            {
                for (int j = i + 1; j < index.Length; j++)
                {
                    if (abs(i - j) == abs(index[i] - index[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int abs(int n)
        {
            if(n < 0)
            {
                return n * -1;
            }
            return n;
        }

        public bool Repeated_Value(int[] index)
        {
            for(int i = 0; i < index.Length; i++)
            {
                for(int j = i + 1; j < index.Length; j++)
                {
                    if(index[i] == index[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Move_Queen(List<Button> list, int index)
        {
            if (index == 0)
            {
                list[4].Text = "";
                list[index].Text = "Q";
            }
            else
            {
                list[index - 1].Text = "";
                list[index].Text = "Q";
            }
        }
        public void Set_Buttons()
        {
            // Add btns to its list

            list_A.Add(A1);
            list_A.Add(A2);
            list_A.Add(A3);
            list_A.Add(A4);
            list_A.Add(A5);

            list_B.Add(B1);
            list_B.Add(B2);
            list_B.Add(B3);
            list_B.Add(B4);
            list_B.Add(B5);

            list_C.Add(C1);
            list_C.Add(C2);
            list_C.Add(C3);
            list_C.Add(C4);
            list_C.Add(C5);

            list_D.Add(D1);
            list_D.Add(D2);
            list_D.Add(D3);
            list_D.Add(D4);
            list_D.Add(D5);

            list_E.Add(E1);
            list_E.Add(E2);
            list_E.Add(E3);
            list_E.Add(E4);
            list_E.Add(E5);

            list_A[0].Text = "Q";
            list_B[0].Text = "Q";
            list_C[0].Text = "Q";
            list_D[0].Text = "Q";
            list_E[0].Text = "Q";

        }
        // Create lists to store butns 
        List<Button> list_A = new List<Button>();
        List<Button> list_B = new List<Button>();
        List<Button> list_C = new List<Button>();
        List<Button> list_D = new List<Button>();
        List<Button> list_E = new List<Button>();

        // Create list to store valid positions
        List<int[]> list_valid_position = new List<int[]>();

        // Just a FLAG for used positions
        // bool FLAG = false;
    }
}




// BY: Jorge Luis Herrada Serrano
// 10/03/2021
// https://github.com/JorgeHerrada