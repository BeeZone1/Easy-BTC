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
    partial class MainWindow
    {
        List<TokenDataRow> dataTableBittrex = new List<TokenDataRow>();
        List<TokenDataRow> dataTableBittrexTemp = new List<TokenDataRow>();
        LogStruct[,] history30minArrB = new LogStruct[2000, 300];
        static int indexHistoryB;
        SortingTime btnSortBittrex = SortingTime.min5;
        SucessClass sucessBittrex = new SucessClass();

        private void RefillBittrex()
        {
            dataTableBittrex.Clear();
            dataTableBittrexTemp.Clear();
            commonBittrexDataGrid.ItemsSource = null;
            commonBittrexDataGrid.Items.Clear();

            using (var client = new WebClient())
            {
                string s = client.DownloadString("https://bittrex.com/api/v1.1/public/getmarketsummaries");
                dynamic d = JsonConvert.DeserializeObject(s);
                JObject jObj = (JObject)d;

                int indexTemp = 0;
                foreach (JToken result in jObj["result"])
                {
                    string[] subStr = result["MarketName"].ToString().Split('-');
                    if(subStr[0] == "BTC" || subStr[0] == "USDT")
                    {
                        TokenDataRow dataRow = new TokenDataRow();
                        if (subStr[0] == "USDT")
                        {
                            subStr[1] += "$";
                        }
                        dataRow.Name = subStr[1];
                        dataRow.CurrentPrice = result["Last"].ToObject<decimal>();
                        dataRow.Low24hr = result["Low"].ToObject<decimal>();

                        if (!flag30min)
                        {
                            if (indexHistoryB >= 300 / interval && indexHistoryB < 900 / interval)
                            {
                                dataRow.PercentChange5min = ChangeColorFormulaB(dataRow.CurrentPrice, 300 / interval, indexTemp);
                            }
                            else if (indexHistoryB >= 900 / interval && indexHistoryB <= 1800 / interval)
                            {
                                dataRow.PercentChange5min = ChangeColorFormulaB(dataRow.CurrentPrice, 300 / interval, indexTemp); ;
                                dataRow.PercentChange15min = ChangeColorFormulaB(dataRow.CurrentPrice, 900 / interval, indexTemp); ;
                            }
                        }
                        else
                        {
                            dataRow.PercentChange5min = ChangeColorFormulaB(dataRow.CurrentPrice, 300 / interval, indexTemp); ;
                            dataRow.PercentChange15min = ChangeColorFormulaB(dataRow.CurrentPrice, 900 / interval, indexTemp); ;
                            dataRow.PercentChange30min = ChangeColorFormulaB(dataRow.CurrentPrice, 1800 / interval, indexTemp); ;
                        }
                        dataTableBittrex.Add(dataRow);
                        indexTemp++;
                    }
                }
            }
        }

        /// <summary>
        /// Формула изменения цвета ячеек
        /// </summary>
        /// <param name="currPrice"></param>
        /// <param name="mins"></param>
        /// <param name="indexTemp"></param>
        /// <returns></returns>
        private decimal ChangeColorFormulaB(decimal currPrice, int ticks, int indexTemp)
        {
            if (indexHistoryB - ticks >= 0)
                return (currPrice / history30minArrB[indexHistoryB - ticks, indexTemp].currentPrice - 1) * 100;
            else
                return (currPrice / history30minArrB[1800 / interval + indexHistoryB - ticks, indexTemp].currentPrice - 1) * 100;
        }


        /// <summary>
        /// Фильтр по названию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_TextChangedB(object sender, TextChangedEventArgs e)
        {
            //CollectionViewSource.GetDefaultView(commonBittrexDataGrid.ItemsSource).Refresh();
        }

        /// <summary>
        /// Сортировка по столбцам битрекс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CheckedB(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            switch (pressed.Content.ToString())
            {
                case "5min":
                    btnSortBittrex = SortingTime.min5;
                    break;
                case "15min":
                    btnSortBittrex = SortingTime.min15;
                    break;
                case "30min":
                    btnSortBittrex = SortingTime.min30;
                    break;
                default:
                    break;
            }
        }

        private void ChangeRowBittrex()
        {
            foreach (var item in dataTableBittrex)
            {
                item.TriggerColor5min = ChangeRowColorBittrex(item.PercentChange5min, item.TriggerColor5min, item.Name);
                item.TriggerColor15min = ChangeRowColorBittrex(item.PercentChange15min, item.TriggerColor15min, item.Name);
                item.TriggerColor30min = ChangeRowColorBittrex(item.PercentChange30min, item.TriggerColor30min, item.Name);

                if (item.CurrentPrice < item.Low24hr)
                {
                    SucessClass sucess = new SucessClass();
                    sucess.Name = item.Name;
                    sucess.Percent = "LOW24";
                    sucess.DateTimeCell = DateTime.Now.ToLongTimeString();
                    successPoloniexDataGrid.Items.Insert(0, sucess);
                }
            }
        }

        private Triggers ChangeRowColorBittrex(decimal percent, Triggers triggerColor, string coinName)
        {
            if (percent <= -50)
            {
                triggerColor = Easy_BTC.Triggers.Green;
                SucessClass sucess = new SucessClass();
                sucess.Name = coinName;
                sucess.Percent = percent.ToString("F2");
                sucess.DateTimeCell = DateTime.Now.ToLongTimeString();
                successBittrexDataGrid.Items.Insert(0, sucess);
            }
            else if (percent > -50 && percent <= 3)
                triggerColor = Easy_BTC.Triggers.Red;
            else if (percent > 3 && percent <= 8)
                triggerColor = Easy_BTC.Triggers.Orange;
            else if (percent > 8)
            {
                triggerColor = Easy_BTC.Triggers.Green;
                SucessClass sucess = new SucessClass();
                sucess.Name = coinName;
                sucess.Percent = percent.ToString("F2");
                sucess.DateTimeCell = DateTime.Now.ToLongTimeString();
                successBittrexDataGrid.Items.Insert(0, sucess);
            }
            return triggerColor;
        }
    }
}
