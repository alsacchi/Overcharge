

using Exiled.API.Interfaces;
using System.ComponentModel;

namespace OverchargePlugin {

    public sealed class Config : IConfig {
        public bool IsEnabled { get; set; } = true;

        [Description("overchargeTimer is the minimun time every overcharge! The maximum time is overchargeTimer * 4")]
        public int overchargeTimer { get; set; } = 5;
        
        [Description("overchargeDurationMin is the minumum duration of the overcharge")]
        public int overchargeDurationMin { get; set; } = 10;

        [Description("overchargeDurationMax is the maximum duration of the overcharge")]
        public int overchargeDurationMax { get; set; } = 90;

    }
}