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
    /// Interaction logic for CreateQuote_Cartridge.xaml
    /// </summary>
    public partial class CreateQuote_Cartridge : Window
    {
        public CreateQuote_Cartridge()
        {
            InitializeComponent();
            QueryCustList();

            cmbDiameter.Items.Add(".250 (1/4”)");
            cmbDiameter.Items.Add(".256 (6.5mm)");
            cmbDiameter.Items.Add(".312 (5/16”)");
            cmbDiameter.Items.Add(".315 (8mm)");
            cmbDiameter.Items.Add(".375 (3/8”)");
            cmbDiameter.Items.Add(".393 (10mm)");
            cmbDiameter.Items.Add(".437 (7/16”)");
            cmbDiameter.Items.Add(".472 (12mm)");
            cmbDiameter.Items.Add(".492 (12.5mm)");
            cmbDiameter.Items.Add(".500 (1/2”)");
            cmbDiameter.Items.Add(".551 (14mm)");
            cmbDiameter.Items.Add(".591 (15mm)");
            cmbDiameter.Items.Add(".625 (5/8”)");
            cmbDiameter.Items.Add(".630 (16mm)");
            cmbDiameter.Items.Add(".669 (17mm)");
            cmbDiameter.Items.Add(".687 (11/16”)");
            cmbDiameter.Items.Add(".750 (3/4”)");
            cmbDiameter.Items.Add(".787 (20mm)");
            cmbDiameter.Items.Add(".875 (7/8”)");
            cmbDiameter.Items.Add("1.000 (1”)");

            cmbTermStyle.Items.Add("AE");
            cmbTermStyle.Items.Add("AR");
            cmbTermStyle.Items.Add("BE");
            cmbTermStyle.Items.Add("BR");
            cmbTermStyle.Items.Add("FH");
            cmbTermStyle.Items.Add("FN");
            cmbTermStyle.Items.Add("N");
            cmbTermStyle.Items.Add("ND");
            cmbTermStyle.Items.Add("NU");
            cmbTermStyle.Items.Add("P");
            cmbTermStyle.Items.Add("S");
            cmbTermStyle.Items.Add("SA");
            cmbTermStyle.Items.Add("SB");
            cmbTermStyle.Items.Add("SE");
            cmbTermStyle.Items.Add("SR");
            cmbTermStyle.Items.Add("ST");
            cmbTermStyle.Items.Add("TA");
            cmbTermStyle.Items.Add("TB");
            cmbTermStyle.Items.Add("TC");

            //SET DEFAULTS
            tbLabor.Text = "1.00";
            vari.Adders = true;
            tbSMT.Text = vari.SMTcart;
            myComboBox.IsDropDownOpen = true;

            //ClearAdders();
        }

        private void ClearAdders()
        {
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
            }
        }

        //PUBLIC VARIABLES
        public double PriceMulti;
        public bool isFirstTime = true;

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

        //PUBLIC FORM VARIABLES

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

        private void btnPrecalculate_Click(object sender, RoutedEventArgs e)
        {
            PreCalcExcel();
        }

        private void btnSaveQuote_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(vari.DefaultDirectory + vari.CartTemplateName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlApp.DisplayAlerts = false;

            //SAVE FILE DIALOGUE
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files|*.pdf";
            saveFileDialog.InitialDirectory = "\\\\ezserver1\\common\\CUSTOMER QUOTES\\";
            saveFileDialog.FileName = vari.SelectedCustomer.ToString() + "_CART_" + vari.pn;
            if (saveFileDialog.ShowDialog() == true)
            {
                //EXPORT QUOTE AS PDF FILE
                xlWorkSheet.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, saveFileDialog.FileName);
                vari.SavedPDFDir = saveFileDialog.FileName;
            }

            //SAVE AND CLOSE THE EXCEL WORKBOOK
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
                    double dia; double.TryParse(cmbDiameter.Text, out dia);
                    double length; double.TryParse(tbLength.Text, out length);
                    double watt; double.TryParse(tbWatts.Text, out watt);
                    double volt; double.TryParse(tbVolts.Text, out volt);
                    int leads; int.TryParse(tbLeads.Text, out leads);
                    int leadcov; int.TryParse(tbLeadCov.Text, out leadcov);
                    double multi; double.TryParse(tbLabor.Text, out multi);
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
                    string CmdLine1 = "INSERT INTO CartQuotes (Cust,dte,q1,q2,q3,q4,p1,p2,p3,p4,dia,length,termstyle,leads,leadcov,watts,volts,multi,adder,notes,smt,filename,ad1,ad1p,ad2,ad2p,ad3,ad3p,ad4,ad4p,ad5,ad5p,ad6,ad6p,pn) " +
                        "VALUES ('" + myComboBox.Text + "','" + DateTime.Now + "'," + q1 + "," + q2 + "," + q3 + "," + q4 + "," + vari.p1 + "," + vari.p2 + "," + vari.p3 + "," + vari.p4 + "," +
                        " '" + cmbDiameter.Text + "'," + length + ",'" + cmbTermStyle.Text + "'," + leads + "," + leadcov + "," + watt + "," + volt + "," + multi + "," + adder + ", '" + tbSpecials.Text + "','" + tbSMT.Text + "'," +
                        " '" + vari.SavedPDFDir + "','" + ad1 + "'," + ad1p + ",'" + ad2 + "'," + ad2p + ",'" + ad3 + "'," + ad3p + ",'" + ad4 + "'," + ad4p + ",'" + ad5 + "'," + ad5p + ",'" + ad6 + "'," + ad6p + ",'" + vari.pn + "'); ";
                    OleDbCommand Insert1 = new OleDbCommand(CmdLine1, connection1);
                    Insert1.ExecuteNonQuery();

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
            cmbTermStyle.SelectedItem = null;
            cmbDiameter.SelectedItem = null;

            tbQty1.Text = null;
            tbQty2.Text = null;
            tbQty3.Text = null;
            tbQty4.Text = null;

            lq1.Text = null;
            lq2.Text = null;
            lq3.Text = null;
            lq4.Text = null;

            lMulti.Text = null;

            tbLength.Text = null;
            tbWatts.Text = null;
            tbVolts.Text = null;
            tbLeads.Text = null;
            tbLeadCov.Text = null;
            tbLabor.Text = "1.00";
            tbSpecials.Text = null;
            tbManualAdder.Text = null;

            vari.AdderArray = null;
        }


        private void PreCalcExcel()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(vari.DefaultDirectory + vari.CartTemplateName, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlApp.DisplayAlerts = false;

            //WRITE DATA TO EXCEL SHEET
            xlWorkSheet.Cells[3, 4] = myComboBox.Text;
            xlWorkSheet.Cells[3, 7] = lMulti.Text;
            xlWorkSheet.Cells[4, 4] = tbQty1.Text;
            xlWorkSheet.Cells[5, 4] = tbQty2.Text;
            xlWorkSheet.Cells[6, 4] = tbQty3.Text;
            xlWorkSheet.Cells[7, 4] = tbQty4.Text;

            xlWorkSheet.Cells[8, 4] = cmbDiameter.Text;
            xlWorkSheet.Cells[9, 4] = tbLength.Text;
            xlWorkSheet.Cells[10, 4] = cmbTermStyle.Text;
            xlWorkSheet.Cells[11, 4] = tbLeads.Text;
            xlWorkSheet.Cells[12, 4] = tbLeadCov.Text;
            xlWorkSheet.Cells[13, 4] = tbWatts.Text;
            xlWorkSheet.Cells[14, 4] = tbVolts.Text;

            xlWorkSheet.Cells[16, 4] = tbLabor.Text;
            xlWorkSheet.Cells[9, 15] = tbManualAdder.Text;

            xlWorkSheet.Cells[18, 4] = tbSpecials.Text;

            xlWorkSheet.Cells[3, 15] = tbSMT.Text;

            databindings.q1 A = new databindings.q1();
            { A.lq1 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("G4").Value)); }
            this.lq1.DataContext = A;
            vari.p1 = xlWorkSheet.get_Range("G4").Value;
            databindings.q2 B = new databindings.q2();
            { B.lq2 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("G5").Value)); }
            this.lq2.DataContext = B;
            vari.p2 = xlWorkSheet.get_Range("G5").Value;
            databindings.q3 C = new databindings.q3();
            { C.lq3 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("G6").Value)); }
            this.lq3.DataContext = C;
            vari.p3 = xlWorkSheet.get_Range("G6").Value;
            databindings.q4 D = new databindings.q4();
            { D.lq4 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("G7").Value)); }
            this.lq4.DataContext = D;
            vari.p4 = xlWorkSheet.get_Range("G7").Value;

            databindings.PN E = new databindings.PN();
            { E.lPN = string.Format("{0:C}", xlWorkSheet.get_Range("D1").Value); }
            this.lPN.DataContext = E;
            vari.pn = xlWorkSheet.get_Range("D1").Text;

            xlWorkBook.SaveAs(vari.TempDir + vari.CartTemplateName);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            AddersCalc2();
        }

        

        private void AddersCalc2()
        {

            //START EXCEL INTEROP OPENING COMS OBJECT
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(vari.DefaultDirectory + vari.CartTemplateName, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlApp.DisplayAlerts = false;

            if (vari.AdderArray == null)
            {
                //CLEAR OUT ADDER CELLS IN EXCEL ON ARRAY NULL CONDITION
                { xlWorkSheet.Cells[11, 7] = ""; xlWorkSheet.Cells[11, 14] = ""; }
                { xlWorkSheet.Cells[12, 7] = ""; xlWorkSheet.Cells[12, 14] = ""; }
                { xlWorkSheet.Cells[13, 7] = ""; xlWorkSheet.Cells[13, 14] = ""; }
                { xlWorkSheet.Cells[14, 7] = ""; xlWorkSheet.Cells[14, 14] = ""; }
                { xlWorkSheet.Cells[15, 7] = ""; xlWorkSheet.Cells[15, 14] = ""; }
                { xlWorkSheet.Cells[16, 7] = ""; xlWorkSheet.Cells[16, 14] = ""; }
            }
            else
            {
                //WRITE DATA TO EXCEL SHEET ON ARRAY NOT NULL CONDITION
                if (vari.AdderArray.GetLength(0) > 0)
                { xlWorkSheet.Cells[11, 7] = vari.AdderArray[0, 0].ToString(); xlWorkSheet.Cells[11, 14] = vari.AdderArray[0, 1].ToString(); }
                else
                { xlWorkSheet.Cells[11, 7] = ""; xlWorkSheet.Cells[11, 14] = ""; }
                if (vari.AdderArray.GetLength(0) > 1)
                { xlWorkSheet.Cells[12, 7] = vari.AdderArray[1, 0].ToString(); xlWorkSheet.Cells[12, 14] = vari.AdderArray[1, 1].ToString(); }
                else
                { xlWorkSheet.Cells[12, 7] = ""; xlWorkSheet.Cells[12, 14] = ""; }
                if (vari.AdderArray.GetLength(0) > 2)
                { xlWorkSheet.Cells[13, 7] = vari.AdderArray[2, 0].ToString(); xlWorkSheet.Cells[13, 14] = vari.AdderArray[2, 1].ToString(); }
                else
                { xlWorkSheet.Cells[13, 7] = ""; xlWorkSheet.Cells[13, 14] = ""; }
                if (vari.AdderArray.GetLength(0) > 3)
                { xlWorkSheet.Cells[14, 7] = vari.AdderArray[3, 0].ToString(); xlWorkSheet.Cells[14, 14] = vari.AdderArray[3, 1].ToString(); }
                else
                { xlWorkSheet.Cells[14, 7] = ""; xlWorkSheet.Cells[14, 14] = ""; }
                if (vari.AdderArray.GetLength(0) > 4)
                { xlWorkSheet.Cells[15, 7] = vari.AdderArray[4, 0].ToString(); xlWorkSheet.Cells[15, 14] = vari.AdderArray[4, 1].ToString(); }
                else
                { xlWorkSheet.Cells[15, 7] = ""; xlWorkSheet.Cells[15, 14] = ""; }
                if (vari.AdderArray.GetLength(0) > 5)
                { xlWorkSheet.Cells[16, 7] = vari.AdderArray[5, 0].ToString(); xlWorkSheet.Cells[16, 14] = vari.AdderArray[5, 1].ToString(); }
                else
                { xlWorkSheet.Cells[16, 7] = ""; xlWorkSheet.Cells[16, 14] = ""; }
            }

            xlWorkBook.SaveAs(vari.TempDir + vari.CartTemplateName);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            vari.Adders = false;
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            vari.Adders = true;
            Q_Adders Q = new Q_Adders();
            Q.ShowDialog();
        }

        private void CloseAdders()
        {
            if (vari.AdderArray == null)
            { }
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

        private void Window_Activated_1(object sender, EventArgs e)
        {
            if (isFirstTime)
            {
                isFirstTime = false;
                CloseAdders();
            }
            isFirstTime = true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(vari.DefaultDirectory + vari.CartTemplateName);
        }

        private void btnDelAdd_Click(object sender, RoutedEventArgs e)
        {
            vari.AdderArray = null;
            CloseAdders();
            lbAdders.ItemsSource = null;
        }

        //HIGHLIGHT TEXTBOX TEXT ON TB FOCUS GAINED
        private void tbQty1_GotFocus(object sender, RoutedEventArgs e) { tbQty1.Select(0, tbQty1.Text.Length); }
        private void tbQty2_GotFocus(object sender, RoutedEventArgs e) { tbQty2.Select(0, tbQty2.Text.Length); }
        private void tbQty3_GotFocus(object sender, RoutedEventArgs e) { tbQty3.Select(0, tbQty3.Text.Length); }
        private void tbQty4_GotFocus(object sender, RoutedEventArgs e) { tbQty4.Select(0, tbQty4.Text.Length); }
        private void tbLength_GotFocus(object sender, RoutedEventArgs e) { tbLength.Select(0, tbLength.Text.Length); }
        private void tbLeads_GotFocus(object sender, RoutedEventArgs e) { tbLeads.Select(0, tbLeads.Text.Length); }
        private void tbLeadCov_GotFocus(object sender, RoutedEventArgs e) { tbLeadCov.Select(0, tbLeadCov.Text.Length); }
        private void tbWatts_GotFocus(object sender, RoutedEventArgs e) { tbWatts.Select(0, tbWatts.Text.Length); }
        private void tbVolts_GotFocus(object sender, RoutedEventArgs e) { tbVolts.Select(0, tbVolts.Text.Length); }
        private void tbLabor_GotFocus(object sender, RoutedEventArgs e) { tbLabor.Select(0, tbLabor.Text.Length); }
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
    }
}
