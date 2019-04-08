using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_Lab2_V2
{
    public partial class MainForm : Form
    {
        private Form childForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            childForm = new Form1();
            childForm.Closed += (s, args) => this.Close();
            childForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            childForm = new Form2();
            childForm.Closed += (s, args) => this.Close();
            childForm.ShowDialog();
        }
    }
}


