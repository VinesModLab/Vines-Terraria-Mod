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
		}

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.TerraBeam);
			AIType = ProjectileID.TerraBeam;
			//Projectile.tileCollide = false;
            Projectile.scale = 1.5f;
			Projectile.light = 0.7f; 
        }

            public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(BuffID.Bleeding, 15 * 60);
			target.AddBuff(BuffID.Frozen, 15 * 60);
			target.AddBuff(BuffID.Chilled, 15 * 60);
        }
	}
}