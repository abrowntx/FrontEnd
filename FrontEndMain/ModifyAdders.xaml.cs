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
    /// Interaction logic for ModifyAdders.xaml
    /// </summary>
    public partial class ModifyAdders : Window
    {
        public ModifyAdders()
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

        private void lbAdders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vari.AdderIndex = lbAdders.Items.IndexOf(lbAdders.SelectedItem);
            DataRowView drv = (DataRowView)lbAdders.SelectedItem;
            if (drv == null)
            {
                
            }
            else
            {
                vari.AdderSelect = drv[1].ToString();
                //CHECK IF INDEX SELECTED IS ZERO
                if (vari.AdderIndex < 0 || vari.CustSelect == "")
                { return; }
                else
                {
                    vari.AdderIndex = Convert.ToInt16(drv[0]);
                    tbAdderName.Text = vari.AdderSelect;
                    tbAdderPrice.Text = drv[2].ToString();
                }
            }
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            lbAdders.SelectedItem = null;
            tbAdderPrice.Text = null;
            tbAdderName.Text = null;
            vari.AdderIndex = 0;
            vari.AdderSelect = null;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (vari.AdderIndex == 0 || vari.AdderSelect == "")
            {
                MessageBox.Show("Cannot update an adder unless an adder is first selected!");
                return;
            }
            else
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
                        connection1.Open();
                        //QUERY THE DB FOR ALL ENTRIES FOR A GIVEN WO NUMBER
                        OComm.CommandText = "UPDATE Adders SET AdderName = '" + tbAdderName.Text + "', AdderCost = " + tbAdderPrice.Text + " WHERE ID = " + vari.AdderIndex + ";";
                        OComm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    { System.Windows.MessageBox.Show(ex.Message); }
                    finally
                    { connection1.Close(); }

                    QueryAdders();
                }
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            if (vari.AdderIndex == 0 || vari.AdderSelect == "")
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
                        connection1.Open();
                        //QUERY THE DB FOR ALL ENTRIES FOR A GIVEN WO NUMBER
                        OComm.CommandText = "INSERT INTO Adders (AdderName,AdderCost) VALUES ('" + tbAdderName.Text + "'," + tbAdderPrice.Text + ");";
                        OComm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    { System.Windows.MessageBox.Show(ex.Message); }
                    finally
                    { connection1.Close(); }

                    QueryAdders();
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this adder entry? This operation cannot be undone!", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
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
                        connection1.Open();
                        OComm.CommandText = "DELETE FROM Adders WHERE ID = " + vari.AdderIndex + ";";
                        OComm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    { System.Windows.MessageBox.Show(ex.Message); }
                    finally
                    { connection1.Close(); }
                    vari.CustRefreshCond = true;
                }
                QueryAdders();
                ClearFields();
            }
        }
    }
}
