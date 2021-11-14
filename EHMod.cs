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
            public class Bubble : EHBase { public Bubble() : base(category: "Hardmode", rarity: 0, station: TileID.TreeAmethyst, material: ItemID.Amethyst) { } }
        }
        public class Other
        {
        }
        public class PreHardmode
        {
            public class Amber : EHBase { 
               public Amber() : base(category: "PreHardmode", rarity: 0, station: TileID.TreeAmber, material: ItemID.Amber) { } }
            public class Amethyst : EHBase { 
               public Amethyst() : base(category: "PreHardmode", rarity: 0, station: TileID.TreeAmethyst, material: ItemID.Amethyst) { } }
            public class BorealWood : EHBase { 
               public BorealWood() : base(category: "PreHardmode", rarity: 0, station: TileID.Trees, material: ItemID.BorealWood) { } }
            public class Cactus : EHBase { 
                public Cactus() : base(category: "PreHardmode", rarity: 0, station: TileID.Cactus, material: ItemID.Cactus) { } }
            public class CandyCane : EHBase {
                public CandyCane() : base(category: "PreHardmode", rarity: 0, station: TileID.WorkBenches, material: ItemID.CandyCaneBlock) { } }
            public class Cloud : EHBase {
                public Cloud() : base(category: "PreHardmode", rarity: 0, station: TileID.WorkBenches, material: ItemID.Cloud) { } }
            public class Copper : EHBase { 
                public Copper() : base(category: "PreHardmode", rarity: 0, station: TileID.Furnaces, material: ItemID.CopperOre) { } }
            public class Coralstone : EHBase {
                public Coralstone() : base(category: "PreHardmode", rarity: 0, station: TileID.WorkBenches, material: ItemID.CoralstoneBlock) { } }
            public class Crimsand : EHBase { 
                public Crimsand() : base(category: "PreHardmode", rarity: 0, station: TileID.HeavyWorkBench, material: ItemID.CrimsandBlock) { } }
            public class Crimtane : EHBase {
                public Crimtane() : base(category: "PreHardmode", rarity: 1, station: TileID.Furnaces, material: ItemID.CrimtaneOre) { } }
            public class Demonite : EHBase {
                public Demonite() : base(category: "PreHardmode", rarity: 1, station: TileID.Furnaces, material: ItemID.DemoniteOre) { } }
            public class Diamond : EHBase { 
                public Diamond() : base(category: "PreHardmode", rarity: 0, station: TileID.Cactus, material: ItemID.Cactus) { } }
            public class Dirt : EHBase {
                public Dirt() : base(category: "PreHardmode", rarity: 0, station: TileID.WorkBenches, material: ItemID.DirtBlock) { } }
            public class Dynasty : EHBase {
                public Dynasty() : base(category: "PreHardmode", rarity: 0, station: TileID.Trees, material: ItemID.DynastyWood) { } }
        }
    }
}