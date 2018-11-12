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
    /// Interaction logic for NumberGen.xaml
    /// </summary>
    public partial class NumberGen : Window
    {
        public NumberGen()
        {
            InitializeComponent();
            QueryList();
        }

        public string Prefix;
        public string Base;
        public string Suffix;
        public int previousFile;
        public string NextFile;
        public string FileNumber;

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

        private void QueryList()
        {
            // SET THE DATABASE CONNECTION VARS
            string file = vari.DefaultDirectory + "Lists.accdb";
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
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT ID,base FROM BHList;", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "*");

                    //sort the queried data by the base column
                    DataView dv = DataSet.Tables[0].DefaultView;
                    dv.Sort = "base";
                    DataTable sortedDT = dv.ToTable();

                    //set the next number textbox with result
                    int NextID = sortedDT.Rows.Count;

                    // Query the database to find all entries without a FINISH TIME
                    OleDbDataAdapter DB = new OleDbDataAdapter("SELECT ID,file,seg,locku,dia,wid,termstyle,base FROM BHList WHERE seg='" + vari.rQD[11] + "' AND locku='" + vari.rQD[12] + "' AND dia = " + vari.rQD[13] + " AND wid = " + vari.rQD[14] + " AND termstyle = '" + vari.rQD[17] + "';", connection1);
                    var DataSet2 = new DataSet();
                    DB.Fill(DataSet2, "*");

                    //fill listbox with potential pn matches
                    lbMatches.DataContext = DataSet2.Tables[0];
                    lbMatches.ItemsSource = DataSet2.Tables[0].DefaultView;


                    previousFile = Convert.ToInt16(sortedDT.Rows[sortedDT.Rows.Count - 1][1]) + 1;
                    NextFile = "BH" + previousFile.ToString() + "-01";



                    Existing();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }

        private void Existing()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("ID");
            dt.Columns.Add("file");
            DataRow _ravi = dt.NewRow();
            _ravi["ID"] = previousFile;
            _ravi["file"] = NextFile;
            dt.Rows.Add(_ravi);

            lbExists.DataContext = dt;
            lbExists.ItemsSource = dt.DefaultView;
        }

        private void lbMatches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //vari.rIndex = lbMatches.Items.IndexOf(lbMatches.SelectedItem);
            DataRowView drv = (DataRowView)lbMatches.SelectedItem;
            if (drv == null) { } else
            {
                Base = drv[7].ToString();
                // SET THE DATABASE CONNECTION VARS
                string file = vari.DefaultDirectory + "Lists.accdb"; string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source =" + file + ";";

                // Attempt to connect to the database
                using (var connection1 = new OleDbConnection(ConnectionString))
                {
                    OleDbCommand OComm = new OleDbCommand();
                    OComm.Connection = connection1;
                    try
                    {
                        connection1.Open();
                        // Query the database to find all entries without a FINISH TIME
                        OleDbDataAdapter DA = new OleDbDataAdapter("SELECT ID FROM BHList WHERE base = '" + Base + "';", connection1);
                        var DataSet = new DataSet();
                        DA.Fill(DataSet, "*");

                        string temp = drv[1].ToString();
                        Prefix = temp.Substring(0, 2);
                        Base = temp.Substring(2, 4);
                        Suffix = (DataSet.Tables[0].Rows.Count + 1).ToString();

                        

                        UpdateLabels();
                        CheckSelection();
                        lbExists.UnselectAll();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                    finally
                    { connection1.Close(); }
                }
            }
        }

        private void CheckSelection()
        {
                // SET THE DATABASE CONNECTION VARS
                string file = vari.DefaultDirectory + "Lists.accdb"; string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source =" + file + ";";

                // Attempt to connect to the database
                using (var connection1 = new OleDbConnection(ConnectionString))
                {
                    OleDbCommand OComm = new OleDbCommand();
                    OComm.Connection = connection1;
                    try
                    {
                        connection1.Open();
                        // Query the database to find all entries without a FINISH TIME
                        string temp = "BH" + Prefix + Base + "-" + Suffix;
                        OleDbDataAdapter DA = new OleDbDataAdapter("SELECT count(*) FROM BHList WHERE file = '" + tbQB_Copy.Text + "';", connection1);
                        var DataSet = new DataSet();
                        DA.Fill(DataSet, "*");

                        if (Convert.ToInt16(DataSet.Tables[0].Rows[0][0]) > 0)
                        {
                            MatchingPN();
                            return;
                        }

                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                    finally
                    { connection1.Close(); }
                }
        }

        private void MatchingPN()
        {
            if (MessageBox.Show("There's an existing file number here with the proposed solution. Would you like to increment the proposed solution and retest?", "Part Number Match Detected!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                tbQB_Copy.Text = null;
                return;
            }
            else
            {
                Suffix = (Convert.ToInt16(Suffix) + 1).ToString("D6");
                UpdateLabels();
                CheckSelection();
                return;
            }
        }

        private void lbExists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //vari.rIndex = lbMatches.Items.IndexOf(lbMatches.SelectedItem);
            DataRowView drv = (DataRowView)lbExists.SelectedItem;
            if (drv == null) { } else
            {
                string temp = drv[1].ToString();
                Prefix = temp.Substring(0, 2);
                Suffix = temp.Substring(7, 2);
                Base = temp.Substring(2, 4);

                UpdateLabels();
                CheckSelection();
                lbMatches.UnselectAll();
            }
        }

        private void UpdateLabels()
        {
            databindings.Prefix A = new databindings.Prefix();
            { A.lPrefix = Prefix; }
            this.lPrefix.DataContext = A;

            databindings.Suffix B = new databindings.Suffix();
            { B.lSuffix = Suffix; }
            this.lSuffix.DataContext = B;

            databindings.Base C = new databindings.Base();
            { C.lBase = Base; }
            this.lBase.DataContext = C;

            tbQB_Copy.Text = Prefix + Base + "-" + string.Format("{0:D2}", Convert.ToInt16(Suffix)); ;
        }

        private void FinalCheck()
        {
            // SET THE DATABASE CONNECTION VARS
            string file = vari.DefaultDirectory + "Lists.accdb"; string ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source =" + file + ";";

            // Attempt to connect to the database
            using (var connection1 = new OleDbConnection(ConnectionString))
            {
                OleDbCommand OComm = new OleDbCommand();
                OComm.Connection = connection1;
                try
                {
                    connection1.Open();
                    // Query the database to find all entries without a FINISH TIME
                    string temp = "BH" + Prefix + Base + "-" + Suffix;
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT count(*) FROM BHList WHERE file = '" + tbQB_Copy.Text + "';", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "*");

                    if (Convert.ToInt16(DataSet.Tables[0].Rows[0][0]) > 0)
                    {
                        MessageBox.Show("There's already a record of the part number that you've selected. Please change the part number and try saving the record again.");
                        return;
                    }

                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
            vari.filenumber = tbQB_Copy.Text;
            this.Close();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            FinalCheck();
        }
    }
}
