using System.Collections.Generic;

namespace NinjaTrader.Custom.AddOns.OrderFlowBot.DataBar.Dependencies
{
    public class OrderFlowBotATR
    {
        public double ATRMultiplier { get; set; }
        public double RangePercentage { get; set; }
        public double Current { get; set; }
        public double Median { get; set; }
        public double HighPlusMedianATR { get; set; }
        public double LowMinusMedianATR { get; set; }
        public double HighLowMedianATR { get; set; }
        public double UpperRange { get; private set; }
        public double LowerRange { get; private set; }

        public void SetMedianATR(List<double> atrs)
        {
            if (atrs == null || atrs.Count == 0)
            {
                return;
            }

            atrs.Sort();

            int midIndex = atrs.Count / 2;

            if (atrs.Count % 2 == 0)
            {
                Median = (atrs[midIndex - 1] + atrs[midIndex]) / 2.0;
            }
            else
            {
                Median = atrs[midIndex];
            }
        }

        private void UpdateRanges()
        {
            double range = HighPlusMedianATR - LowMinusMedianATR;
            UpperRange = HighPlusMedianATR - range * (RangePercentage / 100);
            LowerRange = LowMinusMedianATR + range * (RangePercentage / 100);
        }

        public void SetPrices(double high, double low)
        {
            // Update only if current high breaks previous HighPlusMedianATR
            // or if current low breaks previous LowMinusMedianATR
            if (high > HighPlusMedianATR || low < LowMinusMedianATR)
            {
                double highPlusMedianATR = high + (Median * ATRMultiplier);
                double lowMinusMedianATR = low - (Median * ATRMultiplier);

                HighPlusMedianATR = highPlusMedianATR;
                LowMinusMedianATR = lowMinusMedianATR;
                // Since we only have two numbers
                HighLowMedianATR = (highPlusMedianATR + lowMinusMedianATR) / 2;

                UpdateRanges();
            }
        }
    }
}
