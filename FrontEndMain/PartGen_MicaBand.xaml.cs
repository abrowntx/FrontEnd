﻿using System;
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

            vari.filegen = false;
            vari.filenumber = null;
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

        private void Startup()
        {
            tbID.Text = vari.rQD[0].ToString();
            tbCust.Text = vari.rQD[1].ToString();
            tbDate.Text = vari.rQD[2].ToString();
            tbPN.Text = vari.rQD[29].ToString();
            tbSeg.Text = vari.rQD[11].ToString();
            tbLock.Text = vari.rQD[12].ToString();
            tbDia.Text = vari.rQD[13].ToString();
            tbWid.Text = vari.rQD[14].ToString();
            tbTerm.Text = vari.rQD[17].ToString();
            tbWatts.Text = vari.rQD[15].ToString();
            tbVolts.Text = vari.rQD[16].ToString();
            tbLeads.Text = vari.rQD[18].ToString();
            tbLeadcov.Text = vari.rQD[19].ToString();
            tbTermLoc.Text = vari.rQD[21].ToString();
            cmbTermLoc.Text = vari.rQD[20].ToString();
            tbNotes.Text = vari.rQD[25].ToString();
            tbDesc.Text = vari.rQD[36].ToString();
            cmbTermLoc.Text = vari.rQD[37].ToString();
            if (vari.rQD[37].ToString() == "Standard")
            {
                cmbTermLoc.SelectedIndex = 0;
            }
            else
            {
                cmbTermLoc.SelectedIndex = 1;
            }
            tbTermLoc.Text = vari.rQD[38].ToString();
            tbHoles.Text = vari.rQD[39].ToString();
            tbNotches.Text = vari.rQD[40].ToString();

            lbAdders.Items.Add(vari.rQD[30].ToString());
            lbAdders.Items.Add(vari.rQD[31].ToString());
            lbAdders.Items.Add(vari.rQD[32].ToString());
            lbAdders.Items.Add(vari.rQD[33].ToString());
            lbAdders.Items.Add(vari.rQD[34].ToString());
            lbAdders.Items.Add(vari.rQD[35].ToString());

            string watt;
            string volt = "";
            if (Convert.ToDouble(tbVolts.Text) < 100) { volt = "0"; }
            else {
                if (Convert.ToDouble(tbVolts.Text) < 200) { volt = "1"; }
                else {
                    if (Convert.ToDouble(tbVolts.Text) < 300) { volt = "2"; }
                    else {
                        if (Convert.ToDouble(tbVolts.Text) < 400) { volt = "3"; }
                        else {
                            if (Convert.ToDouble(tbVolts.Text) < 500) { volt = "4"; }
                            else {
                                if (Convert.ToDouble(tbVolts.Text) < 600) { volt = "5"; }
                                else {
                                    if (Convert.ToDouble(tbVolts.Text) < 700) { volt = "6"; } }
                            }
                        }
                    }
                }
            }

            watt = (Math.Round(Convert.ToDouble(tbWatts.Text) / 100d) * 100).ToString();

            tbQB.Text = tbPN.Text + "-" + watt + "-" + volt + "-01";

            switch (vari.rQD[11])
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
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT count(*) FROM BHList WHERE file = '" + tbBH.Text + "';", connection1);
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

        private void btnBH_Click(object sender, RoutedEventArgs e)
        {
            NumberGen NG = new NumberGen();
            NG.Show();
        }

        private void Window_Activated(object sender, EventArgs e)
        {

            tbBH.Text = vari.filenumber;

            vari.filegen = false;
            vari.filenumber = null;
        }
    }
}
