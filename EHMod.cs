using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace ElementalHeartsMod
{
    public class EHMod : Mod
    {
        public override void Load()
        {
        }

        internal enum PacketType : byte
        {
            SyncPlayer
        }
    }
    public class Hearts
    {
        public class Boss
        {
        }
        public class Hardmode 
        {
            public class Adamantite : EHBase { public Adamantite() : base(2, TileID.AdamantiteForge, ItemID.AdamantiteOre) { } }  
            public class Bubble : EHBase { public Bubble() : base(2, TileID.BubbleMachine, ItemID.Bubble) { } }

            public class Flesh : EHBase { public Flesh() : base(2, TileID.FleshCloningVat, ItemID.FleshBlock) { } }

            public class Lesion : EHBase { public Lesion() : base(2, TileID.LesionStation, ItemID.LesionBlock) { } }

        }
        public class Other
        {
        }
        public class PreHardmode
        {
            public class Amber : EHBase { public Amber() : base(4, TileID.TreeAmber, ItemID.Amber) { } }
            public class Amethyst : EHBase { public Amethyst() : base(4, TileID.TreeAmethyst, ItemID.Amethyst) { } }
            public class BorealWood : EHBase { public BorealWood() : base(4, TileID.Trees, ItemID.BorealWood) { } }
            public class Cactus : EHBase { public Cactus() : base(4, TileID.Cactus, ItemID.Cactus) { } }
            public class CandyCane : EHBase { public CandyCane() : base(4, TileID.WorkBenches, ItemID.CandyCaneBlock) { } }
            public class Cloud : EHBase { public Cloud() : base(4, TileID.SkyMill, ItemID.Cloud) { } }
            public class Copper : EHBase { public Copper() : base(4, TileID.Furnaces, ItemID.CopperOre) { } }
            public class Coralstone : EHBase { public Coralstone() : base(4, TileID.WorkBenches, ItemID.CoralstoneBlock) { } }
            public class Crimsand : EHBase { public Crimsand() : base(4, TileID.HeavyWorkBench, ItemID.CrimsandBlock) { } }
            public class Crimtane : EHBase { public Crimtane() : base(4, TileID.Furnaces, ItemID.CrimtaneOre) { } }
            public class Demonite : EHBase { public Demonite() : base(4, TileID.Furnaces, ItemID.DemoniteOre) { } }
            public class Diamond : EHBase { public Diamond() : base(4, TileID.TreeDiamond, ItemID.Diamond) { } }
            public class Dirt : EHBase { public Dirt() : base(4, TileID.WorkBenches, ItemID.DirtBlock) { } }
            public class Dynasty : EHBase { public Dynasty() : base(4, TileID.Trees, ItemID.DynastyWood) { } }
            public class Ebonsand : EHBase { public Ebonsand() : base(4, TileID.HeavyWorkBench, ItemID.EbonsandBlock) { } }
            public class Ebonstone : EHBase { public Ebonstone() : base(4, TileID.Furnaces, ItemID.EbonstoneBlock) { } }
            public class Emerald : EHBase { public Emerald() : base(4, TileID.TreeEmerald, ItemID.Emerald) { } }
            public class Enchanted : EHBase { public Enchanted() : base(4, TileID.DemonAltar, ItemID.EnchantedSword) { } }
            public class Fossil : EHBase { public Fossil() : base(4, TileID.Extractinator, ItemID.DesertFossil) { } }
            public class Glass : EHBase { public Glass() : base(4, TileID.GlassKiln, ItemID.Glass) { } }
            public class Gold : EHBase { public Gold() : base(4, TileID.Furnaces, ItemID.GoldOre) { } }
            public class Granite : EHBase { public Granite() : base(4, TileID.WorkBenches, ItemID.GraniteBlock) { } }
            public class Hay : EHBase { public Hay() : base(4, TileID.WorkBenches, ItemID.Hay) { } }
            public class Hellstone : EHBase { public Hellstone() : base(4, TileID.Hellforge, ItemID.Hellstone) { } }
            public class Honey : EHBase { public Honey() : base(4, TileID.HoneyDispenser, ItemID.HoneyBlock) { } }
            public class Ice : EHBase { public Ice() : base(4, TileID.IceMachine, ItemID.IceBlock) { } }
            public class Iron : EHBase { public Iron() : base(4, TileID.Furnaces, ItemID.IronOre) { } }
            public class Lead : EHBase { public Lead() : base(4, TileID.Furnaces, ItemID.LeadOre) { } }
            public class Marble : EHBase { public Marble() : base(4, TileID.WorkBenches, ItemID.Marble) { } }
            public class Meteorite : EHBase { public Meteorite() : base(4, TileID.Furnaces, ItemID.Meteorite) { } }
            public class Mushroom : EHBase { public Mushroom() : base(4, TileID.Sawmill, ItemID.GlowingMushroom) { } }
            public class Obsidian : EHBase { public Obsidian() : base(4, TileID.Hellforge, ItemID.Obsidian) { } }
            public class PalmWood : EHBase { public PalmWood() : base(4, TileID.Trees, ItemID.PalmWood) { } }
            public class Platinum : EHBase { public Platinum() : base(4, TileID.Furnaces, ItemID.PlatinumOre) { } }
            public class Pumpkin : EHBase { public Pumpkin() : base(4, TileID.Sawmill, ItemID.Pumpkin) { } }
            public class PurpleIce : EHBase { public PurpleIce() : base(4, TileID.IceMachine, ItemID.PurpleIceBlock) { } }
            public class RainCloud : EHBase { public RainCloud() : base(4, TileID.SkyMill, ItemID.RainCloud) { } }
            public class RedIce : EHBase { public RedIce() : base(4, TileID.IceMachine, ItemID.RedIceBlock) { } }
            public class RichMahogany : EHBase { public RichMahogany() : base(4, TileID.Trees, ItemID.RichMahogany) { } }
            public class Ruby : EHBase { public Ruby() : base(4, TileID.TreeRuby, ItemID.Ruby) { } }
            public class Sand : EHBase { public Sand() : base(4, TileID.HeavyWorkBench, ItemID.SandBlock) { } }
            public class Sapphire : EHBase { public Sapphire() : base(4, TileID.TreeSapphire, ItemID.Sapphire) { } }
            public class Shadewood : EHBase { public Shadewood() : base(4, TileID.Trees, ItemID.Shadewood) { } }
            public class Silver : EHBase { public Silver() : base(4, TileID.Furnaces, ItemID.SilverOre) { } }
            public class Slime : EHBase { public Slime() : base(4, TileID.Solidifier, ItemID.Gel) { } }
            public class SnowCloud : EHBase { public SnowCloud() : base(4, TileID.SkyMill, ItemID.SnowCloudBlock) { } }
            public class Stone : EHBase { public Stone() : base(4, TileID.Furnaces, ItemID.StoneBlock) { } }
            public class Sunplate : EHBase { public Sunplate() : base(4, TileID.SkyMill, ItemID.SunplateBlock) { } }
            public class Tin : EHBase { public Tin() : base(4, TileID.Furnaces, ItemID.TinOre) { } }
            public class Topaz : EHBase { public Topaz() : base(4, TileID.TreeTopaz, ItemID.Topaz) { } }
            public class Tungsten : EHBase { public Tungsten() : base(4, TileID.Furnaces, ItemID.TungstenOre) { } }
            public class Wood : EHBase { public Wood() : base(4, TileID.Trees, ItemID.Wood) { } }
        }
    }
}