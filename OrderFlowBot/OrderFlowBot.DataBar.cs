using NinjaTrader.Custom.AddOns.OrderFlowBot.DataBar;
using System;
using System.Collections.Generic;

namespace NinjaTrader.NinjaScript.Strategies
{
    // Set custom values that needs to access NinjaScript methods since it gives issues when extending elsewhere
    public partial class OrderFlowBot : Strategy
    {
        private OrderFlowDataBarBase GetOrderFlowDataBarBase(int barsAgo)
        {
            NinjaTrader.NinjaScript.BarsTypes.VolumetricBarsType volumetricBar = Bars.BarsSeries.BarsType as NinjaTrader.NinjaScript.BarsTypes.VolumetricBarsType;

            OrderFlowDataBarBase baseBar = new OrderFlowDataBarBase
            {
                VolumetricBar = volumetricBar,
                BarsAgo = barsAgo,
                Time = ToTime(Time[barsAgo]),
                CurrentBar = CurrentBar,
                High = High[barsAgo],
                Low = Low[barsAgo],
                Open = Open[barsAgo],
                Close = Close[barsAgo]
            };

            PopulateBaseATR(baseBar);

            return baseBar;
        }

        private void PopulateBaseATR(OrderFlowDataBarBase baseBar)
        {
            if (CurrentBar < ATRPeriod)
            {
                return;
            }

            List<double> atrs = new List<double>();

            for (int i = 0; i < ATRMedianPeriod; i++)
            {
                atrs.Add(Math.Round(ATR(ATRPeriod)[i], 2));
            }

            baseBar.ATRList = atrs;
            baseBar.ATRCurrent = Math.Round(ATR(ATRPeriod)[baseBar.BarsAgo], 2);
        }
    }
}
