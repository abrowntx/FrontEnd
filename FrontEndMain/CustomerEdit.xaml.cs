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
    /// Interaction logic for CustomerEdit.xaml
    /// </summary>
    public partial class CustomerEdit : Window
    {
        public CustomerEdit()
        {
            InitializeComponent();
            QueryCustType();

            cmbStamp.Items.Add("(Standard) EZ Heat, EZ Number, W/V/D");
            cmbStamp.Items.Add("No EZ Heat, EZ Number, W/V/D");
            cmbStamp.Items.Add("Customer Name, EZ Number, W/V/D");
            cmbStamp.Items.Add("Customer Name, Customer Number, W/V/D");
            cmbStamp.Items.Add("No EZ Heat, Customer Number, W/V/D");
            cmbStamp.Items.Add("Customer Name, Customer Number, W/V/D, Telephone");

            if (vari.ModCust == true)
            {
                QueryExisting();
            }
            else
            {
                //cmbStamp.SelectedIndex = 0;
            }
        }

        //Public Vars
        public int multiplier;
        public bool ExistingCust;

        private void QueryExisting()
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
                    // Query the database to find all entries without a FINISH TIME
                    OleDbCommand CheckMulti = new OleDbCommand("SELECT ID,CustName,CustType,Multi,Phone,Fax,Add1,Add2,Add3,Add4,Add5,Stamp FROM CustomerList WHERE CustName = '" + vari.CustSelect + "';", connection1);
                    OleDbDataReader reader = CheckMulti.ExecuteReader();
                    while (reader.Read())
                    {
                        tbName.Text = reader[1].ToString();
                        cmbType.Text = reader[2].ToString();
                        tbMulti.Text = reader[3].ToString();
                        tbPhone.Text = reader[4].ToString();
                        tbFax.Text = reader[5].ToString();
                        cmbAdd1.Text = reader[6].ToString();
                        cmbAdd2.Text = reader[7].ToString();
                        cmbAdd3.Text = reader[8].ToString();
                        cmbAdd4.Text = reader[9].ToString();
                        cmbAdd5.Text = reader[10].ToString();
                        cmbStamp.Text = reader[11].ToString();
                    }
                    reader.Close();

                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

        private void QueryCustType()
        {
            string file = vari.DefaultDirectory + "Customers.accdb";
            string ConnectionString =
            "Provider = Microsoft.ACE.OLEDB.12.0;" +
            "Data Source =" + file + ";";
            // Attempt to connect to the database
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand();
                OComm.Connection = connection1;
                try
                {
                    connection1.Open();
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT ID,CustType FROM CustomerType;", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "CustomerType");

                    cmbType.DataContext = this;
                    cmbType.ItemsSource = DataSet.Tables[0].DefaultView;
                    cmbType.DisplayMemberPath = DataSet.Tables[0].Columns["CustType"].ToString();
                    cmbType.SelectedValuePath = DataSet.Tables[0].Columns["ID"].ToString();

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

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string file = vari.DefaultDirectory + "Customers.accdb";
            string ConnectionString =
            "Provider = Microsoft.ACE.OLEDB.12.0;" +
            "Data Source =" + file + ";";
            // Attempt to connect to the database
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand();
                OComm.Connection = connection1;
                try
                {
                    connection1.Open();

                    DataRowView DRV = cmbType.SelectedItem as DataRowView;
                    vari.CustType = string.Empty;

                    if (DRV != null)
                    { vari.CustType = DRV.Row[1] as string; }

                    string Type = cmbType.SelectedItem.ToString();
                    OleDbCommand GetMulti = new OleDbCommand("SELECT Multi FROM CustomerType WHERE CustType = '" + vari.CustType + "';", connection1);
                    OleDbDataReader reader = GetMulti.ExecuteReader();
                    while (reader.Read())
                    {
                        multiplier = Convert.ToInt16(reader[0]);
                        tbMulti.Text = reader[0].ToString();

                    }
                    reader.Close();

                }
                catch (Exception ex)
                { System.Windows.MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }

            }
        }

        private void btnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            //VALIDATOR!
            if (cmbStamp.Text == "")
            {
                MessageBox.Show("Please enter a Stamping Style!");
                return;
            }
            if (tbName.Text == "")
            {
                MessageBox.Show("Please enter a Customer Name!");
                return;
            }
            if (cmbType.Text == "")
            {
                MessageBox.Show("Please enter a Customer Type!");
                return;
            }

            //Start Submit New Customer
            if (vari.ModCust == true)
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
                        // Query the database to find all entries without a FINISH TIME
                        OleDbCommand CheckMulti = new OleDbCommand("UPDATE CustomerList SET CustName = '" + tbName.Text +"',CustType = '" + cmbType.Text +"',Multi = '" + tbMulti.Text +"'," +
                            "Phone = '" + tbPhone.Text +"',Fax = '" + tbFax.Text +"',Add1 = '" + cmbAdd1.Text +"',Add2 = '" + cmbAdd2.Text + "',Add3 = '" + cmbAdd3.Text + "'," +
                            "Add4 = '" + cmbAdd4.Text + "',Add5 = '" + cmbAdd5.Text + "',Stamp = '" + cmbStamp.Text + "' WHERE CustName = '" + vari.CustSelect + "';", connection1);
                        OleDbDataReader reader = CheckMulti.ExecuteReader();

                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                    finally
                    { connection1.Close(); }
                }
                this.Close();
            } else
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
                        // Query the database to find all entries without a FINISH TIME
                        OleDbCommand CheckMulti = new OleDbCommand("SELECT count(*) FROM CustomerList WHERE CustName = '" + tbName.Text + "';", connection1);
                        OleDbDataReader reader = CheckMulti.ExecuteReader();
                        while (reader.Read())
                        {
                            if (Convert.ToInt16(reader[0]) > 0)
                            {
                                ExistingCust = true;
                            }
                            else
                            {
                                ExistingCust = false;
                            }
                        }
                        reader.Close();

                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                    finally
                    { connection1.Close(); }
                }

                if (ExistingCust)
                {
                    MessageBox.Show("A record for this customer's name already exists. Please enter a unique name or edit the existing record as needed.");
                }
                else
                {

                    // Attempt to connect to the database
                    using (var connection1 = new OleDbConnection(ConnectionString))
                    {
                        try
                        {
                            connection1.Open();
                            OleDbCommand GetMulti = new OleDbCommand("INSERT INTO CustomerList(CustName,CustType,Multi,Phone,Fax,Add1,Add2,Add3,Add4,Add5,Stamp) VALUES ('" + tbName.Text + "','" + vari.CustType + "'," + tbMulti.Text + ",'" + tbPhone.Text + "','" + tbFax.Text + "','" + cmbAdd1.Text + "','" + cmbAdd2.Text + "','" + cmbAdd3.Text + "','" + cmbAdd4.Text + "','" + cmbAdd5.Text + "', '" + cmbStamp.Text + "');", connection1);
                            OleDbDataReader reader = GetMulti.ExecuteReader();
                            while (reader.Read())
                            {
                                multiplier = Convert.ToInt16(reader[0]);
                                tbMulti.Text = reader[0].ToString();

                            }
                            reader.Close();

                        }
                        catch (Exception ex)
                        { System.Windows.MessageBox.Show(ex.Message); }
                        finally
                        { connection1.Close(); }
                        vari.CustRefreshCond = true;

                        MessageBox.Show("Customer was successfully created and added to the database!");
                        this.Close();
                    }

                }
            }
        }
    }
}
