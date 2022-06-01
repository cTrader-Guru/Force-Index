/*  CTRADER GURU --> Indicator Template 1.0.6

    Homepage    : https://ctrader.guru/
    Telegram    : https://t.me/ctraderguru
    Twitter     : https://twitter.com/cTraderGURU/
    Facebook    : https://www.facebook.com/ctrader.guru/
    YouTube     : https://www.youtube.com/channel/UCKkgbw09Fifj65W5t5lHeCQ
    GitHub      : https://github.com/ctrader-guru

*/

using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.Indicators;

namespace cAlgo
{

    [Indicator(IsOverlay = false, TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    [Levels(0)]
    public class ForceIndex : Indicator
    {

        #region Identity

        public const string NAME = "Force Index";

        public const string VERSION = "1.0.4";

        #endregion

        #region Params

        [Parameter(NAME + " " + VERSION, Group = "Identity", DefaultValue = "https://www.google.com/search?q=ctrader+guru+force+index")]
        public string ProductInfo { get; set; }

        [Parameter("Period", Group = "Params", DefaultValue = 14, MinValue = 1, Step = 1)]
        public int Period { get; set; }

        [Output("Main", LineColor = "DodgerBlue")]
        public IndicatorDataSeries Result { get; set; }

        #endregion

        #region Indicator Events

        protected override void Initialize()
        {

            Print("{0} : {1}", NAME, VERSION);

        }

        public override void Calculate(int index)
        {

            Result[index] = Bars.TickVolumes[index] * (Bars.ClosePrices[index] - Bars.ClosePrices[index - Period]);

        }

        #endregion

    }

}
