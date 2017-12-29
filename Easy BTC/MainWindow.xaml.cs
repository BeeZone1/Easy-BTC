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
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Globalization;
using System.Windows.Threading;
using System.Timers;
using System.Threading;

namespace Easy_BTC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer UpdateTablesTimer = new DispatcherTimer();
        DispatcherTimer OneMinTimer = new DispatcherTimer();
        private bool UserFilterPoloniex(object item)
        {
            if (String.IsNullOrEmpty(txtFilterPoloniex.Text))
                return true;
            else
                return ((item as TokenDataRow).Name.IndexOf(txtFilterPoloniex.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private bool UserFilterBittrex(object item)
        {
            if (String.IsNullOrEmpty(txtFilterBittrex.Text))
                return true;
            else
                return ((item as TokenDataRow).Name.IndexOf(txtFilterBittrex.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public MainWindow()
        {
            InitializeComponent();
            indexHistoryP = 0;
            indexHistoryB = 0;
        }

        #region Таймер
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateTables(sender, e);
            UpdateTablesTimer.Interval = new TimeSpan(0, 0, 0, 1);
            UpdateTablesTimer.Tick += new EventHandler(UpdateTables);
            UpdateTablesTimer.Start();

        }
        #endregion

        private void UpdateTables(object sender, EventArgs e)
        {
            RefillPoloniex();
            ChangeRowPoloniex();
            RefillBittrex();
            ChangeRowBittrex();

            #region Logs, Sort, Filter
            //Log Poloniex
            if (indexHistoryP == 1800) indexHistoryP = 0;
            for (int i = 0; i < dataTablePoloniex.Count; i++)
            {
                history30minArrP[indexHistoryP, i].coinName = dataTablePoloniex[i].Name;
                history30minArrP[indexHistoryP, i].currentPrice = dataTablePoloniex[i].CurrentPrice;
            }
            indexHistoryP++;

            //Log Bittrex
            if (indexHistoryB == 1800) indexHistoryB = 0;
            for (int i = 0; i < dataTableBittrex.Count; i++)
            {
                history30minArrB[indexHistoryB, i].coinName = dataTableBittrex[i].Name;
                history30minArrB[indexHistoryB, i].currentPrice = dataTableBittrex[i].CurrentPrice;
            }
            indexHistoryB++;

            //Sort&Filter Poloniex
            switch (btnSortPoloniex)
            {
                case SortingTime.min5:
                    dataTablePoloniexTemp = dataTablePoloniex.OrderByDescending(i => i.PercentChange5min).ToList();
                    break;
                case SortingTime.min15:
                    dataTablePoloniexTemp = dataTablePoloniex.OrderByDescending(i => i.PercentChange15min).ToList();
                    break;
                case SortingTime.min30:
                    dataTablePoloniexTemp = dataTablePoloniex.OrderByDescending(i => i.PercentChange30min).ToList();
                    break;
                default:
                    break;
            }
            commonPoloniexDataGrid.ItemsSource = dataTablePoloniexTemp;
            CollectionView viewP = (CollectionView)CollectionViewSource.GetDefaultView(commonPoloniexDataGrid.ItemsSource);
            viewP.Filter = UserFilterPoloniex;

            //Sort&Filter Bittrex

            switch (btnSortBittrex)
            {
                case SortingTime.min5:
                    dataTableBittrexTemp = dataTableBittrex.OrderByDescending(i => i.PercentChange5min).ToList();
                    break;
                case SortingTime.min15:
                    dataTableBittrexTemp = dataTableBittrex.OrderByDescending(i => i.PercentChange15min).ToList();
                    break;
                case SortingTime.min30:
                    dataTableBittrexTemp = dataTableBittrex.OrderByDescending(i => i.PercentChange30min).ToList();
                    break;
                default:
                    break;
            }
            commonBittrexDataGrid.ItemsSource = dataTableBittrexTemp;
            CollectionView viewB = (CollectionView)CollectionViewSource.GetDefaultView(commonBittrexDataGrid.ItemsSource);
            viewB.Filter = UserFilterBittrex;
            #endregion
        }

    }
}
