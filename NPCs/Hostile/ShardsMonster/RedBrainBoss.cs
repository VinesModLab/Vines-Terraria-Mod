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
    public class RedBrainBoss : ModNPC
    {
        private Player player;
        private float speed;

        public override string Texture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/RedBrainBoss";
			}
		}

        public override string HeadTexture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/RedBrainBoss_Head_Boss";
			}
		}

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 8;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.BrainofCthulhu);
            NPC.aiStyle = -1;
            NPC.lifeMax = 2000; 
            NPC.damage = 35; 
            NPC.defense = 3; 
            NPC.value = 5000;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true; 
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0.5f;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
            NPC.defense = (int)(NPC.defense + numPlayers);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<global::VinesMod.Items.TreasureBags.RedBrainBossBag>()));
        }
        
        public override void AI()
        {
            Target();
            DespawnHandler();

            bool secondPhase = NPC.life < NPC.lifeMax / 2;
            NPC.ai[0]++;

            if (NPC.ai[0] < (secondPhase ? 85f : 120f))
            {
                Vector2 hoverOffset = new Vector2((float)Math.Cos(NPC.ai[0] / 22f) * 210f, -120f + (float)Math.Sin(NPC.ai[0] / 18f) * 70f);
                Move(player.Center + hoverOffset, secondPhase ? 10f : 7f, secondPhase ? 12f : 20f);
            }
            else if (NPC.ai[0] == (secondPhase ? 85f : 120f))
            {
                BlinkNearPlayer(secondPhase);
                PsychicBurst(secondPhase);
            }
            else if (NPC.ai[0] > (secondPhase ? 125f : 170f))
            {
                NPC.ai[0] = 0f;
            }
        }

        private void Target()
        {
            NPC.TargetClosest(false);
            player = Main.player[NPC.target];
        }

        private void DespawnHandler()
        {
            if (!player.active || player.dead)
            {
                NPC.TargetClosest(false);
                player = Main.player[NPC.target];
                if (!player.active || player.dead)
                {
                    NPC.velocity = new Vector2(0f, -10f);
                    if (NPC.timeLeft > 10)
                    {
                        NPC.timeLeft = 10;
                    }
                }
            }
        }

        private void Move(Vector2 destination, float maxSpeed, float turnResistance)
        {
            Vector2 move = destination - NPC.Center;
            float magnitude = move.Length();
            if (magnitude > maxSpeed)
            {
                move *= maxSpeed / magnitude;
            }

            NPC.velocity = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
            if (NPC.velocity.Length() > maxSpeed)
            {
                NPC.velocity = Vector2.Normalize(NPC.velocity) * maxSpeed;
            }
            NPC.direction = NPC.spriteDirection = NPC.velocity.X >= 0f ? 1 : -1;
        }

        private void BlinkNearPlayer(bool secondPhase)
        {
            for (int i = 0; i < 24; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood);
            }

            Vector2 offset = new Vector2(Main.rand.Next(-260, 261), Main.rand.Next(-190, -80));
            NPC.Center = player.Center + offset;
            Vector2 velocity = player.Center - NPC.Center;
            float magnitude = velocity.Length();
            NPC.velocity = magnitude > 0f ? velocity * (secondPhase ? 9f : 6f) / magnitude : Vector2.Zero;
            NPC.netUpdate = true;
        }

        private void PsychicBurst(bool secondPhase)
        {
            int spread = secondPhase ? 2 : 1;
            Vector2 velocity = player.Center - NPC.Center;
            float magnitude = velocity.Length();
            velocity = magnitude > 0f ? velocity * (secondPhase ? 6f : 4.5f) / magnitude : new Vector2(0f, 4.5f);
            for (int i = -spread; i <= spread; i++)
            {
                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity.RotatedBy(MathHelper.ToRadians(i * 18f)), ProjectileID.DemonScythe, NPC.damage, 1f);
            }
        }

        public override void OnKill()
        {
            if (!Main.expertMode)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.PanicNecklace, 1);
                        break;
                    case 1:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.CrimsonRod, 1);
                        break;
                    case 2:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.TheRottedFork, 1);
                        break;
                    case 3:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.RedEyeBall>(), 1);
                        break;
                }

                if (Main.rand.Next(10) == 0)
                    Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BoneRattle, 1);

                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), Main.rand.Next(8, 15));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.TissueSample, Main.rand.Next(8, 15));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Ruby, Main.rand.Next(1, 4));
            }

            // For settings if the boss has been downed
            VinesWorld.downedRedBrainBoss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        
    }
}
