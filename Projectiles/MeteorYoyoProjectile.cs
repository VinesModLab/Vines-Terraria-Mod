using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ID;

namespace VinesMod.Projectiles
{
    public class MeteorYoyoProjectile : ModProjectile
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

            if (Main.myPlayer != Projectile.owner || Projectile.localAI[0] % 50f != 0f)
            {
                return;
            }

            NPC target = FindTarget(500f);
            Vector2 impactPoint = target?.Center ?? Projectile.Center;
            Vector2 spawnPosition = impactPoint + new Vector2(Main.rand.NextFloat(-120f, 120f), -520f);
            Vector2 velocity = (impactPoint - spawnPosition).SafeNormalize(Vector2.UnitY) * 10f;

            Projectile.NewProjectile(
                Projectile.GetSource_FromThis(),
                spawnPosition,
                velocity,
                ModContent.ProjectileType<MeteorSparkProjectile>(),
                (int)(Projectile.damage * 0.55f),
                2f,
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
