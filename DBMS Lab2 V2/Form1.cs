using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DBMS_Lab2_V2
{

    public partial class Form1 : Form
    {
        public static string sqlQuery, TableFirst, TableSecond, idFirst, idSecond;
        public static SqlConnection connection = new SqlConnection();
        public static SqlDataAdapter dataAdapterFirst, dataAdapterSecond;
        public static DataSet dataSet;
        public static SqlCommand command;
        public static SqlCommandBuilder commandBuilder;

        private void GridFirst_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public static BindingSource bindingSourceFirst, bindingSourceSecond;

        public Form1()
        {
            InitializeComponent();
            this.Text = SqlConn.myApp();
        }


    }
}
