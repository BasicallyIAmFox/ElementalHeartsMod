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

    public class Hearts
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
            mod.AddContent(new EHBase("Dirt Heart", "dirt", 1, 1, "ElementalHeartsMod/Assets/Items/Consumables/Hearts/PreHardmode/DirtHeart"));
        }
    }
}