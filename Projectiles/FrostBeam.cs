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
			DisplayName.SetDefault("FrostBeam");
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
            target.AddBuff(BuffID.Frozen, 15 * 60);
			target.AddBuff(BuffID.Chilled, 15 * 60);
        }
    }
}