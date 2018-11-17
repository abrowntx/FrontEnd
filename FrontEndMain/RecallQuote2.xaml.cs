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
            QueryCustList("SELECT ID,CustName FROM CustomerList;");
            btnClearPNSearch_Copy.IsEnabled = false;
            tbCustSearch.IsEnabled = false;
            lbCust.IsEnabled = false;
        }

//PUBLIC VARIABLES
        public int Code;

        //MOVE TO NEXT FORM OBJECT ON ENTER KEY PRESS
        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;
            if (e.Key == Key.Enter)
            { e.Handled = true; uie.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next)); }
        }
        //CLOSE THE CURRENT WINDOW ON ESCAPE KEY PRESS - ASSOCIATE EVENT WITH WINDOW COMPONENT
        private void escape(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;
            if (e.Key == Key.Escape) { this.Close(); }
        }

        //FILL CUSTOMERS PANEL
        private void QueryCustList(string Query)
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
                    OleDbDataAdapter DA = new OleDbDataAdapter(Query, connection1);
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

//FILL DETAILS PANEL
        private void FillDetails(string Dep, int C, string prefix, string Query)
        {
            btnClearPNSearch_Copy.IsEnabled = true;
            tbCustSearch.IsEnabled = true;
            lbCust.IsEnabled = true;

            Code = C;
            vari.rIndex = C;
            vari.rDep = Dep;
            vari.rPre = prefix;
            lPrefix.Text = prefix;
            // SET THE DATABASE CONNECTION VARS
            string file = vari.DefaultDirectory + "Quotes.accdb";
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
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT * FROM " + Dep + Query + ";", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "*");
                    if (vari.Recall == true)
                    {
                        vari.RQD = null;
                        vari.RQD = DataSet;
                        vari.Recall = false;
                    }
                    else
                    {
                        // Set the dataset from OleDBAdapter to the item source of the data grid object
                        lbList.DataContext = DataSet.Tables[0];
                        lbList.ItemsSource = DataSet.Tables[0].DefaultView;

                        ICollectionView dataView = CollectionViewSource.GetDefaultView(lbList.ItemsSource);
                        dataView.SortDescriptions.Clear();
                        dataView.SortDescriptions.Add(new SortDescription("id", ListSortDirection.Descending));
                        dataView.Refresh();
                    }

                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

//DEPARTMENT SELECT BUTTONS
        private void btnMicaBand_Click(object sender, RoutedEventArgs e)
        { FillDetails("MicaQuotes", 1, "Mica Band Heater Quotes", ""); }

        private void btnMicaStrip_Click(object sender, RoutedEventArgs e)
        { FillDetails("FlatQuotes", 2, "Mica Strip Heater Quotes", ""); }

        private void btnCeramic_Click(object sender, RoutedEventArgs e)
        { FillDetails("CerQuotes", 3, "Ceramic Heater Quotes", ""); }

        private void btnCeramicStrip_Click(object sender, RoutedEventArgs e)
        { FillDetails("CSQuotes", 4, "Ceramic Strip Heater Quotes", ""); }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        { FillDetails("CartQuotes", 5, "Cartridge Heater Quotes", ""); }

        private void btnMisc_Click(object sender, RoutedEventArgs e)
        { FillDetails("MiscQuotes", 6, "Miscellaneous Quotes", ""); }

        private void RQD()
        {
            //Break functiion if listbox selection is null
            if (lbList.SelectedItem == null) { return; }

            vari.Recall = true;
            vari.drvSelect = (DataRowView)lbList.SelectedItem;
            //int i = 0;
            //string s = "";
            //for (i = 0; i < vari.drvSelect.Row.Table.Columns.Count; i++)
            //{
            //    s = s + "     [" + i + "] - " + vari.drvSelect[i].ToString();
            //}
            FillDetails(vari.rDep, vari.rIndex, vari.rPre, " WHERE id = " + vari.drvSelect[0].ToString() + "");

            vari.Recall = true;
            CreateQuote CMBQ = new CreateQuote();
            CMBQ.Show();
        }

        private void CreateNewPart()
        {
            //Break functiion if listbox selection is null
            if (lbList.SelectedItem == null) { return; }

            vari.Recall = true;
            vari.drvSelect = (DataRowView)lbList.SelectedItem;
            FillDetails(vari.rDep, vari.rIndex, vari.rPre, " WHERE id = " + vari.drvSelect[0].ToString() + "");
            PartGen_MicaBand CNPMB = new PartGen_MicaBand();
            CNPMB.Show();
        }


//CUSTOMER LIST BOX ACTIONS!
        private void lbCust_MouseLBU(object sender, MouseButtonEventArgs e)
        {
            //Break functiion if listbox selection is null
            if (lbCust.SelectedItem == null) { return; }

            vari.drvSelect = (DataRowView)lbCust.SelectedItem;
            string s = " WHERE Cust = '" + vari.drvSelect[1].ToString() + "'";

            FillDetails(vari.rDep, vari.rIndex, vari.rPre, s);
        }

//DETAILS LIST BOX ACTIONS!
        private void lbList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

//SEARCH CUSTOMERS FUNCTION
        private void btnClearPNSearch_Copy_Click(object sender, RoutedEventArgs e)
        {
            QueryCustList("SELECT ID,CustName FROM CustomerList WHERE CustName LIKE '%" + tbCustSearch.Text + "%';");
        }


//CUSTOMER LISTBOX CONTEXT MENU ITEMS
        private void cmMBQ_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }


//DETAILS LISTBOX CONTEXT MENU ITEMS
        //CREATE NEW PART
        private void cmCreatePart_MouseDown(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                CreateNewPart();
            }
        }

        //EDIT QUOTE DETAILS
        private void cmEditQuodeDetails_MouseDown(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                RQD();
            }
        }
    }
}
