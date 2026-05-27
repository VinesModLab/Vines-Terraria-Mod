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
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Starfury);
			Projectile.scale = 2f;
			Projectile.light = 1f; 
			AIType = ProjectileID.Starfury;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.Starfury;
			return true;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
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

			Player owner = Main.player[Projectile.owner];
            owner.statLife += 75;

			for (int i = 0; i < 30; i++)
			{
				int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y - 30f, Main.rand.Next(-10, 11) * .30f, Main.rand.Next(-10, -5) * .30f, ProjectileID.Starfury, (int)(Projectile.damage * 2f), 0, Projectile.owner);
				Main.projectile[a].aiStyle = ProjAIStyleID.Arrow;
				Main.projectile[a].tileCollide = true;
			}
        }

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int i = 0; i < 30; i++)
			{
				int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y - 30f, Main.rand.Next(-10, 11) * .30f, Main.rand.Next(-10, -5) * .30f, ProjectileID.Starfury, (int)(Projectile.damage * 2f), 0, Projectile.owner);
				Main.projectile[a].aiStyle = ProjAIStyleID.Arrow;
				Main.projectile[a].tileCollide = true;
			}
			return true;
		}
	}
}
