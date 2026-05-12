using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace VinesMod.Projectiles
{
    public class FrostBeam : ModProjectile
    {
        public override void SetStaticDefaults()
		{
		}

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.InfluxWaver);
			AIType = ProjectileID.InfluxWaver;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.scale = 1.5f;
            Projectile.light = 0.6f; 
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frozen, 15 * 60);
			target.AddBuff(BuffID.Chilled, 15 * 60);
        }
    }
}