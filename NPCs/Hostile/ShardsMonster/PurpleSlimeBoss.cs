using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
    public class PurpleSlimeBoss : ModNPC
    {
        private Player player;
        private float speed;

        public override string Texture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/PurpleSlimeBoss";
			}
		}

        public override string HeadTexture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/PurpleSlimeBoss_Head_Boss";
			}
		}

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 6;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.KingSlime);
            NPC.aiStyle = 15;
            NPC.lifeMax = 2200; 
            NPC.width = 122;
            NPC.height = 115;
            NPC.damage = 5; 
            NPC.defense = 5; 
            NPC.value = 5000;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.knockBackResist = 0.2f;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
            NPC.defense = (int)(NPC.defense + numPlayers);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<global::VinesMod.Items.TreasureBags.PurpleSlimeBossBag>()));
        }

        public override void AI()
        {
            Target();
            DespawnHandler();

            bool secondPhase = NPC.life < NPC.lifeMax / 2;
            NPC.ai[0]++;
            NPC.ai[1]++;

            if (NPC.collideY && NPC.ai[0] > (secondPhase ? 42f : 62f))
            {
                Vector2 jump = player.Center - NPC.Center;
                float horizontal = jump.X == 0f ? 0f : Math.Sign(jump.X) * (secondPhase ? 9.5f : 7f);
                NPC.velocity = new Vector2(horizontal, secondPhase ? -11.5f : -9f);
                NPC.ai[0] = 0f;
                DustBurst(DustID.PurpleTorch, 12);
            }

            if (NPC.ai[1] > (secondPhase ? 95f : 135f))
            {
                Shoot(secondPhase);
                if (secondPhase)
                {
                    RadialBurst();
                }
                NPC.ai[1] = 0f;
            }
        }

        private void Target()
        {
            player = Main.player[NPC.target]; // This will get the player target.
        }

        private void DespawnHandler()// Handles if the NPC should despawn.
        {
            if(!player.active || player.dead)
            {
                NPC.TargetClosest(false);
                player = Main.player[NPC.target];
                if(!player.active || player.dead)
                {
                    NPC.velocity = new Vector2(0f, -10f);
                    if(NPC.timeLeft > 10)
                    {
                        NPC.timeLeft = 10;
                    }
                    return;
                }
            }
        }

        private void Shoot(bool secondPhase)
        {
            int type = ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.PurpleSlimeBossProjectile>();
            Vector2 velocity = player.Center - NPC.Center; // Get the distance between target and NPC.
            float magnitude = Magnitude(velocity);
            if(magnitude > 0) {
                velocity *= (secondPhase ? 7f : 5f) / magnitude;
            } else
            {
                velocity = new Vector2(0f, 5f);
            }
            int spread = secondPhase ? 2 : 1;
            for (int i = -spread; i <= spread; i++)
            {
                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity.RotatedBy(MathHelper.ToRadians(i * 14f)), type, NPC.damage, 2f);
            }
        }

        private void RadialBurst()
        {
            int type = ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.PurpleSlimeBossProjectile>();
            for (int i = 0; i < 8; i++)
            {
                Vector2 velocity = Vector2.UnitX.RotatedBy(MathHelper.TwoPi * i / 8f) * 4.5f;
                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity, type, (int)(NPC.damage * 0.75f), 1f);
            }
        }

        private void DustBurst(int dustId, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, dustId);
            }
        }

        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 1;
            NPC.frameCounter %= 20;
            int frame = (int)(NPC.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[Type]) frame = 0;
            NPC.frame.Y = frame * frameHeight;
        }

        public override void OnKill()
        {
            if (!Main.expertMode)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Vilethorn, 1);
                        break;
                    case 1:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BallOHurt, 1);
                        break;
                    case 2:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BandofStarpower, 1);
                        break;
                    case 3:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Solidifier, 1);
                        break;
                }

                if (Main.rand.Next(20) == 0)
                    Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.SlimeStaff, 1);

                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), Main.rand.Next(8, 15));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Amethyst, Main.rand.Next(1, 4));
            }

            // For settings if the boss has been downed
            VinesWorld.downedPurpleSlimeBoss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        
    }
}
