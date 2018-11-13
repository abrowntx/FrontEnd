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
    /// Interaction logic for RecallQuote.xaml
    /// </summary>
    public partial class RecallQuote : Window
    {
        public RecallQuote()
        {
            InitializeComponent();

            //populate dropdown
            QueryDepartments();
            QueryCustList();
            lbCust.IsEnabled = false;


            tbParam1.Visibility = System.Windows.Visibility.Hidden;
            tbParam2.Visibility = System.Windows.Visibility.Hidden;
            tbParam3.Visibility = System.Windows.Visibility.Hidden;
            tbParam4.Visibility = System.Windows.Visibility.Hidden;
            tbParam5.Visibility = System.Windows.Visibility.Hidden;
            tbParam6.Visibility = System.Windows.Visibility.Hidden;
            tbParam7.Visibility = System.Windows.Visibility.Hidden;
            tbParam8.Visibility = System.Windows.Visibility.Hidden;
            tbParam9.Visibility = System.Windows.Visibility.Hidden;
            tbParam10.Visibility = System.Windows.Visibility.Hidden;

            //labels
            lPN.Visibility = System.Windows.Visibility.Hidden;
            lS.Visibility = System.Windows.Visibility.Hidden;
            lC.Visibility = System.Windows.Visibility.Hidden;
            lD.Visibility = System.Windows.Visibility.Hidden;
            lSN.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                uie.MoveFocus(
                new TraversalRequest(
                FocusNavigationDirection.Next));
            }
        }

        private void QueryDepartments()
        {
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
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT ID,Dep FROM Dep;", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "*");
                    // Set the dataset from OleDBAdapter to the item source of the data grid object
                    cmbDep.DataContext = this;
                    cmbDep.ItemsSource = DataSet.Tables[0].DefaultView;
                    cmbDep.DisplayMemberPath = DataSet.Tables[0].Columns["Dep"].ToString();
                    cmbDep.SelectedValuePath = DataSet.Tables[0].Columns["ID"].ToString();

                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

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

        private void cmbDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Dep = Convert.ToInt16(cmbDep.SelectedValue);
            //SET NAME VARIABLE TO THE SELECTED DEPARTMENT
            if (Dep == 1)
            {
                vari.rDep = "MicaQuotes";
                vari.rTempStr = ",seg as 1,locku as 2,dia as 3,wid as 4,watts as 5,volts as 6,termstyle as 7";

                databindings.param1 A = new databindings.param1(); { A.lParam1 = "lockup"; } this.lParam1.DataContext = A;
                tbParam1.Visibility = System.Windows.Visibility.Visible;
                databindings.param2 B = new databindings.param2(); { B.lParam2 = "segments"; } this.lParam2.DataContext = B;
                tbParam2.Visibility = System.Windows.Visibility.Visible;
                databindings.param3 C = new databindings.param3(); { C.lParam3 = "diameter"; } this.lParam3.DataContext = C;
                tbParam3.Visibility = System.Windows.Visibility.Visible;
                databindings.param4 D = new databindings.param4(); { D.lParam4 = "width"; } this.lParam4.DataContext = D;
                tbParam4.Visibility = System.Windows.Visibility.Visible;
                databindings.param5 E = new databindings.param5(); { E.lParam5 = "watts"; } this.lParam5.DataContext = E;
                tbParam5.Visibility = System.Windows.Visibility.Visible;
                databindings.param6 F = new databindings.param6(); { F.lParam6 = "volts"; } this.lParam6.DataContext = F;
                tbParam6.Visibility = System.Windows.Visibility.Visible;
                databindings.param7 G = new databindings.param7(); { G.lParam7 = "termination"; } this.lParam7.DataContext = G;
                tbParam7.Visibility = System.Windows.Visibility.Visible;
                databindings.param8 H = new databindings.param8(); { H.lParam8 = "filename"; } this.lParam8.DataContext = H;
                tbParam8.Visibility = System.Windows.Visibility.Visible;
                databindings.param9 I = new databindings.param9(); { I.lParam9 = ""; } this.lParam9.DataContext = I;
                tbParam9.Visibility = System.Windows.Visibility.Hidden;
                databindings.param10 J = new databindings.param10(); { J.lParam10 = ""; } this.lParam10.DataContext = J;
                tbParam10.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                if (Dep == 2)
                {
                    vari.rDep = "FlatQuotes";
                    vari.rTempStr = ",locku as 1,seg as 2,width as 3,length as 4,height as 5,watts as 6,volts as 7,termstyle as 8";

                    databindings.param1 A = new databindings.param1(); { A.lParam1 = "segments"; } this.lParam1.DataContext = A;
                    tbParam1.Visibility = System.Windows.Visibility.Visible;
                    databindings.param2 B = new databindings.param2(); { B.lParam2 = "width"; } this.lParam2.DataContext = B;
                    tbParam2.Visibility = System.Windows.Visibility.Visible;
                    databindings.param3 C = new databindings.param3(); { C.lParam3 = "length"; } this.lParam3.DataContext = C;
                    tbParam3.Visibility = System.Windows.Visibility.Visible;
                    databindings.param4 D = new databindings.param4(); { D.lParam4 = "height"; } this.lParam4.DataContext = D;
                    tbParam4.Visibility = System.Windows.Visibility.Visible;
                    databindings.param5 E = new databindings.param5(); { E.lParam5 = "watts"; } this.lParam5.DataContext = E;
                    tbParam5.Visibility = System.Windows.Visibility.Visible;
                    databindings.param6 F = new databindings.param6(); { F.lParam6 = "volts"; } this.lParam6.DataContext = F;
                    tbParam6.Visibility = System.Windows.Visibility.Visible;
                    databindings.param7 G = new databindings.param7(); { G.lParam7 = "termination"; } this.lParam7.DataContext = G;
                    tbParam7.Visibility = System.Windows.Visibility.Visible;
                    databindings.param8 H = new databindings.param8(); { H.lParam8 = "filename"; } this.lParam8.DataContext = H;
                    tbParam8.Visibility = System.Windows.Visibility.Visible;
                    databindings.param9 I = new databindings.param9(); { I.lParam9 = ""; } this.lParam9.DataContext = I;
                    tbParam9.Visibility = System.Windows.Visibility.Hidden;
                    databindings.param10 J = new databindings.param10(); { J.lParam10 = ""; } this.lParam10.DataContext = J;
                    tbParam10.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                {
                    if (Dep == 3)
                    {
                        vari.rDep = "CartQuotes";
                        vari.rTempStr = ",dia as 1,length as 2,termstyle as 3,watts as 4,volts as 5";

                        databindings.param1 A = new databindings.param1(); { A.lParam1 = "diameter"; } this.lParam1.DataContext = A;
                        tbParam1.Visibility = System.Windows.Visibility.Visible;
                        databindings.param2 B = new databindings.param2(); { B.lParam2 = "length"; } this.lParam2.DataContext = B;
                        tbParam2.Visibility = System.Windows.Visibility.Visible;
                        databindings.param3 C = new databindings.param3(); { C.lParam3 = "watts"; } this.lParam3.DataContext = C;
                        tbParam3.Visibility = System.Windows.Visibility.Visible;
                        databindings.param4 D = new databindings.param4(); { D.lParam4 = "volts"; } this.lParam4.DataContext = D;
                        tbParam4.Visibility = System.Windows.Visibility.Visible;
                        databindings.param5 E = new databindings.param5(); { E.lParam5 = "term"; } this.lParam5.DataContext = E;
                        tbParam5.Visibility = System.Windows.Visibility.Visible;
                        databindings.param6 F = new databindings.param6(); { F.lParam6 = "filename"; } this.lParam6.DataContext = F;
                        tbParam6.Visibility = System.Windows.Visibility.Visible;
                        databindings.param7 G = new databindings.param7(); { G.lParam7 = ""; } this.lParam7.DataContext = G;
                        tbParam7.Visibility = System.Windows.Visibility.Hidden;
                        databindings.param8 H = new databindings.param8(); { H.lParam8 = ""; } this.lParam8.DataContext = H;
                        tbParam8.Visibility = System.Windows.Visibility.Hidden;
                        databindings.param9 I = new databindings.param9(); { I.lParam9 = ""; } this.lParam9.DataContext = I;
                        tbParam9.Visibility = System.Windows.Visibility.Hidden;
                        databindings.param10 J = new databindings.param10(); { J.lParam10 = ""; } this.lParam10.DataContext = J;
                        tbParam10.Visibility = System.Windows.Visibility.Hidden;
                    }
                    else
                    {
                        if (Dep == 4)
                        {
                            vari.rDep = "CerQuotes";
                            vari.rTempStr = ",seg as 1,locku as 2,dia as 3,wid as 4,watts as 5,volts as 6,termstyle as 7";

                            databindings.param1 A = new databindings.param1(); { A.lParam1 = "lockup"; } this.lParam1.DataContext = A;
                            tbParam1.Visibility = System.Windows.Visibility.Visible;
                            databindings.param2 B = new databindings.param2(); { B.lParam2 = "segments"; } this.lParam2.DataContext = B;
                            tbParam2.Visibility = System.Windows.Visibility.Visible;
                            databindings.param3 C = new databindings.param3(); { C.lParam3 = "diameter"; } this.lParam3.DataContext = C;
                            tbParam3.Visibility = System.Windows.Visibility.Visible;
                            databindings.param4 D = new databindings.param4(); { D.lParam4 = "width"; } this.lParam4.DataContext = D;
                            tbParam4.Visibility = System.Windows.Visibility.Visible;
                            databindings.param5 E = new databindings.param5(); { E.lParam5 = "watts"; } this.lParam5.DataContext = E;
                            tbParam5.Visibility = System.Windows.Visibility.Visible;
                            databindings.param6 F = new databindings.param6(); { F.lParam6 = "volts"; } this.lParam6.DataContext = F;
                            tbParam6.Visibility = System.Windows.Visibility.Visible;
                            databindings.param7 G = new databindings.param7(); { G.lParam7 = "termination"; } this.lParam7.DataContext = G;
                            tbParam7.Visibility = System.Windows.Visibility.Visible;
                            databindings.param8 H = new databindings.param8(); { H.lParam8 = "filename"; } this.lParam8.DataContext = H;
                            tbParam8.Visibility = System.Windows.Visibility.Visible;
                            databindings.param9 I = new databindings.param9(); { I.lParam9 = ""; } this.lParam9.DataContext = I;
                            tbParam9.Visibility = System.Windows.Visibility.Hidden;
                            databindings.param10 J = new databindings.param10(); { J.lParam10 = ""; } this.lParam10.DataContext = J;
                            tbParam10.Visibility = System.Windows.Visibility.Hidden;
                        }
                        else
                        {
                            if (Dep == 5) { vari.rDep = "MiscQuotes"; vari.rTempStr = ""; }
                        }
                    }
                }
            }
            Clear();
            QueryDetails();
            lbCust.IsEnabled = true;
        }

        private void QueryDetails()
        {
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
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT ID,Cust,dte,filename,pn" + vari.rTempStr + " FROM " + vari.rDep + vari.rTempCust + ";", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "*");
                    // Set the dataset from OleDBAdapter to the item source of the data grid object
                    lbQuotes.DataContext = DataSet.Tables[0];
                    lbQuotes.ItemsSource = DataSet.Tables[0].DefaultView;

                    ICollectionView dataView = CollectionViewSource.GetDefaultView(lbQuotes.ItemsSource);
                    dataView.SortDescriptions.Clear();
                    dataView.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Descending));
                    dataView.Refresh();

                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

        private void QueryMicaQuote()
        {
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
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT ID,Cust,dte,q1,q2,q3,q4,p1,p2,p3,p4,seg,locku,dia,wid,watts,volts,termstyle,leadlen,leadcov,termloc,termdetail,holes,cutouts,multi,notes,smt,adder,filename,pn,ad1,ad2,ad3,ad4,ad5,ad6,descr,termloc,termdetail,holes,cutouts FROM MicaQuotes WHERE ID = " + vari.rQuoteID + ";", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "*");

                    lPN.Visibility = System.Windows.Visibility.Visible;
                    lS.Visibility = System.Windows.Visibility.Visible;
                    lC.Visibility = System.Windows.Visibility.Visible;
                    lD.Visibility = System.Windows.Visibility.Visible;
                    lSN.Visibility = System.Windows.Visibility.Visible;

                    vari.rQD = new string[DataSet.Tables[0].Columns.Count];
                    //vari.rQD[0] = DataSet.Tables[0].Rows[0][0].ToString();

                    for (int col = 0; col < DataSet.Tables[0].Columns.Count; col++)
                    {
                        vari.rQD[col] = DataSet.Tables[0].Rows[0][col].ToString();
                    }

                    databindings.Cust A = new databindings.Cust(); { A.lCust = DataSet.Tables[0].Rows[0][1].ToString(); } this.lCust.DataContext = A;
                    databindings.Date B = new databindings.Date(); { B.lDate = DataSet.Tables[0].Rows[0][2].ToString(); } this.lDate.DataContext = B;
                    databindings.PartNumb C = new databindings.PartNumb(); { C.lPartNumb = DataSet.Tables[0].Rows[0][29].ToString(); } this.lPartNumb.DataContext = C;
                    databindings.P1 D = new databindings.P1(); { D.lp1 = DataSet.Tables[0].Rows[0][11].ToString(); } this.lP1.DataContext = D;
                    databindings.P2 E = new databindings.P2(); { E.lp2 = string.Format("{0:0.00}", DataSet.Tables[0].Rows[0][13]); } this.lP2.DataContext = E;
                    databindings.P3 F = new databindings.P3(); { F.lp3 = string.Format("{0:0.00}", DataSet.Tables[0].Rows[0][14]); } this.lP3.DataContext = F;
                    databindings.P4 G = new databindings.P4(); { G.lp4 = DataSet.Tables[0].Rows[0][12].ToString(); } this.lP4.DataContext = G;
                    databindings.Plab1 H = new databindings.Plab1(); { H.lPlab1 = "seg:"; } this.lPLab1.DataContext = H;
                    databindings.Plab2 I = new databindings.Plab2(); { I.lPlab2 = "dia:"; } this.lPLab2.DataContext = I;
                    databindings.Plab3 J = new databindings.Plab3(); { J.lPlab3 = "wid:"; } this.lPLab3.DataContext = J;
                    databindings.Plab4 K = new databindings.Plab4(); { K.lPlab4 = "lockup:"; } this.lPLab4.DataContext = K;
                    databindings.Watts L = new databindings.Watts(); { L.lWatts = string.Format("{0:00}", DataSet.Tables[0].Rows[0][15]); } this.lWatts.DataContext = L;
                    databindings.Volts M = new databindings.Volts(); { M.lVolts = string.Format("{0:00}", DataSet.Tables[0].Rows[0][16]); } this.lVolts.DataContext = M;
                    databindings.Term N = new databindings.Term(); { N.lTerm = DataSet.Tables[0].Rows[0][17].ToString(); } this.lTerm.DataContext = N;
                    databindings.laWatts O = new databindings.laWatts(); { O.labWatts = "watts:"; } this.labWatts.DataContext = O;
                    databindings.laVolts P = new databindings.laVolts(); { P.labVolts = "volts:"; } this.labVolts.DataContext = P;
                    databindings.laTerm Q = new databindings.laTerm(); { Q.labTerm = "term style:"; } this.labTerm.DataContext = Q;
                    databindings.Notes R = new databindings.Notes(); { R.lNotes = DataSet.Tables[0].Rows[0][25].ToString(); } this.lNotes.DataContext = R;
                    databindings.rP1 S = new databindings.rP1(); { S.lPr1 = string.Format("{0:c2}", DataSet.Tables[0].Rows[0][7]); } this.lPr1.DataContext = S;
                    databindings.rP2 T = new databindings.rP2(); { T.lPr2 = string.Format("{0:c2}", DataSet.Tables[0].Rows[0][8]); } this.lPr2.DataContext = T;
                    databindings.rP3 U = new databindings.rP3(); { U.lPr3 = string.Format("{0:c2}", DataSet.Tables[0].Rows[0][9]); } this.lPr3.DataContext = U;
                    databindings.rP4 V = new databindings.rP4(); { V.lPr4 = string.Format("{0:c2}", DataSet.Tables[0].Rows[0][10]); } this.lPr4.DataContext = V;
                    databindings.Q1 W = new databindings.Q1(); { W.lQ1 = DataSet.Tables[0].Rows[0][3].ToString(); } this.lQ1.DataContext = W;
                    databindings.Q2 X = new databindings.Q2(); { X.lQ2 = DataSet.Tables[0].Rows[0][4].ToString(); } this.lQ2.DataContext = X;
                    databindings.Q3 Y = new databindings.Q3(); { Y.lQ3 = DataSet.Tables[0].Rows[0][5].ToString(); } this.lQ3.DataContext = Y;
                    databindings.Q4 Z = new databindings.Q4(); { Z.lQ4 = DataSet.Tables[0].Rows[0][6].ToString(); } this.lQ4.DataContext = Z;

                    //MessageBox.Show(DataSet.Tables[0].Rows[0][1].ToString() + " | " + DataSet.Tables[0].Rows[0][29].ToString());
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

        private void QueryCartQuote()
        {
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
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT * FROM MicaQuotes WHERE ID = " + vari.rQuoteID + ";", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "*");

                    lPN.Visibility = System.Windows.Visibility.Visible;
                    lS.Visibility = System.Windows.Visibility.Visible;
                    lC.Visibility = System.Windows.Visibility.Visible;
                    lD.Visibility = System.Windows.Visibility.Visible;
                    lSN.Visibility = System.Windows.Visibility.Visible;

                    vari.rQD = new string[DataSet.Tables[0].Columns.Count];
                    //vari.rQD[0] = DataSet.Tables[0].Rows[0][0].ToString();

                    for (int col = 0; col < DataSet.Tables[0].Columns.Count; col++)
                    {
                        vari.rQD[col] = DataSet.Tables[0].Rows[0][col].ToString();
                    }

                    databindings.Cust A = new databindings.Cust(); { A.lCust = DataSet.Tables[0].Rows[0][1].ToString(); } this.lCust.DataContext = A;
                    databindings.Date B = new databindings.Date(); { B.lDate = DataSet.Tables[0].Rows[0][2].ToString(); } this.lDate.DataContext = B;
                    databindings.PartNumb C = new databindings.PartNumb(); { C.lPartNumb = DataSet.Tables[0].Rows[0][29].ToString(); } this.lPartNumb.DataContext = C;
                    databindings.P1 D = new databindings.P1(); { D.lp1 = DataSet.Tables[0].Rows[0][11].ToString(); } this.lP1.DataContext = D;
                    databindings.P2 E = new databindings.P2(); { E.lp2 = string.Format("{0:0.00}", DataSet.Tables[0].Rows[0][13]); } this.lP2.DataContext = E;
                    databindings.P3 F = new databindings.P3(); { F.lp3 = string.Format("{0:0.00}", DataSet.Tables[0].Rows[0][14]); } this.lP3.DataContext = F;
                    databindings.P4 G = new databindings.P4(); { G.lp4 = DataSet.Tables[0].Rows[0][12].ToString(); } this.lP4.DataContext = G;
                    databindings.Plab1 H = new databindings.Plab1(); { H.lPlab1 = "seg:"; } this.lPLab1.DataContext = H;
                    databindings.Plab2 I = new databindings.Plab2(); { I.lPlab2 = "dia:"; } this.lPLab2.DataContext = I;
                    databindings.Plab3 J = new databindings.Plab3(); { J.lPlab3 = "wid:"; } this.lPLab3.DataContext = J;
                    databindings.Plab4 K = new databindings.Plab4(); { K.lPlab4 = "lockup:"; } this.lPLab4.DataContext = K;
                    databindings.Watts L = new databindings.Watts(); { L.lWatts = string.Format("{0:00}", DataSet.Tables[0].Rows[0][15]); } this.lWatts.DataContext = L;
                    databindings.Volts M = new databindings.Volts(); { M.lVolts = string.Format("{0:00}", DataSet.Tables[0].Rows[0][16]); } this.lVolts.DataContext = M;
                    databindings.Term N = new databindings.Term(); { N.lTerm = DataSet.Tables[0].Rows[0][17].ToString(); } this.lTerm.DataContext = N;
                    databindings.laWatts O = new databindings.laWatts(); { O.labWatts = "watts:"; } this.labWatts.DataContext = O;
                    databindings.laVolts P = new databindings.laVolts(); { P.labVolts = "volts:"; } this.labVolts.DataContext = P;
                    databindings.laTerm Q = new databindings.laTerm(); { Q.labTerm = "term style:"; } this.labTerm.DataContext = Q;
                    databindings.Notes R = new databindings.Notes(); { R.lNotes = DataSet.Tables[0].Rows[0][25].ToString(); } this.lNotes.DataContext = R;
                    databindings.rP1 S = new databindings.rP1(); { S.lPr1 = string.Format("{0:c2}", DataSet.Tables[0].Rows[0][7]); } this.lPr1.DataContext = S;
                    databindings.rP2 T = new databindings.rP2(); { T.lPr2 = string.Format("{0:c2}", DataSet.Tables[0].Rows[0][8]); } this.lPr2.DataContext = T;
                    databindings.rP3 U = new databindings.rP3(); { U.lPr3 = string.Format("{0:c2}", DataSet.Tables[0].Rows[0][9]); } this.lPr3.DataContext = U;
                    databindings.rP4 V = new databindings.rP4(); { V.lPr4 = string.Format("{0:c2}", DataSet.Tables[0].Rows[0][10]); } this.lPr4.DataContext = V;
                    databindings.Q1 W = new databindings.Q1(); { W.lQ1 = DataSet.Tables[0].Rows[0][3].ToString(); } this.lQ1.DataContext = W;
                    databindings.Q2 X = new databindings.Q2(); { X.lQ2 = DataSet.Tables[0].Rows[0][4].ToString(); } this.lQ2.DataContext = X;
                    databindings.Q3 Y = new databindings.Q3(); { Y.lQ3 = DataSet.Tables[0].Rows[0][5].ToString(); } this.lQ3.DataContext = Y;
                    databindings.Q4 Z = new databindings.Q4(); { Z.lQ4 = DataSet.Tables[0].Rows[0][6].ToString(); } this.lQ4.DataContext = Z;

                    //MessageBox.Show(DataSet.Tables[0].Rows[0][1].ToString() + " | " + DataSet.Tables[0].Rows[0][29].ToString());
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

        private void lbCust_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbCust.SelectedIndex == -1)
            { }
            else
            {
                vari.rIndex = lbCust.Items.IndexOf(lbCust.SelectedItem);
                DataRowView drv = (DataRowView)lbCust.SelectedItem;
                vari.rSelect = drv[1].ToString();
                //CHECK IF INDEX SELECTED IS ZERO
                if (vari.rIndex < 0 || vari.rSelect == "")
                {
                    vari.rTempCust = "";
                    return;
                }
                vari.rTempCust = " WHERE Cust = '" + vari.rSelect + "'";
                lbQuotes.DataContext = null;
                lbQuotes.ItemsSource = null;
                QueryDetails();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            vari.rTempCust = "";
            //clear quote list
            lbQuotes.DataContext = null;
            lbQuotes.ItemsSource = null;

            lbCust.UnselectAll();

            if (cmbDep != null)
            {
                QueryDetails();
            }

            //HIDE LABELS
            lPN.Visibility = System.Windows.Visibility.Hidden;
            lS.Visibility = System.Windows.Visibility.Hidden;
            lC.Visibility = System.Windows.Visibility.Hidden;
            lD.Visibility = System.Windows.Visibility.Hidden;
            lSN.Visibility = System.Windows.Visibility.Hidden;

            //CLEAR DATABINDINGS
            databindings.Cust A = new databindings.Cust(); { A.lCust = ""; } this.lCust.DataContext = A;
            databindings.Date B = new databindings.Date(); { B.lDate = ""; } this.lDate.DataContext = B;
            databindings.PartNumb C = new databindings.PartNumb(); { C.lPartNumb = ""; } this.lPartNumb.DataContext = C;
            databindings.P1 D = new databindings.P1(); { D.lp1 = ""; } this.lP1.DataContext = D;
            databindings.P2 E = new databindings.P2(); { E.lp2 = ""; } this.lP2.DataContext = E;
            databindings.P3 F = new databindings.P3(); { F.lp3 = ""; } this.lP3.DataContext = F;
            databindings.P4 G = new databindings.P4(); { G.lp4 = ""; } this.lP4.DataContext = G;
            databindings.Plab1 H = new databindings.Plab1(); { H.lPlab1 = ""; } this.lPLab1.DataContext = H;
            databindings.Plab2 I = new databindings.Plab2(); { I.lPlab2 = ""; } this.lPLab2.DataContext = I;
            databindings.Plab3 J = new databindings.Plab3(); { J.lPlab3 = ""; } this.lPLab3.DataContext = J;
            databindings.Plab4 K = new databindings.Plab4(); { K.lPlab4 = ""; } this.lPLab4.DataContext = K;
            databindings.Watts L = new databindings.Watts(); { L.lWatts = ""; } this.lWatts.DataContext = L;
            databindings.Volts M = new databindings.Volts(); { M.lVolts = ""; } this.lVolts.DataContext = M;
            databindings.Term N = new databindings.Term(); { N.lTerm = ""; } this.lTerm.DataContext = N;
            databindings.laWatts O = new databindings.laWatts(); { O.labWatts = ""; } this.labWatts.DataContext = O;
            databindings.laVolts P = new databindings.laVolts(); { P.labVolts = ""; } this.labVolts.DataContext = P;
            databindings.laTerm Q = new databindings.laTerm(); { Q.labTerm = ""; } this.labTerm.DataContext = Q;
            databindings.Notes R = new databindings.Notes(); { R.lNotes = ""; } this.lNotes.DataContext = R;
            databindings.rP1 S = new databindings.rP1(); { S.lPr1 = ""; } this.lPr1.DataContext = S;
            databindings.rP2 T = new databindings.rP2(); { T.lPr2 = ""; } this.lPr2.DataContext = T;
            databindings.rP3 U = new databindings.rP3(); { U.lPr3 = ""; } this.lPr3.DataContext = U;
            databindings.rP4 V = new databindings.rP4(); { V.lPr4 = ""; } this.lPr4.DataContext = V;
            databindings.Q1 W = new databindings.Q1(); { W.lQ1 = ""; } this.lQ1.DataContext = W;
            databindings.Q2 X = new databindings.Q2(); { X.lQ2 = ""; } this.lQ2.DataContext = X;
            databindings.Q3 Y = new databindings.Q3(); { Y.lQ3 = ""; } this.lQ3.DataContext = Y;
            databindings.Q4 Z = new databindings.Q4(); { Z.lQ4 = ""; } this.lQ4.DataContext = Z;
        }

        private void lbQuotes_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            vari.rQuoteID = lbQuotes.Items.IndexOf(lbQuotes.SelectedItem);
            DataRowView drv = (DataRowView)lbQuotes.SelectedItem;
            vari.rQuoteID = Convert.ToInt16(drv[0]);

            //CHECK IF INDEX SELECTED IS ZERO
            if (vari.rQuoteID < 0)
            {
                return;
            }
            
            if (vari.rDep == "MicaQuotes" || vari.rDep == "CerQuotes")
            {
                QueryMicaQuote();
            }
            
        }

        private void btnCreatePN_Click(object sender, RoutedEventArgs e)
        {
            PartGen_MicaBand MB = new PartGen_MicaBand();
            MB.Show();
        }

        private void btnEditQuote_Click(object sender, RoutedEventArgs e)
        {
            PullDetails();
        }

        private void lbQuotes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PullDetails();
        }

        private void PullDetails()
        {
            if (vari.rDep == "MicaQuotes")
            {
                vari.Recall = true;

                CreateQuote CQ = new CreateQuote();
                CQ.Show();
            }
        }
    }
}
