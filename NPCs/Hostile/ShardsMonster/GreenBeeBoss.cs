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
            NPC.lifeMax = 2200; 
            NPC.damage = 45; 
            NPC.defense = 10; 
            NPC.value = 5000;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true; 
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0.2f;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
            NPC.defense = (int)(NPC.defense + numPlayers);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<global::VinesMod.Items.TreasureBags.GreenBeeBossBag>()));
        }
        
        public override void AI()
        {
            NPC.ai[2]++;
            int swarmRate = NPC.life < NPC.lifeMax / 2 ? 120 : 180;
            if (NPC.ai[2] >= swarmRate)
            {
                NPC.ai[2] = 0f;
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    int beeCount = NPC.life < NPC.lifeMax / 2 ? 3 : 2;
                    for (int i = 0; i < beeCount; i++)
                    {
                        Vector2 offset = new Vector2(Main.rand.Next(-80, 81), Main.rand.Next(-60, 61));
                        NPC.NewNPC(NPC.GetSource_FromAI(), (int)(NPC.Center.X + offset.X), (int)(NPC.Center.Y + offset.Y), NPCID.BeeSmall);
                    }
                }
            }
        }

        public override void OnKill()
        {
            if (!Main.expertMode)
            {
                if (Main.rand.Next(10) == 0)
                    Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.HoneyedGoggles, 1);

                if (Main.rand.Next(8) == 0)
                    Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Nectar, 1);

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

                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardGreen>(), Main.rand.Next(8, 15));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BeeWax, Main.rand.Next(8, 17));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Emerald, Main.rand.Next(1, 4));
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
