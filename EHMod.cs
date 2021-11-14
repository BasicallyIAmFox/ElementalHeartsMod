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
        }
        public class Other
        {
        }
        public class PreHardmode
        {
            public class Amber : EHBase { public Amber() : base(rarity: 0, station: TileID.Furnaces, material: ItemID.Amber) { } }
            public class Amethyst : EHBase { public Amethyst() : base(rarity: 0) { } }
            public class BorealWood : EHBase { public BorealWood() : base(rarity: 0) { } }
            public class Bubble : EHBase { public Bubble() : base(rarity: 1) { } }
            public class Cactus : EHBase { public Cactus() : base(rarity: 0) { } }
        }
    }
}