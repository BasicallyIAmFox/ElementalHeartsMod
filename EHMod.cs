using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Terraria.ModLoader;
using Terraria.ID;

namespace ElementalHeartsMod
{
    public class EHMod : Mod
    {
        public override void Load()
        {
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
        }
    }
}