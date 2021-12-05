using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static ElementalHeartsMod.EHMod;

namespace ElementalHeartsMod
{
    public class EHTracker : ModPlayer
    {
        public IDictionary<string, int> used = new Dictionary<string, int>();

        public override void ResetEffects()
        {
            foreach (KeyValuePair<string, int> usedEH in used)
            {
                Player.statLifeMax2 += usedEH.Value;
            }
        }

        public override void clientClone(ModPlayer clientClone)
        {
            EHTracker clone = clientClone as EHTracker;
        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            int writeOperations = 0;
            ModPacket packet = Mod.GetPacket();

            packet.Write((byte)PacketType.SyncPlayer);
            writeOperations++;
            packet.Write((byte)Player.whoAmI);
            writeOperations++;
            packet.Write(used.Count);
            writeOperations++;
            foreach (KeyValuePair<string, int> usedHeart in used)
            {
                packet.Write(usedHeart.Key);
                writeOperations++;
                packet.Write(usedHeart.Value);
                writeOperations++;
            }
            packet.Send(toWho, fromWho);
            Mod.Logger.Debug(writeOperations);
        }
        public override void SaveData(TagCompound tag)
        {
            TagCompound tagCompound = new TagCompound();
            foreach (KeyValuePair<string, int> usedEH in used)
            {
                tagCompound.Add(usedEH.Key, usedEH.Value);
            }

            base.SaveData(tag);
        }
        public override void PostSavePlayer()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string time = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            File.WriteAllLines(path + "/EHTracker-" + time + ".txt", used.Select(x => "[" + x.Key + " " + x.Value + "]").ToArray());
            base.PostSavePlayer();
        }
        public override void LoadData(TagCompound tag)
        {
            Dictionary<string, int> tags = tag.AsEnumerable().ToDictionary(x => x.Key, x => int.Parse(x.Value.ToString()));
            this.used = tags;

            base.LoadData(tag);
        }
    }
}
