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
            DisplayName.SetDefault("Green Bee");
            Main.npcFrameCount[npc.type] = 12;
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.QueenBee);
            npc.aiStyle = 43; 
            npc.lifeMax = 4000; 
            npc.damage = 45; 
            npc.defense = 20; 
            npc.value = 10000;
            npc.boss = true; // Is a boss
            npc.lavaImmune = true;
            npc.noGravity = true; 
            npc.noTileCollide = true;
            bossBag = mod.ItemType("GreenBeeBossBag"); // Needed for the NPC to drop loot bag.
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
            npc.defense = (int)(npc.defense + numPlayers);
        }
        
        public override void AI()
        {
        }

        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
            npc.DropBossBags();
            }
            
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.HoneyedGoggles, 1);
            }

            if (Main.rand.Next(9) == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.Nectar, 1);
            }

            switch (Main.rand.Next(3))
            {
                case 0:
                Item.NewItem(npc.getRect(), ItemID.BeeKeeper, 1);
                break;

                case 1:
                Item.NewItem(npc.getRect(), ItemID.BeeGun, 1);
                break;

                case 2:
                Item.NewItem(npc.getRect(), ItemID.BeesKnees, 1);
                break;

            }

            if (Main.rand.Next(3) == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.HoneyComb, 1);
            }
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardGreen"), Main.rand.Next(3, 5));
            Item.NewItem(npc.getRect(), ItemID.GoldBar, Main.rand.Next(5, 8));
            Item.NewItem(npc.getRect(), ItemID.IronBar, Main.rand.Next(5, 10));
            Item.NewItem(npc.getRect(), ItemID.SilverOre, Main.rand.Next(15, 20));
            Item.NewItem(npc.getRect(), ItemID.ManaCrystal, Main.rand.Next(1, 2));
            Item.NewItem(npc.getRect(), ItemID.LifeCrystal, Main.rand.Next(1, 2));

            Item.NewItem(npc.getRect(), ItemID.BottledHoney, Main.rand.Next(15, 30));
            Item.NewItem(npc.getRect(), ItemID.BeeWax, Main.rand.Next(10, 20));
            Item.NewItem(npc.getRect(), ItemID.Beenade, Main.rand.Next(30, 45));
            
            

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
