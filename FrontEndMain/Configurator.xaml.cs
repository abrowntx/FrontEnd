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
using System.Configuration;
using System.Collections.Specialized;

namespace FrontEndMain
{
    /// <summary>
    /// Interaction logic for Configurator.xaml
    /// </summary>
    public partial class Configurator : Window
    {
        public Configurator()
        {
            InitializeComponent();
            UpdateConfigTexts();
        }

        private void UpdateConfigTexts()
        {
            vari.DefaultDirectory = ConfigurationManager.AppSettings.Get("DefaultDirectory");
            vari.MicaTemplateName = ConfigurationManager.AppSettings.Get("Q_MicaBand");
            vari.StripTemplateName = ConfigurationManager.AppSettings.Get("Q_MicaStrip");
            vari.CartTemplateName = ConfigurationManager.AppSettings.Get("Q_Cartridge");
            vari.CeramicTemplateName = ConfigurationManager.AppSettings.Get("Q_Ceramic");
            vari.TempDir = ConfigurationManager.AppSettings.Get("TempDir");
            vari.SMT = ConfigurationManager.AppSettings.Get("SMT");
            vari.SMTcart = ConfigurationManager.AppSettings.Get("SMTcart");
            vari.SMTcer = ConfigurationManager.AppSettings.Get("SMTcer");

            tbDefaultDirectory.Text = vari.DefaultDirectory;
            tbDefaultMicaTemplate.Text = vari.MicaTemplateName;
            tbDefaultCartTemplate.Text = vari.CartTemplateName;
            tbDefaultCeramicTemplate.Text = vari.CeramicTemplateName;
            tbTempDir.Text = vari.TempDir;
            tbSMT.Text = vari.SMT;
            tbSMTCart.Text = vari.SMTcart;
            tbSMTCer.Text = vari.SMTcer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["DefaultDirectory"].Value = tbDefaultDirectory.Text;
                config.AppSettings.Settings["Q_MicaBand"].Value = tbDefaultMicaTemplate.Text;
                config.AppSettings.Settings["Q_MicaStrip"].Value = tbDefaultStripTemplate.Text;
                config.AppSettings.Settings["Q_Cartridge"].Value = tbDefaultCartTemplate.Text;
                config.AppSettings.Settings["Q_Ceramic"].Value = tbDefaultCeramicTemplate.Text;
                config.AppSettings.Settings["TempDir"].Value = tbTempDir.Text;
                config.AppSettings.Settings["SMT"].Value = tbSMT.Text;
                config.AppSettings.Settings["SMTcart"].Value = tbSMTCart.Text;
                config.AppSettings.Settings["SMTcer"].Value = tbSMTCer.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
