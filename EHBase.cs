using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHeartsMod
{
    public abstract class EHBase : ModItem
    {
        public string name; 
        public string tag;
        public int bonus;
        public int rarity;

        public string texturePath; public override string Texture => texturePath;

        public override bool CanUseItem(Player player)
        {
            return player.GetModPlayer<EHTracker>().used[tag] < ModContent.GetInstance<EHConfig>().MaxHearts;
        }

        public override bool? UseItem(Player player)
        {
            player.statLifeMax2 += bonus;
            player.statLife += bonus;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(bonus, true);
            }

            if (player.GetModPlayer<EHTracker>().used.ContainsKey(tag))
            {
                player.GetModPlayer<EHTracker>().used[tag] += 1;
            }
            else
            {
                player.GetModPlayer<EHTracker>().used.Add(tag, 1);
            }

            return true;
        }
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by " + bonus + ".");
            DisplayName.SetDefault(name);
        }
        public override void SetDefaults()
        {
            Item.rare = rarity;
        }

        public override void UpdateInventory(Player player)
        {
            //Make UI next to heart amount that shows how much hp this will raise by.

            Main.NewText(player.GetModPlayer<EHTracker>().used[tag]);
        }
    }
}