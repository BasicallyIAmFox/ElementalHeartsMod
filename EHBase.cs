﻿using Terraria.Graphics.Effects;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ElementalHeartsMod.Effects;
using Terraria.DataStructures;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Terraria.GameContent.ItemDropRules;

namespace ElementalHeartsMod
{
    public class EHBase : ModItem
    {
        public EHBase(int category, int station = 0, int material = 0, int rarity = -1, int val = 100, bool boss = false, bool rainbowEffect = false)
        {
            this.boss = boss;
            cat = category;
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

            if (boss)
            {
                this.rarity = -11;
            }

            this.station = station;
            this.material = material;

            tag = Regex.Replace(GetType().Name, "[A-Z]", " $0").Trim();
            name = (tag + " Heart");

            switch (cat)
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

            if (boss)
            {
                bonusHP = 10;
            }
            else
            {
                bonusHP = (this.rarity + 1) * 5;
            }
            texturePath = pathPrefix + Regex.Replace(name, " ", string.Empty);


            switch (this.rarity)
            {
                case 0:
                    rareColor = Colors.RarityNormal;
                    break;
                case 1:
                    rareColor = Colors.RarityBlue;
                    break;
                case 2:
                    rareColor = Colors.RarityGreen;
                    break;
                case 3:
                    rareColor = Colors.RarityOrange;
                    break;
                case 4:
                    rareColor = Colors.RarityRed;
                    break;
                case 5:
                    rareColor = Colors.RarityPink;
                    break;
                case 6:
                    rareColor = Colors.RarityPurple;
                    break;
                case 7:
                    rareColor = Colors.RarityLime;
                    break;
                case 8:
                    rareColor = Colors.RarityYellow;
                    break;
                case 9:
                    rareColor = Colors.RarityCyan;
                    break;
                case 10:
                    rareColor = Colors.RarityDarkRed;
                    break;
                case 11:
                    rareColor = Colors.RarityDarkPurple;
                    break;
                case -11:
                    rareColor = Colors.RarityAmber;
                    break;
                default:
                    break;
            }
            this.backupValue = val;
            this.rainbowEffect = rainbowEffect;
        }
        public bool boss;

        public string tag;
        public string name;
        public int rarity; public int bonusHP;
        public int cat;

        public int station;
        public int material;

        public int backupValue;

        public string texturePath; string pathPrefix;
        public override string Texture => texturePath;
        public Color rareColor;

        public bool tooltipCreated = false;

        public bool rainbowEffect;
        public override bool CanUseItem(Player player)
        {
            if (boss)
            {
                if (!ModContent.GetInstance<EHConfig>().EHBossEnabled)
                {
                    return false;
                }
            }
            else
            {
                if (!ModContent.GetInstance<EHConfig>().EHMaterialEnabled)
                {
                    return false;
                }
            }
            if (ModContent.GetInstance<EHConfig>().MaxHearts == 0)
            {
                return false;
            }
            if (!Filters.Scene["EHWave"].IsActive())
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
            else
            {
                return false;
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
                player.GetModPlayer<EHTracker>().used[tag] += bonusHP;
            }
            else
            {
                player.GetModPlayer<EHTracker>().used.Add(tag, bonusHP);
            }

            if (Main.netMode != NetmodeID.Server && !Filters.Scene["EHWave"].IsActive())
            {
                if (ModContent.GetInstance<EHConfig>().EHWaveEnabled)
                {
                    IProjectileSource source = new ProjectileSource_Item(player, Item);

                    int waveI = Projectile.NewProjectile(source, player.Center, new Vector2(0, 0), ModContent.GetInstance<EHWave>().Type, 0, 0f, Main.myPlayer);
                    Projectile wave = Main.projectile[waveI];
                    EHWave waveProjectile = wave.ModProjectile as EHWave;
                    waveProjectile.SetWaveValues(bonusHP / 5);
                }
            }
            ModContent.GetInstance<EHMod>().DeleteText();
            return true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(name);
            Mod.Logger.Info(tag + " initialized.");
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.rare = rarity;
            if(material != 0)
            {
                Item.value = (int)(new Item(material).value * (CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[material] / 1.25));
            }
            else
            {
                Item.value = backupValue;
            }
        }
        /*
        public override void ExtractinatorUse(ref int resultType, ref int resultStack)
        {
            resultType = material;

            var rand = new Random();
            double stackCountMultiplier = (rand.Next(105, 135) * .01);
            resultStack = (int)(CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[material] / stackCountMultiplier);
            base.ExtractinatorUse(ref resultType, ref resultStack);
        }
        */
        public override void HoldItem(Player player)
        {
            if (CanUseItem(player) == true)
            {
                ModContent.GetInstance<EHMod>().SendEHText("+" + bonusHP + " Max HP", rareColor);
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (player.HeldItem != Item)
            {
                ModContent.GetInstance<EHMod>().DeleteText();
            }
            if (boss)
            {
                if (!ModContent.GetInstance<EHConfig>().EHBossEnabled)
                {
                    player.SellItem(Item);
                    Item.TurnToAir();
                }
            }
            else
            {
                if (!ModContent.GetInstance<EHConfig>().EHMaterialEnabled)
                {
                    player.SellItem(Item);
                    Item.TurnToAir();
                }
            }
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if(tooltipCreated == false)
            {
                TooltipLine currentTooltip = new TooltipLine(Mod, tag, name);
                tooltips.Add(currentTooltip);
                tooltipCreated = true;
            }
            if (tooltipCreated)
            {
                tooltips.Find(_ => _.Name == tag).text = CalculateTooltip();
            }
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            ModContent.GetInstance<EHMod>().DeleteText();
        }
        public override void AddRecipes()
        {
            if (!boss)
            {
                if (!ModContent.GetInstance<EHConfig>().EHMaterialEnabled)
                {

                }
                else if (material != 0)
                {
                    //Create this item:
                    CreateRecipe(1)
                        .AddIngredient(material, CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[material])
                        .AddTile(station)
                        .Register();

                    //Return back to ingrediants:
                    Recipe reverse = CreateRecipe()
                        .AddIngredient(this, 1)
                        .AddTile(TileID.Extractinator);
                    reverse.ReplaceResult(material, Math.Max(1, (int)(CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[material] / 1.25)));
                    reverse.Register();
                }
            }
        }

        public override bool OnPickup(Player player)
        {
            return base.OnPickup(player);
        }
        public string CalculateTooltip()
        {
            if (boss)
            {
                if (!ModContent.GetInstance<EHConfig>().EHBossEnabled)
                {
                    return "Permanently increases maximum life by " + bonusHP + "\n[Boss Hearts Disabled]";
                }
            }
            else
            {
                if (!ModContent.GetInstance<EHConfig>().EHMaterialEnabled)
                {
                    return "Permanently increases maximum life by " + bonusHP + "\n[Material Hearts Disabled]";
                }
            }
            if (ModContent.GetInstance<EHConfig>().MaxHearts == 1)
            {
                if (CanUseItem(Main.LocalPlayer) == false)
                {
                    return "Permanently increases maximum life by " + bonusHP + "\n[Max Consumed]";
                }
                else
                {
                    return "Permanently increases maximum life by " + bonusHP;
                }
            }
            else if (ModContent.GetInstance<EHConfig>().MaxHearts > 1)
            {
                if (Main.LocalPlayer.GetModPlayer<EHTracker>().used.ContainsKey(tag))
                {
                    return ("Permanently increases maximum life by " + bonusHP + "\n[" + (Main.LocalPlayer.GetModPlayer<EHTracker>().used[tag] / bonusHP) + "/" + ModContent.GetInstance<EHConfig>().MaxHearts + "]");
                }
                else
                {
                    return ("Permanently increases maximum life by " + bonusHP + "\n[0/" + ModContent.GetInstance<EHConfig>().MaxHearts + "]");
                }
            }
            else if (ModContent.GetInstance<EHConfig>().MaxHearts == 0)
            {
                return ("Permanently increases maximum life by " + bonusHP + "\n[Disabled]");
            }
            return "";
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (rainbowEffect)
            {
                return Main.DiscoColor;
            }
            else return lightColor;
        }

    }
    
    public abstract class EHNPC : GlobalNPC
    {
        public EHNPC(int npcType, int item, bool shopLoot = true, int killsRequired = 1)
        {
            this.npcType = npcType;
            this.item = item;
            this.shopLoot = shopLoot;
            this.killsRequired = killsRequired;
        }

        int npcType;
        int item;
        bool shopLoot;
        int killsRequired;

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == npcType)
            {
                if (shopLoot)
                {
                    shop.item[nextSlot].SetDefaults(item);
                    shop.item[nextSlot].shopCustomPrice = (int)(shop.item[nextSlot].value);
                    nextSlot++;
                }

            }
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == npcType)
            {
                if(shopLoot == false)
                {
                    npcLoot.Add(ItemDropRule.Common(item));
                }
            }
        }
    }  
}