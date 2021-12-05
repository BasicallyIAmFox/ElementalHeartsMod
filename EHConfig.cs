using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ElementalHeartsMod
{
    [Label("Settings")]
    public class EHConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("Settings")]
        [DefaultValue(1)]
        [ReloadRequired]
        [Label("Max Heart Consumption (Default: 1)")]
        public int MaxHearts;
        [DefaultValue(true)]
        [Label("Enable Consumption Effect (Default: True)")]
        public bool EHWaveEnabled;
        [DefaultValue(false)]
        [Label("Show Bonus HP Info (Default: False)")]
        public bool EHInfoEnabled;
    }
}