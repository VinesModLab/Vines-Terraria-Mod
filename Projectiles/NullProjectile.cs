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
			DisplayName.SetDefault("Power of Null");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.StarWrath);
			aiType = ProjectileID.StarWrath;
			projectile.width = 500;
			projectile.height = 500;
			projectile.ignoreWater = true;
			projectile.penetrate = 999;
			projectile.scale = 5f;
			projectile.light = 1f; 
		}
	}
}