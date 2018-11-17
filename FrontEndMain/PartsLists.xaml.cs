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
using System.Reflection;

namespace FrontEndMain
{
    /// <summary>
    /// Interaction logic for PartsLists.xaml
    /// </summary>
    public partial class PartsLists : Window
    {
        public PartsLists(int index)
        {
            InitializeComponent();
            switch (index)
            {
                case 1:
                    TextConc("BH", "Mica Band Heater Parts List");
                    FillList("BHList", 1);
                    break;
                case 2:
                    TextConc("SH", "Mica Strip Heater Parts List");
                    FillList("SHList", 2);
                    break;
                case 3:
                    TextConc("CB", "Ceramic Band Heater Parts List");
                    FillList("CBList", 3);
                    break;
                case 4:
                    TextConc("C", "Cartridge Heater Parts List");
                    FillList("CBList", 3);
                    break;
                case 5:
                    TextConc("CS", "Ceramic Strip Heater Parts List");
                    FillList("CBList", 3);
                    break;
                case 6:
                    TextConc("M", "Miscellaneous Parts List");
                    FillList("CBList", 3);
                    break;
            }

        }

        //Initialize the public classes
        CRUD.BHList PLEntry = new CRUD.BHList();
        ListBox lb = new ListBox();

        private void LBVisib()
        {
            lbBH.Visibility = Visibility.Collapsed;
            lbSH.Visibility = Visibility.Collapsed;
            lbCB.Visibility = Visibility.Collapsed;
            lbC.Visibility = Visibility.Collapsed;
            lbCS.Visibility = Visibility.Collapsed;
            lbMisc.Visibility = Visibility.Collapsed;
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

        private void FillList(string table, int index)
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
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT * FROM " + table + ";", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "*");
                    // Set the dataset from OleDBAdapter to the item source of the data grid object
                    
                    
                    //SWITCH VISIBILITY OF THE LISTBOX FOR THE SELECTED DEPARTMENT
                    switch(index)
                    {
                        case 1:
                            LBVisib();
                            lb = lbBH;
                            lbBH.Visibility = Visibility.Visible;
                            break;
                        case 2:
                            LBVisib();
                            lb = lbSH;
                            lbCB.Visibility = Visibility.Visible;
                            break;
                        case 3:
                            LBVisib();
                            lb = lbCB;
                            lbCB.Visibility = Visibility.Visible;
                            break;
                        case 4:
                            LBVisib();
                            lb = lbC;
                            lbCB.Visibility = Visibility.Visible;
                            break;
                        case 5:
                            LBVisib();
                            lb = lbCS;
                            lbCB.Visibility = Visibility.Visible;
                            break;
                        case 6:
                            LBVisib();
                            lb = lbMisc;
                            lbCB.Visibility = Visibility.Visible;
                            break;
                    }

                    lb.DataContext = DataSet.Tables[0];
                    lb.ItemsSource = DataSet.Tables[0].DefaultView;

                    ICollectionView dataView = CollectionViewSource.GetDefaultView(lb.ItemsSource);
                    dataView.SortDescriptions.Clear();
                    dataView.SortDescriptions.Add(new SortDescription("file", ListSortDirection.Ascending));
                    dataView.Refresh();

                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }







    private void TextConc(string Suffix, string Head)
        {
            lSuffix.Text = Suffix;
            lHeader.Text = Head;
        }


    private void btnMicaBand_Click(object sender, RoutedEventArgs e)
        {
            TextConc("BH", "Mica Band Heater Parts List");
            FillList("BHList", 1);
        }

        private void btnMicaStrip_Click(object sender, RoutedEventArgs e)
        {
            TextConc("SH", "Mica Strip Heater Parts List");
            FillList("SHList", 2);
        }

        private void btnCeramic_Click(object sender, RoutedEventArgs e)
        {
            TextConc("CB", "Ceramic Band Heater Parts List");
            FillList("CBList", 3);
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            TextConc("C", "Cartridge Heater Parts List");
            FillList("CList", 4);
        }

        private void btnTC_Click(object sender, RoutedEventArgs e)
        {
            TextConc("CS", "Ceramic Strip Heater Parts List");
            FillList("CSList", 5);
        }

        private void btnMisc_Click(object sender, RoutedEventArgs e)
        {
            TextConc("M", "Miscellaneous Heater Parts List");
            FillList("MList", 6);
        }

//MAIN DATABASE QUERY FUNCTION
        private void FillDetails(string Dep, int C, string prefix, string Query)
        {
            vari.rIndex = C;
            vari.rDep = Dep;
            vari.rPre = prefix;
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
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT * FROM " + Dep + Query + ";", connection1);
                    var DataSet = new DataSet();
                    DA.Fill(DataSet, "*");
                    if (vari.Recall == true)
                    {
                        vari.RQD = null;
                        vari.RQD = DataSet;
                        vari.Recall = false;
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
                finally
                { connection1.Close(); }
            }
        }


        //PART EDIT AND GENERATION FUNCTIONS

        private void CreateNewPart()
        {
            //Break functiion if listbox selection is null
            if (lbBH.SelectedItem == null) { return; }

            vari.Recall = true;
            vari.drvSelect = (DataRowView)lbBH.SelectedItem;
            //MessageBox.Show(vari.drvSelect[1].ToString());
            FillDetails("BHList", vari.rIndex, vari.rPre, " WHERE file = '" + vari.drvSelect[1].ToString() + "'");
            PartsList_MicaBand PLMB = new PartsList_MicaBand();
            PLMB.ShowDialog();
        }


        //CONTEXT MENU FUNCTIONS
        //MICA BAND LIST FUNCTIONS
        private void cm_EditPart(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                CreateNewPart();
            }
        }

        private void cm_CreateSimilar(object sender, RoutedEventArgs e)
        {

        }

        private void cm_DeletePart(object sender, RoutedEventArgs e)
        {

        }


    }
}
