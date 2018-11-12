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

namespace FrontEndMain
{
    /// <summary>
    /// Interaction logic for PartsLists_MicaBand.xaml
    /// </summary>
    public partial class PartsLists_MicaBand : Window
    {
        public PartsLists_MicaBand()
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveQuote_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }
    }
}
