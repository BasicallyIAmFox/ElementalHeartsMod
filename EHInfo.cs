using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ElementalHeartsMod
{

    class EHInfo : InfoDisplay
    {
        public override void SetStaticDefaults()
        {
            InfoName.SetDefault("Elemental Hearts Bonus HP");
        }

        public override bool Active()
        {
            return ModContent.GetInstance<EHConfig>().EHInfoEnabled;
        }

        public override string DisplayValue()
        {
            int bonusHPTotal = 0;
            if (Main.LocalPlayer.GetModPlayer<EHTracker>().used.Count > 1)
            {
                foreach (KeyValuePair<string, int> usedEH in Main.LocalPlayer.GetModPlayer<EHTracker>().used)
                {
                    bonusHPTotal += usedEH.Value;
                }
            }

            return $"+{bonusHPTotal}";
        }
    }
}