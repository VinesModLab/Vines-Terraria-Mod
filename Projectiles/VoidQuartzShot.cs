using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class VoidQuartzShot : ModProjectile
	{
		public override string Texture => "VinesMod/Projectiles/BladeArtProjectile";

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 140;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.extraUpdates = 1;
			Projectile.DamageType = DamageClass.Ranged;
		}

		public override void AI()
		{
			Projectile.rotation = Projectile.velocity.ToRotation();
			Projectile.light = 0.35f;
			if (Main.rand.NextBool(2))
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GemAmethyst, 0f, 0f, 120);
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			Vector2 pull = Projectile.Center - target.Center;
			if (pull.Length() > 1f)
			{
				target.velocity += Vector2.Normalize(pull) * 2.2f;
			}
			target.AddBuff(BuffID.ShadowFlame, 120);
		}
	}
}
