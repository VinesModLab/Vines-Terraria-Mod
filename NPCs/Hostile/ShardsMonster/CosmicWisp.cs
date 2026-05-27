using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	public class CosmicWisp : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.width = 22;
			NPC.height = 22;
			NPC.damage = 16;
			NPC.defense = 6;
			NPC.lifeMax = 85;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 180f;
			NPC.knockBackResist = 0.35f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.aiStyle = -1;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}

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
			Vector2 hoverPoint = target.Center + new Vector2((float)System.Math.Sin(NPC.ai[0] / 44f) * 190f, -135f + (float)System.Math.Cos(NPC.ai[0] / 37f) * 30f);
			Vector2 move = hoverPoint - NPC.Center;
			float speed = 5.2f;
			if (move.Length() > speed)
			{
				move = Vector2.Normalize(move) * speed;
			}
			NPC.velocity = (NPC.velocity * 30f + move) / 31f;
			NPC.direction = NPC.spriteDirection = NPC.velocity.X >= 0f ? 1 : -1;

			if (NPC.ai[0] % 105f == 0f && Main.netMode != NetmodeID.MultiplayerClient)
			{
				Vector2 shot = target.Center - NPC.Center;
				if (shot.Length() < 1f)
				{
					shot = Vector2.UnitY;
				}
				shot = Vector2.Normalize(shot) * 4.6f;
				Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, shot, ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.CosmicWispProjectile>(), 13, 1f, Main.myPlayer);
			}

			Lighting.AddLight(NPC.Center, 0.08f, 0.16f, 0.24f);
			if (Main.rand.NextBool(8))
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.BlueTorch, -NPC.velocity.X * 0.1f, -NPC.velocity.Y * 0.1f);
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			NPC.frame.Y = (int)(NPC.frameCounter / 10f) % Main.npcFrameCount[Type] * frameHeight;
		}

		public override void OnKill()
		{
			ShardInvasionSystem.CountShardEnemyKill();
			if (Main.rand.NextBool(2))
			{
				Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), 1);
			}
		}
	}
}
