using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHeartsMod.Effects
{
    public class EHWave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("EHWave");
        }
        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.alpha = 255;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 333;
        }

        public float rippleCount;       
        public float rippleSize;
        public float rippleSpeed;
        
        public float distortStrength = 333f;
        public int initialStrength = 333;
        public void SetWaveValues(int count = 1, int size = 30)
        {
            rippleCount = count;
            rippleSize = size + (rippleCount + 1) * 7;
            rippleSpeed = 10 + (rippleSize / 2);
            distortStrength = (333 / (rippleSpeed / 10)) + 100;
            Projectile.ai[0] = 1;
        }

        public override void AI()
        {
            if (Projectile.ai[0] == 1)
            {
                Projectile.ai[0] = 2;
                if (Main.netMode != NetmodeID.Server && !Filters.Scene["EHWave"].IsActive())
                {
                    Filters.Scene.Activate("EHWave", Projectile.Center).GetShader().UseColor(rippleCount, rippleSize, rippleSpeed).UseTargetPosition(Projectile.Center);
                }
            }

            if (Main.netMode != NetmodeID.Server && Filters.Scene["EHWave"].IsActive())
            {
                float progress = (333 - Projectile.timeLeft) / 90f;
                Filters.Scene["EHWave"].GetShader().UseProgress(progress).UseOpacity(distortStrength * (1 - progress / 3f));
            }
        }

        public override void Kill(int timeLeft)
        {
            if (Main.netMode != NetmodeID.Server && Filters.Scene["EHWave"].IsActive())
            {
                Filters.Scene["EHWave"].Deactivate();
            }
        }
    }
}