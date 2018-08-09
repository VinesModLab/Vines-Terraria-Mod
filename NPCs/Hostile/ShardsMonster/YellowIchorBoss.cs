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

namespace VinesMod.NPCs.Hostile.ShardMonster
{
    [AutoloadBossHead]
    public class YellowIchorBoss : ModNPC
    {
        private Player player;
        private float speed;

        public override string Texture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/YellowIchorBoss";
			}
		}

        public override string HeadTexture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/YellowIchor_Head_Boss";
			}
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yellow Ichor");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.IchorSticker);
            npc.aiStyle = -1; 
            npc.lifeMax = 4000; 
            npc.damage = 5; 
            npc.defense = 5; 
            npc.scale = 2f;
            npc.value = 10000;
            npc.boss = true; // Is a boss
            npc.lavaImmune = true;
            npc.noGravity = true; 
            npc.noTileCollide = true;
            bossBag = mod.ItemType("YellowIchorBossBag"); // Needed for the NPC to drop loot bag.
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
            npc.defense = (int)(npc.defense + numPlayers);
        }
        

        public override void AI()
        {
            Target();
            DespawnHandler();

            Move(new Vector2(Main.rand.Next(-300, 300), -Main.rand.Next(45, 250))); // Calls the Move Method
            //Attacking
            npc.ai[1] -= 1f; // Subtracts 1 from the ai.
            if(npc.ai[1] <= 0f)
            {
                Shoot();
            }
        }

        private void Target()
        {
            player = Main.player[npc.target]; // This will get the player target.
        }

        private void Move(Vector2 offset)
        {
            speed = 7f; // Sets the max speed of the npc.
            Vector2 moveTo = player.Center + offset; // Gets the point that the npc will be moving to.
            Vector2 move = moveTo - npc.Center;
            float magnitude = Magnitude(move);
            if(magnitude > speed)
            {
                move *= speed / magnitude; 
            }
            float turnResistance = 25f; // The larget the number the slower the npc will turn.
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if(magnitude > speed)
            {
                move *= speed / magnitude;
            }
            npc.velocity = move;
        }

        private void DespawnHandler()// Handles if the NPC should despawn.
        {
            if(!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if(!player.active || player.dead)
                {
                    npc.velocity = new Vector2(0f, -10f);
                    if(npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                    return;
                }
            }
        }

        private void Shoot()
        {
            int type = mod.ProjectileType("YellowIchorBossProjectile");
            Vector2 velocity = player.Center - npc.Center; // Get the distance between target and npc.
            float magnitude = Magnitude(velocity);
            if(magnitude > 0) {
                velocity *= 5f / magnitude;
            } else
            {
                velocity = new Vector2(0f, 5f);
            }
            Projectile.NewProjectile(npc.Center, velocity, type, npc.damage, 2f);
            npc.ai[1] = 100f;
        }

        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1;
            npc.frameCounter %= 20;
            int frame = (int)(npc.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;

        }


        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
            npc.DropBossBags();
            }
            else
            {
                
                if (Main.rand.Next(2) == 0)
                {
                    switch (Main.rand.Next(3))
                {
                    case 0:
                    Item.NewItem(npc.getRect(), mod.ItemType("BallisticStaff"), 1);
                    break;
                    case 1:
                    Item.NewItem(npc.getRect(), mod.ItemType("GoldenGunBlade"), 1);
                    break;
                    case 2:
                    Item.NewItem(npc.getRect(), mod.ItemType("ShieldOfFlag"), 1);
                    break;
                }
                }
            

                if (Main.rand.Next(3) == 0)
                {
                Item.NewItem(npc.getRect(), ItemID.EatersBone, 1);
                }

            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardYellow"), Main.rand.Next(5, 10));
            Item.NewItem(npc.getRect(), ItemID.GoldBar, Main.rand.Next(5, 8));
            Item.NewItem(npc.getRect(), ItemID.IronBar, Main.rand.Next(5, 10));
            Item.NewItem(npc.getRect(), ItemID.SilverOre, Main.rand.Next(15, 20));
            Item.NewItem(npc.getRect(), ItemID.ManaCrystal, Main.rand.Next(1, 2));
            Item.NewItem(npc.getRect(), ItemID.LifeCrystal, Main.rand.Next(1, 2));

            Item.NewItem(npc.getRect(), ItemID.PlatinumOre, Main.rand.Next(30, 50));
            Item.NewItem(npc.getRect(), ItemID.GoldOre, Main.rand.Next(30, 50));
            Item.NewItem(npc.getRect(), ItemID.Amber, Main.rand.Next(3, 5));
            Item.NewItem(npc.getRect(), ItemID.Topaz, Main.rand.Next(1, 2));
            
            }

            

            // For settings if the boss has been downed
            VinesWorld.downedYellowIchorBoss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        
    }
}
