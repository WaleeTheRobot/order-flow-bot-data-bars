namespace NinjaTrader.Custom.AddOns.OrderFlowBot.DataBar.Dependencies
{
    // This is intended to store values that may persist throughout many bars until updated
    public class Persistent
    {
        public double HighPlusMedianATR { get; set; }
        public double LowMinusMedianATR { get; set; }
        public double HighLowMedianATR { get; set; }
        public double UpperRange { get; private set; }
        public double LowerRange { get; private set; }

        public void ResetPersistent()
        {
            HighPlusMedianATR = 0;
            LowMinusMedianATR = 0;
            HighLowMedianATR = 0;
            UpperRange = 0;
            LowerRange = 0;
        }
    }
}
