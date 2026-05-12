using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class ODDeathStormProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
		}

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.DeathSickle);
			AIType = ProjectileID.DeathSickle;
			//Projectile.tileCollide = false;
            Projectile.scale = 1.5f;
			Projectile.light = 0.7f; 
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(BuffID.Bleeding, 15 * 60);
			target.AddBuff(BuffID.Frozen, 15 * 60);
			target.AddBuff(BuffID.Chilled, 15 * 60);
        }

		public override void AI()
		{
			if (Projectile.alpha > 70)
			{
				Projectile.alpha -= 15;
				if (Projectile.alpha < 70)
				{
					Projectile.alpha = 70;
				}
			}
			Vector2 move = Vector2.Zero;
			float distance = 400f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
					Vector2 newMove = Main.npc[k].Center - Projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target)
			{
				Projectile.velocity = (10 * Projectile.velocity + move) / 11f;
			}

			if(Projectile.timeLeft % 60 == 0)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, MathHelper.Lerp(-1f, 1f, (float)Main.rand.NextDouble()), MathHelper.Lerp(-1f, 1f, (float)Main.rand.NextDouble()), ModContent.ProjectileType<global::VinesMod.Projectiles.ScytheProjectile>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Main.myPlayer); //owner.rangedDamage is basically the damage multiplier for ranged weapons
            }
		}

	}
}