using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles.Enemy
{
	public class WhiteFlyingFishBossProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Type] = 4;
			ProjectileID.Sets.TrailingMode[Type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 280;
			Projectile.ignoreWater = true;
		}

		public override void AI()
		{
			Projectile.alpha = System.Math.Max(0, Projectile.alpha - 25);
			Projectile.localAI[0]++;
			Vector2 normal = Projectile.velocity.SafeNormalize(Vector2.UnitY).RotatedBy(MathHelper.PiOver2);
			Projectile.position += normal * (float)System.Math.Sin(Projectile.localAI[0] * 0.22f) * 0.65f;
			Projectile.rotation += 0.18f * Projectile.direction;
			Lighting.AddLight(Projectile.Center, 0.35f, 0.55f, 0.65f);

			if (Main.rand.NextBool(4))
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GemDiamond, Projectile.velocity.X * 0.08f, Projectile.velocity.Y * 0.08f);
			}
		}
	}
}
