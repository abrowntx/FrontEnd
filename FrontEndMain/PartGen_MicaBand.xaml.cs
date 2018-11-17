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
    /// Interaction logic for PartGen_MicaBand.xaml
    /// </summary>
    public partial class PartGen_MicaBand : Window
    {
        public PartGen_MicaBand()
        {
            InitializeComponent();
            Startup();
            

            //Populate wiring style
            cmbWiring.SelectedIndex = 0;
            cmbWiring.Items.Add("Standard");
            cmbWiring.Items.Add("Dual Voltage");
            cmbWiring.Items.Add("Dual Zone");
            cmbWiring.Items.Add("3-Phase");

            //populate construction
            cmbConstr.SelectedIndex = 0;
            cmbConstr.Items.Add("Standard");
            cmbConstr.Items.Add("Reverse Construction");
            cmbConstr.Items.Add("Cone Heater");

            //Populate Term Loc
            cmbTermLoc.Items.Add("Standard");
            cmbTermLoc.Items.Add("Degree");

            //Populate Stamp Style
            cmbStamp.Items.Add("(Standard) EZ Heat, EZ Number, W/V/D");
            cmbStamp.Items.Add("No EZ Heat, EZ Number, W/V/D");
            cmbStamp.Items.Add("Customer Name, EZ Number, W/V/D");
            cmbStamp.Items.Add("Customer Name, Customer Number, W/V/D");
            cmbStamp.Items.Add("No EZ Heat, Customer Number, W/V/D");

            vari.filegen = false;
            vari.filenumber = null;

            
        }

        private void Window_Activated(object sender, EventArgs e)
        {

            tbBH.Text = vari.filenumber;

            vari.filegen = false;
            vari.filenumber = null;

            CustomerDetails();
        }

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

        private void Startup()
        {
            tbID.Text = vari.RQD.Tables[0].Rows[0][0].ToString();
            tbCust.Text = vari.RQD.Tables[0].Rows[0][1].ToString();
            tbDate.Text = vari.RQD.Tables[0].Rows[0][2].ToString();
            tbPN.Text = vari.RQD.Tables[0].Rows[0][45].ToString();
            tbSeg.Text = vari.RQD.Tables[0].Rows[0][12].ToString();
            tbLock.Text = vari.RQD.Tables[0].Rows[0][13].ToString();
            tbDia.Text = vari.RQD.Tables[0].Rows[0][14].ToString();
            tbWid.Text = vari.RQD.Tables[0].Rows[0][15].ToString();
            tbTerm.Text = vari.RQD.Tables[0].Rows[0][18].ToString();
            tbWatts.Text = vari.RQD.Tables[0].Rows[0][16].ToString();
            tbVolts.Text = vari.RQD.Tables[0].Rows[0][17].ToString();
            tbLeads.Text = vari.RQD.Tables[0].Rows[0][19].ToString();
            tbLeadcov.Text = vari.RQD.Tables[0].Rows[0][20].ToString();
            tbTermLoc.Text = vari.RQD.Tables[0].Rows[0][22].ToString();
            cmbTermLoc.Text = vari.RQD.Tables[0].Rows[0][21].ToString();
            tbNotes.Text = vari.RQD.Tables[0].Rows[0][26].ToString();
            tbDesc.Text = vari.RQD.Tables[0].Rows[0][31].ToString();
            if (vari.RQD.Tables[0].Rows[0][21].ToString() == "Standard")
            {
                cmbTermLoc.SelectedIndex = 0;
            }
            else
            {
                cmbTermLoc.SelectedIndex = 1;
            }
            tbHoles.Text = vari.RQD.Tables[0].Rows[0][23].ToString();
            tbNotches.Text = vari.RQD.Tables[0].Rows[0][24].ToString();

            lbAdders.Items.Add(vari.RQD.Tables[0].Rows[0][33].ToString());
            lbAdders.Items.Add(vari.RQD.Tables[0].Rows[0][35].ToString());
            lbAdders.Items.Add(vari.RQD.Tables[0].Rows[0][37].ToString());
            lbAdders.Items.Add(vari.RQD.Tables[0].Rows[0][39].ToString());
            lbAdders.Items.Add(vari.RQD.Tables[0].Rows[0][41].ToString());
            lbAdders.Items.Add(vari.RQD.Tables[0].Rows[0][43].ToString());

            string watt;
            string volt = "";
            if (Convert.ToDouble(tbVolts.Text) < 100) { volt = "0"; }
            else
            {
                if (Convert.ToDouble(tbVolts.Text) < 200) { volt = "1"; }
                else
                {
                    if (Convert.ToDouble(tbVolts.Text) < 300) { volt = "2"; }
                    else
                    {
                        if (Convert.ToDouble(tbVolts.Text) < 400) { volt = "3"; }
                        else
                        {
                            if (Convert.ToDouble(tbVolts.Text) < 500) { volt = "4"; }
                            else
                            {
                                if (Convert.ToDouble(tbVolts.Text) < 600) { volt = "5"; }
                                else
                                {
                                    if (Convert.ToDouble(tbVolts.Text) < 700) { volt = "6"; }
                                }
                            }
                        }
                    }
                }
            }

            watt = (Math.Round(Convert.ToDouble(tbWatts.Text) / 100d) * 100).ToString();

            tbQB.Text = tbPN.Text + "-" + watt + "-" + volt + "-01";

            switch (vari.RQD.Tables[0].Rows[0][12].ToString())
            {
                case "1":
                    tbG1.IsEnabled = IsEnabled;
                    tbG2.IsEnabled = false;
                    tbG3.IsEnabled = false;
                    tbG4.IsEnabled = false;
                    break;
                case "2":
                    tbG1.IsEnabled = IsEnabled;
                    tbG2.IsEnabled = IsEnabled;
                    tbG3.IsEnabled = false;
                    tbG4.IsEnabled = false;
                    break;
                case "3":
                    tbG1.IsEnabled = IsEnabled;
                    tbG2.IsEnabled = IsEnabled;
                    tbG3.IsEnabled = IsEnabled;
                    tbG4.IsEnabled = false;
                    break;
                case "4":
                    tbG1.IsEnabled = IsEnabled;
                    tbG2.IsEnabled = IsEnabled;
                    tbG3.IsEnabled = IsEnabled;
                    tbG4.IsEnabled = IsEnabled;
                    break;
            }
        }

        private void CustomerDetails()
        {
            // SET THE DATABASE CONNECTION VARS
            string file = vari.DefaultDirectory + "Customers.accdb"; string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source =" + file + ";";
            // Attempt to connect to the database
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand();
                OComm.Connection = connection1;
                try
                {
                    connection1.Open();
                    // Query the database to find all entries without a FINISH TIME
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT * FROM CustomerList WHERE CustName = '" + tbCust.Text + "';", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "*");

                    //Standard) EZ Heat, EZ Number, W/V/D
                    //No EZ Heat, EZ Number, W/V/D
                    //Customer Name, EZ Number, W/V/D
                    //Customer Name, Customer Number, W/V/D
                    //No EZ Heat, Customer Number, W/V/D

                    //DataSet.Tables[0].Rows[0][11].ToString()

                    cmbStamp.Text = DataSet.Tables[0].Rows[0][11].ToString();

                    Stamp(DataSet.Tables[0].Rows[0][11].ToString());
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

        private void Stamp(string value)
        {
            if (value == null)
            {
                tbS1.Text = "EZ HEAT";
                tbS2.Text = tbBH.Text;
                tbS3.Text = tbWatts.Text + " " + tbVolts.Text + " DATE";
            }
            if (value == "(Standard) EZ Heat, EZ Number, W/V/D")
            {
                tbS1.Text = "EZ HEAT";
                tbS2.Text = tbBH.Text;
                tbS3.Text = tbWatts.Text + "W " + tbVolts.Text + "V DATE";
            }
            if (value == "No EZ Heat, EZ Number, W/V/D")
            {
                tbS1.Text = "NO EZ HEAT!";
                tbS2.Text = tbBH.Text;
                tbS3.Text = tbWatts.Text + "W " + tbVolts.Text + "V DATE";
            }
            if (value == "Customer Name, EZ Number, W/V/D")
            {
                tbS1.Text = tbCust.Text;
                tbS2.Text = tbBH.Text;
                tbS3.Text = tbWatts.Text + "W " + tbVolts.Text + "V DATE";
            }
            if (value == "Customer Name, Customer Number, W/V/D")
            {
                tbS1.Text = tbCust.Text;
                tbS2.Text = tbCustPN.Text;
                tbS3.Text = tbWatts.Text + "W " + tbVolts.Text + "V DATE";
            }
            if (value == "No EZ Heat, Customer Number, W/V/D")
            {
                tbS1.Text = "NO EZ HEAT!";
                tbS2.Text = tbCustPN.Text;
                tbS3.Text = tbWatts.Text + "W " + tbVolts.Text + "V DATE";
            }
        }
        

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveQuote_Click(object sender, RoutedEventArgs e)
        {
            FinalCheck();
        }

        private void FinalCheck()
        {
        //CHECK FOR STAMPING STYLE
            if (cmbStamp.SelectedItem == null)
            {
                MessageBox.Show("Please select a stamping style");
                return;
            }
        //CHECK THAT THE CHOSEN FILE NUMBER DOES NOT EXIST
            string file = vari.DefaultDirectory + "Lists.accdb"; string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source =" + file + ";";
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand(); OComm.Connection = connection1;
                try
                {
                    connection1.Open();
                    // Query the database to find all entries without a FINISH TIME
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT count(*) FROM BHList WHERE file = '" + tbBH.Text + "';", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "*");

                    if (Convert.ToInt16(DataSet.Tables[0].Rows[0][0]) > 0)
                    {
                        MessageBox.Show("There's already a record of the part number that you've selected. Please change the part number and try saving the record again.");
                        return;
                    }
                    //CALL WRITE FUNCTION
                    PartWriter();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); } finally { connection1.Close(); }
                OleDbCommand Write = new OleDbCommand(); Write.Connection = connection1;
            }
            //vari.filenumber = tbQB_Copy.Text;
            this.Close();
        }


//WRITE A FRESH RECORD
        private void PartWriter()
        {
            string file = vari.DefaultDirectory + "Lists.accdb"; string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source =" + file + ";";
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand(); OComm.Connection = connection1;
                try
                {
                    connection1.Open();
                    string CmdLine1 = "INSERT INTO BHList (" +
                        "file, cust, pn, qbpn, notes, custpn, seg, locku, dia, wid, termstyle, watts, volts, leads, leadcov, dte, ezleg, gap, qby, base, suffix, g1, g2, g3, g4, termloc, " +
                        "termdet, wiring, constr, holes, notches, dsc, ad1, ad2, ad3, ad4, ad5, ad6, stmp1, stmp2, stmp3, stmp4, quoterefid, qbdesc, stampoverride) " +
                        "VALUES (" +
                        "'" + tbBH.Text + "', " +
                        "'" + tbCust.Text + "', " +
                        "'" + tbPN.Text + "', " +
                        "'" + tbQB.Text + "', " +
                        "'" + tbNotes.Text + "', " +
                        "'" + tbCustPN.Text + "', " +
                        "'" + tbSeg.Text + "', " +
                        "'" + tbLock.Text + "', " +
                        tbDia.Text + ", " + //number
                        tbWid.Text + ", " + //number
                        "'" + tbTerm.Text + "', " +
                        tbWatts.Text + ", " + //number
                        tbVolts.Text + ", " + //number
                        tbLeads.Text + ", " + //number
                        "'" + tbLeadcov.Text + "', " +
                        "'" + tbDate.Text + "', " +
                        "'" + "" + "', " +
                        "'" + "" + "', " +
                        "'" + "" + "', " +
                        "'" + tbBHBase.Text + "', " +
                        "'" + tbBHSuffix.Text + "', " +
                        "'" + tbG1.Text + "', " +
                        "'" + tbG2.Text + "', " +
                        "'" + tbG3.Text + "', " +
                        "'" + tbG4.Text + "', " +
                        "'" + cmbTermLoc.SelectedItem.ToString() + "', " +
                        "'" + tbTermLoc.Text + "', " +
                        "'" + cmbWiring.SelectedItem.ToString() + "', " +
                        "'" + cmbConstr.SelectedItem.ToString() + "', " +
                        "'" + tbHoles.Text + "', " +
                        "'" + tbNotches.Text + "', " +
                        "'" + tbDesc.Text + "', " +
                        "'" + "" + "', " +
                        "'" + "" + "', " +
                        "'" + "" + "', " +
                        "'" + "" + "', " +
                        "'" + "" + "', " +
                        "'" + "" + "', " +
                        "'" + tbS1.Text + "', " +
                        "'" + tbS2.Text + "', " +
                        "'" + tbS3.Text + "', " +
                        "'" + tbS4.Text + "', " +
                        "'" + tbID.Text + "', " +
                        "'" + "" + "', " +
                        "'" + cmbStamp.SelectedItem.ToString() + "'" +
                        ");";

                    //tbDesc.Text = CmdLine1;
                    OleDbCommand Insert1 = new OleDbCommand(CmdLine1, connection1);
                    Insert1.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { connection1.Close(); }
                OleDbCommand Write = new OleDbCommand(); Write.Connection = connection1;
            }
            //this.Close();
        }


                        





    private void btnBH_Click(object sender, RoutedEventArgs e)
        {
            NumberGen NG = new NumberGen();
            NG.Show();
        }

        private void cmbStamp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Stamp(cmbStamp.SelectedItem.ToString());
        }

        private void tbBH_TextChanged(object sender, TextChangedEventArgs e)
        {
            Stamp(cmbStamp.SelectedItem.ToString());
            //Break down BH Number for individual DB columns
            if (tbBH.Text == "")
            { return; }
            else
            {
                string BH = tbBH.Text;
                string b = "";
                string s = "";
                int l = BH.Length;
                if (l < 9 || l > 10 ) { return; }
                if (l == 9)
                {
                    b = BH.Substring(2, 4);
                    s = BH.Substring(7, 2);
                }
                else
                {
                    b = BH.Substring(2, 5);
                    s = BH.Substring(8, 2);
                }
                tbBHBase.Text = b;
                tbBHSuffix.Text = s;
            }
        }

        private void tbCustPN_TextChanged(object sender, TextChangedEventArgs e)
        {
            Stamp(cmbStamp.SelectedItem.ToString());
        }

        private void cmbConstr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbConstr.SelectedItem.ToString() == "Reverse Construction")
            {
                tbSeg.Text = "R";
            } else
            {
                tbSeg.Text = vari.RQD.Tables[0].Rows[0][12].ToString();
            }
        }
    }
}
