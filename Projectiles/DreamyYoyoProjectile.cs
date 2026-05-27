using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace VinesMod.Projectiles
{
    public class DreamyYoyoProjectile : ModProjectile
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

        public override void AI()
        {
            Projectile.localAI[0]++;

            if (Main.myPlayer != Projectile.owner || Projectile.localAI[0] % 45f != 0f)
            {
                return;
            }

            NPC target = FindTarget(420f);
            if (target == null)
            {
                return;
            }

            Vector2 velocity = Projectile.DirectionTo(target.Center) * 7f;
            Projectile.NewProjectile(
                Projectile.GetSource_FromThis(),
                Projectile.Center,
                velocity,
                ModContent.ProjectileType<DreamyMoteProjectile>(),
                (int)(Projectile.damage * 0.45f),
                1.5f,
                Projectile.owner);
        }

        private NPC FindTarget(float maxRange)
        {
            NPC closest = null;
            float closestDistance = maxRange;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (!npc.CanBeChasedBy(Projectile))
                {
                    continue;
                }

                float distance = Projectile.Distance(npc.Center);
                if (distance < closestDistance)
                {
                    closest = npc;
                    closestDistance = distance;
                }
            }

            return closest;
        }
    }
}
