using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class MeteorOverDriveYoyoProjectile : ModProjectile
	{
		public override string Texture => "VinesMod/Projectiles/MeteorYoyoProjectile";

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.aiStyle = ProjAIStyleID.Yoyo;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.scale = 1.15f;
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 6f;
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 390f;
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 16f;
		}

		public override void AI()
		{
			Projectile.localAI[0]++;
			if (Main.myPlayer != Projectile.owner || Projectile.localAI[0] % 28f != 0f)
			{
				return;
			}

			for (int i = -1; i <= 1; i++)
			{
				Vector2 impactPoint = Projectile.Center + new Vector2(i * 70f, 0f);
				Vector2 spawnPosition = impactPoint + new Vector2(Main.rand.NextFloat(-80f, 80f), -520f);
				Vector2 velocity = (impactPoint - spawnPosition).SafeNormalize(Vector2.UnitY) * 11f;
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), spawnPosition, velocity, ModContent.ProjectileType<MeteorSparkProjectile>(), (int)(Projectile.damage * 0.42f), 2f, Projectile.owner);
			}
		}
	}
}
