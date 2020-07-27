using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class MoonlightProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moonlight");
		}

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.InfluxWaver);
            aiType = ProjectileID.InfluxWaver;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.scale = 1.5f;
            projectile.light = 0.6f; 
        }

            public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			
        }
	}
}