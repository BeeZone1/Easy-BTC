using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_BTC
{
    class TokenDataRow
    {

        public TokenDataRow(string Name, decimal Low24hr, decimal PercentChangePoloniex, decimal CurrentPrice,
                                decimal Volume5min, decimal PercentChange5min,
                                decimal Volume15min, decimal PercentChange15min,
                                decimal Volume30min, decimal PercentChange30min)
        {
            this.Name = Name;
            this.Low24hr = Low24hr;
            this.PercentChangePoloniex = PercentChangePoloniex;
            this.CurrentPrice = CurrentPrice;
            this.Volume5min = Volume5min;
            this.PercentChange5min = PercentChange5min;
            this.Volume15min = Volume15min;
            this.PercentChange15min = PercentChange15min;
            this.Volume30min = Volume30min;
            this.PercentChange30min = PercentChange30min;
        }

        public TokenDataRow()
        {
        }

        public string Name { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal Low24hr { get; set; }
        public decimal PercentChangePoloniex { get; set; }

        public decimal Volume5min { get; set; }
        public decimal PercentChange5min { get; set; }
        public Triggers TriggerColor5min { get; set; }

        public decimal Volume15min { get; set; }
        public decimal PercentChange15min { get; set; }
        public Triggers TriggerColor15min { get; set; }

        public decimal Volume30min { get; set; }
        public decimal PercentChange30min { get; set; }
        public Triggers TriggerColor30min { get; set; }
    }
    
    enum Triggers
    {
        Red,
        Orange,
        Green
    }

    public struct LogStruct
    {
        public string coinName;
        public decimal currentPrice;
    }

    enum SortingTime
    {
        min5,
        min15,
        min30
    }

    class SucessClass
    {
        public string Name { get; set; }
        public string Percent { get; set; }
        public string DateTimeCell { get; set; }
    }
}
