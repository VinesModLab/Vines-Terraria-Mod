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
            NPC.lifeMax = 2000; 
            NPC.damage = 35; 
            NPC.defense = 3; 
            NPC.value = 5000;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true; 
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0.5f;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * balance);
            NPC.damage = (int)(NPC.damage * 0.6f);
            NPC.defense = (int)(NPC.defense + numPlayers);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<global::VinesMod.Items.TreasureBags.RedBrainBossBag>()));
        }
        
        public override void AI()
        {
            NPC.ai[2]++;
            int blinkRate = NPC.life < NPC.lifeMax / 2 ? 120 : 180;
            if (NPC.ai[2] >= blinkRate)
            {
                NPC.ai[2] = 0f;
                Player target = Main.player[NPC.target];
                if (target.active && !target.dead)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood);
                    }

                    Vector2 offset = new Vector2(Main.rand.Next(-260, 261), Main.rand.Next(-180, -80));
                    NPC.Center = target.Center + offset;
                    NPC.velocity = Vector2.Normalize(target.Center - NPC.Center) * 6f;
                    NPC.netUpdate = true;
                }
            }
        }

        public override void OnKill()
        {
            if (!Main.expertMode)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.PanicNecklace, 1);
                        break;
                    case 1:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.CrimsonRod, 1);
                        break;
                    case 2:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.TheRottedFork, 1);
                        break;
                    case 3:
                        Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.RedEyeBall>(), 1);
                        break;
                }

                if (Main.rand.Next(10) == 0)
                    Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BoneRattle, 1);

                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), Main.rand.Next(8, 15));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.TissueSample, Main.rand.Next(8, 15));
                Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Ruby, Main.rand.Next(1, 4));
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
