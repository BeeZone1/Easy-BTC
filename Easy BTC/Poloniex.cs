using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Easy_BTC
{
    partial class MainWindow : Window
    {
        List<TokenDataRow> dataTablePoloniex = new List<TokenDataRow>();
        List<TokenDataRow> dataTablePoloniexTemp = new List<TokenDataRow>();
        LogStruct[,] history30minArrP = new LogStruct[108001, 80];
        static int indexHistoryP;
        SortingTime btnSortPoloniex = SortingTime.min5;

        private void RefillPoloniex()
        {
            dataTablePoloniex.Clear();
            dataTablePoloniexTemp.Clear();
            commonPoloniexDataGrid.ItemsSource = null;
            commonPoloniexDataGrid.Items.Clear();

            using (var client = new WebClient())
            {
                string s = client.DownloadString("https://poloniex.com/public?command=returnTicker");
                dynamic d = JsonConvert.DeserializeObject(s);
                JObject jObj = (JObject)d;
                //long currentTimeUnix = DateTimeOffset.Now.ToUnixTimeSeconds();

                int indexTemp = 0;
                foreach (JProperty prop in jObj.Properties())
                {
                    string beginningToken = prop.Name.Substring(0, 3);
                    if (beginningToken == "BTC" || beginningToken == "USD")
                    {
                        TokenDataRow dataRow = new TokenDataRow();
                        string[] subStr = prop.Name.Split('_');
                        if (beginningToken == "USD")
                        {
                            subStr[1] += "$";
                        }
                        dataRow.Name = subStr[1];
                        dataRow.CurrentPrice = prop.Value["last"].ToObject<decimal>();
                        dataRow.Low24hr = prop.Value["low24hr"].ToObject<decimal>();
                        dataRow.PercentChangePoloniex = prop.Value["percentChange"].ToObject<decimal>() * 100;

                        if (indexHistoryP >= 5 && indexHistoryP < 15)
                        {
                            dataRow.PercentChange5min = ChangeColorFormulaP(dataRow.CurrentPrice, 5, indexTemp);
                        }
                        else if (indexHistoryP >= 15 && indexHistoryP < 30)
                        {
                            dataRow.PercentChange5min = ChangeColorFormulaP(dataRow.CurrentPrice, 5, indexTemp); ;
                            dataRow.PercentChange15min = ChangeColorFormulaP(dataRow.CurrentPrice, 15, indexTemp); ;
                        }
                        else if (indexHistoryP >= 30)
                        {
                            dataRow.PercentChange5min = ChangeColorFormulaP(dataRow.CurrentPrice, 5, indexTemp); ;
                            dataRow.PercentChange15min = ChangeColorFormulaP(dataRow.CurrentPrice, 15, indexTemp); ;
                            dataRow.PercentChange30min = ChangeColorFormulaP(dataRow.CurrentPrice, 30, indexTemp); ;
                        }
                        //((ArrayList)commonPoloniexListView.Resources["poloniexCommonInfoListViewData"]).Add(dataRow);
                        dataTablePoloniex.Add(dataRow);
                        indexTemp++;
                    }
                }
            }
        }


        /// <summary>
        /// Фильтр по названию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_TextChangedP(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(commonPoloniexDataGrid.ItemsSource).Refresh();
        }

        /// <summary>
        /// Сортировка по столбцам полоникс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CheckedP(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            switch (pressed.Content.ToString())
            {
                case "5min":
                    btnSortPoloniex = SortingTime.min5;
                    break;
                case "15min":
                    btnSortPoloniex = SortingTime.min15;
                    break;
                case "30min":
                    btnSortPoloniex = SortingTime.min30;
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Формула изменения цвета ячеек
        /// </summary>
        /// <param name="currPrice"></param>
        /// <param name="mins"></param>
        /// <param name="indexTemp"></param>
        /// <returns></returns>
        private decimal ChangeColorFormulaP(decimal currPrice, int mins, int indexTemp)
        {
            return 100 - currPrice * 100 / history30minArrP[indexHistoryP - mins, indexTemp].currentPrice;
        }

        private void ChangeRowPoloniex()
        {
            foreach (var item in dataTablePoloniex)
            {
                item.TriggerColor5min = ChangeRowColorPoloniex(item.PercentChange5min, item.TriggerColor5min, item.Name);
                item.TriggerColor15min = ChangeRowColorPoloniex(item.PercentChange15min, item.TriggerColor15min, item.Name);
                item.TriggerColor30min = ChangeRowColorPoloniex(item.PercentChange30min, item.TriggerColor30min, item.Name);
            }
        }

        private Triggers ChangeRowColorPoloniex(decimal percent, Triggers triggerColor, string coinName)
        {
            if (percent <= -50)
                triggerColor = Easy_BTC.Triggers.Green;
            else if (percent > -50 && percent <= 1)
                triggerColor = Easy_BTC.Triggers.Red;
            else if (percent > 1 && percent <= 8)
            {
                triggerColor = Easy_BTC.Triggers.Orange;
                SucessClass sucess = new SucessClass();
                sucess.Name = coinName;
                sucess.Percent = percent;
                sucess.DateTimeCell = DateTime.Now;
                successPoloniexDataGrid.Items.Insert(0, sucess);
            }

            else if (percent > 8)
                triggerColor = Easy_BTC.Triggers.Green;
            return triggerColor;
        }
    }
}
