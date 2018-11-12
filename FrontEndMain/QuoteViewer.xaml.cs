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
    /// Interaction logic for QuoteViewer.xaml
    /// </summary>
    public partial class QuoteViewer : Window
    {
        public QuoteViewer()
        {
            InitializeComponent();
            pdfWebViewer.Navigate(new Uri("about:blank"));
            pdfWebViewer.Navigate(vari.SavedPDFDir);

            this.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.85);
            this.Width = (System.Windows.SystemParameters.PrimaryScreenWidth * 0.85);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pdfWebViewer.Navigate("about:blank");
        }
    }
}
