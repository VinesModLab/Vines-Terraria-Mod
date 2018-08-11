using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class ZeoxingProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ZeoxingFall");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Starfury);
			projectile.scale = 2f;
			projectile.light = 1f; 
			aiType = ProjectileID.Starfury;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.Starfury;
			return true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 15 * 60);
			target.AddBuff(BuffID.Bleeding, 15 * 60);
			target.AddBuff(BuffID.Frozen, 15 * 60);
			target.AddBuff(BuffID.Chilled, 15 * 60);
			target.AddBuff(BuffID.ShadowFlame, 15* 60);
			target.AddBuff(BuffID.Poisoned, 15* 60);
			target.AddBuff(BuffID.Venom, 15* 60);
			target.AddBuff(BuffID.Confused, 15* 60);
			target.AddBuff(BuffID.Ichor, 15* 60);

			for (int i = 0; i < 30; i++)
			{
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 30f, Main.rand.Next(-10, 11) * .30f, Main.rand.Next(-10, -5) * .30f, ProjectileID.Starfury, (int)(projectile.damage * .5f), 0, projectile.owner);
				Main.projectile[a].aiStyle = 1;
				Main.projectile[a].tileCollide = true;
			}
        }

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int i = 0; i < 30; i++)
			{
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 30f, Main.rand.Next(-10, 11) * .30f, Main.rand.Next(-10, -5) * .30f, ProjectileID.Starfury, (int)(projectile.damage * .5f), 0, projectile.owner);
				Main.projectile[a].aiStyle = 1;
				Main.projectile[a].tileCollide = true;
			}
			return true;
		}
	}
}