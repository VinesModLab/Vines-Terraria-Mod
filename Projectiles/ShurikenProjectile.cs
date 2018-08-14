using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{	
	public class ShurikenProjectile : ModProjectile 
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ShurikenProjectile");
        }

		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 36;
			projectile.timeLeft = 60;
			projectile.penetrate = 3;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.ranged = true;
			projectile.aiStyle = 0;
		}
		
		public override void AI()
        {
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            projectile.light = 0.9f;
            projectile.alpha = 75;
            projectile.rotation += (float)projectile.direction * 0.8f; //Spins in a good speed
            int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 4, projectile.height + 4, 36, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.75f);
            Main.dust[DustID].noGravity = true;
        }
		
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            int rand = Main.rand.Next(2);
            if(rand == 0)
            {
                target.AddBuff(BuffID.Chilled, 15 * 60);
            }
            else if (rand == 1)
            {
                owner.statLife += 5; //Gives 5 Health
				owner.HealEffect(5, true); //Shows you have healed by 5 health
            }
        }
		
        public override bool OnTileCollide(Vector2 velocityChange)  
        {
            if (projectile.velocity.X != velocityChange.X)
            {
                projectile.velocity.X = -velocityChange.X/2; //Goes in the opposite direction with half of its x velocity
            }
            if (projectile.velocity.Y != velocityChange.Y)
            {
                projectile.velocity.Y = -velocityChange.Y/2; //Goes in the opposite direction with half of its y velocity
            }
            return false;
        }
	}
}
