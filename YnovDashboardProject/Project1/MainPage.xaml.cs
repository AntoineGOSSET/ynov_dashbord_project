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
        }
        

        private void NbCustomersByCountry_Loaded(object sender, RoutedEventArgs e)
        {

            YnovServiceClient c = new YnovServiceClient();
            ObservableCollection<CompteurPays> nbCustomers = new ObservableCollection<CompteurPays>();
            nbCustomers = c.GetNbCustomersByCountryAsync().Result;

            List<FinancialStuff> financialStuffList = new List<FinancialStuff>();

            for(var i=0; i<5; i++)
            {
                financialStuffList.Add(new FinancialStuff() { Name = nbCustomers[i].Pays, Amount = nbCustomers[i].Nbr });
            }

            var pie = (PieSeries)sender;
            pie.ItemsSource = financialStuffList;

        }
        

        private void NbCommandsByCustomers_Loaded(object sender, RoutedEventArgs e)
        {

            YnovServiceClient c = new YnovServiceClient();
            ObservableCollection<Nb> NbCommands = new ObservableCollection<Nb>();
            NbCommands = c.GetNbCommandsByCustomersAsync().Result;

            List<FinancialStuff> financialStuffList = new List<FinancialStuff>();

            for (var i = 0; i < 5; i++)
            {
                financialStuffList.Add(new FinancialStuff() { Name = NbCommands[i].FullName, Amount = NbCommands[i].Count });
            }

            var bar = (BarSeries)sender;
            bar.ItemsSource = financialStuffList;

        }

        private void TotalSpendByCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            YnovServiceClient c = new YnovServiceClient();
            ObservableCollection<TotalSpend> TotalSpend = new ObservableCollection<TotalSpend>();
            TotalSpend = c.GetTotalSpendByCustomersAsync().Result;

            List<FinancialStuff> financialStuffList = new List<FinancialStuff>();

            for (var i = 0; i < 5; i++)
            {
                financialStuffList.Add(new FinancialStuff() { Name = TotalSpend[i].FullName, Amount = (int)TotalSpend[i].Amount });
            }

            var column = (ColumnSeries)sender;
            column.ItemsSource = financialStuffList;
        }
    }
}
