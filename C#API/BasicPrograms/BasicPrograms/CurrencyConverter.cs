using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPrograms
{
    internal class CurrencyConverter
    {
        
            public double Convert(string fromCurrency, string toCurrency, double amount)
            {
                double rate = GetRate(fromCurrency, toCurrency);
                return amount * rate;
            }

            private static double GetRate(String fromCurrency, string toCurrency)
            {
              
                switch (fromCurrency + toCurrency)
                {
                    case "USDINR":
                    return 74.35;
                    case "INRUSD":
                    return 0.013;
                    case "USDEUR":
                    return 0.84;
                    case "EURUSD":
                    return 1.19;
                    case "INREUR":
                    return 0.008;
                    case "EURINR":
                    return 125.06;
                    default:
                    Console.WriteLine("Invalid currency pair: {from}/{to}");
                    return 0;
                    
                }
            }
       
    }
}
