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
    /// Interaction logic for CustomerManager.xaml
    /// </summary>
    public partial class CustomerManager : Window
    {
        public CustomerManager()
        {
            InitializeComponent();
            QueryCustomers();
            vari.ModCust = false;
        }

        private void ReloadCustList()
        {
            if (vari.CustRefreshCond)
            {
                lbCust.ItemsSource = null;
                lbCust.Items.Refresh();
                QueryCustomers();
                vari.CustRefreshCond = false;
            } else
            { return; }

        }

        private void QueryCustomers()
        {
            string file = vari.DefaultDirectory + "Customers.accdb";
            string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + file + ";";
            // Attempt to connect to the database
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand();
                OComm.Connection = connection1;
                try
                {
                    //QUERY THE DB FOR ALL ENTRIES FOR A GIVEN WO NUMBER
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT ID,CustName,CustType,Multi FROM CustomerList;", connection1);
                    var DataSet2 = new DataSet();
                    DA.Fill(DataSet2, "*");
                    // Set the dataset from OleDBAdapter to the item source of the data grid object
                    lbCust.DataContext = DataSet2.Tables[0];
                    lbCust.ItemsSource = DataSet2.Tables[0].DefaultView;

                    ICollectionView dataView = CollectionViewSource.GetDefaultView(lbCust.ItemsSource);
                    dataView.SortDescriptions.Clear();
                    dataView.SortDescriptions.Add(new SortDescription("CustName", ListSortDirection.Ascending));
                    dataView.Refresh();
                }
                catch (Exception ex)
                { System.Windows.MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

        private void QueryDetails()
        {
            string file = vari.DefaultDirectory + "Customers.accdb";
            string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + file + ";";
            // Attempt to connect to the database
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand();
                OComm.Connection = connection1;
                try
                {
                    //QUERY THE DB FOR ALL ENTRIES FOR A GIVEN WO NUMBER
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT ID,CustName,CustType,Multi,Phone,Fax,Add1,Add2,Add3,Add4,Add5,Stamp FROM CustomerList WHERE CustName = '" + vari.CustSelect + "';", connection1);
                    var DataSet2 = new DataSet();
                    DA.Fill(DataSet2, "*");
                    // Set the dataset from OleDBAdapter to the item source of the data grid object
                    lbCustDetails.DataContext = DataSet2.Tables[0];
                    lbCustDetails.ItemsSource = DataSet2.Tables[0].DefaultView;

                }
                catch (Exception ex)
                { System.Windows.MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

        private void lbCust_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vari.CustIndex = lbCust.Items.IndexOf(lbCust.SelectedItem);
            DataRowView drv = (DataRowView)lbCust.SelectedItem;
            if (drv == null)
            {

            }else
            {
                vari.CustSelect = drv[1].ToString();
                //CHECK IF INDEX SELECTED IS ZERO
                if (vari.CustIndex < 0 || vari.CustSelect == "")
                { return; }
                QueryDetails();
            }
        }

        private void btnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerEdit CE = new CustomerEdit();
            CE.ShowDialog();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            vari.ModCust = false;
            ReloadCustList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete this customer? This operation cannot be undone!", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                string file = vari.DefaultDirectory + "Customers.accdb";
                string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + file + ";";
                // Attempt to connect to the database
                using (var connection1 = new OleDbConnection(ConnectionString))
                {
                    OleDbCommand OComm = new OleDbCommand();
                    OComm.Connection = connection1;
                    try
                    {
                        connection1.Open();
                        OComm.CommandText = "DELETE FROM CustomerList WHERE CustName = '" + vari.CustSelect + "';";
                        OComm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    { System.Windows.MessageBox.Show(ex.Message); }
                    finally
                    { connection1.Close(); }
                    vari.CustRefreshCond = true;
                }
                ReloadCustList();
            }
        }

        private void btnModifyCust_Click(object sender, RoutedEventArgs e)
        {
            vari.ModCust = true;
            CustomerEdit CE = new CustomerEdit();
            CE.ShowDialog();
        }
    }
}
