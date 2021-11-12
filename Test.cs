using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHeartsMod
{
    public class Test : ModItem
    {
        public Test(string name, string tag, int bonus, int rarity, string texturePath)
        {
            string name1 = name;
            string tag1 = tag;
            int bonus1 = bonus;
            int rarity1 = rarity;
            string texturePath1 = texturePath;
        }

        public string name1 = "Test";
        public string tag1 = "test";
        public int bonus1 = 1;
        public int rarity1 = 1;

        public string texturePath1 = "ElementalHeartsMod/Test1"; public override string Texture => texturePath1;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by " + bonus1);
            DisplayName.SetDefault(name1);
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.rare = rarity1;
        }

        public override bool? UseItem(Player player)
        {
            player.statLifeMax2 += bonus1;
            player.statLife += bonus1;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(bonus1, true);
            }

            if (player.GetModPlayer<EHTracker>().used.ContainsKey(tag1))
            {
                player.GetModPlayer<EHTracker>().used[tag1] += 1;
            }
            else
            {
                player.GetModPlayer<EHTracker>().used.Add(tag1, 1);
            }

            return true;
        }

        public override void HoldItem(Player player)
        {
            //Make UI next to heart amount that shows how much hp this will raise by.

            if (player.GetModPlayer<EHTracker>().used.ContainsKey(tag1))
            {
                Main.NewText(player.GetModPlayer<EHTracker>().used[tag1]);
            }
        }
    }
}