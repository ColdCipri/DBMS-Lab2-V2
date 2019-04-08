using System.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DBMS_Lab2_V2
{

    public partial class Form1 : Form
    {
        public static SqlDataAdapter dataAdapterFirst, dataAdapterSecond;
        public static DataSet dataSet;
        public static SqlCommandBuilder commandBuilder;
        public static BindingSource bindingSourceFirst, bindingSourceSecond;

        private void Form1_Load(object sender, EventArgs e)
        {

            SqlConn.OpenConn();
            dataSet = new DataSet();
            bindingSourceFirst = new BindingSource();
            

            dataAdapterFirst = new SqlDataAdapter(ConfigurationManager.AppSettings.Get("selectAllFromParent"), SqlConn.connection);
            dataAdapterSecond = new SqlDataAdapter(ConfigurationManager.AppSettings.Get("selectAllFromChildren"), SqlConn.connection);
            commandBuilder = new SqlCommandBuilder(dataAdapterSecond);

            dataAdapterFirst.Fill(dataSet, ConfigurationManager.AppSettings.Get("ParentTable"));
            dataAdapterSecond.Fill(dataSet, ConfigurationManager.AppSettings.Get("ChildTable"));

            DataRelation dr = new DataRelation(ConfigurationManager.AppSettings.Get("FkServ"), 
                dataSet.Tables[ConfigurationManager.AppSettings.Get("ParentTable")]
                    .Columns[ConfigurationManager.AppSettings.Get("FK")], 
                dataSet.Tables[ConfigurationManager.AppSettings.Get("ChildTable")]
                    .Columns[ConfigurationManager.AppSettings.Get("FK")]);
            dataSet.Relations.Add(dr);

            bindingSourceFirst = new BindingSource
            {
                DataSource = dataSet,
                DataMember = ConfigurationManager.AppSettings.Get("ParentTable")
            };

            bindingSourceSecond = new BindingSource();
            bindingSourceSecond.DataSource = bindingSourceFirst;
            bindingSourceSecond.DataMember = ConfigurationManager.AppSettings.Get("FkServ");

            GridFirst.DataSource = bindingSourceFirst;
            GridSecond.DataSource = bindingSourceSecond;
        }
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlConn.CloseConn();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataAdapterSecond.Update(dataSet, ConfigurationManager.AppSettings.Get("ChildTable"));
        }
        
        public Form1()
        {
            InitializeComponent();
            this.Text = SqlConn.myApp();
        }

        private void GridFirst_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dataGridViewRow = GridFirst.Rows[e.RowIndex];
                textBox1.Text = dataGridViewRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridViewRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridViewRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridViewRow.Cells[3].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 childForm = new Form1();
            this.Hide();
            childForm.Closed += (s, args) => this.Close();
            childForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm childForm = new MainForm();
            this.Hide();
            childForm.Closed += (s, args) => this.Close();
            childForm.ShowDialog();
        }
    }
}
