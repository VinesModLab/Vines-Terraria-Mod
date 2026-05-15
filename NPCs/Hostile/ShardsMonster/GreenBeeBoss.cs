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
    public class GreenBeeBoss : ModNPC
    {
        private Player player;
        private float speed;

        public override string Texture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/GreenBeeBoss";
			}
		}

        public override string HeadTexture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/GreenBeeBoss_Head_Boss";
			}
		}

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 12;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.QueenBee);
            NPC.aiStyle = -1; 
            NPC.lifeMax = 2200; 
            NPC.damage = 45; 
            NPC.defense = 10; 
            NPC.value = 5000;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true; 
            NPC.noTileCollide = true;
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
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<global::VinesMod.Items.TreasureBags.GreenBeeBossBag>()));
        }
        
        public override void AI()
        {
            Target();
            DespawnHandler();

            bool secondPhase = NPC.life < NPC.lifeMax / 2;
            NPC.ai[0]++;
            NPC.ai[1]++;

            if (NPC.ai[0] < (secondPhase ? 65f : 90f))
            {
                Vector2 hoverOffset = new Vector2((float)Math.Sin(NPC.ai[0] / 14f) * 230f, -150f);
                Move(player.Center + hoverOffset, secondPhase ? 12f : 9f, secondPhase ? 13f : 20f);
            }
            else if (NPC.ai[0] == (secondPhase ? 65f : 90f))
            {
                Dash(secondPhase ? 15f : 11f);
                ShootStingers(secondPhase ? 2 : 1, secondPhase ? 8f : 6f);
            }
            else if (NPC.ai[0] > (secondPhase ? 98f : 130f))
            {
                NPC.ai[0] = 0f;
            }

            int swarmRate = secondPhase ? 150 : 220;
            if (NPC.ai[1] >= swarmRate)
            {
                NPC.ai[1] = 0f;
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    int beeCount = secondPhase ? 3 : 2;
                    for (int i = 0; i < beeCount; i++)
                    {
                        Vector2 offset = new Vector2(Main.rand.Next(-80, 81), Main.rand.Next(-60, 61));
                        NPC.NewNPC(NPC.GetSource_FromAI(), (int)(NPC.Center.X + offset.X), (int)(NPC.Center.Y + offset.Y), NPCID.BeeSmall);
                    }
                }
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
        }

        private void Dash(float dashSpeed)
        {
            Vector2 velocity = player.Center - NPC.Center;
            float magnitude = velocity.Length();
            NPC.velocity = magnitude > 0f ? velocity * dashSpeed / magnitude : new Vector2(0f, dashSpeed);
        }

        private void ShootStingers(int spread, float speed)
        {
            Vector2 velocity = player.Center - NPC.Center;
            float magnitude = velocity.Length();
            velocity = magnitude > 0f ? velocity * speed / magnitude : new Vector2(0f, speed);
            for (int i = -spread; i <= spread; i++)
            {
                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity.RotatedBy(MathHelper.ToRadians(i * 13f)), ProjectileID.Stinger, NPC.damage, 1f);
            }
        }

        public override void OnKill()
        {
            if (!Main.expertMode)
            {
                if (Main.rand.Next(10) == 0)
                    Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.HoneyedGoggles, 1);

                if (Main.rand.Next(8) == 0)
                    Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Nectar, 1);

                switch (Main.rand.Next(3))
                {
                    case 0:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BeeKeeper, 1);
                        break;
                    case 1:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BeeGun, 1);
                        break;
                    case 2:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BeesKnees, 1);
                        break;
                }

                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardGreen>(), Main.rand.Next(8, 15));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BeeWax, Main.rand.Next(8, 17));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Emerald, Main.rand.Next(1, 4));
            }

            // For settings if the boss has been downed
            VinesWorld.downedGreenBeeBoss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        
    }
}
