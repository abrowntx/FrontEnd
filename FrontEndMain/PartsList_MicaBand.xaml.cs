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
    /// Interaction logic for PartsList_MicaBand.xaml
    /// </summary>
    public partial class PartsList_MicaBand : Window
    {

        public PartsList_MicaBand()
        {
            InitializeComponent();

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

            Startup();
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

        //GENERAL STARTUP FORM FIELD POPULATION
        private void Startup()
        {
            //Watts and volts populate first to properly concatenate stamp lines
            tbWatts.Text = vari.RQD.Tables[0].Rows[0][12].ToString();
            tbVolts.Text = vari.RQD.Tables[0].Rows[0][13].ToString();
            //Check the stamp settings from the file
            checkStamp();
            //Start populating the rest of the form fields
            tbID.Text = vari.RQD.Tables[0].Rows[0][0].ToString();
            tbCust.Text = vari.RQD.Tables[0].Rows[0][2].ToString();
            tbDate.Text = vari.RQD.Tables[0].Rows[0][16].ToString();
            tbPN.Text = vari.RQD.Tables[0].Rows[0][3].ToString();
            tbCustPN.Text = vari.RQD.Tables[0].Rows[0][6].ToString();
            tbBH.Text = vari.RQD.Tables[0].Rows[0][1].ToString();
            tbSeg.Text = vari.RQD.Tables[0].Rows[0][7].ToString();
            tbLock.Text = vari.RQD.Tables[0].Rows[0][8].ToString();
            tbDia.Text = vari.RQD.Tables[0].Rows[0][9].ToString();
            tbWid.Text = vari.RQD.Tables[0].Rows[0][10].ToString();
            tbTerm.Text = vari.RQD.Tables[0].Rows[0][11].ToString();
            tbLeads.Text = vari.RQD.Tables[0].Rows[0][14].ToString();
            tbLeadcov.Text = vari.RQD.Tables[0].Rows[0][15].ToString();
            tbTermLoc.Text = vari.RQD.Tables[0].Rows[0][27].ToString();
            cmbTermLoc.Text = vari.RQD.Tables[0].Rows[0][26].ToString();
            tbNotes.Text = vari.RQD.Tables[0].Rows[0][5].ToString();
            tbDesc.Text = vari.RQD.Tables[0].Rows[0][44].ToString();

            if (vari.RQD.Tables[0].Rows[0][26].ToString() == "Standard")
            {
                cmbTermLoc.SelectedIndex = 0;
            }
            else
            {
                cmbTermLoc.SelectedIndex = 1;
            }

            tbHoles.Text = vari.RQD.Tables[0].Rows[0][30].ToString();
            tbNotches.Text = vari.RQD.Tables[0].Rows[0][31].ToString();

            lbAdders.Items.Add(vari.RQD.Tables[0].Rows[0][33].ToString());
            lbAdders.Items.Add(vari.RQD.Tables[0].Rows[0][34].ToString());
            lbAdders.Items.Add(vari.RQD.Tables[0].Rows[0][35].ToString());
            lbAdders.Items.Add(vari.RQD.Tables[0].Rows[0][36].ToString());
            lbAdders.Items.Add(vari.RQD.Tables[0].Rows[0][37].ToString());
            lbAdders.Items.Add(vari.RQD.Tables[0].Rows[0][38].ToString());
            tbQB.Text = vari.RQD.Tables[0].Rows[0][4].ToString();

            switch (vari.RQD.Tables[0].Rows[0][7].ToString())
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


        //MODIFY STAMP DETAILS BASED ON USER INPUT
        private void Stamp(string value)
        {
            string cust = tbCust.Text.ToUpper();

            if (value == null || value == "")
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
                tbS1.Text = cust;
                tbS2.Text = tbBH.Text;
                tbS3.Text = tbWatts.Text + "W " + tbVolts.Text + "V DATE";
            }
            if (value == "Customer Name, Customer Number, W/V/D")
            {
                tbS1.Text = cust;
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

        private void stampSwitch()
        {

        }

//QUERY CUSTOMER STAMP
        private void checkStamp()
        {
            int i = 0;
            string s = "";
            for (i = 0; i < vari.RQD.Tables[0].Columns.Count; i++)
            {
                s = s + " - [" + vari.RQD.Tables[0].Rows[0][i].ToString() + "]";
            }
            cmbStamp.Text = vari.RQD.Tables[0].Rows[0][46].ToString();

            if (vari.RQD.Tables[0].Rows[0][46].ToString() == "")
            {
                cmbStamp.SelectedIndex = 0;
            } else
            {
                // SET THE DATABASE CONNECTION VARS
                string file = vari.DefaultDirectory + "Customers.accdb"; string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source =" + file + ";";
                using (var connection1 = new OleDbConnection(ConnectionString))
                {
                    OleDbCommand OComm = new OleDbCommand(); OComm.Connection = connection1;
                    try
                    {
                        connection1.Open();
                        // Query the database to find all entries without a FINISH TIME
                        OleDbDataAdapter DA = new OleDbDataAdapter("SELECT * from CustomerList WHERE CustName = '" + vari.RQD.Tables[0].Rows[0][2].ToString() + "';", connection1);
                        var DataSet = new DataSet();
                        DA.Fill(DataSet, "*");
                        if (DataSet.Tables[0].Rows.Count > 0)
                        {
                            if (DataSet.Tables[0].Rows[0][11].ToString() == "(Standard) EZ Heat, EZ Number, W/V/D")
                            { cmbStamp.SelectedIndex = 0; }
                            if (DataSet.Tables[0].Rows[0][11].ToString() == "No EZ Heat, EZ Number, W/V/D")
                            { cmbStamp.SelectedIndex = 1; }
                            if (DataSet.Tables[0].Rows[0][11].ToString() == "Customer Name, EZ Number, W/V/D")
                            { cmbStamp.SelectedIndex = 2; }
                            if (DataSet.Tables[0].Rows[0][11].ToString() == "Customer Name, Customer Number, W/V/D")
                            { cmbStamp.SelectedIndex = 3; }
                            if (DataSet.Tables[0].Rows[0][11].ToString() == "No EZ Heat, Customer Number, W/V/D")
                            { cmbStamp.SelectedIndex = 4; }
                        }
                        else
                        {
                            cmbStamp.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    finally { connection1.Close(); }
                }
            }
        }

        //CHECK FOR EXISTING FILE NUMBER
        private void fileNumberCHeck()
        {
            // SET THE DATABASE CONNECTION VARS
            string file = vari.DefaultDirectory + "Lists.accdb"; string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source =" + file + ";";
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand(); OComm.Connection = connection1;
                try
                {
                    connection1.Open();
                    // Query the database to find all entries without a FINISH TIME
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT * from BHList WHERE file = '" + tbBH.Text + "';", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "*");

                    if (DataSet.Tables[0].Rows.Count > 0)
                    {
                        string sMessageBoxText = "Part Exists. Would you like to overwrite the existing part with these details? This operation cannot be undone!";
                        string sCaption = "Part Exists";

                        MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                        MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                        MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
                        switch (rsltMessageBox)
                        {
                            case MessageBoxResult.Yes:
                                PartUpdater(); break;
                            case MessageBoxResult.No:
                                break;
                            case MessageBoxResult.Cancel:
                                break;
                        }
                    }
                    else
                    {
                        string sMessageBoxText = "Part Doesn't Exist. Would you like to create a new part number with these details?";
                        string sCaption = "Part Doesn't Exist";

                        MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                        MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                        MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
                        switch (rsltMessageBox)
                        {
                            case MessageBoxResult.Yes:
                                PartWriter(); break;
                            case MessageBoxResult.No:
                                break;
                            case MessageBoxResult.Cancel:
                                break;
                        }
                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { connection1.Close(); }
            }
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

        //WRITE A FRESH RECORD
        private void PartUpdater()
        {
            string file = vari.DefaultDirectory + "Lists.accdb"; string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source =" + file + ";";
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand(); OComm.Connection = connection1;
                try
                {
                    connection1.Open();
                    string CmdLine1 = "UPDATE BHList SET " +
                        "file='" + tbBH.Text + "'," +
                        "cust='" + tbCust.Text + "', " +
                        "pn='" + tbPN.Text + "', " +
                        "qbpn='" + tbQB.Text + "', " +
                        "notes='" + tbNotes.Text + "', " +
                        "custpn='" + tbCustPN.Text + "', " +
                        "seg='" + tbSeg.Text + "', " +
                        "locku='" + tbLock.Text + "', " +
                        "dia=" + tbDia.Text + ", " + //number
                        "wid=" + tbWid.Text + ", " + //number
                        "termstyle='" + tbTerm.Text + "', " +
                        "watts=" + tbWatts.Text + ", " + //number
                        "volts=" + tbVolts.Text + ", " + //number
                        "leads=" + tbLeads.Text + ", " + //number
                        "leadcov='" + tbLeadcov.Text + "', " +
                        "dte='" + tbDate.Text + "', " +
                        "ezleg='" + "" + "', " +
                        "gap='" + "" + "', " +
                        "qby='" + "" + "', " +
                        "base='" + tbBHBase.Text + "', " +
                        "suffix='" + tbBHSuffix.Text + "', " +
                        "g1='" + tbG1.Text + "', " +
                        "g2='" + tbG2.Text + "', " +
                        "g3='" + tbG3.Text + "', " +
                        "g4='" + tbG4.Text + "', " +
                        "termloc='" + cmbTermLoc.SelectedItem.ToString() + "', " +
                        "termdet='" + tbTermLoc.Text + "', " +
                        "wiring='" + cmbWiring.SelectedItem.ToString() + "', " +
                        "constr='" + cmbConstr.SelectedItem.ToString() + "', " +
                        "holes='" + tbHoles.Text + "', " +
                        "notches='" + tbNotches.Text + "', " +
                        "dsc='" + tbDesc.Text + "', " +
                        "ad1='" + "" + "', " +
                        "ad2='" + "" + "', " +
                        "ad3='" + "" + "', " +
                        "ad4='" + "" + "', " +
                        "ad5='" + "" + "', " +
                        "ad6='" + "" + "', " +
                        "stmp1='" + tbS1.Text + "', " +
                        "stmp2='" + tbS2.Text + "', " +
                        "stmp3='" + tbS3.Text + "', " +
                        "stmp4='" + tbS4.Text + "', " +
                        "quoterefid='" + tbID.Text + "', " +
                        "qbdesc='" + tbDesc.Text + "'," +
                        "stampoverride='" + cmbStamp.SelectedItem.ToString() + "' WHERE file='" + tbBH.Text + "';";
                       

                    //tbDesc.Text = CmdLine1;return;
                    OleDbCommand Insert1 = new OleDbCommand(CmdLine1, connection1);
                    Insert1.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { connection1.Close(); }
                OleDbCommand Write = new OleDbCommand(); Write.Connection = connection1;
            }
            //this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveQuote_Click(object sender, RoutedEventArgs e)
        {
            fileNumberCHeck();
        }

        private void tbCustPN_TextChanged(object sender, TextChangedEventArgs e)
        {
            string st = "(Standard) EZ Heat, EZ Number, W/V/D";
            if (cmbStamp.SelectedItem == null) { st = "(Standard) EZ Heat, EZ Number, W/V/D"; } else { st = cmbStamp.SelectedItem.ToString(); }
            Stamp(st);
        }

        private void cmbStamp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string st = "(Standard) EZ Heat, EZ Number, W/V/D";
            if (cmbStamp.SelectedItem == null) { st = "(Standard) EZ Heat, EZ Number, W/V/D"; } else { st = cmbStamp.SelectedItem.ToString(); }
            Stamp(st);
        }

        private void tbBH_TextChanged(object sender, TextChangedEventArgs e)
        {
            string st = "(Standard) EZ Heat, EZ Number, W/V/D";
            if (cmbStamp.SelectedItem == null || cmbStamp.SelectedItem.ToString() == "") { st = "(Standard) EZ Heat, EZ Number, W/V/D"; } else { st = cmbStamp.SelectedItem.ToString(); }
            Stamp(st);
            //Break down BH Number for individual DB columns
            if (tbBH.Text == "")
            { return; }
            else
            {
                string BH = tbBH.Text;
                string b = "";
                string s = "";
                int l = BH.Length;
                if (l < 9 || l > 10) { return; }
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

        private void cmbConstr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbConstr.SelectedItem.ToString() == "Reverse Construction")
            {
                tbSeg.Text = "R";
            }
            else
            {
                tbSeg.Text = vari.RQD.Tables[0].Rows[0][7].ToString();
            }
        }
    }
}
