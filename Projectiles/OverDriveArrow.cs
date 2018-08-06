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
            DisplayName.SetDefault("OverDrive Arrow");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = 1;
            projectile.friendly = true;         
            projectile.hostile = false;         
            projectile.ranged = true;           
            projectile.penetrate = 5;           
            projectile.timeLeft = 600;           
            projectile.light = 1f;            
            projectile.ignoreWater = true;      
            projectile.tileCollide = true;      
            projectile.extraUpdates = 1;                                           
            aiType = ProjectileID.WoodenArrowFriendly; 
        }

        public override void AI()
		{
            	int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 105, 0f, 0f, 200, default(Color), 1.5f);
	            Main.dust[dust].velocity *= 0.2f;
                Main.dust[dust].noGravity = true;

            if (Main.rand.Next(2) == 0)
            {
	            int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 90, 0f, 0f, 200, default(Color), 1f);
	            Main.dust[dust2].velocity *= 0.3f;
                Main.dust[dust2].noGravity = true;
            }
            if (Main.rand.Next(3) == 0)
            {
	            int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("SparkleRed"), 0f, 0f, 200, default(Color), 1f);
	            Main.dust[dust2].velocity *= 0.3f;
                Main.dust[dust2].noGravity = true;
            }
		}
    }
}
