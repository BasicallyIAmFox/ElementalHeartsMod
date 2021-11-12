using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHeartsMod
{
    public class EHBase : ModItem
    {            
        public EHBase(string name, string tag, int bonus, int rarity, string texturePath)
        {
            this.name = name;
            this.tag = tag;
            this.bonus = bonus;
            this.rarity = rarity;
            this.texturePath = texturePath;
        }

        public string name; 
        public string tag;
        public int bonus;
        public int rarity;

        public string texturePath; public override string Texture => texturePath;

        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<EHTracker>().used.ContainsKey(tag))
            {
                return player.GetModPlayer<EHTracker>().used[tag] < ModContent.GetInstance<EHConfig>().MaxHearts;
            }
            else
            {
                return true;
            }
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
            Tooltip.SetDefault("Permanently increases maximum life by " + bonus);
            DisplayName.SetDefault(name);
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.rare = rarity;
        }
        public override void HoldItem(Player player)
        {
            //Make UI next to heart amount that shows how much hp this will raise by.

            if (player.GetModPlayer<EHTracker>().used.ContainsKey(tag))
            {
                Main.NewText(player.GetModPlayer<EHTracker>().used[tag]);
            }
        }
    }
}