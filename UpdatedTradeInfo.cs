using System;
using System.Collections.Generic;
using System.Linq;

namespace StockTrader
{
    public class UpdatedTradeInfo
    {
        public string Symbol { get; set; }
        public double MaxTimeGap { get; set; }
        public int Volume { get; set; }
        public double WeightedAvgPrice { get; set; }
        public int MaxPrice { get; set; }
        public double PreviousTime { get; set; }

        public UpdatedTradeInfo(string symbol, double maxTimeGap, int volume, double weightedAvgPrice, int maxPrice, double previousTime)
        {
            Symbol = symbol;
            MaxTimeGap = maxTimeGap;
            Volume = volume;
            WeightedAvgPrice = weightedAvgPrice;
            MaxPrice = maxPrice;
            PreviousTime = previousTime;

        }

        public static string GetHeaderInfo()
        {
            return $"{nameof(Symbol)}, {nameof(MaxTimeGap)}, {nameof(Volume)}, {nameof(WeightedAvgPrice)}, {nameof(MaxPrice)}";
        }

        public string GetString()
        {
            return Symbol + ", " + MaxTimeGap + ", " + Volume
                        + "," + Convert.ToInt32(Math.Truncate(WeightedAvgPrice)) + "," + MaxPrice;
        }

        public void Calculations(TradeInfo trade)
        {
            SetMaxPrice(trade.Price);
            SetMaxTimeGap(trade.TimeStamp);
            SetWeightAveragePrice(trade.Quantity, trade.Price);
            SetVolume(trade.Quantity);
        }

        private void SetMaxPrice(int price)
        {
            if (price > MaxPrice)
            {
                MaxPrice = price;
            }
        }

        private void SetMaxTimeGap(double timeStamp)
        {
            double tempTimeGap = timeStamp - PreviousTime;
            if (tempTimeGap > MaxTimeGap)
            {
                MaxTimeGap = tempTimeGap;
            }

            PreviousTime = timeStamp;

        }

        private void SetWeightAveragePrice(int quantity, int price)
        {
            WeightedAvgPrice = ((quantity * price) + (Volume * WeightedAvgPrice)) / (quantity + Volume);

        }

        private void SetVolume(int quantity)
        {
            Volume += quantity;
        }
    }
}
