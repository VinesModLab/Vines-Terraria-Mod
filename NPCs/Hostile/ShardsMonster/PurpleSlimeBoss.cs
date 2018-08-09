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
            DisplayName.SetDefault("Purple Slime");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.KingSlime);
            npc.aiStyle = 1;
            npc.lifeMax = 4000; 
            npc.width = 122;
            npc.height = 115;
            npc.damage = 5; 
            npc.defense = 5; 
            npc.value = 10000;
            npc.boss = true; // Is a boss
            npc.lavaImmune = true;
            bossBag = mod.ItemType("PurpleSlimeBossBag"); // Needed for the NPC to drop loot bag.
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
            int type = mod.ProjectileType("PurpleSlimeBossProjectile");
            Vector2 velocity = player.Center - npc.Center; // Get the distance between target and npc.
            float magnitude = Magnitude(velocity);
            if(magnitude > 0) {
                velocity *= 5f / magnitude;
            } else
            {
                velocity = new Vector2(0f, 5f);
            }
            Projectile.NewProjectile(npc.Center, velocity, type, npc.damage, 2f);
            npc.ai[1] = (float) Main.rand.Next(100 , 150);
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
                            
                if (Main.rand.Next(4) == 0)
                {
                Item.NewItem(npc.getRect(), ItemID.BloodWater, 1);
                }

                switch (Main.rand.Next(4))
                {
                case 0:
                Item.NewItem(npc.getRect(), ItemID.ShadowOrb, 1);
                break;

                case 1:
                Item.NewItem(npc.getRect(), ItemID.Vilethorn, 1);
                break;

                case 2:
                Item.NewItem(npc.getRect(), ItemID.BallOHurt, 1);
                break;

                case 3:
                Item.NewItem(npc.getRect(), ItemID.BandofStarpower, 1);
                break;
                }

                if (Main.rand.Next(2) == 0)
                {
                Item.NewItem(npc.getRect(), ItemID.Solidifier, 1);
                }
                
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardPurple"), Main.rand.Next(5, 10));
            Item.NewItem(npc.getRect(), ItemID.GoldBar, Main.rand.Next(3, 5));
            Item.NewItem(npc.getRect(), ItemID.IronBar, Main.rand.Next(3, 7));
            Item.NewItem(npc.getRect(), ItemID.SilverOre, Main.rand.Next(10, 20));
            Item.NewItem(npc.getRect(), ItemID.ManaCrystal, Main.rand.Next(1, 2));

            Item.NewItem(npc.getRect(), ItemID.DemoniteOre, Main.rand.Next(40, 60));
            Item.NewItem(npc.getRect(), ItemID.ShadowScale, Main.rand.Next(10, 20));
            Item.NewItem(npc.getRect(), ItemID.Amethyst, Main.rand.Next(1, 2));
            
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
