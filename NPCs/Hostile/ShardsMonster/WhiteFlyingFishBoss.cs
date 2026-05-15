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
    [AutoloadBossHead]
    public class WhiteFlyingFishBoss : ModNPC
    {
        private Player player;
        private float speed;

        public override string Texture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/WhiteFlyingFishBoss";
			}
		}

        public override string HeadTexture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/WhiteFlyingFishBoss_Head_Boss";
			}
		}

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 4;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.IchorSticker);
            NPC.aiStyle = -1; 
            NPC.lifeMax = 9000; 
            NPC.damage = 55; 
            NPC.defense = 12; 
            NPC.scale = 5f;
            NPC.value = 25000;
            NPC.boss = true; // Is a boss
            NPC.lavaImmune = true;
            NPC.noGravity = true; 
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0f;
            if (!Main.dedServ)
            {
                Music = MusicID.Boss2;
            }
 // Needed for the NPC to drop loot bag.
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
            NPC.defense = (int)(NPC.defense + numPlayers);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<global::VinesMod.Items.TreasureBags.WhiteFlyingFishBossBag>()));
        }
        
        public override void AI()
        {
            Target();
            DespawnHandler();

            bool secondPhase = NPC.life < NPC.lifeMax / 2;
            NPC.ai[0]++;

            if (NPC.ai[0] < (secondPhase ? 70f : 95f))
            {
                Vector2 hoverOffset = new Vector2((float)Math.Sin(NPC.ai[0] / 18f) * 260f, -220f);
                Move(player.Center + hoverOffset, secondPhase ? 11f : 8f, 18f);
            }
            else if (NPC.ai[0] == (secondPhase ? 70f : 95f))
            {
                Charge(secondPhase ? 14f : 11f);
            }
            else if (NPC.ai[0] > (secondPhase ? 95f : 130f))
            {
                Shoot(secondPhase);
                if (secondPhase)
                {
                    RainShards();
                }
                else
                {
                    CrossingShards();
                }
                NPC.ai[0] = 0f;
            }

            NPC.rotation = NPC.velocity.X * 0.04f;
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

        private void Move(Vector2 destination, float maxSpeed, float turnResistance)
        {
            Vector2 move = destination - NPC.Center;
            float magnitude = Magnitude(move);
            if (magnitude > maxSpeed)
            {
                move *= maxSpeed / magnitude;
            }

            NPC.velocity = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
        }

        private void Charge(float chargeSpeed)
        {
            Vector2 velocity = player.Center - NPC.Center;
            float magnitude = Magnitude(velocity);
            if (magnitude > 0f)
            {
                velocity *= chargeSpeed / magnitude;
            }
            else
            {
                velocity = new Vector2(0f, chargeSpeed);
            }

            NPC.velocity = velocity;
        }

        private void Shoot(bool secondPhase)
        {
            int type = ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.WhiteFlyingFishBossProjectile>();
            Vector2 velocity = player.Center - NPC.Center; // Get the distance between target and NPC.
            float magnitude = Magnitude(velocity);
            if(magnitude > 0) {
                velocity *= (secondPhase ? 9f : 7.5f) / magnitude;
            } else
            {
                velocity = new Vector2(0f, 5f);
            }

            int spread = secondPhase ? 2 : 1;
            for (int i = -spread; i <= spread; i++)
            {
                Vector2 shotVelocity = velocity.RotatedBy(MathHelper.ToRadians(i * 10f));
                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, shotVelocity, type, NPC.damage, 2f);
            }
        }

        private void RainShards()
        {
            int type = ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.WhiteFlyingFishBossProjectile>();
            for (int i = -2; i <= 2; i++)
            {
                Vector2 position = player.Center + new Vector2(i * 90f, -520f);
                Vector2 velocity = new Vector2(i * 0.35f, 7.5f);
                Projectile.NewProjectile(NPC.GetSource_FromAI(), position, velocity, type, (int)(NPC.damage * 0.75f), 1f);
            }
        }

        private void CrossingShards()
        {
            int type = ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.WhiteFlyingFishBossProjectile>();
            for (int i = -1; i <= 1; i++)
            {
                Vector2 leftPosition = player.Center + new Vector2(-520f, -90f + i * 80f);
                Vector2 rightPosition = player.Center + new Vector2(520f, -90f + i * 80f);
                Projectile.NewProjectile(NPC.GetSource_FromAI(), leftPosition, new Vector2(7f, 0.35f * i), type, (int)(NPC.damage * 0.7f), 1f);
                Projectile.NewProjectile(NPC.GetSource_FromAI(), rightPosition, new Vector2(-7f, 0.35f * i), type, (int)(NPC.damage * 0.7f), 1f);
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
                switch (Main.rand.Next(5))
                {
                    case 0:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.StarCannon, 1);
                        break;
                    case 1:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.LargeDiamond, 1);
                        break;
                    case 2:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.LargeRuby, 1);
                        break;
                    case 3:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.LargeSapphire, 1);
                        break;
                    case 4:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.WhiteFishSword>(), 1);
                        break;
                }

                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), Main.rand.Next(35, 56));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceWhite>(), 1);
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Diamond, Main.rand.Next(3, 6));
            }

            // For settings if the boss has been downed
            VinesWorld.downedWhiteFlyingFishBoss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        
    }
}
