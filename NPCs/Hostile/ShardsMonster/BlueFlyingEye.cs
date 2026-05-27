using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
    public class BlueFlyingEye : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 24;
            NPC.damage = 12;
            NPC.defense = 5;
            NPC.lifeMax = 75;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 150f;
            NPC.knockBackResist = 0.25f;
            NPC.aiStyle = NPCAIStyleID.DemonEye; // DemonEye AI
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return 0f;
        }

        public override void OnKill()
        {
                ShardInvasionSystem.CountShardEnemyKill();

                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), Main.rand.Next(1, 2));
                }

                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Summon.BlueEyeBossSummonItem>(), 1);
                }

                if (Main.rand.Next(20) == 0)
                {
                    Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.BlackLens, 1);
                }

            Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.Lens, Main.rand.Next(1, 3));
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter >= 12)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y >= frameHeight * Main.npcFrameCount[Type])
                {
                    NPC.frame.Y = 0;
                }
            }
        }
    }
}
