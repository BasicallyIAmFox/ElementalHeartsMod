using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ElementalHeartsMod
{
    public class EHTracker : ModPlayer
    {
        public IDictionary<string, int> used = new Dictionary<string, int>();
    }
}
