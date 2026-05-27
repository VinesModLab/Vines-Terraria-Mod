using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class SlimeHexProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 140;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = false;
			Projectile.DamageType = DamageClass.Magic;
		}

		public override void AI()
		{
			Projectile.rotation += 0.18f * Projectile.direction;
			Projectile.velocity.Y += 0.08f;
			Projectile.light = 0.3f;

			if (Main.rand.NextBool(2))
			{
				int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, 0f, 0f, 140, default, 0.9f);
				Main.dust[dust].noGravity = true;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (Projectile.velocity.X != oldVelocity.X)
			{
				Projectile.velocity.X = -oldVelocity.X * 0.86f;
			}

			if (Projectile.velocity.Y != oldVelocity.Y)
			{
				Projectile.velocity.Y = -oldVelocity.Y * 0.86f;
			}

			Projectile.penetrate--;
			return Projectile.penetrate <= 0;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.ShadowFlame, 180);
		}
	}
}
