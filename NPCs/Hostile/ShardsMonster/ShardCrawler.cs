using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	public class ShardCrawler : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.Zombie);
			NPC.width = 30;
			NPC.height = 22;
			NPC.damage = 18;
			NPC.defense = 8;
			NPC.lifeMax = 110;
			NPC.value = 260f;
			ShardNpcTargeting.MakeHostileTargetable(NPC);
			NPC.knockBackResist = 0.28f;
			AIType = NPCID.Zombie;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) => 0f;

		public override void AI()
		{
			ShardNpcTargeting.MakeHostileTargetable(NPC);

			Lighting.AddLight(NPC.Center, 0.05f, 0.22f, 0.18f);
			if (NPC.collideX && NPC.velocity.Y == 0f)
			{
				NPC.velocity.Y = -5.5f;
			}
			if (Main.rand.NextBool(8))
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.GemEmerald);
			}
		}

		public override void OnKill()
		{
			ShardInvasionSystem.CountShardEnemyKill();
			if (Main.rand.NextBool(3))
			{
				Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardGreen>(), 1);
			}
		}
	}
}
