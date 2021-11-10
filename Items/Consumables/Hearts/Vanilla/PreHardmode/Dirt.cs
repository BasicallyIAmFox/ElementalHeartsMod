using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHeartsMod.Items.Consumables.Hearts.Vanilla.PreHardmode
{
    public class Dirt : ElementalHeart
    {
        public Dirt()
        {
            TexturePath = "ElementalHeartsMod/Assets/Items/Consumables/Hearts/Vanilla/PreHardmode/DirtHeart";

            hpIncrease = 1;
        }
        public override void UpdateInventory(Player player)
        {
            trackerValue = player.GetModPlayer<EHTracker>().Dirt;
            PotentialHPDisplay();
        }
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 1");
            DisplayName.SetDefault("Dirt Heart");
        }
    }
}
