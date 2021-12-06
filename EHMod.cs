using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using ElementalHeartsMod;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

using Terraria.Graphics.Shaders;
using Terraria.Graphics.Effects;

namespace ElementalHeartsMod
{
    public class EHMod : Mod
    {
        //public static EHMod Instance => ModContent.GetInstance<EHMod>();

        public UserInterface EHInterface;
        internal EHUIState EHUIS;
        public override void Load()
        {
            if (!Main.dedServ)
            {
                EHInterface = new UserInterface();

                EHUIS = new EHUIState();
                EHUIS.Activate();

                Ref<Effect> screenRef = new Ref<Effect>(Assets.Request<Effect>(("Effects/EHWaveEffect"), ReLogic.Content.AssetRequestMode.ImmediateLoad).Value);
                Filters.Scene["EHWave"] = new Filter(new ScreenShaderData(screenRef, "Shockwave"), EffectPriority.VeryHigh);
                Filters.Scene["EHWave"].Load();
            }
        }
        public override void PostSetupContent()
        {
            EHInterface?.SetState(EHUIS);
        }
        public void SendEHText(string text, Color color)
        {
            EHUIS.CreateText(text, color);
        }
        public void DeleteText()
        {
            EHUIS.RemoveAllChildren();
        }
        internal enum PacketType : byte
        {
            SyncPlayer
        }
    }

    public class EHModSystem : ModSystem
    {
        private GameTime _lastUpdateUiGameTime;
        internal EHMod mod = ModContent.GetInstance<EHMod>();
        public override void UpdateUI(GameTime gameTime)
        {
            _lastUpdateUiGameTime = gameTime;
            if (mod.EHInterface?.CurrentState != null)
            {
                mod.EHUIS.Update(gameTime);
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "Elemental Hearts: UI",
                    delegate
                    {
                        if (_lastUpdateUiGameTime != null && mod.EHInterface?.CurrentState != null)
                        {
                            mod.EHInterface.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                        }
                        return true;
                    },
                       InterfaceScaleType.UI));
            }
        }
    }

    public class Hearts
    {
        public class Boss
        {
            public class EyeOfCthulu : EHBase { public EyeOfCthulu() : base(1, boss: true) { } } public class EyeOfCthuluNPC : EHNPC { public EyeOfCthuluNPC() : base(NPCID.EyeofCthulhu, ModContent.ItemType<EyeOfCthulu>(), false) { } }

        }
        public class Hardmode
        {
            public class Adamantite : EHBase { public Adamantite() : base(2, TileID.AdamantiteForge, ItemID.AdamantiteOre) { } }
            public class Bubble : EHBase { public Bubble() : base(2, TileID.BubbleMachine, ItemID.Bubble) { } }
            public class Chlorophyte : EHBase { public Chlorophyte() : base(2, TileID.MythrilAnvil, ItemID.ChlorophyteOre) { } }
            public class Cobalt : EHBase { public Cobalt() : base(2, TileID.Furnaces, ItemID.CobaltOre) { } }
            public class Cog : EHBase { public Cog() : base(2, val: 1000000) { } } public class CogNPC : EHNPC { public CogNPC() : base(NPCID.Steampunker, ModContent.ItemType<Cog>()) { } }
            public class Crystal : EHBase { public Crystal() : base(2, TileID.MythrilAnvil, ItemID.CrystalShard) { } }
            public class CursedFlame : EHBase { public CursedFlame() : base(2, TileID.CrystalBall, ItemID.CursedFlame) { } }
            public class Discord : EHBase { public Discord() : base(2, TileID.DemonAltar, ItemID.RodofDiscord) { } }
            public class Ectoplasm : EHBase { public Ectoplasm() : base(2, TileID.CrystalBall, ItemID.Ectoplasm) { } }
            public class Flesh : EHBase { public Flesh() : base(2, TileID.FleshCloningVat, ItemID.FleshBlock) { } }
            public class Flight : EHBase { public Flight() : base(2, TileID.MythrilAnvil, ItemID.SoulofFlight) { } }
            public class Ichor : EHBase { public Ichor() : base(2, TileID.CrystalBall, ItemID.Ichor) { } }
            public class Lesion : EHBase { public Lesion() : base(2, TileID.LesionStation, ItemID.LesionBlock) { } }
            public class Light : EHBase { public Light() : base(2, TileID.MythrilAnvil, ItemID.SoulofLight) { } }
            public class Luminite : EHBase { public Luminite() : base(2, TileID.LunarCraftingStation, ItemID.LunarOre) { } }
            public class Mythril : EHBase { public Mythril() : base(2, TileID.MythrilAnvil, ItemID.MythrilOre) { } }
            public class Night : EHBase { public Night() : base(2, TileID.MythrilAnvil, ItemID.SoulofNight) { } }
            public class Orichalcum : EHBase { public Orichalcum() : base(2, TileID.MythrilAnvil, ItemID.OrichalcumAnvil) { } }
            public class Palladium : EHBase { public Palladium() : base(2, TileID.Furnaces, ItemID.OrichalcumAnvil) { } }
            public class Pearlsand : EHBase { public Pearlsand() : base(2, TileID.HeavyWorkBench, ItemID.PearlsandBlock) { } }
            public class Pearlstone : EHBase { public Pearlstone() : base(2, TileID.Furnaces, ItemID.PearlstoneBlock) { } }
            public class Pearlwood : EHBase { public Pearlwood() : base(2, TileID.Trees, ItemID.PearlstoneBlock) { } }
            public class PinkIce : EHBase { public PinkIce() : base(2, TileID.IceMachine, ItemID.PinkIceBlock) { } }
            public class Rainbow : EHBase { public Rainbow() : base(2, TileID.Anvils, ItemID.RainbowBrick, rainbowEffect: true) { } }
            public class SpookyWood : EHBase { public SpookyWood() : base(2, TileID.Trees, ItemID.SpookyWood) { } }
            public class Titanium : EHBase { public Titanium() : base(2, TileID.AdamantiteForge, ItemID.TitaniumOre) { } }
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
            public class Honey : EHBase { public Honey() : base(4, TileID.HoneyDispenser, ItemID.HoneyBlock) { } }
            public class Ice : EHBase { public Ice() : base(4, TileID.IceMachine, ItemID.IceBlock) { } }
            public class Iron : EHBase { public Iron() : base(4, TileID.Furnaces, ItemID.IronOre) { } }
            public class Lead : EHBase { public Lead() : base(4, TileID.Furnaces, ItemID.LeadOre) { } }
            public class Marble : EHBase { public Marble() : base(4, TileID.WorkBenches, ItemID.Marble) { } }
            public class Meteorite : EHBase { public Meteorite() : base(4, TileID.Furnaces, ItemID.Meteorite) { } }
            public class Mushroom : EHBase { public Mushroom() : base(4, TileID.Sawmill, ItemID.GlowingMushroom) { } }
            public class Obsidian : EHBase { public Obsidian() : base(4, TileID.Hellforge, ItemID.Obsidian) { } }
            public class PalmWood : EHBase { public PalmWood() : base(4, TileID.Trees, ItemID.PalmWood) { } }
            public class Platinum : EHBase { public Platinum() : base(4, TileID.Furnaces, ItemID.PlatinumOre) { } }
            public class Pumpkin : EHBase { public Pumpkin() : base(4, TileID.Sawmill, ItemID.Pumpkin) { } }
            public class PurpleIce : EHBase { public PurpleIce() : base(4, TileID.IceMachine, ItemID.PurpleIceBlock) { } }
            public class RainCloud : EHBase { public RainCloud() : base(4, TileID.SkyMill, ItemID.RainCloud) { } }
            public class RedIce : EHBase { public RedIce() : base(4, TileID.IceMachine, ItemID.RedIceBlock) { } }
            public class RichMahogany : EHBase { public RichMahogany() : base(4, TileID.Trees, ItemID.RichMahogany) { } }
            public class Ruby : EHBase { public Ruby() : base(4, TileID.TreeRuby, ItemID.Ruby) { } }
            public class Sand : EHBase { public Sand() : base(4, TileID.HeavyWorkBench, ItemID.SandBlock) { } }
            public class Sapphire : EHBase { public Sapphire() : base(4, TileID.TreeSapphire, ItemID.Sapphire) { } }
            public class Shadewood : EHBase { public Shadewood() : base(4, TileID.Trees, ItemID.Shadewood) { } }
            public class Silver : EHBase { public Silver() : base(4, TileID.Furnaces, ItemID.SilverOre) { } }
            public class Slime : EHBase { public Slime() : base(4, TileID.Solidifier, ItemID.Gel) { } }
            public class SnowCloud : EHBase { public SnowCloud() : base(4, TileID.SkyMill, ItemID.SnowCloudBlock) { } }
            public class Stone : EHBase { public Stone() : base(4, TileID.Furnaces, ItemID.StoneBlock) { } }
            public class Sunplate : EHBase { public Sunplate() : base(4, TileID.SkyMill, ItemID.SunplateBlock) { } }
            public class Tin : EHBase { public Tin() : base(4, TileID.Furnaces, ItemID.TinOre) { } }
            public class Topaz : EHBase { public Topaz() : base(4, TileID.TreeTopaz, ItemID.Topaz) { } }
            public class Tungsten : EHBase { public Tungsten() : base(4, TileID.Furnaces, ItemID.TungstenOre) { } }
            public class Wood : EHBase { public Wood() : base(4, TileID.Trees, ItemID.Wood) { } }
        }
    }
}