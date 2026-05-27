using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	public class RubyShardKnight : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.ArmoredSkeleton);
			NPC.width = 28;
			NPC.height = 38;
			NPC.damage = 24;
			NPC.defense = 14;
			NPC.lifeMax = 160;
			NPC.value = 420f;
			ShardNpcTargeting.MakeHostileTargetable(NPC);
			NPC.knockBackResist = 0.18f;
			AIType = NPCID.ArmoredSkeleton;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}

		public override void AI()
		{
			ShardNpcTargeting.MakeHostileTargetable(NPC);

			Lighting.AddLight(NPC.Center, 0.26f, 0.08f, 0.03f);
			if (Main.rand.NextBool(7))
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.GemRuby, NPC.velocity.X * 0.2f, NPC.velocity.Y * 0.2f);
			}
		}

		public override void ModifyHitByItem(Player player, Item item, ref NPC.HitModifiers modifiers)
		{
			ApplyFrontGuard(player.Center.X, ref modifiers);
		}

		public override void ModifyHitByProjectile(Projectile projectile, ref NPC.HitModifiers modifiers)
		{
			ApplyFrontGuard(projectile.Center.X, ref modifiers);
		}

		private void ApplyFrontGuard(float attackerX, ref NPC.HitModifiers modifiers)
		{
			bool hitShield = NPC.spriteDirection == 1 ? attackerX > NPC.Center.X : attackerX < NPC.Center.X;
			if (hitShield)
			{
				modifiers.FinalDamage *= 0.72f;
				modifiers.Knockback *= 0.45f;
			}
		}

		public override void OnKill()
		{
			ShardInvasionSystem.CountShardEnemyKill(2);
			Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), Main.rand.Next(1, 3));
		}
	}
}
