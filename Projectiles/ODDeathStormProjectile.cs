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
			DisplayName.SetDefault("DeathStormOverDriveProjectile");
		}

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.DeathSickle);
            aiType = ProjectileID.DeathSickle;
			//projectile.tileCollide = false;
            projectile.scale = 1.5f;
			projectile.light = 0.7f; 
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.Bleeding, 15 * 60);
			target.AddBuff(BuffID.Frozen, 15 * 60);
			target.AddBuff(BuffID.Chilled, 15 * 60);
        }

		public override void AI()
		{
			if (projectile.alpha > 70)
			{
				projectile.alpha -= 15;
				if (projectile.alpha < 70)
				{
					projectile.alpha = 70;
				}
			}
			Vector2 move = Vector2.Zero;
			float distance = 400f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
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
				projectile.velocity = (10 * projectile.velocity + move) / 11f;
			}

			if(projectile.timeLeft % 60 == 0)
            {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, MathHelper.Lerp(-1f, 1f, (float)Main.rand.NextDouble()), MathHelper.Lerp(-1f, 1f, (float)Main.rand.NextDouble()), mod.ProjectileType("ScytheProjectile"), (int)(projectile.damage * 0.5f), projectile.knockBack, Main.myPlayer); //owner.rangedDamage is basically the damage multiplier for ranged weapons
            }
		}

	}
}