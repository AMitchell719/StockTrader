using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace StockTrader
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            var stockData = new List<UpdatedTradeInfo>();

            using (StreamReader inputFile = new StreamReader(args[0]))
            {

                while ((line = inputFile.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    var stock = new TradeInfo(double.Parse(values[0]), values[1], int.Parse(values[2]), int.Parse(values[3]));


                    if (!stockData.Any(x => x.Symbol.Equals(stock.Symbol)))
                    {
                        var updatedStock = new UpdatedTradeInfo(stock.Symbol, 0, stock.Quantity, stock.Price, stock.Price, stock.TimeStamp);
                        stockData.Add(updatedStock);
                    }
                    else
                    {
                        var updatedStock = stockData.FirstOrDefault(x => x.Symbol.Equals(stock.Symbol));

                        updatedStock.Calculations(stock);

                    }

                }
            }

            // Sort the list of stocks
            stockData = stockData.OrderBy(x => x.Symbol).ToList();

            using (StreamWriter outputFile = new StreamWriter(args[1]))
            {
                // Header
                outputFile.WriteLine(UpdatedTradeInfo.GetHeaderInfo());

                // Write each stock one line at a time
                foreach(var stock in stockData)
                {
                    outputFile.WriteLine(stock.GetString());
                }

            }
        }
    }
}
