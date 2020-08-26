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
            DisplayName.SetDefault("White FlyingFish");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.IchorSticker);
            npc.aiStyle = 14; 
            npc.lifeMax = 6000; 
            npc.damage = 50; 
            npc.defense = 5; 
            npc.scale = 5f;
            npc.value = 10000;
            npc.boss = true; // Is a boss
            npc.lavaImmune = true;
            npc.noGravity = true; 
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            bossBag = mod.ItemType("WhiteFlyingFishBossBag"); // Needed for the NPC to drop loot bag.
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
            int type = mod.ProjectileType("WhiteFlyingFishBossProjectile");
            Vector2 velocity = player.Center - npc.Center; // Get the distance between target and npc.
            float magnitude = Magnitude(velocity);
            if(magnitude > 0) {
                velocity *= 7.5f / magnitude;
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
                
                if (Main.rand.Next(2) == 0)
                {
                    switch (Main.rand.Next(5))
                {
                    case 0:
                    player.QuickSpawnItem(ItemID.StarCannon, 1);
                    break;
                    case 1:
                    player.QuickSpawnItem(ItemID.LargeDiamond, 1);
                    break;
                    case 2:
                    player.QuickSpawnItem(ItemID.LargeRuby, 1);
                    break;
                    case 3:
                    player.QuickSpawnItem(ItemID.LargeSapphire, 1);
                    break;
                    case 4:
                    player.QuickSpawnItem(mod.ItemType("WhiteFishSword"), 1);
                    break;
                }
                }
            
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardWhite"), Main.rand.Next(5, 10));
            Item.NewItem(npc.getRect(), ItemID.GoldBar, Main.rand.Next(5, 8));
            Item.NewItem(npc.getRect(), ItemID.IronBar, Main.rand.Next(5, 10));
            Item.NewItem(npc.getRect(), ItemID.SilverOre, Main.rand.Next(15, 20));
            Item.NewItem(npc.getRect(), ItemID.ManaCrystal, Main.rand.Next(1, 2));
            Item.NewItem(npc.getRect(), ItemID.LifeCrystal, Main.rand.Next(1, 2));

            Item.NewItem(npc.getRect(), ItemID.PlatinumOre, Main.rand.Next(30, 50));
            Item.NewItem(npc.getRect(), ItemID.GoldOre, Main.rand.Next(30, 50));
            Item.NewItem(npc.getRect(), ItemID.Diamond, Main.rand.Next(3, 5));
            
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
