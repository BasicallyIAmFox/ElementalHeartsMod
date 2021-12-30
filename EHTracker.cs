using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ElementalHeartsMod
{
    public class EHTracker : ModPlayer
    {
        public IDictionary<string, int> used = new Dictionary<string, int>();

        public override void ResetEffects()
        {
            if (used != null)
            {
                foreach (KeyValuePair<string, int> usedEH in used)
                {
                    Player.statLifeMax2 += usedEH.Value;
                }
            }
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write(Player.statLifeMax2);

            packet.Send(toWho, fromWho);
        }
        public override void SaveData(TagCompound tag)
        {
            foreach (KeyValuePair<string, int> usedEH in used)
            {
                tag.Add(usedEH.Key, usedEH.Value);
            }
        }
        public override void PostSavePlayer()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string time = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            File.WriteAllLines(path + "/EHTracker-" + time + ".txt", used.Select(x => "[" + x.Key + " " + x.Value + "]").ToArray());
            File.WriteAllLines(path + "/EHTrackerLast.txt", used.Select(x => "[" + x.Key + " " + x.Value + "]").ToArray());
        }
        public override void LoadData(TagCompound tag)
        {
            Dictionary<string, int> tags = tag.AsEnumerable().ToDictionary(x => x.Key, x => int.Parse(x.Value.ToString()));
            this.used = tags;
        }
    }
}
