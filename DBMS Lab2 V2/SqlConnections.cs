using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DBMS_Lab2_V2
{
    static class SqlConn
    {
        public static string sqlQuery, TableFirst, TableSecond, idFirst, idSecond;
        public static SqlConnection connection = new SqlConnection();
        public static SqlDataAdapter dataAdapterFirst, dataAdapterSecond;
        public static DataSet dataSet;
        public static SqlCommand command;
        public static SqlCommandBuilder commandBuilder;
        public static BindingSource bindingSourceFirst, bindingSourceSecond;

        public static string GetConnectionString()
        {
            return @"Data Source = CIPRI-ASUS\SQLEXPRESS; " +
                    "Initial Catalog = Car_Shop; " +
                    "Integrated Security = True; " +
                    "MultipleActiveResultSets = True;";
        }

        public static string myApp()
        {
            return "DBMS Lab2 ";
        }

        public static void ConnectionState()
        {
            string msg = "Connection state: " + "The connection is ";
            string title = SqlConn.myApp();
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            MessageBox.Show(msg + connection.State.ToString(), title, btn, icon);
        }

        public static void GenericDatabase()
        {
            dataSet = new DataSet();

            TableFirst = "Service";
            TableSecond = "Mechanic";

            dataAdapterFirst = new SqlDataAdapter("select * from " + TableFirst, connection);
            dataAdapterSecond = new SqlDataAdapter("select * from " + TableSecond, connection);
            commandBuilder = new SqlCommandBuilder(dataAdapterFirst);

            dataAdapterFirst.Fill(dataSet, TableFirst);
            dataAdapterSecond.Fill(dataSet, TableSecond);

            idFirst = "ServiceID";
            idSecond = "ServiceID";

            DataRelation dr = new DataRelation("FK_" + TableFirst + "_" + TableSecond, dataSet.Tables[TableFirst].Columns[idFirst], dataSet.Tables[TableSecond].Columns[idSecond]);
            dataSet.Relations.Add(dr);

            bindingSourceFirst = new BindingSource
            {
                DataSource = dataSet,
                DataMember = TableFirst
            };

            bindingSourceSecond = new BindingSource();
            bindingSourceSecond.DataSource = bindingSourceFirst;
            bindingSourceSecond.DataMember = "FK_" + TableFirst + "_" + TableSecond;

            GridFirst.DataSource = TableFirst;
            GridSecond.DataSource = TableSecond;
        }

        public static void OpenConn()
        {
            connection.Close();
            try
            {
                connection.ConnectionString = SqlConn.GetConnectionString();
                connection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("The sysyem failed to establish a connection." + Environment.NewLine + e);
            }
            //finally
            //{
            //    ConnectionState();
            //}
        }

        public static void CloseConn()
        {
            connection.Close();
            connection.Dispose();
            //ConnectionState();
        }
    }
}
