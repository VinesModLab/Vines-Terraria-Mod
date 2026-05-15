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
    public class BlueEyeBoss : ModNPC
    {
        private Player player;
        private float speed;

        public override string Texture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/BlueEyeBoss";
			}
		}

        public override string HeadTexture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/BlueEyeBoss_Head_Boss";
			}
		}

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 3;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.EyeofCthulhu);
            NPC.aiStyle = -1; // Will not have any AI from any existing AI styles. 
            NPC.lifeMax = 1800; 
            NPC.damage = 5; 
            NPC.defense = 5; 
            //NPC.width = 120;
            //NPC.height = 120;
            NPC.scale = 1.2f;
            NPC.value = 5000;
            NPC.npcSlots = 1f; // The higher the number, the more NPC slots this NPC takes.
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true; 
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.2f;
            NPC.aiStyle = -1;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
            NPC.defense = (int)(NPC.defense + numPlayers);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<global::VinesMod.Items.TreasureBags.BlueEyeBossBag>()));
        }
        
        public override void AI() //Daytime movement
        {
            Target();
            DespawnHandler();

            bool secondPhase = NPC.life < NPC.lifeMax / 2;
            NPC.ai[0]++;

            if (NPC.ai[0] < (secondPhase ? 70f : 95f))
            {
                Vector2 hoverOffset = new Vector2((float)Math.Sin(NPC.ai[0] / 18f) * 260f, -210f);
                Move(hoverOffset, secondPhase ? 16f : 12f, secondPhase ? 16f : 24f);
                if (NPC.ai[0] % 12f == 0f)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Electric);
                }
            }
            else if (NPC.ai[0] < (secondPhase ? 105f : 135f))
            {
                NPC.velocity *= 0.94f;
                if (NPC.ai[0] % 10f == 0f)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Electric);
                }
            }
            else if (NPC.ai[0] == (secondPhase ? 105f : 135f))
            {
                Shoot(secondPhase ? 2 : 1, secondPhase ? 7.5f : 5.5f);
                CrystalDash(secondPhase ? 15f : 11f);
            }
            else if (NPC.ai[0] > (secondPhase ? 135f : 170f))
            {
                NPC.ai[0] = 0f;
            }
        }

        private void Target()
        {
            player = Main.player[NPC.target]; // This will get the player target.
        }

        private void Move(Vector2 offset, float maxSpeed, float turnResistance)
        {
            speed = maxSpeed; // Sets the max speed of the NPC.
            Vector2 moveTo = player.Center + offset; // Gets the point that the npc will be moving to.
            Vector2 move = moveTo - NPC.Center;
            float magnitude = Magnitude(move);
            if(magnitude > speed)
            {
                move *= speed / magnitude; 
            }
            move = (NPC.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if(magnitude > speed)
            {
                move *= speed / magnitude;
            }
            NPC.velocity = move;
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

        private void CrystalDash(float dashSpeed)
        {
            Vector2 velocity = player.Center - NPC.Center;
            float magnitude = Magnitude(velocity);
            NPC.velocity = magnitude > 0f ? velocity * dashSpeed / magnitude : new Vector2(0f, dashSpeed);
        }

        private void Shoot(int spread, float projectileSpeed)
        {
            int type = ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.BlueEyeBossProjectile>();
            Vector2 velocity = player.Center - NPC.Center; // Get the distance between target and NPC.
            float magnitude = Magnitude(velocity);
            if(magnitude > 0) {
                velocity *= projectileSpeed / magnitude;
            } else
            {
                velocity = new Vector2(0f, 5f);
            }
            for (int i = -spread; i <= spread; i++)
            {
                Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity.RotatedBy(MathHelper.ToRadians(i * 11f)), type, NPC.damage, 2f);
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

            RotateNPCToTarget();
        }

        private void RotateNPCToTarget()
        {
            if (player == null) return;
            Vector2 direction = NPC.Center - player.Center;
            float rotation = (float)Math.Atan2(direction.Y, direction.X);
            NPC.rotation = rotation + ((float)Math.PI * 0.5f);
        }

        public override void OnKill()
        {
            if (!Main.expertMode)
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.BlueEyeBall>(), 1);

                if (Main.rand.Next(5) == 0)
                    Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.CodeO>(), 1);

                if (Main.rand.Next(10) == 0)
                    Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BlackLens, 1);

                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), Main.rand.Next(8, 15));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Lens, Main.rand.Next(2, 5));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Sapphire, Main.rand.Next(1, 4));
            }

            // For settings if the boss has been downed
            VinesWorld.downedBlueEyeBoss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        
    }
}
