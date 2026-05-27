using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	public class WhitePrismSentinel : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.ArmoredSkeleton);
			NPC.width = 34;
			NPC.height = 48;
			NPC.damage = 28;
			NPC.defense = 20;
			NPC.lifeMax = 340;
			NPC.value = 850f;
			ShardNpcTargeting.MakeHostileTargetable(NPC);
			NPC.knockBackResist = 0.04f;
			AIType = NPCID.ArmoredSkeleton;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) => 0f;

		public override void AI()
		{
			ShardNpcTargeting.MakeHostileTargetable(NPC);

			NPC.ai[0]++;
			NPC.TargetClosest(false);
			Player target = Main.player[NPC.target];
			if (target.active && !target.dead && NPC.ai[0] % 155f == 0f && Main.netMode != NetmodeID.MultiplayerClient)
			{
				Vector2 baseShot = target.Center - NPC.Center;
				if (baseShot.Length() < 1f)
				{
					baseShot = Vector2.UnitY;
				}
				baseShot = Vector2.Normalize(baseShot) * 5.6f;
				for (int i = -1; i <= 1; i++)
				{
					Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, baseShot.RotatedBy(MathHelper.ToRadians(i * 13f)), ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.WhitePrismSentinelProjectile>(), 18, 1.5f, Main.myPlayer);
				}
			}
			Lighting.AddLight(NPC.Center, 0.22f, 0.24f, 0.28f);
		}

		public override void OnKill()
		{
			ShardInvasionSystem.CountShardEnemyKill(3);
			Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), Main.rand.Next(2, 5));
		}
	}
}
