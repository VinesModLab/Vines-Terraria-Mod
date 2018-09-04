using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace VinesMod.Projectiles
{
    public class MeteorYoyoProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Projectile Meteor");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 99;
            projectile.friendly = true; 
            projectile.penetrate = -1; 
            projectile.melee = true; 
            projectile.scale = 1f;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 3.5f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 13f;
        }
    }
}
