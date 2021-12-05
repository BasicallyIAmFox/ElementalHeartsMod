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

namespace ElementalHeartsMod
{
    public class EHBase : ModItem
    {
        public EHBase(int category, int station = 0, int material = 0, int rarity = -1, int val = 100)
        {
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
            bonusHP = (this.rarity + 1) * 5;
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
                default:
                    break;
            }

            this.backupValue = val;

            currentTooltip = new TooltipLine(Mod, tag, name);
            tooltipCreated = true;
        }

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
        public TooltipLine currentTooltip;

        public override bool CanUseItem(Player player)
        {
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

        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (tooltipCreated)
            {   
                currentTooltip.text = CalculateTooltip();
            }
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            ModContent.GetInstance<EHMod>().DeleteText();
        }
        public override void AddRecipes()
        {
            if (material != 0)
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

        public override bool OnPickup(Player player)
        {
            return base.OnPickup(player);
        }
        public string CalculateTooltip()
        {
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

        int npcType = -1;
        int item;
        bool shopLoot;
        int killsRequired;

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (npcType == -1)
            {

            }
            else if (type == npcType)
            {
                if (shopLoot)
                {
                    shop.item[nextSlot].SetDefaults(item);
                    shop.item[nextSlot].shopCustomPrice = (int)(shop.item[nextSlot].value * 1.25);
                    nextSlot++;
                }

            }
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npcType == -1)
            {

            }
            else if (npc.type == npcType)
            {
                if(shopLoot == false)
                {
                    //npcLoot.Add()
                }
            }
        }
    }
    
}