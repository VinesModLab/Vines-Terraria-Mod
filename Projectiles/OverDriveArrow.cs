using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace VinesMod.Projectiles
{
    public class OverDriveArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = ProjAIStyleID.Arrow;
            Projectile.friendly = true;         
            Projectile.hostile = false;         
            Projectile.DamageType = DamageClass.Ranged;           
            Projectile.penetrate = 5;           
            Projectile.timeLeft = 600;           
            Projectile.light = 1f;            
            Projectile.ignoreWater = true;      
            Projectile.tileCollide = true;      
            Projectile.extraUpdates = 1;                                           
			AIType = ProjectileID.WoodenArrowFriendly;
        }

        public override void AI()
		{
            	int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Water_BloodMoon, 0f, 0f, 200, default(Color), 1.5f);
	            Main.dust[dust].velocity *= 0.2f;
                Main.dust[dust].noGravity = true;

            if (Main.rand.Next(2) == 0)
            {
	            int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GemRuby, 0f, 0f, 200, default(Color), 1f);
	            Main.dust[dust2].velocity *= 0.3f;
                Main.dust[dust2].noGravity = true;
            }
            if (Main.rand.Next(3) == 0)
            {
	            int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<global::VinesMod.Dusts.SparkleRed>(), 0f, 0f, 200, default(Color), 1f);
	            Main.dust[dust2].velocity *= 0.3f;
                Main.dust[dust2].noGravity = true;
            }
		}
    }
}
