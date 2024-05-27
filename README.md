# OrderFlowBot DataBars

This repository holds the custom data bars. The purpose is to extract it so it can be easier to maintain and used in other custom applications.

Copy

```
- OrderFlowBot.DataBar into AddOns/OrderFlowBot
- DataBar into AddOns/OrderFlowBot
```

Declare

```
namespace NinjaTrader.NinjaScript.Strategies
{
    public static class GroupConstants
    {
        public const string GROUP_NAME_DATA_BAR = "Data Bar";
    }

    [Gui.CategoryOrder(GroupConstants.GROUP_NAME_DATA_BAR, 1)]
    public partial class OrderFlowBot : Strategy
    {
        private OrderFlowBotDataBars _dataBars;
        ...
    }
    ...
}
```

DataBar properties

```
#region DataBar Properties

[NinjaScriptProperty]
[Display(Name = "Min Look Back Bars", Description = "The minimum bars to look back. This should be equal to or higher than and period to look back", Order = 0, GroupName = GroupConstants.GROUP_NAME_DATA_BAR)]
public int MinLookBackBars { get; set; }

[NinjaScriptProperty]
[Display(Name = "Imbalance Ratio", Description = "The minimum imbalance ratio.", Order = 1, GroupName = GroupConstants.GROUP_NAME_DATA_BAR)]
public double ImbalanceRatio { get; set; }

[NinjaScriptProperty]
[Display(Name = "Stacked Imbalance", Description = "The minimum number for a stacked imbalance.", Order = 2, GroupName = GroupConstants.GROUP_NAME_DATA_BAR)]
public int StackedImbalance { get; set; }

[NinjaScriptProperty]
[Display(Name = "Valid Imbalance Volume", Description = "The minimum number of volume for a valid imbalance.", Order = 3, GroupName = GroupConstants.GROUP_NAME_DATA_BAR)]
public long ValidImbalanceVolume { get; set; }

[NinjaScriptProperty]
[Display(Name = "Valid Exhaustion Ratio", Description = "The valid exhaustion ratio for comparing top and bottom.", Order = 4, GroupName = GroupConstants.GROUP_NAME_DATA_BAR)]
public double ValidExhaustionRatio { get; set; }

[NinjaScriptProperty]
[Display(Name = "Valid Absorption Ratio", Description = "The valid absorption ratio for comparing top and bottom.", Order = 5, GroupName = GroupConstants.GROUP_NAME_DATA_BAR)]
public double ValidAbsorptionRatio { get; set; }

[NinjaScriptProperty]
[Display(Name = "Valid Volume Sequencing", Description = "The valid number of price to check for volume sequencing.", Order = 6, GroupName = GroupConstants.GROUP_NAME_DATA_BAR)]
public int ValidVolumeSequencing { get; set; }

[NinjaScriptProperty]
[Display(Name = "Valid Volume Sequencing Minimum Volume", Description = "The valid number of volume to check for volume sequencing.", Order = 7, GroupName = GroupConstants.GROUP_NAME_DATA_BAR)]
public long ValidVolumeSequencingMinimumVolume { get; set; }

#endregion
```

Set State.DataLoaded

```
else if (State == State.DataLoaded)
{
     _dataBars = new OrderFlowBotDataBars(
        new OrderFlowBotDataBarConfigValues
        {
            TickSize = TickSize,
            MinLookBackBars = MinLookBackBars,
            ImbalanceRatio = ImbalanceRatio,
            StackedImbalance = StackedImbalance,
            ValidImbalanceVolume = ValidImbalanceVolume,
            ValidExhaustionRatio = ValidExhaustionRatio,
            ValidAbsorptionRatio = ValidAbsorptionRatio,
            ValidVolumeSequencing = ValidVolumeSequencing,
            ValidVolumeSequencingMinimumVolume = ValidVolumeSequencingMinimumVolume
        }
    );
}
```

Set State.Defaults

```
if (State == State.SetDefaults)
{
    ...

    // DataBar
    MinLookBackBars = 20;
    ImbalanceRatio = 1.5;
    StackedImbalance = 3;
    ValidImbalanceVolume = 10;
    ValidExhaustionRatio = 15;
    ValidAbsorptionRatio = 1.4;
    ValidVolumeSequencing = 4;
    ValidVolumeSequencingMinimumVolume = 500;
}
```

Include in OnBarUpdate

```
protected override void OnBarUpdate()
{
    // Include all look back bars
    if (CurrentBar < MinLookBackBars)
        return;

    if (IsFirstTickOfBar)
    {
        // Ensure we are setting the last bar in bars with the completed previous data
        _dataBars.SetOrderFlowDataBarBase(GetOrderFlowDataBarBase(1));
        _dataBars.UpdateDataBars();
    }

    _dataBars.SetOrderFlowDataBarBase(GetOrderFlowDataBarBase(0));
    _dataBars.SetCurrentDataBar();
}
```
