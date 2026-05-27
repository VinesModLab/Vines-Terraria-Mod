using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	public class EmeraldShardBloom : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 12;
		}

		public override void SetDefaults()
		{
			NPC.width = 34;
			NPC.height = 42;
			NPC.damage = 20;
			NPC.defense = 10;
			NPC.lifeMax = 210;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 520f;
			NPC.knockBackResist = 0.08f;
			NPC.aiStyle = -1;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) => 0f;

		public override void AI()
		{
			NPC.TargetClosest(false);
			Player target = Main.player[NPC.target];
			NPC.velocity.X *= 0.88f;
			NPC.ai[0]++;
			NPC.direction = NPC.spriteDirection = NPC.Center.X < target.Center.X ? 1 : -1;

			if (target.active && !target.dead && NPC.ai[0] % 110f == 0f && Main.netMode != NetmodeID.MultiplayerClient)
			{
				Vector2 shot = target.Center - NPC.Center;
				if (shot.Length() < 1f)
				{
					shot = Vector2.UnitY;
				}
				shot = Vector2.Normalize(shot) * 5f;
				Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, shot, ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.EmeraldBloomProjectile>(), 15, 1f, Main.myPlayer);
			}

			Lighting.AddLight(NPC.Center, 0.08f, 0.24f, 0.06f);
			if (Main.rand.NextBool(7))
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.GemEmerald);
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			NPC.frame.Y = (int)(NPC.frameCounter / 10f) % Main.npcFrameCount[Type] * frameHeight;
		}

		public override void OnKill()
		{
			ShardInvasionSystem.CountShardEnemyKill(2);
			Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardGreen>(), Main.rand.Next(1, 3));
		}
	}
}
