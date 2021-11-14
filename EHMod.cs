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
            public class Amber : EHBase { public Amber() : base(category: "PreHardmode", rarity: 0, station: TileID.TreeAmber, material: ItemID.Amber) { } }
            public class Amethyst : EHBase { public Amethyst() : base(category: "PreHardmode", rarity: 0, station: TileID.TreeAmethyst, material: ItemID.Amethyst) { } }
            public class BorealWood : EHBase { public BorealWood() : base(category: "PreHardmode", rarity: 0, station: TileID.Trees, material: ItemID.BorealWood) { } }
            public class Cactus : EHBase { public Cactus() : base(category: "PreHardmode", rarity: 0, station: TileID.Cactus, material: ItemID.Cactus) { } }
        }
    }
}