using System.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBMS_Lab2_V2
{
    public partial class Form2 : Form
    {
        public static SqlDataAdapter dataAdapterFirst, dataAdapterSecond;
        public static DataSet dataSet;
        public static SqlCommandBuilder commandBuilder;
        public static BindingSource bindingSourceFirst, bindingSourceSecond;

        public Form2()
        {
            InitializeComponent();
            this.Text = SqlConn.myApp();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConn.OpenConn();
            dataSet = new DataSet();
            bindingSourceFirst = new BindingSource();


            dataAdapterFirst = new SqlDataAdapter(ConfigurationManager.AppSettings.Get("selectAllParent"), SqlConn.connection);
            dataAdapterSecond = new SqlDataAdapter(ConfigurationManager.AppSettings.Get("selectAllChildren"), SqlConn.connection);
            commandBuilder = new SqlCommandBuilder(dataAdapterSecond);

            dataAdapterFirst.Fill(dataSet, ConfigurationManager.AppSettings.Get("Parent"));
            dataAdapterSecond.Fill(dataSet, ConfigurationManager.AppSettings.Get("Child"));

            DataRelation dr = new DataRelation(ConfigurationManager.AppSettings.Get("FKCar"),
                dataSet.Tables[ConfigurationManager.AppSettings.Get("Parent")]
                    .Columns[ConfigurationManager.AppSettings.Get("ParentFK")],
                dataSet.Tables[ConfigurationManager.AppSettings.Get("Child")]
                    .Columns[ConfigurationManager.AppSettings.Get("ParentFK")]);
            dataSet.Relations.Add(dr);

            bindingSourceFirst = new BindingSource
            {
                DataSource = dataSet,
                DataMember = ConfigurationManager.AppSettings.Get("Parent")
            };

            bindingSourceSecond = new BindingSource();
            bindingSourceSecond.DataSource = bindingSourceFirst;
            bindingSourceSecond.DataMember = ConfigurationManager.AppSettings.Get("FKCar");

            GridFirst.DataSource = bindingSourceFirst;
            GridSecond.DataSource = bindingSourceSecond;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataAdapterSecond.Update(dataSet, ConfigurationManager.AppSettings.Get("Child"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 childForm = new Form2();
            this.Hide();
            childForm.Closed += (s, args) => this.Close();
            childForm.ShowDialog();
        }
        private void GridFirst_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dataGridViewRow = GridFirst.Rows[e.RowIndex];
                textBox1.Text = dataGridViewRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridViewRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridViewRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridViewRow.Cells[6].Value.ToString();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlConn.CloseConn();
            
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
