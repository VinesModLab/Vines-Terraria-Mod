using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class NullProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.StarWrath);
			AIType = ProjectileID.StarWrath;
			Projectile.width = 500;
			Projectile.height = 500;
			Projectile.ignoreWater = true;
			Projectile.penetrate = 999;
			Projectile.scale = 5f;
			Projectile.light = 1f; 
		}
	}
}