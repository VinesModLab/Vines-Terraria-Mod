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
            Main.npcFrameCount[Type] = 8;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.BrainofCthulhu);
            NPC.aiStyle = 54; // Brain
            NPC.lifeMax = 3500; 
            NPC.damage = 35; 
            NPC.defense = 3; 
            NPC.value = 10000;
            NPC.boss = true; // Is a boss
            NPC.lavaImmune = true;
            NPC.noGravity = true; 
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0.5f;
            if (!Main.dedServ)
            {
                Music = MusicID.Boss3;
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
                if (Main.rand.Next(4) == 0)
                {
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.UnholyWater, 1);
                }

                switch (Main.rand.Next(5))
                {
                case 0:
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.PanicNecklace, 1);
                break;

                case 1:
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.CrimsonHeart, 1);
                break;

                case 2:
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.CrimsonRod, 1);
                break;

                case 3:
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.TheRottedFork, 1);
                break;

                case 4:
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.RedEyeBall>(), 1);
                break;
                }

                if (Main.rand.Next(10) == 0)
                {
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BoneRattle, 1);
                }
            Item.NewItem(NPC.GetSource_Loot(), (int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), Main.rand.Next(5, 10));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.GoldBar, Main.rand.Next(3, 5));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.IronBar, Main.rand.Next(3, 7));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.SilverOre, Main.rand.Next(10, 20));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.ManaCrystal, Main.rand.Next(1, 2));

            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.CrimtaneOre, Main.rand.Next(40, 60));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.TissueSample, Main.rand.Next(10, 20));
            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Ruby, Main.rand.Next(1, 2));
            }
            

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
