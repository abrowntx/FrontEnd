using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.IO;
using Microsoft.Win32;

namespace FrontEndMain
{
    /// <summary>
    /// Interaction logic for Q_Adders.xaml
    /// </summary>
    public partial class Q_Adders : Window
    {
        public Q_Adders()
        {
            InitializeComponent();
            QueryAdders();
        }

        private void QueryAdders()
        {
            string file = vari.DefaultDirectory + "Quotes.accdb";
            string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + file + ";";
            // Attempt to connect to the database
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand();
                OComm.Connection = connection1;
                try
                {
                    //QUERY THE DB FOR ALL ENTRIES FOR A GIVEN WO NUMBER
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT ID,AdderName,AdderCost FROM Adders;", connection1);
                    var DataSet2 = new DataSet();
                    DA.Fill(DataSet2, "*");
                    // Set the dataset from OleDBAdapter to the item source of the data grid object
                    lbAdders.DataContext = DataSet2.Tables[0];
                    lbAdders.ItemsSource = DataSet2.Tables[0].DefaultView;
                }
                catch (Exception ex)
                { System.Windows.MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveQuote_Click(object sender, RoutedEventArgs e)
        {
            SaveQuote2();
        }

        private void SaveQuote2()
        {
            DataTable DT = new DataTable();
            DT.Columns.Add("AdderName", typeof(string));
            DT.Columns.Add("AdderCost", typeof(double));
            var lst = lbAdders.SelectedItems.Cast<DataRowView>();
            //ADD SELECTED ITEMS TO THE DATATABLE
            foreach (var item in lst)
            {
                //MessageBox.Show(item.Row[0].ToString() + " | " + item.Row[1].ToString() + " | " + item.Row[2].ToString());
                DT.Rows.Add(new Object[]{
                item.Row[1].ToString(),
                Convert.ToDouble(item.Row[2]) });
            }

            //SMASH THE SELECTED ADDER DATA TABLE INTO AN OBJECT ARRAY
            object[,] objectArray = new object[DT.Rows.Count,
                                               DT.Columns.Count];

            for (int row = 0; row < DT.Rows.Count; row++)
            {
                for (int col = 0; col < DT.Columns.Count; col++)
                {
                    objectArray[row, col] = DT.Rows[row][col];
                }
            }

            string file = vari.DefaultDirectory + "Quotes.accdb";
            string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + file + ";";
            // Attempt to connect to the database
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand();
                OComm.Connection = connection1;
                connection1.Open();
                OComm.CommandText = "DELETE from AddersSelect;";
                OComm.ExecuteNonQuery();
                connection1.Close();

                foreach (DataRow row in DT.Rows)
                {
                    OComm.Connection = connection1;
                    connection1.Open();
                    OComm.CommandText = "INSERT INTO AddersSelect (AdderName,AdderCost) VALUES ('" + row[0] + "'," + row[1] + ");";
                    OComm.ExecuteNonQuery();
                    connection1.Close();
                }
            }


            vari.AdderArray = objectArray;
            vari.Adders = true;
            this.Close();

            //MessageBox.Show(vari.AdderArray[0, 0].ToString() + " | " + vari.AdderArray[0, 1].ToString() + " | " + vari.AdderArray[1, 0].ToString() + " | " + vari.AdderArray[1, 1].ToString());
        }

        private void SaveQuote()
        {
            DataTable DT = new DataTable();
            DT.Columns.Add("AdderName", typeof(string));
            DT.Columns.Add("AdderCost", typeof(double));
            var lst = lbAdders.SelectedItems.Cast<DataRowView>();
            //ADD SELECTED ITEMS TO THE DATATABLE
            foreach (var item in lst)
            {
                //MessageBox.Show(item.Row[0].ToString() + " | " + item.Row[1].ToString() + " | " + item.Row[2].ToString());
                DT.Rows.Add(new Object[]{
                item.Row[1].ToString(),
                Convert.ToDouble(item.Row[2]) });
            }

            string file = vari.DefaultDirectory + "Quotes.accdb";
            string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + file + ";";
            // Attempt to connect to the database
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand();
                OComm.Connection = connection1;
                connection1.Open();
                OComm.CommandText = "DELETE from AddersSelect;";
                OComm.ExecuteNonQuery();
                connection1.Close();

                foreach (DataRow row in DT.Rows)
                {
                    OComm.Connection = connection1;
                    connection1.Open();
                    OComm.CommandText = "INSERT INTO AddersSelect (AdderName,AdderCost) VALUES ('" + row[0] + "'," + row[1] + ");";
                    OComm.ExecuteNonQuery();
                    connection1.Close();
                }
            }
            vari.Adders = true;
            this.Close();
        }



    }
}
