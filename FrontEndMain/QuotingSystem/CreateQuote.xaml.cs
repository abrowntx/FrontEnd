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
    /// Interaction logic for CreateQuote.xaml
    /// </summary>
    public partial class CreateQuote : Window
    {
        public CreateQuote()
        {
            InitializeComponent();

            //Set Defaults
            tbMulti.Text = "1.00";

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

        }

        //PUBLIC FORM VARIABLES
        public double PriceMulti;

        private void QueryCustList()
        {
            string file = vari.DefaultDirectory + "Customers.accdb";
            string ConnectionString =
            "Provider = Microsoft.ACE.OLEDB.12.0;" +
            "Data Source ="+file+";";
            
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
            xlWorkBook = xlApp.Workbooks.Open(vari.DefaultDirectory + "quoting_mica.xls", 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
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
            xlWorkSheet.Cells[19, 5] = tbSpecials.Text;

            databindings.q1 A = new databindings.q1();
            { A.lq1 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("E4").Value)); }
            this.lq1.DataContext = A;
            vari.p1 = xlWorkSheet.get_Range("E4").Value;
            databindings.q2 B = new databindings.q2();
            { B.lq2 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("E5").Value)); }
            this.lq2.DataContext = B;
            vari.p2 = xlWorkSheet.get_Range("E5").Value;
            databindings.q3 C = new databindings.q3();
            { C.lq3 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("E6").Value)); }
            this.lq3.DataContext = C;
            vari.p3 = xlWorkSheet.get_Range("E6").Value;
            databindings.q4 D = new databindings.q4();
            { D.lq4 = string.Format("{0:C}", Convert.ToDecimal(xlWorkSheet.get_Range("E7").Value)); }
            this.lq4.DataContext = D;
            vari.p4 = xlWorkSheet.get_Range("E7").Value;

            databindings.PN E = new databindings.PN();
            { E.lPN = string.Format("{0:C}", xlWorkSheet.get_Range("C1").Value); }
            this.lPN.DataContext = E;
            vari.pn = xlWorkSheet.get_Range("C1").Value;


            xlWorkBook.SaveAs(vari.DefaultDirectory + "quoting_mica.xls");
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private void btnSaveQuote_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(vari.DefaultDirectory + "quoting_mica.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlApp.DisplayAlerts = false;
            
            //SAVE FILE DIALOGUE
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files|*.pdf";
            saveFileDialog.InitialDirectory = "\\\\ezserver1\\engineering\\";
            saveFileDialog.FileName = (DateTime.Today).ToString("yyyy-MM-dd") + "_MICA_" + vari.pn;
            if (saveFileDialog.ShowDialog() == true)
            {
                xlWorkSheet.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, saveFileDialog.FileName + ".pdf");
            }
            else
            {
                
            }

            xlWorkBook.SaveAs(vari.DefaultDirectory + "quoting_mica.xls" + lPN.Text);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

        }


        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
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
                    OleDbCommand CheckMulti = new OleDbCommand("SELECT Multi FROM CustomerList WHERE ID = " + vari.CustID + ";", connection1);
                    OleDbDataReader reader = CheckMulti.ExecuteReader();
                    while (reader.Read())
                    {
                        Multiplier = reader[0].ToString();

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


    }
}
