using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	public class TopazStormcaller : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 34;
			NPC.height = 42;
			NPC.damage = 24;
			NPC.defense = 8;
			NPC.lifeMax = 190;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 540f;
			NPC.knockBackResist = 0.2f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.aiStyle = -1;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) => 0f;

		public override void AI()
		{
			NPC.TargetClosest(false);
			Player target = Main.player[NPC.target];
			if (!target.active || target.dead)
			{
				NPC.velocity.Y -= 0.08f;
				NPC.timeLeft = 10;
				return;
			}

			NPC.ai[0]++;
			Vector2 hover = target.Center + new Vector2((float)System.Math.Sin(NPC.ai[0] / 30f) * 190f, -185f);
			Vector2 move = hover - NPC.Center;
			if (move.Length() > 6f)
			{
				move = Vector2.Normalize(move) * 6f;
			}
			NPC.velocity = (NPC.velocity * 18f + move) / 19f;
			NPC.direction = NPC.spriteDirection = NPC.Center.X < target.Center.X ? 1 : -1;

			if (NPC.ai[0] % 130f == 0f && Main.netMode != NetmodeID.MultiplayerClient)
			{
				for (int i = -1; i <= 1; i++)
				{
					Vector2 start = target.Center + new Vector2(i * 90f, -360f);
					Projectile.NewProjectile(NPC.GetSource_FromAI(), start, new Vector2(0f, 7.5f), ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.TopazStormProjectile>(), 16, 1f, Main.myPlayer);
				}
			}

			Lighting.AddLight(NPC.Center, 0.28f, 0.22f, 0.04f);
			if (Main.rand.NextBool(5))
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.GemTopaz);
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			NPC.frame.Y = (int)(NPC.frameCounter / 8f) % Main.npcFrameCount[Type] * frameHeight;
		}

		public override void OnKill()
		{
			ShardInvasionSystem.CountShardEnemyKill(2);
			Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardYellow>(), Main.rand.Next(1, 3));
		}
	}
}
