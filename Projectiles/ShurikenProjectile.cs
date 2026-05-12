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
        }

		public override void SetDefaults()
		{
			Projectile.width = 36;
			Projectile.height = 36;
			Projectile.timeLeft = 60;
			Projectile.penetrate = 3;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.aiStyle = 0;
		}
		
		public override void AI()
        {
            Player owner = Main.player[Projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            Projectile.light = 0.9f;
            Projectile.alpha = 75;
            Projectile.rotation += (float)Projectile.direction * 0.8f; //Spins in a good speed
            int DustID = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width + 4, Projectile.height + 4, 36, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default(Color), 0.75f);
            Main.dust[DustID].noGravity = true;
        }
		
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player owner = Main.player[Projectile.owner];
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
            if (Projectile.velocity.X != velocityChange.X)
            {
                Projectile.velocity.X = -velocityChange.X/2; //Goes in the opposite direction with half of its x velocity
            }
            if (Projectile.velocity.Y != velocityChange.Y)
            {
                Projectile.velocity.Y = -velocityChange.Y/2; //Goes in the opposite direction with half of its y velocity
            }
            return false;
        }
	}
}
