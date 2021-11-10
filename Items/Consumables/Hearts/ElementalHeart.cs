using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHeartsMod.Items.Consumables.Hearts
{
    public abstract class ElementalHeart : ModItem
    {
        public string TexturePath;
        public override string Texture => TexturePath;

        public int hpIncrease;
        public int trackerValue;

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && trackerValue <
                   ModContent.GetInstance<EHConfig>().MaxHearts;
        }

        public override bool? UseItem(Player player)
        {
            player.statLifeMax2 += hpIncrease;
            player.statLife += hpIncrease;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(hpIncrease, true);
            }
            trackerValue += 1;

            return true;
        }

        public void PotentialHPDisplay()
        {
            //Make UI next to heart amount that shows how much hp this will raise by.
        }
    }
}