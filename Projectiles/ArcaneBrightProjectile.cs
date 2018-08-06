using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class ArcaneBrightProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ArcaneBright");
		}

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.TerraBeam);
            aiType = ProjectileID.TerraBeam;
			//projectile.tileCollide = false;
            projectile.scale = 1.5f;
			projectile.light = 1f; 
        }

            public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.OnFire, 15 * 60);
			target.AddBuff(BuffID.Bleeding, 15 * 60);
			target.AddBuff(BuffID.Frozen, 15 * 60);
			target.AddBuff(BuffID.Chilled, 15 * 60);
        }
	}
}