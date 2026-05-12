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
            NPC.aiStyle = 43; 
            NPC.lifeMax = 4000; 
            NPC.damage = 45; 
            NPC.defense = 10; 
            NPC.value = 10000;
            NPC.boss = true; // Is a boss
            NPC.lavaImmune = true;
            NPC.noGravity = true; 
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0.2f;
            if (!Main.dedServ)
            {
                Music = MusicID.Boss5;
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
        }

        public override void OnKill()
        {
            if (Main.expertMode)
            {
            // Boss bags now drop via ModifyNPCLoot (1.4)
            }
            else
            {
                        
                if (Main.rand.Next(10) == 0)
                {
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.HoneyedGoggles, 1);
                }

                if (Main.rand.Next(9) == 0)
                {
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Nectar, 1);
                }

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

                if (Main.rand.Next(3) == 0)
                {
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.HoneyComb, 1);
                }
            Item.NewItem(NPC.GetSource_Loot(), (int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardGreen>(), Main.rand.Next(5, 10));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.GoldBar, Main.rand.Next(5, 8));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.IronBar, Main.rand.Next(5, 10));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.SilverOre, Main.rand.Next(15, 20));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.ManaCrystal, Main.rand.Next(1, 2));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.LifeCrystal, Main.rand.Next(1, 2));

            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BottledHoney, Main.rand.Next(15, 30));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BeeWax, Main.rand.Next(10, 20));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Beenade, Main.rand.Next(30, 45));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Emerald, Main.rand.Next(1, 2));
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
