using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
    public class BlueFlyingEye : ModNPC
    {
        public override void SetStaticDefaults()
        {
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
            NPC.aiStyle = 2; // DemonEye AI
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.ZoneOverworldHeight && !Main.dayTime ? 0.05f : 0f; // was OverworldNightMonster * 0.05f;
        }

        public override void OnKill()
        {
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
    }
}
