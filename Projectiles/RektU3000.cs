using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace VinesMod.Projectiles
{
    public class RektU3000 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = ProjAIStyleID.Yoyo;
            Projectile.friendly = true; 
            Projectile.penetrate = -1; 
            Projectile.DamageType = DamageClass.Melee; 
            Projectile.scale = 1f;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 3.5f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 300f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13f;
        }
    }
}
