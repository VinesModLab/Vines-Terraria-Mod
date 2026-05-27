using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles.Enemy
{
	public class PurpleSlimeBossProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 260;
			Projectile.ignoreWater = true;
		}

		public override void AI()
		{
			Projectile.alpha = System.Math.Max(0, Projectile.alpha - 20);
			Projectile.velocity.Y += 0.045f;
			Projectile.velocity.X *= 0.995f;
			Projectile.rotation += Projectile.velocity.X * 0.045f;
			Projectile.scale = 1f + (float)System.Math.Sin(Projectile.localAI[0]++ * 0.16f) * 0.08f;
			Lighting.AddLight(Projectile.Center, 0.35f, 0.05f, 0.55f);

			if (Main.rand.NextBool(4))
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, Projectile.velocity.X * 0.08f, Projectile.velocity.Y * 0.08f);
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				return true;
			}

			if (Projectile.velocity.X != oldVelocity.X)
			{
				Projectile.velocity.X = -oldVelocity.X * 0.75f;
			}
			if (Projectile.velocity.Y != oldVelocity.Y)
			{
				Projectile.velocity.Y = -oldVelocity.Y * 0.65f;
			}
			return false;
		}
	}
}
