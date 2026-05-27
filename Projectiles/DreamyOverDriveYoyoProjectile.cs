using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class DreamyOverDriveYoyoProjectile : ModProjectile
	{
		public override string Texture => "VinesMod/Projectiles/DreamyYoyoProjectile";

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
			if (Main.myPlayer != Projectile.owner || Projectile.localAI[0] % 24f != 0f)
			{
				return;
			}

			for (int i = -1; i <= 1; i++)
			{
				Vector2 velocity = new Vector2(0f, -7f).RotatedBy(MathHelper.ToRadians(i * 28f + Projectile.localAI[0]));
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, velocity, ModContent.ProjectileType<DreamyMoteProjectile>(), (int)(Projectile.damage * 0.38f), 1.5f, Projectile.owner);
			}
		}
	}
}
