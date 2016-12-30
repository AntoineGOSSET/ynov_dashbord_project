using Project1.YnovServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Project1
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public class FinancialStuff
        {
            public string Name { get; set; }
            public int Amount { get; set; }
        }

        public MainPage()
        {
            this.InitializeComponent();
            YnovServiceClient c = new YnovServiceClient();
            c.GetCustomersAsync();

            ObservableCollection<Nb> test = new ObservableCollection<Nb>();

            test = c.GetNbCommandsByCustomersAsync().Result;

            foreach(var nb in test)
            {
                System.Diagnostics.Debug.WriteLine("Test : "+nb.Count.ToString()+" ---- "+nb.FullName);
            }

        }
        

        private void PieChart_Loaded(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            List<FinancialStuff> financialStuffList = new List<FinancialStuff>();
            financialStuffList.Add(new FinancialStuff() { Name = "Windows Phone", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Apple", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Sony", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Samsung", Amount = rand.Next(0, 200) });

            var pie = (PieSeries)sender;
            pie.ItemsSource = financialStuffList;

           
        }

        private void ColumnSeries_Loaded(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            List<FinancialStuff> financialStuffList = new List<FinancialStuff>();
            financialStuffList.Add(new FinancialStuff() { Name = "Windows Phone", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Apple", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Sony", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Samsung", Amount = rand.Next(0, 200) });

            var column = (ColumnSeries)sender;
            column.ItemsSource = financialStuffList;

        }

        private void LineSeries_Loaded(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            List<FinancialStuff> financialStuffList = new List<FinancialStuff>();
            financialStuffList.Add(new FinancialStuff() { Name = "Windows Phone", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Apple", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Sony", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Samsung", Amount = rand.Next(0, 200) });

            var line = (LineSeries)sender;
            line.ItemsSource = financialStuffList;
        }

        private void BarSeries_Loaded(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            List<FinancialStuff> financialStuffList = new List<FinancialStuff>();
            financialStuffList.Add(new FinancialStuff() { Name = "Windows Phone", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Apple", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Sony", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Samsung", Amount = rand.Next(0, 200) });

            var bar = (BarSeries)sender;
            bar.ItemsSource = financialStuffList;
        }

        private void BubbleSeries_Loaded(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            List<FinancialStuff> financialStuffList = new List<FinancialStuff>();
            financialStuffList.Add(new FinancialStuff() { Name = "Windows Phone", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Apple", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Sony", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "Samsung", Amount = rand.Next(0, 200) });

            var bubble = (BubbleSeries)sender;
            bubble.ItemsSource = financialStuffList;
        }
    }
}
