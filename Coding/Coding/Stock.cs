using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class Stock
    {
        public static double MaxProfitNonDayTrade(double[] prices)
        {
            int minIndex = 0;
            double maxProfit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if(prices[i] < prices[minIndex])
                {
                    minIndex = i;
                }

                double profit = prices[i] - prices[minIndex];
                if(profit > maxProfit)
                {
                    maxProfit = profit;
                }
            }
            return maxProfit;
        }

        public static double MaxProfitDayTradeOncePerDay(double[] prices)
        {
            double accumulativeProfits = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                if (prices[i] < prices[i + 1])
                {
                    accumulativeProfits += (prices[i + 1] - prices[i]);
                }
            }

            return accumulativeProfits;
        }


        public static void TestMaxProfit()
        {
            double[] prices = new double[] { 1.1, 2.2, 3, 2, 1, 5, 6, 4, 8, 20, 5, 2, 1, 0.5 };
            Console.WriteLine(MaxProfitNonDayTrade(prices));
            Console.WriteLine(MaxProfitDayTradeOncePerDay(prices));
        }

    }
}
