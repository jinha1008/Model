using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Taxi1ML.Model;

namespace taxi1
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text =="")
            {
                MessageBox.Show(" 이동경로의 최단거리값을 입력하세요! ", "Erro");

            }
            else
            {
                var input = new ModelInput()
                {

                    Vendor_id = "CMT",
                    Rate_code = 1,
                    Passenger_count = 1,
                    Trip_distance = Convert.ToInt64(textBox1.Text),
                    Payment_type = "CRD"
                };


                // Load model and predict output of sample data
                ModelOutput result = ConsumeModel.Predict(input);
                int abc = Convert.ToInt32(result.Score);
                String b = "";
                if (1 <= abc && abc <= 20)
                {
                    b = "A";
                }
                else if( abc <= 40)
                {
                    b = "B";
                }
                else
                {
                    b = "C";
                }



                
                label1.Text = "                     이용 요금은  " + Convert.ToString(result.Score) + " 원 으로 가장 싼 업체는 " + b +"  입니다.";

            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)

                Application.Exit();

        }

        
    }
}


