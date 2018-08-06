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
            npc.lifeMax = 10;
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardBlue"), Main.rand.Next(1, 2));
        }
    }
}
