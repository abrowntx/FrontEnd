using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Data.OleDb;
using System.Data;
using System.ComponentModel;

namespace FrontEndMain
{
    /// <summary>
    /// Interaction logic for RecallQuote2.xaml
    /// </summary>
    public partial class RecallQuote2 : Window
    {
        public RecallQuote2()
        {
            InitializeComponent();
            QueryCustList();
        }

        //PUBLIC VARIABLES
        public int Code;
        
        private void QueryCustList()
        {
            // SET THE DATABASE CONNECTION VARS
            string file = vari.DefaultDirectory + "Customers.accdb";
            string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source =" + file + ";";

            // Attempt to connect to the database
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand();
                OComm.Connection = connection1;
                try
                {
                    connection1.Open();
                    // Query the database to find all entries without a FINISH TIME
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT ID,CustName FROM CustomerList;", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "*");
                    // Set the dataset from OleDBAdapter to the item source of the data grid object
                    lbCust.DataContext = DataSet.Tables[0];
                    lbCust.ItemsSource = DataSet.Tables[0].DefaultView;

                    ICollectionView dataView = CollectionViewSource.GetDefaultView(lbCust.ItemsSource);
                    dataView.SortDescriptions.Clear();
                    dataView.SortDescriptions.Add(new SortDescription("CustName", ListSortDirection.Ascending));
                    dataView.Refresh();

                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

        private void FillDetails(string Dep, int C, string prefix)
        {
            Code = C;
            lPrefix.Text = prefix;
            // SET THE DATABASE CONNECTION VARS
            string file = vari.DefaultDirectory + "Lists.accdb";
            string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source =" + file + ";";

            // Attempt to connect to the database
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand();
                OComm.Connection = connection1;
                try
                {
                    connection1.Open();
                    // Query the database to find all entries without a FINISH TIME
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT * FROM " + Dep + ";", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "*");
                    // Set the dataset from OleDBAdapter to the item source of the data grid object
                    lbList.DataContext = DataSet.Tables[0];
                    lbList.ItemsSource = DataSet.Tables[0].DefaultView;

                    ICollectionView dataView = CollectionViewSource.GetDefaultView(lbList.ItemsSource);
                    dataView.SortDescriptions.Clear();
                    dataView.SortDescriptions.Add(new SortDescription("file", ListSortDirection.Descending));
                    dataView.Refresh();

                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

        private void btnMicaBand_Click(object sender, RoutedEventArgs e)
        {
            FillDetails("BHList", 1, "BH");
        }

        private void btnMicaStrip_Click(object sender, RoutedEventArgs e)
        {
            FillDetails("SHList", 2, "SH");
        }

        private void btnCeramic_Click(object sender, RoutedEventArgs e)
        {
            FillDetails("CBList", 3, "CB");
        }

        private void btnCeramicStrip_Click(object sender, RoutedEventArgs e)
        {
            FillDetails("CSList", 4, "CS");
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            FillDetails("CList", 5, "C");
        }

        private void btnMisc_Click(object sender, RoutedEventArgs e)
        {
            FillDetails("MList", 6, "M");
        }
    }
}
