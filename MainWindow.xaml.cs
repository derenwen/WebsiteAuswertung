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

namespace Websiteauswertung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        internal WebsiteVerwaltung wv = new WebsiteVerwaltung();
        public MainWindow()
        {
            InitializeComponent();

            int pointCount = 10;
            double[] Xs = new double[pointCount];
            string[] labels = new string[pointCount];
            double[] dataB = new double[pointCount];
            double[] errorB = new double[pointCount];

            wv.getWebsiteDaten();
            var bar = plot_Auswertung.plt;
            for(int i=0;i<wv.domains.Length;i++)
                bar.PlotBar(new double[] {i}, new double[]{wv.amounts[i]}, label: wv.domains[i], barWidth: 0.5);
            bar.Title("Websiteauswertung");
            bar.Grid(true);
            bar.Legend(location: ScottPlot.legendLocation.upperRight);
            bar.Axis(y1: 0);
        }
    }
}
