using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Data;
using System.ComponentModel;
using Microsoft.Win32;

namespace FrontEndMain
{
    /// <summary>
    /// Interaction logic for CreateQuote.xaml
    /// </summary>
    public partial class CreateQuote : Window
    {
        public CreateQuote()
        {
            InitializeComponent();

            //Set Defaults
            tbMulti.Text = "1.00";
            tbSMT.Text = vari.SMT;
            vari.Adders = true;

            //Populate Lockup
            cmbLockup.Items.Add("C");
            cmbLockup.Items.Add("EC");
            cmbLockup.Items.Add("EF");
            cmbLockup.Items.Add("ECL");
            cmbLockup.Items.Add("ECU");
            cmbLockup.Items.Add("ESU");
            cmbLockup.Items.Add("ES");
            cmbLockup.Items.Add("F");
            cmbLockup.Items.Add("HCL");
            cmbLockup.Items.Add("HC");
            cmbLockup.Items.Add("HN");
            cmbLockup.Items.Add("HCU");
            cmbLockup.Items.Add("HSU");
            cmbLockup.Items.Add("HS");
            cmbLockup.Items.Add("CL");
            cmbLockup.Items.Add("N");
            cmbLockup.Items.Add("RF");
            cmbLockup.Items.Add("RN");
            cmbLockup.Items.Add("CU");
            cmbLockup.Items.Add("S");
            cmbLockup.Items.Add("SL");
            cmbLockup.Items.Add("SU");

            //Populate Term Style
            cmbTermStyle.Items.Add("AB");
            cmbTermStyle.Items.Add("AH");
            cmbTermStyle.Items.Add("AP");
            cmbTermStyle.Items.Add("BA");
            cmbTermStyle.Items.Add("BB");
            cmbTermStyle.Items.Add("BG");
            cmbTermStyle.Items.Add("BH");
            cmbTermStyle.Items.Add("BP");
            cmbTermStyle.Items.Add("LA");
            cmbTermStyle.Items.Add("LB");
            cmbTermStyle.Items.Add("LG");
            cmbTermStyle.Items.Add("LH");
            cmbTermStyle.Items.Add("LP");
            cmbTermStyle.Items.Add("PB");
            cmbTermStyle.Items.Add("PC");
            cmbTermStyle.Items.Add("PT");
            cmbTermStyle.Items.Add("PX");
            cmbTermStyle.Items.Add("RA");
            cmbTermStyle.Items.Add("RB");
            cmbTermStyle.Items.Add("RF");
            cmbTermStyle.Items.Add("TA");
            cmbTermStyle.Items.Add("TB");
            cmbTermStyle.Items.Add("TC");
            cmbTermStyle.Items.Add("TT");
            cmbTermStyle.Items.Add("XB");
            cmbTermStyle.Items.Add("XC");

            //Populate Term Loc
            cmbTermLoc.SelectedIndex = 0;
            cmbTermLoc.Items.Add("Standard");
            cmbTermLoc.Items.Add("Degree");

            QueryCustList();
            myComboBox.IsDropDownOpen = true;

            if (vari.Recall == true)
            {
                QueryExistingDetails();
            }
        }

        //PUBLIC FORM VARIABLES
        public double PriceMulti;
        public bool isFirstTime = true;
        public bool DeleteAdders = false;
        public string FileName;

        private void QueryExistingDetails()
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

                    //Populate the form with database entries
                    myComboBox.Text = DataSet.Tables[0].Rows[0][1].ToString();
                    myComboBox.IsDropDownOpen = false;
                    tbQty1.Text = DataSet.Tables[0].Rows[0][3].ToString();
                    tbQty2.Text = DataSet.Tables[0].Rows[0][4].ToString();
                    tbQty3.Text = DataSet.Tables[0].Rows[0][5].ToString();
                    tbQty4.Text = DataSet.Tables[0].Rows[0][6].ToString();

                    lq1.Text = DataSet.Tables[0].Rows[0][7].ToString();
                    lq1.Text = DataSet.Tables[0].Rows[0][8].ToString();
                    lq1.Text = DataSet.Tables[0].Rows[0][9].ToString();
                    lq1.Text = DataSet.Tables[0].Rows[0][10].ToString();

                    tbSeg.Text = DataSet.Tables[0].Rows[0][11].ToString();
                    cmbLockup.Text = DataSet.Tables[0].Rows[0][12].ToString();
                    tbDia.Text = DataSet.Tables[0].Rows[0][13].ToString();
                    tbWidth.Text = DataSet.Tables[0].Rows[0][14].ToString();
                    tbWatts.Text = DataSet.Tables[0].Rows[0][15].ToString();
                    tbVolts.Text = DataSet.Tables[0].Rows[0][16].ToString();

                    cmbTermStyle.Text = DataSet.Tables[0].Rows[0][17].ToString();
                    tbLeads.Text = DataSet.Tables[0].Rows[0][18].ToString();
                    tbLeadCov.Text = DataSet.Tables[0].Rows[0][19].ToString();
                    cmbTermLoc.Text = DataSet.Tables[0].Rows[0][20].ToString();
                    tbTermMeasure.Text = DataSet.Tables[0].Rows[0][21].ToString();

                    tbHoles.Text = DataSet.Tables[0].Rows[0][22].ToString();
                    tbCutouts.Text = DataSet.Tables[0].Rows[0][23].ToString();
                    tbMulti.Text = DataSet.Tables[0].Rows[0][24].ToString();
                    tbManualAdder.Text = DataSet.Tables[0].Rows[0][29].ToString();
                    tbSpecials.Text = DataSet.Tables[0].Rows[0][25].ToString();


                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

        private void QueryCustList()
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
                    // Query the database to find all entries without a FINISH TIME
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT ID,CustName FROM CustomerList;", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "CustomerList");

                    myComboBox.DataContext = this;
                    myComboBox.ItemsSource = DataSet.Tables[0].DefaultView;
                    myComboBox.DisplayMemberPath = DataSet.Tables[0].Columns["CustName"].ToString();
                    myComboBox.SelectedValuePath = DataSet.Tables[0].Columns["ID"].ToString();

                    ICollectionView dataView = CollectionViewSource.GetDefaultView(myComboBox.ItemsSource);
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

        private void btnPrecalculate_Click(object sender, RoutedEventArgs e)
        {
            PreCalcExcel();
        }

        private void PreCalcExcel()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(vari.DefaultDirectory + vari.MicaTemplateName, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlApp.DisplayAlerts = false;
            //MessageBox.Show(xlWorkSheet.get_Range("B3").Value.ToString());

            //WRITE DATA TO EXCEL SHEET
            xlWorkSheet.Cells[3, 3] = myComboBox.Text;
            xlWorkSheet.Cells[4, 3] = tbQty1.Text;
            xlWorkSheet.Cells[5, 3] = tbQty2.Text;
            xlWorkSheet.Cells[6, 3] = tbQty3.Text;
            xlWorkSheet.Cells[7, 3] = tbQty4.Text;
            xlWorkSheet.Cells[9, 3] = tbSeg.Text;
            xlWorkSheet.Cells[10, 3] = cmbLockup.Text;
            xlWorkSheet.Cells[11, 3] = tbDia.Text;
            xlWorkSheet.Cells[12, 3] = tbWidth.Text;
            xlWorkSheet.Cells[13, 3] = cmbTermStyle.Text;
            xlWorkSheet.Cells[14, 3] = tbLeads.Text;
            xlWorkSheet.Cells[15, 3] = tbLeadCov.Text;
            xlWorkSheet.Cells[16, 3] = tbWatts.Text;
            xlWorkSheet.Cells[17, 3] = tbVolts.Text;
            xlWorkSheet.Cells[19, 3] = tbHoles.Text;
            xlWorkSheet.Cells[20, 3] = tbCutouts.Text;
            xlWorkSheet.Cells[21, 3] = cmbTermLoc.Text;
            xlWorkSheet.Cells[22, 3] = tbTermMeasure.Text;
            xlWorkSheet.Cells[23, 3] = tbMulti.Text;
            xlWorkSheet.Cells[20, 6] = tbSpecials.Text;
            xlWorkSheet.Cells[3, 13] = tbSMT.Text;
            xlWorkSheet.Cells[3, 4] = lMulti.Text;
            xlWorkSheet.Cells[7, 13] = tbManualAdder.Text;

            databindings.q1 A = new databindings.q1();
            { A.lq1 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("F4").Value)); }
            this.lq1.DataContext = A;
            vari.p1 = xlWorkSheet.get_Range("F4").Value;
            databindings.q2 B = new databindings.q2();
            { B.lq2 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("F5").Value)); }
            this.lq2.DataContext = B;
            vari.p2 = xlWorkSheet.get_Range("F5").Value;
            databindings.q3 C = new databindings.q3();
            { C.lq3 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("F6").Value)); }
            this.lq3.DataContext = C;
            vari.p3 = xlWorkSheet.get_Range("F6").Value;
            databindings.q4 D = new databindings.q4();
            { D.lq4 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("F7").Value)); }
            this.lq4.DataContext = D;
            vari.p4 = xlWorkSheet.get_Range("F7").Value;

            databindings.PN E = new databindings.PN();
            { E.lPN = string.Format("{0:C}", xlWorkSheet.get_Range("C1").Value); }
            this.lPN.DataContext = E;
            vari.pn = xlWorkSheet.get_Range("C1").Text;

            vari.desc = xlWorkSheet.get_Range("B26").Text;


            xlWorkBook.SaveAs(vari.TempDir + vari.MicaTemplateName);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            AddersCalc2();
        }

        private void releaseObject(object obj)
        {
            try
            { System.Runtime.InteropServices.Marshal.ReleaseComObject(obj); obj = null; }
            catch (Exception ex)
            { obj = null; MessageBox.Show("Unable to release the Object " + ex.ToString()); }
            finally
            { GC.Collect(); }
        }

        private void btnSaveQuote_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(vari.DefaultDirectory + vari.MicaTemplateName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlApp.DisplayAlerts = false;

            //SAVE FILE DIALOGUE
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files|*.pdf";
            saveFileDialog.InitialDirectory = "\\\\ezserver1\\common\\CUSTOMER QUOTES\\";
            saveFileDialog.FileName = vari.SelectedCustomer.ToString() + "_MICA_" + vari.pn;
            if (saveFileDialog.ShowDialog() == true)
            {
                //EXPORT QUOTE AS PDF FILE
                xlWorkSheet.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, saveFileDialog.FileName);
                vari.SavedPDFDir = saveFileDialog.FileName;
            }

            //lbAddersCLOSE THE EXCEL WORKBOOK
            xlWorkBook.Close(false, misValue, misValue);
            xlApp.Quit();

            //RELEASE THE XL COM OBJECTS
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            WriteQuoteRecord();

            QuoteViewer QV = new QuoteViewer();
            QV.ShowDialog();

        }

        private void WriteQuoteRecord()
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
                    int q1; int.TryParse(tbQty1.Text, out q1);
                    int q2; int.TryParse(tbQty2.Text, out q2);
                    int q3; int.TryParse(tbQty3.Text, out q3);
                    int q4; int.TryParse(tbQty4.Text, out q4);
                    double p1; double.TryParse(lq1.Text, out p1);
                    double p2; double.TryParse(lq2.Text, out p2);
                    double p3; double.TryParse(lq3.Text, out p3);
                    double p4; double.TryParse(lq4.Text, out p4);
                    double dia; double.TryParse(tbDia.Text, out dia);
                    double wid; double.TryParse(tbWidth.Text, out wid);
                    double watt; double.TryParse(tbWatts.Text, out watt);
                    double volt; double.TryParse(tbVolts.Text, out volt);
                    int leads; int.TryParse(tbLeads.Text, out leads);
                    int leadcov; int.TryParse(tbLeadCov.Text, out leadcov);
                    int holes; int.TryParse(tbHoles.Text, out holes);
                    int cutouts; int.TryParse(tbCutouts.Text, out cutouts);
                    double multi; double.TryParse(tbMulti.Text, out multi);
                    double adder; double.TryParse(tbManualAdder.Text, out adder);

                    string ad1 = ""; double ad1p = 0; string ad2 = ""; double ad2p = 0; string ad3 = ""; double ad3p = 0; string ad4 = ""; double ad4p = 0; string ad5 = ""; double ad5p = 0; string ad6 = ""; double ad6p = 0;

                    //VALIDATE THE ARRAY AND SET VARIABLES TO NULL IF ARRAY IS NULL
                    if (vari.AdderArray == null || vari.AdderArray.Length == 0)
                    {
                        ad1 = ""; ad1p = 0; ad2 = ""; ad2p = 0; ad3 = ""; ad3p = 0; ad4 = ""; ad4p = 0; ad5 = ""; ad5p = 0; ad6 = ""; ad6p = 0;
                    }
                    else
                    {
                        if (vari.AdderArray.GetLength(0) > 0)
                        { ad1 = vari.AdderArray[0, 0].ToString(); ad1p = Convert.ToDouble(vari.AdderArray[0, 1]); }
                        else { ad1 = ""; ad1p = 0; }
                        if (vari.AdderArray.GetLength(0) > 1)
                        { ad2 = vari.AdderArray[1, 0].ToString(); ad2p = Convert.ToDouble(vari.AdderArray[1, 1]); }
                        else { ad2 = ""; ad2p = 0; }
                        if (vari.AdderArray.GetLength(0) > 2)
                        { ad3 = vari.AdderArray[2, 0].ToString(); ad3p = Convert.ToDouble(vari.AdderArray[2, 1]); }
                        else { ad3 = ""; ad3p = 0; }
                        if (vari.AdderArray.GetLength(0) > 3)
                        { ad4 = vari.AdderArray[3, 0].ToString(); ad4p = Convert.ToDouble(vari.AdderArray[3, 1]); }
                        else { ad4 = ""; ad4p = 0; }
                        if (vari.AdderArray.GetLength(0) > 4)
                        { ad5 = vari.AdderArray[4, 0].ToString(); ad5p = Convert.ToDouble(vari.AdderArray[4, 1]); }
                        else { ad5 = ""; ad5p = 0; }
                        if (vari.AdderArray.GetLength(0) > 5)
                        { ad6 = vari.AdderArray[5, 0].ToString(); ad6p = Convert.ToDouble(vari.AdderArray[5, 1]); }
                        else { ad6 = ""; ad6p = 0; }
                    }

                    connection1.Open();
                    // INSERT A NEW RECORD FOR THE QUOTE
                    string CmdLine1 = "INSERT INTO MicaQuotes (Cust,dte,q1,q2,q3,q4,p1,p2,p3,p4,seg,locku,dia,wid,watts,volts,termstyle,leadlen,leadcov,termloc,termdetail,holes,cutouts,multi,notes,smt,adder,descr,filename,ad1,ad1p,ad2,ad2p,ad3,ad3p,ad4,ad4p,ad5,ad5p,ad6,ad6p,pn)" +
                        " VALUES ('" + myComboBox.Text + "','" + DateTime.Now + "'," + q1 + "," + q2 + "," + q3 + "," + q4 + "," + vari.p1 + "," + vari.p2 + "," + vari.p3 + "," + vari.p4 + ",'" + tbSeg.Text + "'," +
                        "'" + cmbLockup.Text + "'," + dia + "," + wid + "," + watt + "," + volt + ",'" + cmbTermStyle.Text + "'," + leads + "," + leadcov + ",'" + cmbTermLoc.Text + "','" + tbTermMeasure.Text + "'," +
                        "" + holes + "," + cutouts + "," + multi + ",'" + tbSpecials.Text + "','" + tbSMT.Text + "','" + adder + "','" + vari.desc + "','" + vari.SavedPDFDir + "'," +
                        "'" + ad1 + "'," + ad1p + ",'" + ad2 + "'," + ad2p + ",'" + ad3 + "'," + ad3p + ",'" + ad4 + "'," + ad4p + ",'" + ad5 + "'," + ad5p + ",'" + ad6 + "'," + ad6p + ",'" + vari.pn + "');";
                    OleDbCommand Insert1 = new OleDbCommand(CmdLine1, connection1);
                    Insert1.ExecuteNonQuery();

                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

        private void RecalcPrice()
        {
            databindings.q1 A = new databindings.q1();
            { A.lq1 = string.Format("{0:C}", Convert.ToDecimal(vari.p1 * PriceMulti * 100) / 100); }
            this.lq1.DataContext = A;

            databindings.q2 B = new databindings.q2();
            { B.lq2 = string.Format("{0:C}", Convert.ToDecimal(vari.p2 * PriceMulti * 100) / 100); }
            this.lq2.DataContext = B;

            databindings.q3 C = new databindings.q3();
            { C.lq3 = string.Format("{0:C}", Convert.ToDecimal(vari.p3 * PriceMulti * 100) / 100); }
            this.lq3.DataContext = C;

            databindings.q4 D = new databindings.q4();
            { D.lq4 = string.Format("{0:C}", Convert.ToDecimal(vari.p4 * PriceMulti * 100) / 100); }
            this.lq4.DataContext = D;
        }

        private void rdoSMT_Clicked(object sender, RoutedEventArgs e)
        { PriceMulti = 1.00; RecalcPrice(); }

        private void rdo5DAY_Click(object sender, RoutedEventArgs e)
        { PriceMulti = 1.5; RecalcPrice(); }

        private void rdoHOT_Click(object sender, RoutedEventArgs e)
        { PriceMulti = 2.2; RecalcPrice(); }

        public string Multiplier;
        public string CustomerName;
        private void myComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vari.CustID = Convert.ToInt16(myComboBox.SelectedValue);

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
                    // Query the database to find all entries without a FINISH TIME
                    OleDbCommand CheckMulti = new OleDbCommand("SELECT Multi, CustName FROM CustomerList WHERE ID = " + vari.CustID + ";", connection1);
                    OleDbDataReader reader = CheckMulti.ExecuteReader();
                    while (reader.Read())
                    {
                        Multiplier = reader[0].ToString();
                        vari.SelectedCustomer = reader[1].ToString();

                        databindings.Multi E = new databindings.Multi();
                        { E.lMulti = Multiplier; }
                        this.lMulti.DataContext = E;
                    }
                    reader.Close();



                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }

            }
        }

        private void btnClearForm_Click(object sender, RoutedEventArgs e)
        {
            myComboBox.SelectedItem = null;
            cmbLockup.SelectedItem = null;
            cmbTermLoc.SelectedItem = null;
            cmbTermStyle.SelectedItem = null;
            cmbTermLoc.SelectedIndex = 0;

            tbQty1.Text = null;
            tbQty2.Text = null;
            tbQty3.Text = null;
            tbQty4.Text = null;

            lq1.Text = null;
            lq2.Text = null;
            lq3.Text = null;
            lq4.Text = null;

            lMulti.Text = null;

            tbSeg.Text = null;
            tbDia.Text = null;
            tbWidth.Text = null;
            tbWatts.Text = null;
            tbVolts.Text = null;
            tbLeads.Text = null;
            tbLeadCov.Text = null;
            tbTermMeasure.Text = null;
            tbHoles.Text = null;
            tbCutouts.Text = null;
            tbMulti.Text = "1.00";
            tbSpecials.Text = null;
            tbManualAdder.Text = null;

            lbAdders.ItemsSource = null;
            vari.AdderArray = null;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            vari.Adders = true;
            Q_Adders Q = new Q_Adders();
            Q.ShowDialog();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (isFirstTime)
            {
                isFirstTime = false;
                CloseAdders();
            }
            isFirstTime = true;
        }


        private void AddersCalc2()
        {

            //START EXCEL INTEROP OPENING COMS OBJECT
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(vari.DefaultDirectory + vari.MicaTemplateName, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlApp.DisplayAlerts = false;

            if (vari.AdderArray == null)
            {
                //CLEAR OUT ADDER CELLS IN EXCEL ON ARRAY NULL CONDITION
                { xlWorkSheet.Cells[13, 6] = ""; xlWorkSheet.Cells[13, 10] = ""; }
                { xlWorkSheet.Cells[14, 6] = ""; xlWorkSheet.Cells[14, 10] = ""; }
                { xlWorkSheet.Cells[15, 6] = ""; xlWorkSheet.Cells[15, 10] = ""; }
                { xlWorkSheet.Cells[16, 6] = ""; xlWorkSheet.Cells[16, 10] = ""; }
                { xlWorkSheet.Cells[17, 6] = ""; xlWorkSheet.Cells[17, 10] = ""; }
                { xlWorkSheet.Cells[18, 6] = ""; xlWorkSheet.Cells[18, 10] = ""; }
            }
            else
            {
                //WRITE DATA TO EXCEL SHEET ON ARRAY NOT NULL CONDITION
                if (vari.AdderArray.GetLength(0) > 0)
                { xlWorkSheet.Cells[13, 6] = vari.AdderArray[0, 0].ToString(); xlWorkSheet.Cells[13, 10] = vari.AdderArray[0, 1].ToString(); }
                else
                { xlWorkSheet.Cells[13, 6] = ""; xlWorkSheet.Cells[13, 10] = ""; }
                if (vari.AdderArray.GetLength(0) > 1)
                { xlWorkSheet.Cells[14, 6] = vari.AdderArray[1, 0].ToString(); xlWorkSheet.Cells[14, 10] = vari.AdderArray[1, 1].ToString(); }
                else
                { xlWorkSheet.Cells[14, 6] = ""; xlWorkSheet.Cells[14, 10] = ""; }
                if (vari.AdderArray.GetLength(0) > 2)
                { xlWorkSheet.Cells[15, 6] = vari.AdderArray[2, 0].ToString(); xlWorkSheet.Cells[15, 10] = vari.AdderArray[2, 1].ToString(); }
                else
                { xlWorkSheet.Cells[15, 6] = ""; xlWorkSheet.Cells[15, 10] = ""; }
                if (vari.AdderArray.GetLength(0) > 3)
                { xlWorkSheet.Cells[16, 6] = vari.AdderArray[3, 0].ToString(); xlWorkSheet.Cells[16, 10] = vari.AdderArray[3, 1].ToString(); }
                else
                { xlWorkSheet.Cells[16, 6] = ""; xlWorkSheet.Cells[16, 10] = ""; }
                if (vari.AdderArray.GetLength(0) > 4)
                { xlWorkSheet.Cells[17, 6] = vari.AdderArray[4, 0].ToString(); xlWorkSheet.Cells[17, 10] = vari.AdderArray[4, 1].ToString(); }
                else
                { xlWorkSheet.Cells[17, 6] = ""; xlWorkSheet.Cells[17, 10] = ""; }
                if (vari.AdderArray.GetLength(0) > 5)
                { xlWorkSheet.Cells[18, 6] = vari.AdderArray[5, 0].ToString(); xlWorkSheet.Cells[18, 10] = vari.AdderArray[5, 1].ToString(); }
                else
                { xlWorkSheet.Cells[18, 6] = ""; xlWorkSheet.Cells[18, 10] = ""; }
            }

            xlWorkBook.SaveAs(vari.TempDir + vari.MicaTemplateName);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            vari.Adders = false;
        }

        private void CloseAdders()
        {
            if (vari.AdderArray == null)
            {  }
            else
            {
                DataTable DT = new DataTable();
                DT.Clear();
                DT.Columns.Add("AdderName");
                DT.Columns.Add("AdderCost");
                if (vari.AdderArray.GetLength(0) > 0)
                {
                    DataRow _0 = DT.NewRow();
                    _0["AdderName"] = vari.AdderArray[0, 0];
                    _0["AdderCost"] = vari.AdderArray[0, 1];
                    DT.Rows.Add(_0);
                }
                if (vari.AdderArray.GetLength(0) > 1)
                {
                    DataRow _1 = DT.NewRow();
                    _1["AdderName"] = vari.AdderArray[1, 0];
                    _1["AdderCost"] = vari.AdderArray[1, 1];
                    DT.Rows.Add(_1);
                }
                if (vari.AdderArray.GetLength(0) > 2)
                {
                    DataRow _2 = DT.NewRow();
                    _2["AdderName"] = vari.AdderArray[2, 0];
                    _2["AdderCost"] = vari.AdderArray[2, 1];
                    DT.Rows.Add(_2);
                }
                if (vari.AdderArray.GetLength(0) > 3)
                {
                    DataRow _3 = DT.NewRow();
                    _3["AdderName"] = vari.AdderArray[3, 0];
                    _3["AdderCost"] = vari.AdderArray[3, 1];
                    DT.Rows.Add(_3);
                }
                if (vari.AdderArray.GetLength(0) > 4)
                {
                    DataRow _4 = DT.NewRow();
                    _4["AdderName"] = vari.AdderArray[4, 0];
                    _4["AdderCost"] = vari.AdderArray[4, 1];
                    DT.Rows.Add(_4);
                }
                if (vari.AdderArray.GetLength(0) > 5)
                {
                    DataRow _5 = DT.NewRow();
                    _5["AdderName"] = vari.AdderArray[5, 0];
                    _5["AdderCost"] = vari.AdderArray[5, 1];
                    DT.Rows.Add(_5);
                }

                lbAdders.DataContext = DT;
                lbAdders.ItemsSource = DT.DefaultView;
            }

        }

        private void HeaterCalcs()
        {
            double watts = 0;
            double volts = 0;
            double dia = 0;
            double width = 0;
            double.TryParse(tbWatts.Text, out watts);
            double.TryParse(tbVolts.Text, out volts);
            double.TryParse(tbDia.Text, out dia);
            double.TryParse(tbWidth.Text, out width);


            databindings.wsi A = new databindings.wsi();
            double wsi = 0;
            wsi = watts / (dia * 3.14 * width);
            { A.lWsi = string.Format("{0:0.00}", wsi); }
            this.lWsi.DataContext = A;

            databindings.amps B = new databindings.amps();
            double amps = 0;
            amps = watts / volts;
            { B.lAmps = string.Format("{0:0.00}", amps); }
            this.lAmps.DataContext = B;
        }

        private void tbDia_SelectionChanged(object sender, RoutedEventArgs e)
        { HeaterCalcs(); }

        private void tbWidth_SelectionChanged(object sender, RoutedEventArgs e)
        { HeaterCalcs(); }

        private void tbWatts_SelectionChanged(object sender, RoutedEventArgs e)
        { HeaterCalcs(); }

        private void tbVolts_SelectionChanged(object sender, RoutedEventArgs e)
        { HeaterCalcs(); }



        private void btnDelAdd_Click(object sender, RoutedEventArgs e)
        {
            vari.AdderArray = null;
            DeleteAdders = true;
            CloseAdders();
            DeleteAdders = false;
            lbAdders.ItemsSource = null;
        }

        //HIGHLIGHT TEXTBOX TEXT ON FOCUS
        private void tbSeg_GotFocus(object sender, RoutedEventArgs e) { tbSeg.Select(0, tbSeg.Text.Length); }
        private void tbQty1_GotFocus(object sender, RoutedEventArgs e) { tbQty1.Select(0, tbQty1.Text.Length); }
        private void tbQty2_GotFocus(object sender, RoutedEventArgs e) { tbQty2.Select(0, tbQty2.Text.Length); }
        private void tbQty3_GotFocus(object sender, RoutedEventArgs e) { tbQty3.Select(0, tbQty3.Text.Length); }
        private void tbQty4_GotFocus(object sender, RoutedEventArgs e) { tbQty4.Select(0, tbQty4.Text.Length); }
        private void tbDia_GotFocus(object sender, RoutedEventArgs e) { tbDia.Select(0, tbDia.Text.Length); }
        private void tbWidth_GotFocus(object sender, RoutedEventArgs e) { tbWidth.Select(0, tbWidth.Text.Length); }
        private void tbWatts_GotFocus(object sender, RoutedEventArgs e) { tbWatts.Select(0, tbWatts.Text.Length); }
        private void tbVolts_GotFocus(object sender, RoutedEventArgs e) { tbVolts.Select(0, tbVolts.Text.Length); }
        private void tbLeads_GotFocus(object sender, RoutedEventArgs e) { tbLeads.Select(0, tbLeads.Text.Length); }
        private void tbLeadCov_GotFocus(object sender, RoutedEventArgs e) { tbLeadCov.Select(0, tbLeadCov.Text.Length); }
        private void tbTermMeasure_GotFocus(object sender, RoutedEventArgs e) { tbTermMeasure.Select(0, tbTermMeasure.Text.Length); }
        private void tbHoles_GotFocus(object sender, RoutedEventArgs e) { tbHoles.Select(0, tbHoles.Text.Length); }
        private void tbCutouts_GotFocus(object sender, RoutedEventArgs e) { tbCutouts.Select(0, tbCutouts.Text.Length); }
        private void tbMulti_GotFocus(object sender, RoutedEventArgs e) { tbMulti.Select(0, tbMulti.Text.Length); }
        private void tbManualAdder_GotFocus(object sender, RoutedEventArgs e) { tbManualAdder.Select(0, tbManualAdder.Text.Length); }
        private void tbSpecials_GotFocus(object sender, RoutedEventArgs e) { tbSpecials.Select(0, tbSpecials.Text.Length); }
        private void tbSMT_GotFocus(object sender, RoutedEventArgs e) { tbSMT.Select(0, tbSMT.Text.Length); }

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

        private void btnClearForm_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            vari.Recall = false;
        }
    }
}
