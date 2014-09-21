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

        // •给定一个数组prices，表示第 i 天的股价，你每天都可以进行一次交易（买入或卖出一股），请确定买入和卖出的时机，使收益最大。
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

        // •给定一个数组prices，表示第 i 天的股价，你只能依次进行两次交易（买入-卖出-买入-卖出），请确定买入和卖出的时机，使收益最大。
        public static double LimitedMaxProfitTrader(double[] prices)
        {
            // This is the  O(n^2) solution. 
            double maxProfit = 0;
            List<double> subPrices = new List<double>();
            List<double> subPrices2 = new List<double>(prices);
            
            for(int i = 0 ; i < prices.Length; i++)
            {
                subPrices.Add(prices[i]);
                subPrices2.Remove(prices[i]);
                double profit1 = MaxProfitNonDayTrade(subPrices.ToArray());
                double profit2 = MaxProfitNonDayTrade(subPrices2.ToArray());

                if (profit1 + profit2 > maxProfit)
                {
                    maxProfit = profit2 + profit1;
                }
            }

            return maxProfit; ;
        }

        public static double LimitedMaxProfitTraderON(double[] prices)
        {
            // This is the O(n) solution.
            double maxProfit = 0;
            double[] maxFromStart = new double[prices.Length];
            double[] maxFromEnd = new double[prices.Length];
            int minIndex = 0; 

            for(int i = 0; i < prices.Length; i++)
            {
                if(prices[i] - prices[minIndex] > maxProfit)
                {
                    maxProfit = prices[i] - prices[minIndex];
                }

                if (prices[i] < prices[minIndex])
                {
                    minIndex = i;
                }

                maxFromStart[i] = (maxProfit);
            }

            int maxIndex = prices.Length - 1;
            maxProfit = 0;
            for (int i = prices.Length - 1; i >= 0; i--)
            {
                if (prices[maxIndex] - prices[i] > maxProfit)
                {
                    maxProfit = prices[maxIndex] - prices[i];
                }

                if (prices[i] > prices[maxIndex])
                {
                    maxIndex = i;
                }

                maxFromEnd[i]= (maxProfit);
            }

            maxProfit = 0;
            for(int i = 0; i < maxFromEnd.Length; i++)
            {
                maxProfit = (maxFromStart[i] + maxFromEnd[i]) > maxProfit ? maxFromStart[i] + maxFromEnd[i] : maxProfit;
            }

            return maxProfit;
        }

        public static void TestMaxProfit()
        {
            double[] prices = new double[] { 1.1, 2.2, 3, 2, 1, 5, 6, 4, 8, 20, 5, 2, 1, 0.5 };
            Console.WriteLine(MaxProfitNonDayTrade(prices));
            Console.WriteLine(MaxProfitDayTradeOncePerDay(prices));

            Console.WriteLine(LimitedMaxProfitTrader(prices));
            Console.WriteLine(LimitedMaxProfitTraderON(prices));
        }

    }
}
