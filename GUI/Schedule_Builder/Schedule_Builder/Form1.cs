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

namespace Schedule_Builder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ID = BroncoID_Field.Text;
            string Pass = Convert.ToString(Password_Field.Text);

            var reader = new StreamReader(File.OpenRead("UserLoadFile.csv")); // open file
            List<string> listD = new List<string>();
            //List<string> listE = new List<string>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var attributes = line.Split(',');
                listD.Add(attributes[4]); // add broncoID
                //listE.Add(attributes[]);
            }
            reader.Close();

                if (listD.Contains(ID))
                {
                    if (Pass == "0")
                    {
                        this.Hide();
                        Form2 m = new Form2();
                        m.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid ID or Password", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid ID or Password", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frm_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
