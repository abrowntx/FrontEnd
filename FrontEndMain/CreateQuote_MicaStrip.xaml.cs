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
    /// Interaction logic for CreateQuote_MicaStrip.xaml
    /// </summary>
    public partial class CreateQuote_MicaStrip : Window
    {
        public CreateQuote_MicaStrip()
        {
            InitializeComponent();
            QueryCustList();
            myComboBox.IsDropDownOpen = true;
            tbHeight.IsEnabled = false;
            tbSeg.IsEnabled = false;
            tbMulti.Text = "1.00";

            //Populate Lockup
            cmbLockup.Items.Add("BC");
            cmbLockup.Items.Add("CE");
            cmbLockup.Items.Add("CM");
            cmbLockup.Items.Add("FC");
            cmbLockup.Items.Add("FE");
            cmbLockup.Items.Add("FM");
            cmbLockup.Items.Add("NC");
            cmbLockup.Items.Add("NE");
            cmbLockup.Items.Add("NM");
            cmbLockup.Items.Add("NU");
            cmbLockup.Items.Add("RN");
            cmbLockup.Items.Add("SE");
            cmbLockup.Items.Add("SH");
            cmbLockup.Items.Add("SM");
            cmbLockup.SelectedIndex = 12;

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


        }

        //PUBLIC FORM VARIABLES
        public double PriceMulti;
        public bool isFirstTime = true;
        public bool DeleteAdders = false;
        public string Multiplier;
        public string CustomerName;

        private void QueryCustList()
        {
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

        private void myComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vari.CustID = Convert.ToInt16(myComboBox.SelectedValue);
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

        private void PreCalcExcel()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(vari.DefaultDirectory + vari.StripTemplateName, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlApp.DisplayAlerts = false;
            //MessageBox.Show(xlWorkSheet.get_Range("B3").Value.ToString());

            //WRITE DATA TO EXCEL SHEET
            xlWorkSheet.Cells[3, 5] = lMulti.Text;
            xlWorkSheet.Cells[3, 4] = myComboBox.Text;
            xlWorkSheet.Cells[4, 4] = tbQty1.Text;
            xlWorkSheet.Cells[5, 4] = tbQty2.Text;
            xlWorkSheet.Cells[6, 4] = tbQty3.Text;
            xlWorkSheet.Cells[7, 4] = tbQty4.Text;
            xlWorkSheet.Cells[8, 4] = cmbLockup.Text;
            xlWorkSheet.Cells[20, 4] = tbSeg.Text;
            xlWorkSheet.Cells[10, 4] = tbWidth1.Text;
            xlWorkSheet.Cells[11, 4] = tbLength.Text;
            xlWorkSheet.Cells[12, 4] = tbHeight.Text;
            xlWorkSheet.Cells[16, 4] = tbWatts.Text;
            xlWorkSheet.Cells[17, 4] = tbVolts.Text;
            xlWorkSheet.Cells[13, 4] = cmbTermStyle.Text;
            xlWorkSheet.Cells[14, 4] = tbLeads.Text;
            xlWorkSheet.Cells[15, 4] = tbLeadCov.Text;
            xlWorkSheet.Cells[19, 4] = tbHoles.Text;
            xlWorkSheet.Cells[21, 4] = tbMulti.Text;
            xlWorkSheet.Cells[18, 14] = tbManualAdder.Text;
            xlWorkSheet.Cells[19, 7] = tbSpecials.Text;
            xlWorkSheet.Cells[3, 14] = tbSMT.Text;

            databindings.q1 A = new databindings.q1();
            { A.lq1 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("G4").Value)); }
            this.lq1.DataContext = A;
            vari.p1 = Convert.ToDouble(xlWorkSheet.get_Range("G4").Value);
            databindings.q2 B = new databindings.q2();
            { B.lq2 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("G5").Value)); }
            this.lq2.DataContext = B;
            vari.p2 = Convert.ToDouble(xlWorkSheet.get_Range("G5").Value);
            databindings.q3 C = new databindings.q3();
            { C.lq3 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("G6").Value)); }
            this.lq3.DataContext = C;
            vari.p3 = Convert.ToDouble(xlWorkSheet.get_Range("G6").Value);
            databindings.q4 D = new databindings.q4();
            { D.lq4 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("G7").Value)); }
            this.lq4.DataContext = D;
            vari.p4 = Convert.ToDouble(xlWorkSheet.get_Range("G7").Value);

            databindings.PN E = new databindings.PN();
            { E.lPN = string.Format("{0:C}", xlWorkSheet.get_Range("D1").Value); }
            this.lPN.DataContext = E;
            vari.pn = xlWorkSheet.get_Range("D1").Text;


            xlWorkBook.SaveAs(vari.TempDir + vari.StripTemplateName);
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
            xlWorkBook = xlApp.Workbooks.Open(vari.DefaultDirectory + vari.StripTemplateName, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlApp.DisplayAlerts = false;

            if (vari.AdderArray == null)
            {
                //CLEAR OUT ADDER CELLS IN EXCEL ON ARRAY NULL CONDITION
                { xlWorkSheet.Cells[12, 7] = ""; xlWorkSheet.Cells[12, 13] = ""; }
                { xlWorkSheet.Cells[13, 7] = ""; xlWorkSheet.Cells[13, 13] = ""; }
                { xlWorkSheet.Cells[14, 7] = ""; xlWorkSheet.Cells[14, 13] = ""; }
                { xlWorkSheet.Cells[15, 7] = ""; xlWorkSheet.Cells[15, 13] = ""; }
                { xlWorkSheet.Cells[16, 7] = ""; xlWorkSheet.Cells[16, 13] = ""; }
                { xlWorkSheet.Cells[17, 7] = ""; xlWorkSheet.Cells[17, 13] = ""; }
            }
            else
            {
                //WRITE DATA TO EXCEL SHEET ON ARRAY NOT NULL CONDITION
                if (vari.AdderArray.GetLength(0) > 0)
                { xlWorkSheet.Cells[12, 7] = vari.AdderArray[0, 0].ToString(); xlWorkSheet.Cells[12, 13] = vari.AdderArray[0, 1].ToString(); }
                else
                { xlWorkSheet.Cells[12, 7] = ""; xlWorkSheet.Cells[12, 13] = ""; }
                if (vari.AdderArray.GetLength(0) > 1)
                { xlWorkSheet.Cells[13, 7] = vari.AdderArray[1, 0].ToString(); xlWorkSheet.Cells[13, 13] = vari.AdderArray[1, 1].ToString(); }
                else
                { xlWorkSheet.Cells[13, 7] = ""; xlWorkSheet.Cells[13, 13] = ""; }
                if (vari.AdderArray.GetLength(0) > 2)
                { xlWorkSheet.Cells[14, 7] = vari.AdderArray[2, 0].ToString(); xlWorkSheet.Cells[14, 13] = vari.AdderArray[2, 1].ToString(); }
                else
                { xlWorkSheet.Cells[14, 7] = ""; xlWorkSheet.Cells[14, 13] = ""; }
                if (vari.AdderArray.GetLength(0) > 3)
                { xlWorkSheet.Cells[15, 7] = vari.AdderArray[3, 0].ToString(); xlWorkSheet.Cells[15, 13] = vari.AdderArray[3, 1].ToString(); }
                else
                { xlWorkSheet.Cells[15, 7] = ""; xlWorkSheet.Cells[15, 13] = ""; }
                if (vari.AdderArray.GetLength(0) > 4)
                { xlWorkSheet.Cells[16, 7] = vari.AdderArray[4, 0].ToString(); xlWorkSheet.Cells[16, 13] = vari.AdderArray[4, 1].ToString(); }
                else
                { xlWorkSheet.Cells[16, 7] = ""; xlWorkSheet.Cells[16, 13] = ""; }
                if (vari.AdderArray.GetLength(0) > 5)
                { xlWorkSheet.Cells[17, 7] = vari.AdderArray[5, 0].ToString(); xlWorkSheet.Cells[17, 13] = vari.AdderArray[5, 1].ToString(); }
                else
                { xlWorkSheet.Cells[17, 7] = ""; xlWorkSheet.Cells[17, 13] = ""; }
            }

            xlWorkBook.SaveAs(vari.TempDir + vari.StripTemplateName);
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

        private void Window_Activated(object sender, EventArgs e)
        {
            if (isFirstTime)
            {
                isFirstTime = false;
                CloseAdders();
            }
            isFirstTime = true;
        }






        private void cmbLockup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = cmbLockup.SelectedValue as ComboBoxItem;
            if ((cmbLockup.SelectedValue.ToString() == "SH") || (cmbLockup.SelectedValue.ToString() == "BC") || (cmbLockup.SelectedValue.ToString() == "RN") || (cmbLockup.SelectedValue.ToString() == "NU"))
            { tbHeight.IsEnabled = false; tbSeg.IsEnabled = false; }
            else
            { tbHeight.IsEnabled = true; tbSeg.IsEnabled = true; }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            vari.Adders = true;
            Q_Adders Q = new Q_Adders();
            Q.ShowDialog();
        }

        private void btnDelAdd_Click(object sender, RoutedEventArgs e)
        {
            vari.AdderArray = null;
            DeleteAdders = true;
            CloseAdders();
            DeleteAdders = false;
            lbAdders.ItemsSource = null;
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

        private void HeaterCalcs()
        {
            double watts = 0;
            double volts = 0;
            double dia = 0;
            double width = 0;
            double.TryParse(tbWatts.Text, out watts);
            double.TryParse(tbVolts.Text, out volts);
            double.TryParse(tbLength.Text, out dia);
            double.TryParse(tbWidth1.Text, out width);


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

        private void tbQty1_GotFocus(object sender, RoutedEventArgs e) { tbQty1.Select(0, tbQty1.Text.Length); }
        private void tbQty2_GotFocus(object sender, RoutedEventArgs e) { tbQty2.Select(0, tbQty2.Text.Length); }
        private void tbQty3_GotFocus(object sender, RoutedEventArgs e) { tbQty3.Select(0, tbQty3.Text.Length); }
        private void tbQty4_GotFocus(object sender, RoutedEventArgs e) { tbQty4.Select(0, tbQty4.Text.Length); }
        private void tbSeg_GotFocus(object sender, RoutedEventArgs e) { tbSeg.Select(0, tbSeg.Text.Length); }
        private void tbDia_GotFocus(object sender, RoutedEventArgs e) { tbWidth1.Select(0, tbWidth1.Text.Length); }
        private void tbWidth_GotFocus(object sender, RoutedEventArgs e) { tbLength.Select(0, tbLength.Text.Length); }
        private void tbHeight_GotFocus(object sender, RoutedEventArgs e) { tbHeight.Select(0, tbHeight.Text.Length); }
        private void tbWatts_GotFocus(object sender, RoutedEventArgs e) { tbWatts.Select(0, tbWatts.Text.Length); }
        private void tbVolts_GotFocus(object sender, RoutedEventArgs e) { tbVolts.Select(0, tbVolts.Text.Length); }
        private void tbLeads_GotFocus(object sender, RoutedEventArgs e) { tbLeads.Select(0, tbLeads.Text.Length); }
        private void tbLeadCov_GotFocus(object sender, RoutedEventArgs e) { tbLeadCov.Select(0, tbLeadCov.Text.Length); }
        private void tbHoles_GotFocus(object sender, RoutedEventArgs e) { tbHoles.Select(0, tbHoles.Text.Length); }
        private void tbMulti_GotFocus(object sender, RoutedEventArgs e) { tbMulti.Select(0, tbMulti.Text.Length); }
        private void tbManualAdder_GotFocus(object sender, RoutedEventArgs e) { tbManualAdder.Select(0, tbManualAdder.Text.Length); }
        private void tbSpecials_GotFocus(object sender, RoutedEventArgs e) { tbSpecials.Select(0, tbSpecials.Text.Length); }
        private void tbSMT_GotFocus(object sender, RoutedEventArgs e) { tbSMT.Select(0, tbSMT.Text.Length); }

        private void btnSaveQuote_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(vari.DefaultDirectory + vari.StripTemplateName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlApp.DisplayAlerts = false;

            //SAVE FILE DIALOGUE
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files|*.pdf";
            saveFileDialog.InitialDirectory = "\\\\ezserver1\\common\\CUSTOMER QUOTES\\";
            saveFileDialog.FileName = vari.SelectedCustomer.ToString() + "_MS_" + vari.pn;
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
                    double seg; double.TryParse(tbSeg.Text, out seg);
                    double width; double.TryParse(tbWidth1.Text, out width);
                    double length; double.TryParse(tbLength.Text, out length);
                    double height; double.TryParse(tbHeight.Text, out height);
                    double watt; double.TryParse(tbWatts.Text, out watt);
                    double volt; double.TryParse(tbVolts.Text, out volt);
                    int leads; int.TryParse(tbLeads.Text, out leads);
                    int leadcov; int.TryParse(tbLeadCov.Text, out leadcov);
                    double holes; double.TryParse(tbHoles.Text, out holes);
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
                    string CmdLine1 = "INSERT INTO FlatQuotes (Cust,dte,q1,q2,q3,q4,p1,p2,p3,p4,locku,seg,width,length,height,watts,volts,termstyle,leads,leadcov,holes,multi,adder,smt,filename,notes,ad1,ad1p,ad2,ad2p,ad3,ad3p,ad4,ad4p,ad5,ad5p,ad6,ad6p,pn) " +
                        "VALUES ('" + myComboBox.Text + "','" + DateTime.Now + "'," + q1 + "," + q2 + "," + q3 + "," + q4 + "," + vari.p1 + "," + vari.p2 + "," + vari.p3 + "," + vari.p4 + "," +
                        "'" + cmbLockup.Text + "'," + seg + "," + width + "," + length + "," + height + "," + watt + "," + volt + ",'" +cmbTermStyle.Text + "'," + leads + "," + leadcov + "," + holes + "," +
                        "" + multi + "," + adder + ",'" + tbSMT.Text + "','" + vari.SavedPDFDir + "','" + tbSpecials.Text + "'," +
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


        private void btnPrecalculate_Click(object sender, RoutedEventArgs e)
        {
            PreCalcExcel();
        }

        private void btnClearForm_Click(object sender, RoutedEventArgs e)
        {
            myComboBox.SelectedItem = null;
            cmbTermStyle.SelectedItem = null;

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
            tbWidth1.Text = null;
            tbLength.Text = null;
            tbHeight.Text = null;
            tbWatts.Text = null;
            tbVolts.Text = null;
            tbLeads.Text = null;
            tbLeadCov.Text = null;
            tbHoles.Text = null;
            tbMulti.Text = null;
            tbManualAdder.Text = null;
            tbSpecials.Text = null;

            lbAdders.ItemsSource = null;
            vari.AdderArray = null;

            cmbLockup.SelectedIndex = 12;
            tbHeight.IsEnabled = false;
            tbSeg.IsEnabled = false;
            tbMulti.Text = "1.00";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
