using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class HivevineStingerProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 100;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.extraUpdates = 1;
		}

		public override void AI()
		{
			Projectile.rotation = Projectile.velocity.ToRotation();
			Projectile.light = 0.35f;

			NPC target = FindTarget(320f);
			if (target != null)
			{
				Vector2 desiredVelocity = Projectile.DirectionTo(target.Center) * Projectile.velocity.Length();
				Projectile.velocity = Vector2.Lerp(Projectile.velocity, desiredVelocity, 0.045f);
			}

			if (Main.rand.NextBool(2))
			{
				int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Grass, Projectile.velocity.X * 0.08f, Projectile.velocity.Y * 0.08f, 120, default, 0.9f);
				Main.dust[dust].noGravity = true;
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Poisoned, 240);
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
