using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles.Enemy
{
	public class RedBrainBossProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Type] = 6;
			ProjectileID.Sets.TrailingMode[Type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 26;
			Projectile.height = 26;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 260;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}

		public override void AI()
		{
			Projectile.alpha = System.Math.Max(0, Projectile.alpha - 18);
			Projectile.localAI[0]++;
			if (Projectile.localAI[0] < 55f)
			{
				Player target = Main.player[Player.FindClosest(Projectile.Center, Projectile.width, Projectile.height)];
				if (target.active && !target.dead)
				{
					float speed = Projectile.velocity.Length();
					Vector2 desired = Projectile.Center.DirectionTo(target.Center) * speed;
					Projectile.velocity = Vector2.Lerp(Projectile.velocity, desired, 0.025f);
				}
			}

			Projectile.rotation += 0.22f * Projectile.direction;
			Lighting.AddLight(Projectile.Center, 0.65f, 0.04f, 0.18f);

			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CrimsonTorch, Projectile.velocity.X * 0.08f, Projectile.velocity.Y * 0.08f);
			}
		}
	}
}
