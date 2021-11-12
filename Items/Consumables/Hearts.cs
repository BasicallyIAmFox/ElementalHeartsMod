using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHeartsMod.Items.Consumables.Hearts
{
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
            public class Dirt : EHBase
            {
                public void Init()
                {
                    name = "Dirt Heart";
                    tag = "dirt";
                    bonus = 1;

                    texturePath = "ElementalHeartsMod/Assets/Items/Consumables/Hearts/Vanilla/PreHardmode/DirtHeart";
                }
            }
        }
    }
}
