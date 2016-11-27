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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var reader = new StreamReader(File.OpenRead("winter 2016 database.csv")); // open file
            var lineCount = File.ReadLines("winter 2016 database.csv").Count(); // count number of rows
            List<string> listA = new List<string>(); // array to store course numbers/title only
            
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var attributes = line.Split(',');
                /*string[] input1 = new string[1];
                string[] input2 = new string[1];
                input1[0] = attributes[0];
                input2[0] = attributes[1];
                string[] z = input1.Concat(input2).ToArray();
                listA.AddRange(z);*/
                listA.Add(attributes[0]); // add course number
                //listA.Add(attributes[1]); // add course name
            }

            var reader2 = new StreamReader(File.OpenRead("Hours.csv"));
            var lineCount2 = File.ReadLines("Hours.csv").Count(); // count number of rows
            List<string> listB = new List<string>();

            while (!reader2.EndOfStream)
            {
                var line2 = reader2.ReadLine();
                var attributes2 = line2.Split(',');
                listB.Add(attributes2[0]); // start time
            }

            for (int row = 0; row < lineCount; row++)
            {
                Course_ComboBox.Items.Insert(row, listA[row]); // add course numbers to combobox
            }

            for (int row2 = 0; row2 < lineCount2; row2++)
            {
                Start_Time_ComboBox.Items.Insert(row2, listB[row2]); // add start times to combobox
                End_Time_ComboBox.Items.Insert(row2, listB[row2]);  // add end times to combobox
            }
            reader.Close();
            reader2.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Course_ComboBox.SelectedIndex == -1)
            {
                Course_List.Text = string.Empty;
            }
            else
            {
                //int i = Course_ComboBox.SelectedIndex;
                //Course_List.Text = listC[i].ToString();
                Course_List.AppendText(Course_ComboBox.SelectedItem.ToString()); // add selected course to textbox
                Course_List.AppendText(Environment.NewLine); // add new selection to next line
            }
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            Course_List.Text = string.Empty; // clear textbox
        }

        private void frm_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}