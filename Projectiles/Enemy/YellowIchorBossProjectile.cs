using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles.Enemy
{
	public class YellowIchorBossProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Type] = 6;
			ProjectileID.Sets.TrailingMode[Type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 22;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 300;
			Projectile.ignoreWater = true;
		}

		public override void AI()
		{
			Projectile.alpha = System.Math.Max(0, Projectile.alpha - 25);
			Projectile.velocity.Y = System.Math.Min(Projectile.velocity.Y + 0.08f, 12f);
			Projectile.velocity.X *= 0.998f;
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			Lighting.AddLight(Projectile.Center, 0.7f, 0.55f, 0.05f);

			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.IchorTorch, Projectile.velocity.X * 0.06f, Projectile.velocity.Y * 0.06f);
			}
		}

		public override void OnHitPlayer(Player target, Player.HurtInfo info)
		{
			target.AddBuff(BuffID.Ichor, 180);
		}
	}
}
