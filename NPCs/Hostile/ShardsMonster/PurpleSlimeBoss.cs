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
            NPC.lifeMax = 4000; 
            NPC.width = 122;
            NPC.height = 115;
            NPC.damage = 5; 
            NPC.defense = 5; 
            NPC.value = 10000;
            NPC.boss = true; // Is a boss
            NPC.lavaImmune = true;
            NPC.knockBackResist = 0.2f;
            if (!Main.dedServ)
            {
                Music = MusicID.Boss1;
            }
 // Needed for the NPC to drop loot bag.
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
            NPC.defense = (int)(NPC.defense + numPlayers);
        }

        public override void AI()
        {
            Target();
            DespawnHandler();

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
            int type = ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.PurpleSlimeBossProjectile>();
            Vector2 velocity = player.Center - NPC.Center; // Get the distance between target and NPC.
            float magnitude = Magnitude(velocity);
            if(magnitude > 0) {
                velocity *= 5f / magnitude;
            } else
            {
                velocity = new Vector2(0f, 5f);
            }
            Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity, type, NPC.damage, 2f);
            NPC.ai[1] = (float) Main.rand.Next(100 , 150);
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
            if (Main.expertMode)
            {
            // Boss bags now drop via ModifyNPCLoot (1.4)
            }
            else
            {
                            
                if (Main.rand.Next(4) == 0)
                {
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BloodWater, 1);
                }

                switch (Main.rand.Next(5))
                {
                case 0:
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.ShadowOrb, 1);
                break;

                case 1:
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Vilethorn, 1);
                break;

                case 2:
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BallOHurt, 1);
                break;

                case 3:
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BandofStarpower, 1);
                break;

                case 4:
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.SlimeStaff, 1);
                break;
                }

                if (Main.rand.Next(2) == 0)
                {
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Solidifier, 1);
                }
                
            Item.NewItem(NPC.GetSource_Loot(), (int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), Main.rand.Next(5, 10));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.GoldBar, Main.rand.Next(3, 5));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.IronBar, Main.rand.Next(3, 7));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.SilverOre, Main.rand.Next(10, 20));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.ManaCrystal, Main.rand.Next(1, 2));

            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.DemoniteOre, Main.rand.Next(40, 60));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.ShadowScale, Main.rand.Next(10, 20));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Amethyst, Main.rand.Next(1, 2));
            
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
