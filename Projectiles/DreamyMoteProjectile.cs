using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class DreamyMoteProjectile : ModProjectile
	{
		public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.EnchantedBeam;

		public override void SetDefaults()
		{
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.friendly = true;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 90;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.extraUpdates = 1;
		}

		public override void AI()
		{
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			Projectile.light = 0.35f;

			NPC target = FindTarget(320f);
			if (target != null)
			{
				Vector2 desiredVelocity = Projectile.DirectionTo(target.Center) * 8f;
				Projectile.velocity = Vector2.Lerp(Projectile.velocity, desiredVelocity, 0.06f);
			}

			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, 0f, 0f, 150, default, 0.8f);
				Main.dust[dust].noGravity = true;
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Confused, 180);
		}

		private NPC FindTarget(float maxRange)
		{
			NPC closest = null;
			float closestDistance = maxRange;

			for (int i = 0; i < Main.maxNPCs; i++)
			{
				NPC npc = Main.npc[i];
				if (!npc.CanBeChasedBy(Projectile))
				{
					continue;
				}

				float distance = Projectile.Distance(npc.Center);
				if (distance < closestDistance)
				{
					closest = npc;
					closestDistance = distance;
				}
			}

			return closest;
		}
	}
}
