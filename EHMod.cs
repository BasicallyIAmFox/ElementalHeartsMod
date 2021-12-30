using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

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
            public class Betsy : EHBase { public Betsy() : base(1, boss: true) { } }
            public class BetsyNPC : EHNPC { public BetsyNPC() : base(NPCID.DD2Betsy, ModContent.ItemType<Betsy>(), false) { } }
            public class BrainOfCthulhu : EHBase { public BrainOfCthulhu() : base(1, boss: true, overideName: "Brain of Cthulhu") { } }
            public class BrainOfCthulhuNPC : EHNPC { public BrainOfCthulhuNPC() : base(NPCID.BrainofCthulhu, ModContent.ItemType<BrainOfCthulhu>(), false) { } }
            public class DukeFishron : EHBase { public DukeFishron() : base(1, boss: true) { } }
            public class DukeFishronNPC : EHNPC { public DukeFishronNPC() : base(NPCID.DukeFishron, ModContent.ItemType<DukeFishron>(), false) { } }
            public class EaterOfWorlds : EHBase { public EaterOfWorlds() : base(1, TileID.DemonAltar, ItemID.ShadowScale, boss: true, overideName: "Eater of Worlds") { } }
            public class EmpressOfLight : EHBase { public EmpressOfLight() : base(1, boss: true, overideName: "Empress of Light") { } }
            public class EmpressOfLightNPC : EHNPC { public EmpressOfLightNPC() : base(NPCID.EmpressButterfly, ModContent.ItemType<EmpressOfLight>(), false) { } }
            public class EyeOfCthulhu : EHBase { public EyeOfCthulhu() : base(1, boss: true, overideName: "Eye of Cthulhu") { } }
            public class EyeOfCthulhuNPC : EHNPC { public EyeOfCthulhuNPC() : base(NPCID.EyeofCthulhu, ModContent.ItemType<EyeOfCthulhu>(), false) { } }
            public class FlyingDutchman : EHBase { public FlyingDutchman() : base(1, boss: true) { } }
            public class FlyingDutchmanNPC : EHNPC { public FlyingDutchmanNPC() : base(NPCID.PirateShip, ModContent.ItemType<FlyingDutchman>(), false) { } }
            public class Golem : EHBase { public Golem() : base(1, boss: true) { } }
            public class GolemNPC : EHNPC { public GolemNPC() : base(NPCID.Golem, ModContent.ItemType<Golem>(), false) { } }
            public class KingSlime : EHBase { public KingSlime() : base(1, boss: true) { } }
            public class KingSlimeNPC : EHNPC { public KingSlimeNPC() : base(NPCID.KingSlime, ModContent.ItemType<KingSlime>(), false) { } }
            public class LunaticCultist : EHBase { public LunaticCultist() : base(1, boss: true) { } }
            public class LunaticCultistNPC : EHNPC { public LunaticCultistNPC() : base(NPCID.CultistBoss, ModContent.ItemType<LunaticCultist>(), false) { } }
            public class MartianSaucer : EHBase { public MartianSaucer() : base(1, boss: true) { } }
            public class MartianSaucerNPC : EHNPC { public MartianSaucerNPC() : base(NPCID.MartianSaucer, ModContent.ItemType<MartianSaucer>(), false) { } }
            public class MoonLord : EHBase { public MoonLord() : base(1, boss: true) { } }
            public class MoonLordNPC : EHNPC { public MoonLordNPC() : base(NPCID.MoonLordCore, ModContent.ItemType<MoonLord>(), false) { } }
            public class Plantera : EHBase { public Plantera() : base(1, boss: true) { } }
            public class PlanteraNPC : EHNPC { public PlanteraNPC() : base(NPCID.Plantera, ModContent.ItemType<Plantera>(), false) { } }
            public class QueenBee : EHBase { public QueenBee() : base(1, boss: true) { } }
            public class QueenBeeNPC : EHNPC { public QueenBeeNPC() : base(NPCID.QueenBee, ModContent.ItemType<QueenBee>(), false) { } }
            public class QueenSlime : EHBase { public QueenSlime() : base(1, boss: true) { } }
            public class QueenSlimeNPC : EHNPC { public QueenSlimeNPC() : base(NPCID.QueenSlimeBoss, ModContent.ItemType<QueenSlime>(), false) { } }
            public class Skeletron : EHBase { public Skeletron() : base(1, boss: true) { } }
            public class SkeletronNPC : EHNPC { public SkeletronNPC() : base(NPCID.SkeletronHead, ModContent.ItemType<Skeletron>(), false) { } }
            public class SoulOfFright : EHBase { public SoulOfFright() : base(1, boss: true, overideName: "Fright") { } }
            public class SoulOfFrightNPC : EHNPC { public SoulOfFrightNPC() : base(NPCID.SkeletronPrime, ModContent.ItemType<SoulOfFright>(), false) { } }
            public class SoulOfMight : EHBase { public SoulOfMight() : base(1, boss: true, overideName: "Might") { } }
            public class SoulOfMightNPC : EHNPC { public SoulOfMightNPC() : base(NPCID.TheDestroyer, ModContent.ItemType<SoulOfMight>(), false) { } }
            public class SoulOfSight : EHBase { public SoulOfSight() : base(1, boss: true, overideName: "Sight") { } }
            public class SoulOfSightNPC : EHNPC { public SoulOfSightNPC() : base(NPCID.Eyezor, ModContent.ItemType<SoulOfSight>(), false) { } }
        }
        public class Hardmode
        {
            public class Adamantite : EHBase { public Adamantite() : base(2, TileID.AdamantiteForge, ItemID.AdamantiteOre) { } }
            public class Bubble : EHBase { public Bubble() : base(2, val: 1000000) { } }
            public class BubbleNPC : EHNPC { public BubbleNPC() : base(NPCID.PartyGirl, ModContent.ItemType<Bubble>()) { } }
            public class Chlorophyte : EHBase { public Chlorophyte() : base(2, TileID.MythrilAnvil, ItemID.ChlorophyteOre) { } }
            public class Cobalt : EHBase { public Cobalt() : base(2, TileID.Furnaces, ItemID.CobaltOre) { } }
            public class Cog : EHBase { public Cog() : base(2, val: 1000000) { } }
            public class CogNPC : EHNPC { public CogNPC() : base(NPCID.Steampunker, ModContent.ItemType<Cog>()) { } }
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
            public class LifeCrystal : EHBase { public LifeCrystal() : base(4, TileID.DemonAltar, ItemID.LifeCrystal, rarity: 4, optionalTooltip: "Dedicated to AdamChromeE!") { } }
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