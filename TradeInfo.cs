using System;

namespace StockTrader
{
    public class TradeInfo
    {
        public double TimeStamp { get; set; }
        public string Symbol { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public TradeInfo(double timeStamp, string symbol, int quantity, int price)
        {
            TimeStamp = timeStamp;
            Symbol = symbol;
            Quantity = quantity;
            Price = price;
        }

    }
}
