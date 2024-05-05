using NinjaTrader.NinjaScript.AddOns.OrderFlowBot;

namespace NinjaTrader.NinjaScript.Strategies
{
    // Add to OrderFlowBot directory for debugging or verification
    public partial class OrderFlowBot : Strategy
    {
        public void PrintDataBar(OrderFlowBotDataBar dataBar)
        {

            Print(string.Format("{0}", ToDay(Time[0])));
            Print(string.Format("Time: {0}", dataBar.Time));
            Print(string.Format("Bar Number: {0}", dataBar.BarNumber));

            /*
            Print(string.Format("Bar Type: {0}", dataBar.BarType));

            Print(string.Format("High: {0}", dataBar.Prices.High));
            Print(string.Format("Low: {0}", dataBar.Prices.Low));
            Print(string.Format("Open: {0}", dataBar.Prices.Open));
            Print(string.Format("Close: {0}", dataBar.Prices.Close));

            Print(string.Format("Volume: {0}", dataBar.Volumes.Volume));
            
            Print(string.Format("BuyingVolume: {0}", dataBar.Volumes.BuyingVolume));
            Print(string.Format("AskSinglePrint: {0}", dataBar.Volumes.HasAskSinglePrint));
            Print(string.Format("BidSinglePrint: {0}", dataBar.Volumes.HasBidSinglePrint));
            Print(string.Format("SellingVolume: {0}", dataBar.Volumes.SellingVolume));
            Print(string.Format("PointOfControl: {0}", dataBar.Volumes.PointOfControl));
            foreach (var kvp in dataBar.Volumes.BidAskVolumes)
            {
                Print(string.Format("{0} : {1}", kvp.BidVolume, kvp.AskVolume));
            }
            
            Print(string.Format("Value Area High: {0}", dataBar.Volumes.ValueAreaHighPrice));
            Print(string.Format("Value Area Low: {0}", dataBar.Volumes.ValueAreaLowPrice));

            Print(string.Format("Bid Ratio: {0}", dataBar.Ratios.BidRatio));
            Print(string.Format("Valid Bid Ratio: {0}", dataBar.Ratios.HasValidBidExhaustionRatio));
            Print(string.Format("Ask Ratio: {0}", dataBar.Ratios.AskRatio));
            Print(string.Format("Valid Ask Ratio: {0}", dataBar.Ratios.HasValidAskExhaustionRatio));
            Print(string.Format("Last Valid Bid Ratio Price: {0}", dataBar.Ratios.LastValidBidRatioPrice));
            Print(string.Format("Last Valid Ask Ratio Price: {0}", dataBar.Ratios.LastValidAskRatioPrice));

            Print(string.Format("Delta: {0}", dataBar.Deltas.Delta));
            Print(string.Format("Min Delta: {0}", dataBar.Deltas.MinDelta));
            Print(string.Format("Max Delta: {0}", dataBar.Deltas.MaxDelta));
            Print(string.Format("Cumulative Delta: {0}", dataBar.Deltas.CumulativeDelta));
            Print(string.Format("Delta Percentage: {0}", dataBar.Deltas.DeltaPercentage));
            Print(string.Format("MinMax Delta %: {0}", dataBar.Deltas.MinMaxDeltaRatio));
            Print(string.Format("MaxMin Delta %: {0}", dataBar.Deltas.MaxMinDeltaRatio));
            Print(string.Format("Delta Change: {0}", dataBar.Deltas.DeltaChange));

            Print("Bid Imbalances");
            Print("[");
            foreach (var kvp in dataBar.Imbalances.BidImbalances)
            {
                Print(string.Format("{0} : {1}", kvp.Price, kvp.Volume));
            }
            Print("]");
            Print("Ask Imbalances");
            Print("[");
            foreach (var kvp in dataBar.Imbalances.AskImbalances)
            {
                Print(string.Format("{0} : {1}", kvp.Price, kvp.Volume));
            }
            Print("]");
            
            Print(string.Format("Current ATR: {0}", dataBar.ATR.Current));
            Print(string.Format("Previous Median ATR: {0}", dataBar.ATR.Median));
            Print(string.Format("HighPlusMedianATR ATR: {0}", dataBar.ATR.HighPlusMedianATR));
            Print(string.Format("LowMinusMedianATR ATR: {0}", dataBar.ATR.LowMinusMedianATR));
            Print(string.Format("HighLowMedianATR ATR: {0}", dataBar.ATR.HighLowMedianATR));
            Print(string.Format("UpperRange ATR: {0}", dataBar.ATR.UpperRange));
            Print(string.Format("LowerRange ATR: {0}", dataBar.ATR.LowerRange));
            */

            Print("\n");
        }
    }
}
