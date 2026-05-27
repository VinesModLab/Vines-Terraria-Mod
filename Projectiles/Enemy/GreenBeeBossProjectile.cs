using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles.Enemy
{
	public class GreenBeeBossProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 28;
			Projectile.height = 12;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 240;
			Projectile.ignoreWater = true;
		}

		public override void AI()
		{
			Projectile.alpha = System.Math.Max(0, Projectile.alpha - 25);
			Projectile.velocity *= 1.004f;
			Projectile.rotation = Projectile.velocity.ToRotation();
			Lighting.AddLight(Projectile.Center, 0.2f, 0.65f, 0.12f);

			if (Main.rand.NextBool(4))
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GemEmerald, Projectile.velocity.X * 0.08f, Projectile.velocity.Y * 0.08f);
			}
		}

		public override void OnHitPlayer(Player target, Player.HurtInfo info)
		{
			target.AddBuff(BuffID.Poisoned, 240);
		}
	}
}
