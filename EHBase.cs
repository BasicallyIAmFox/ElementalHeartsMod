using System;
using System.Text.RegularExpressions;
using System.Threading;
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

            tag = Regex.Replace(GetType().Name, "[A-Z]", " $0").Trim();
            name = (tag + " Heart");

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
            bonusHP = (this.rarity + 1) * 5;
            texturePath = pathPrefix + Regex.Replace(name, " ", string.Empty);
        }

        public string tag;
        public string name;
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
                return player.GetModPlayer<EHTracker>().used[tag] < (ModContent.GetInstance<EHConfig>().MaxHearts * bonusHP);
            }
            else
            {
                return true;
            }
        }

        public override bool? UseItem(Player player)
        {
            Thread.Sleep(100);

            player.statLifeMax2 += bonusHP;
            player.statLife += bonusHP;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(bonusHP, true);
            }

            if (player.GetModPlayer<EHTracker>().used.ContainsKey(tag))
            {
                player.GetModPlayer<EHTracker>().used[tag] += bonusHP;
            }
            else
            {
                player.GetModPlayer<EHTracker>().used.Add(tag, bonusHP);
            }

            //Spawn flashwave based on bonusHP.
            return true;
        }
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by " + bonusHP);
            DisplayName.SetDefault(name);

            Mod.Logger.Info(tag + " initialized.");
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.rare = rarity;
            Item.value = (int)(new Item(material).value * (CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[material] / 1.5));
        }
        public override void HoldItem(Player player)
        {
        }
        public override void AddRecipes()
        {
            if (material != 0) CreateRecipe().AddIngredient(material, CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[material]).AddTile(station).Register();
        }
    }
}