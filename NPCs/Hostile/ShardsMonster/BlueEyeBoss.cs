using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
    [AutoloadBossHead]
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
            NPC.lifeMax = 3500; 
            NPC.damage = 5; 
            NPC.defense = 5; 
            //NPC.width = 120;
            //NPC.height = 120;
            NPC.scale = 1.2f;
            NPC.value = 10000;
            NPC.npcSlots = 1f; // The higher the number, the more NPC slots this NPC takes.
            NPC.boss = true; // Is a boss
            NPC.lavaImmune = true;
            NPC.noGravity = true; 
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.2f;
            if (!Main.dedServ)
            {
                Music = MusicID.Boss1;
            }
 // Needed for the NPC to drop loot bag.
            NPC.aiStyle = 2; // aiType renamed to NPC.aiStyle // Different Movement at Night
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
            NPC.defense = (int)(NPC.defense + numPlayers);
        }
        
        public override void AI() //Daytime movement
        {
            Target();
            DespawnHandler();

            Move(new Vector2(Main.rand.Next(-200, 200), -Main.rand.Next(100, 250))); // Calls the Move Method
            //Attacking
            NPC.ai[1] -= 1f; // Subtracts 1 from the ai.
            if(NPC.ai[1] <= 0f)
            {
                Shoot();
            }
        }

        private void Target()
        {
            player = Main.player[NPC.target]; // This will get the player target.
        }

        private void Move(Vector2 offset)
        {
            speed = 15f; // Sets the max speed of the NPC.
            Vector2 moveTo = player.Center + offset; // Gets the point that the npc will be moving to.
            Vector2 move = moveTo - NPC.Center;
            float magnitude = Magnitude(move);
            if(magnitude > speed)
            {
                move *= speed / magnitude; 
            }
            float turnResistance = 25f; // The larget the number the slower the npc will turn.
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

        private void Shoot()
        {
            int type = ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.BlueEyeBossProjectile>();
            Vector2 velocity = player.Center - NPC.Center; // Get the distance between target and NPC.
            float magnitude = Magnitude(velocity);
            if(magnitude > 0) {
                velocity *= 5f / magnitude;
            } else
            {
                velocity = new Vector2(0f, 5f);
            }
            Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity, type, NPC.damage, 2f);
            NPC.ai[1] = (float) Main.rand.Next(75 , 100);
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
            if (Main.expertMode)
            {
            // Boss bags now drop via ModifyNPCLoot (1.4)
            }
            else{
                    if (Main.rand.Next(2) == 0)
                    {
                        Item.NewItem(NPC.GetSource_Loot(), (int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.BlueEyeBall>(), 1);
                    }

                    if (Main.rand.Next(5) == 0)
                    {
                        Item.NewItem(NPC.GetSource_Loot(), (int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.CodeO>(), 1);
                    }

                    if (Main.rand.Next(10) == 0)
                {
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BlackLens, 1);
                }

                    if (Main.rand.Next(30) == 0)
                {
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Binoculars, 1);
                }

                Item.NewItem(NPC.GetSource_Loot(), (int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), Main.rand.Next(5, 10));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Lens, Main.rand.Next(3, 5));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.GoldBar, Main.rand.Next(3, 5));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.SilverOre, Main.rand.Next(10, 20));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.IronBar, Main.rand.Next(3, 7));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.ManaCrystal, Main.rand.Next(1, 2));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.CrimsonSeeds, Main.rand.Next(1, 2));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.CorruptSeeds, Main.rand.Next(1, 2));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.DemoniteOre, Main.rand.Next(20, 40));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.CrimtaneOre, Main.rand.Next(20, 40));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Sapphire, Main.rand.Next(1, 2));   
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
