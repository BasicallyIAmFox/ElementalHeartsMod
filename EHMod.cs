using System;
using Terraria.ModLoader;

namespace ElementalHeartsMod
{
	public class EHMod : Mod
	{
        public override void Load()
        {
            Hearts EHInit = new Hearts { };
            EHInit.Boss(this);
            EHInit.Hardmode(this);
            EHInit.Other(this);
            EHInit.PreHardmode(this);

            base.Load();
        }
    }
    public class Hearts : ICloneable
    {

        public void Boss(Mod mod)
        {
        }
        public void Hardmode(Mod mod)
        {
        }
        public void Other(Mod mod)
        {
        }
        public void PreHardmode(Mod mod)
        {
            const string pathPrefix = "ElementalHeartsMod/Assets/Items/Consumables/Hearts/PreHardmode/";


            mod.AddContent(new EHBase("Amber Heart", "amber", 1, 1, pathPrefix + "AmberHeart").cClone());
            mod.AddContent(new EHBase("Amethyst Heart", "amethyst", 1, 1, pathPrefix + "AmethystHeart").cClone());
            mod.AddContent(new EHBase("Boreal Heart", "boreal", 1, 1, pathPrefix + "BorealHeart").cClone());

            /*
            mod.AddContent(new EHBase("Bubble Heart", "bubble", 1, 1, pathPrefix + "BubbleHeart"));
            mod.AddContent(new EHBase("Cactus Heart", "cactus", 1, 1, pathPrefix + "CactusHeart"));
            mod.AddContent(new EHBase("Candy Heart", "candy", 1, 1, pathPrefix + "CandyHeart"));
            mod.AddContent(new EHBase("Cloud Heart", "cloud", 1, 1, pathPrefix + "CloudHeart"));
            mod.AddContent(new EHBase("Copper Heart", "copper", 1, 1, pathPrefix + "CopperHeart"));
            mod.AddContent(new EHBase("Coralstone Heart", "coralstone", 1, 1, pathPrefix + "CoralstoneHeart"));
            mod.AddContent(new EHBase("Crimstone Heart", "crimstone", 1, 1, pathPrefix + "CrimstoneHeart"));
            mod.AddContent(new EHBase("Crimtane Heart", "crimtane", 1, 1, pathPrefix + "CrimtaneHeart"));
            mod.AddContent(new EHBase("Demonite Heart", "demonite", 1, 1, pathPrefix + "DemoniteHeart"));
            mod.AddContent(new EHBase("Diamond Heart", "diamond", 1, 1, pathPrefix + "DiamondHeart"));
            mod.AddContent(new EHBase("Dirt Heart", "dirt", 1, 1, pathPrefix + "DirtHeart"));
            mod.AddContent(new EHBase("Dynasty Heart", "dynasty", 1, 1, pathPrefix + "DynastyHeart"));
            */
        }
        public static string hName()
        {
            return "test";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}