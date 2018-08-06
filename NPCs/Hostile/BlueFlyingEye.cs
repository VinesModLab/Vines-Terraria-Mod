using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace VinesMod.NPCs.Hostile
{
    public class BlueFlyingEye : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Flying Eye");
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 24;
            npc.damage = 12;
            npc.defense = 5;
            npc.lifeMax = 75;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 150f;
            npc.knockBackResist = 0.25f;
            npc.aiStyle = 2;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DemonEye]; //Main.npcFrameCount[2];
            aiType = NPCID.DemonEye; // aiType = 2;
            animationType = NPCID.DemonEye; // animationType = 2;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
        }

        public override void NPCLoot()
        {
                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("BlueEyeBossSummonItem"), 1);
                }

                if (Main.rand.Next(20) == 0)
                {
                    Item.NewItem(npc.getRect(), ItemID.BlackLens, 1);
                }

            Item.NewItem(npc.getRect(), mod.ItemType("ShardBlue"), Main.rand.Next(1, 2));
            Item.NewItem(npc.getRect(), ItemID.Lens, Main.rand.Next(1, 3));
        }
    }
}
