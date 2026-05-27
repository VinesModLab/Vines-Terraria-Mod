using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class MeteorSparkProjectile : ModProjectile
	{
		public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.Starfury;

		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 120;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.extraUpdates = 1;
		}

		public override void AI()
		{
			Projectile.rotation += 0.25f * Projectile.direction;
			Projectile.velocity.Y += 0.08f;
			Projectile.light = 0.45f;

			if (Main.rand.NextBool(2))
			{
				int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 1f);
				Main.dust[dust].noGravity = true;
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.OnFire, 240);
		}
	}
}
