using System;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHeartsMod
{
    public class EHBase : ModItem
    {
        public EHBase(int category, int station = 0, int material = 0, int rarity = -1)
        {
            if (rarity == -1)
            {
                if (material != 0)
                {
                    this.rarity = new Item(material).rare;
                }
                else
                {
                    this.rarity = 0;
                }
            }
            else
            {
                this.rarity = rarity;
            }

            this.station = station;
            this.material = material;

            name = (Regex.Replace(GetType().Name, "[A-Z]", " $0").Trim() + " Heart");

            switch (category)
            {
                case 1:
                    pathPrefix = "ElementalHeartsMod/Assets/Items/Consumables/Hearts/Boss/";
                    break;
                case 2:
                    pathPrefix = "ElementalHeartsMod/Assets/Items/Consumables/Hearts/Hardmode/";
                    break;
                case 3:
                    pathPrefix = "ElementalHeartsMod/Assets/Items/Consumables/Hearts/Other/";
                    break;
                case 4:
                    pathPrefix = "ElementalHeartsMod/Assets/Items/Consumables/Hearts/PreHardmode/";
                    break;
            }
            bonusHP = (this.rarity + 1) * 2;
            texturePath = pathPrefix + Regex.Replace(name, " ", string.Empty);

            tag = GetType().Name;
        }

        public string name; 
        public string tag;
        public int rarity; public int bonusHP;

        public int station;
        public int material;
        public int materialCost;


        public string texturePath; string pathPrefix;
        public override string Texture => texturePath;


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
            player.statLifeMax2 += bonusHP;
            player.statLife += bonusHP;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(bonusHP, true);
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
            Tooltip.SetDefault("Permanently increases maximum life by " + bonusHP);
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
        public override void AddRecipes()
        {
            if (material != 0) CreateRecipe().AddIngredient(material, CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[material]).AddTile(station).Register();
        }
    }
}