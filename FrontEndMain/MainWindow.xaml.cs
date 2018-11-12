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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace FrontEndMain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Set default variables from config manager at startup
            vari.DefaultDirectory = ConfigurationManager.AppSettings.Get("DefaultDirectory");
            vari.MicaTemplateName = ConfigurationManager.AppSettings.Get("Q_MicaBand");
            vari.StripTemplateName = ConfigurationManager.AppSettings.Get("Q_MicaStrip");
            vari.CartTemplateName = ConfigurationManager.AppSettings.Get("Q_Cartridge");
            vari.CeramicTemplateName = ConfigurationManager.AppSettings.Get("Q_Ceramic");
            vari.TempDir = ConfigurationManager.AppSettings.Get("TempDir");
            vari.SMT = ConfigurationManager.AppSettings.Get("SMT");
            vari.SMTcart = ConfigurationManager.AppSettings.Get("SMTcart");
            vari.SMTcer = ConfigurationManager.AppSettings.Get("SMTcer");
        }

        private void btnRecallQuote_Click(object sender, RoutedEventArgs e)
        {
            RecallQuote RecallQuote = new RecallQuote();
            RecallQuote.ShowDialog();
        }

        private void btnNewQuote_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HConfig_Click(object sender, RoutedEventArgs e)
        {
            Configurator config = new Configurator();
            config.ShowDialog();
        }

        private void HCreateMica_Click(object sender, RoutedEventArgs e)
        {
            CreateQuote CreateQuote = new CreateQuote();
            CreateQuote.Show();
        }

        private void HRecallQuote_Click(object sender, RoutedEventArgs e)
        {
            RecallQuote RecallQuote = new RecallQuote();
            RecallQuote.ShowDialog();
        }

        private void HClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCreateMicaQuote_Click(object sender, RoutedEventArgs e)
        {
            CreateQuote CreateQuote = new CreateQuote();
            CreateQuote.ShowDialog();
        }

        private void btnCustManager_Click(object sender, RoutedEventArgs e)
        {
            CustomerManager CustMan = new CustomerManager();
            CustMan.ShowDialog();
        }

        private void btnCreateCartridgeQuote_Click(object sender, RoutedEventArgs e)
        {
            CreateQuote_Cartridge CQ_C = new CreateQuote_Cartridge();
            CQ_C.ShowDialog();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Configurator Conf = new Configurator();
            Conf.ShowDialog();
        }

        private void btnModAdders_Click(object sender, RoutedEventArgs e)
        {
            ModifyAdders MA = new ModifyAdders();
            MA.ShowDialog();
        }

        private void btnSystemConfig_Click(object sender, RoutedEventArgs e)
        {
            Configurator Conf = new Configurator();
            Conf.ShowDialog();
        }

        private void btnCreateMicaQuote_Copy_Click(object sender, RoutedEventArgs e)
        {
            CreateQuote_MicaStrip MS = new CreateQuote_MicaStrip();
            MS.Show();
        }

        private void btnRecallQuote_Copy3_Click(object sender, RoutedEventArgs e)
        {
            CreateQuote_Ceramic CQ_C = new CreateQuote_Ceramic();
            CQ_C.Show();
        }

        private void HCreateStrip_Click(object sender, RoutedEventArgs e)
        {
            CreateQuote_MicaStrip MS = new CreateQuote_MicaStrip();
            MS.Show();
        }

        private void HCreateCeramic_Click(object sender, RoutedEventArgs e)
        {
            CreateQuote_Ceramic CQ_C = new CreateQuote_Ceramic();
            CQ_C.Show();
        }

        private void HCreateCart_Click(object sender, RoutedEventArgs e)
        {
            CreateQuote_Cartridge CQ_C = new CreateQuote_Cartridge();
            CQ_C.ShowDialog();
        }

        private void HCreateMisc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ManageCust_Click(object sender, RoutedEventArgs e)
        {
            CustomerManager CustMan = new CustomerManager();
            CustMan.ShowDialog();
        }

        private void HManageAdders_Click(object sender, RoutedEventArgs e)
        {
            ModifyAdders MA = new ModifyAdders();
            MA.ShowDialog();
        }

        private void btnMicaBand_Click(object sender, RoutedEventArgs e)
        {
            PartsLists PartsList = new PartsLists(1);
            PartsList.ShowDialog();
        }

        private void btnMicaStrip_Click(object sender, RoutedEventArgs e)
        {
            PartsLists PartsList = new PartsLists(2);
            PartsList.ShowDialog();
        }

        private void btnCeramic_Click(object sender, RoutedEventArgs e)
        {
            PartsLists PartsList = new PartsLists(3);
            PartsList.ShowDialog();
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            PartsLists PartsList = new PartsLists(4);
            PartsList.ShowDialog();
        }

        private void btnTC_Click(object sender, RoutedEventArgs e)
        {
            PartsLists PartsList = new PartsLists(6);
            PartsList.ShowDialog();
        }

        private void btnMisc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
