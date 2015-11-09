using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restBing.Models
{
    public class tickerStore
    {
        double[] price;
        int priceIdx;
        string ticker;
        double highBB;
        double lowBB;
        public tickerStore(string stock)
        {
            price = new double[21];
            priceIdx = 0;
            this.ticker = stock;
        }
        public void add(double close, out bool u, out bool l)
        {
            price[priceIdx] = close;
            priceIdx++;
            if (priceIdx >= 21) priceIdx = 0;
            double ma = price.Average();
            double bb = compute2ndStdDev();
            highBB = close + bb;
            lowBB = close - bb;

            // Set flags for outside the 2 standard deviation area
            u = false;
            l = false;
            if (close < lowBB) l = true;
            if (close > highBB) u = true;
        }
        public double compute2ndStdDev()
        {
            double ma = price.Average();
            double sumOfSquaresOfDifferences = price.Select(val => (val - ma) * (val - ma)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / price.Length);
            return sd * 2;
        }

    }
    public class stdDev
    {
        List<double> price;
        public stdDev()
        {
            price = new List<double>();
        }
        public bool addPrice(double close)
        {

        }

    }
}