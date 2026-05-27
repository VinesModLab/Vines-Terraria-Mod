using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class CometCarbineShot : ModProjectile
	{
		public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.Starfury;

		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 100;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.extraUpdates = 1;
			Projectile.DamageType = DamageClass.Ranged;
		}

		public override void AI()
		{
			Projectile.rotation += 0.3f * Projectile.direction;
			Projectile.light = 0.55f;
			if (Main.rand.NextBool(2))
			{
				int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, -Projectile.velocity.X * 0.15f, -Projectile.velocity.Y * 0.15f);
				Main.dust[dust].noGravity = true;
			}
		}

		public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < Main.maxNPCs; i++)
			{
				NPC npc = Main.npc[i];
				if (npc.CanBeChasedBy(Projectile) && npc.Distance(Projectile.Center) < 72f)
				{
					int damage = (int)(Projectile.damage * 0.45f);
					npc.SimpleStrikeNPC(damage, Projectile.direction);
				}
			}
			for (int i = 0; i < 16; i++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
			}
		}
	}
}
