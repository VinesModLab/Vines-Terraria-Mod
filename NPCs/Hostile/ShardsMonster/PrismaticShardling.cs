using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	public class PrismaticShardling : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.BlueSlime);
			NPC.width = 22;
			NPC.height = 18;
			NPC.damage = 14;
			NPC.defense = 4;
			NPC.lifeMax = 55;
			NPC.value = 120f;
			ShardNpcTargeting.MakeHostileTargetable(NPC);
			NPC.knockBackResist = 0.55f;
			AIType = NPCID.BlueSlime;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}

		public override void AI()
		{
			ShardNpcTargeting.MakeHostileTargetable(NPC);

			Lighting.AddLight(NPC.Center, 0.12f, 0.20f, 0.26f);
			if (Main.rand.NextBool(10))
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.GemSapphire, NPC.velocity.X * 0.15f, NPC.velocity.Y * 0.15f);
			}
		}

		public override void OnKill()
		{
			ShardInvasionSystem.CountShardEnemyKill();
			if (Main.rand.NextBool(3))
			{
				Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), Main.rand.Next(1, 3));
			}
		}
	}
}
