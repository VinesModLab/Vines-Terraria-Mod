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
    public class RedBrainBoss : ModNPC
    {
        private Player player;
        private float speed;

        public override string Texture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/RedBrainBoss";
			}
		}

        public override string HeadTexture
		{
			get
			{
				return "VinesMod/NPCs/Hostile/ShardsMonster/RedBrainBoss_Head_Boss";
			}
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Brain");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.CloneDefaults(NPCID.BrainofCthulhu);
            npc.aiStyle = 54; // Brain
            npc.lifeMax = 3500; 
            npc.damage = 35; 
            npc.defense = 10; 
            npc.value = 10000;
            npc.boss = true; // Is a boss
            npc.lavaImmune = true;
            npc.noGravity = true; 
            npc.noTileCollide = true;
            bossBag = mod.ItemType("RedBrainBossBag"); // Needed for the NPC to drop loot bag.
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
            
            if (Main.rand.Next(4) == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.UnholyWater, 1);
            }

            switch (Main.rand.Next(4))
            {
                case 0:
                Item.NewItem(npc.getRect(), ItemID.PanicNecklace, 1);
                break;

                case 1:
                Item.NewItem(npc.getRect(), ItemID.CrimsonHeart, 1);
                break;

                case 2:
                Item.NewItem(npc.getRect(), ItemID.CrimsonRod, 1);
                break;

                case 3:
                Item.NewItem(npc.getRect(), ItemID.TheRottedFork, 1);
                break;
            }

            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem(npc.getRect(), ItemID.BoneRattle, 1);
            }
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardRed"), Main.rand.Next(5, 10));
            Item.NewItem(npc.getRect(), ItemID.GoldBar, Main.rand.Next(3, 5));
            Item.NewItem(npc.getRect(), ItemID.IronBar, Main.rand.Next(3, 7));
            Item.NewItem(npc.getRect(), ItemID.SilverOre, Main.rand.Next(10, 20));
            Item.NewItem(npc.getRect(), ItemID.ManaCrystal, Main.rand.Next(1, 2));

            Item.NewItem(npc.getRect(), ItemID.CrimtaneOre, Main.rand.Next(40, 60));
            Item.NewItem(npc.getRect(), ItemID.TissueSample, Main.rand.Next(10, 20));
            Item.NewItem(npc.getRect(), ItemID.Ruby, Main.rand.Next(1, 2));
            

            // For settings if the boss has been downed
            VinesWorld.downedRedBrainBoss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        
    }
}
