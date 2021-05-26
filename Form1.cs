using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soliman_FCFSALGO
{
    public partial class Form1 : Form
    {
        int[] arrival = new int[4], burst = new int[4], order = new int[4];
        int[] waiting = new int[4], turn = new int[4];

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {

            //setting the values of arrival
            arrival[0] = Int32.Parse(txtArr1.Text);
            arrival[1] = Int32.Parse(txtArr2.Text);
            arrival[2] = Int32.Parse(txtArr3.Text);
            arrival[3] = Int32.Parse(txtArr4.Text);

            //setting the values of burst
            burst[0] = Int32.Parse(txtBrs1.Text);
            burst[1] = Int32.Parse(txtBrs2.Text);
            burst[2] = Int32.Parse(txtBrs3.Text);
            burst[3] = Int32.Parse(txtBrs4.Text);

            //get the order or sort the order
            GetOrder();

            //Display one by one
            Display();

        }

        private void Display() {

            txtord0.Text = "P" + (order[0] + 1).ToString();
            txtord1.Text = "P" + (order[1] + 1).ToString();
            txtord2.Text = "P" + (order[2] + 1).ToString();
            txtord3.Text = "P" + (order[3] + 1).ToString();

            double[] lstwt = new double[4], lstta = new double[4];
            double curpos = 0, totwt = 0, totta = 0; 

            for (int i = 0; i < 4; ++i) {

                lstwt[i] = curpos - arrival[order[i]];
                if (lstwt[i] < 0) 
                {
                    lstwt[i] = 0;
                }

                totwt += lstwt[i];// to get the tot

                curpos += burst[order[i]];
                lstta[i] = curpos - arrival[order[i]];

                if (lstta[i] < 0)
                {
                    lstta[i] = 0;
                }

                totta += lstta[i];//just to get the tot
            }

            txtwt0.Text = lstwt[0].ToString() + " ms";
            txtwt1.Text = lstwt[1].ToString() + " ms";
            txtwt2.Text = lstwt[2].ToString() + " ms";
            txtwt3.Text = lstwt[3].ToString() + " ms";

            txttotwt.Text = totwt.ToString() + " ms";
            txtavewt.Text = (totwt/4).ToString() + " ms";

            txtta0.Text = lstta[0].ToString() + " ms";
            txtta1.Text = lstta[1].ToString() + " ms";
            txtta2.Text = lstta[2].ToString() + " ms";
            txtta3.Text = lstta[3].ToString() + " ms";


            txttotta.Text = totta.ToString() + " ms";
            txtaveta.Text = (totta/4).ToString() +" ms";
        }

        private void GetOrder() {

            int[,] arr = new int[4, 2];

            for(int i = 0; i < 4; ++i)
            {
                arr[i,0] = arrival[i];
                arr[i,1]  = i ;
            }

            int n = 4;

            for (int i = 0; i < n - 1; i++)
            {

                for (int j = 0; j < n - i - 1; j++)
                {
                    if(arr[j,0] > arr[j + 1, 0])
                    {
                        int temp = arr[j + 1, 0];
                        int ind = arr[j + 1, 1];

                        arr[j + 1, 0] = arr[j, 0];
                        arr[j + 1, 1] = arr[j, 1];

                        arr[j, 0] = temp;
                        arr[j, 1] = ind;
                    }
                }
            }

            for(int i = 0; i < 4; ++i)
            {
                order[i] = arr[i, 1];
            }
        }
    }
}
