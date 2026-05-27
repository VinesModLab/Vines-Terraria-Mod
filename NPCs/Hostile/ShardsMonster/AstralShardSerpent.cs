using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	public class AstralShardSerpent : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 88;
			NPC.height = 42;
			NPC.damage = 38;
			NPC.defense = 16;
			NPC.lifeMax = 1500;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.value = 3000f;
			NPC.knockBackResist = 0.04f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.aiStyle = -1;
			NPC.npcSlots = 5f;
			NPC.scale = 1.18f;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) => 0f;

		public override void AI()
		{
			NPC.TargetClosest(false);
			Player target = Main.player[NPC.target];
			if (!target.active || target.dead)
			{
				NPC.velocity.Y -= 0.12f;
				NPC.timeLeft = 10;
				return;
			}

			NPC.ai[0]++;
			Vector2 orbit = new Vector2((float)System.Math.Cos(NPC.ai[0] / 45f) * 300f, (float)System.Math.Sin(NPC.ai[0] / 55f) * 120f - 70f);
			Vector2 move = target.Center + orbit - NPC.Center;
			float speed = NPC.ai[0] % 180f > 130f ? 13f : 8f;
			if (move.Length() > speed)
			{
				move = Vector2.Normalize(move) * speed;
			}
			NPC.velocity = (NPC.velocity * 16f + move) / 17f;
			NPC.rotation = NPC.velocity.ToRotation();
			NPC.direction = NPC.spriteDirection = NPC.velocity.X >= 0f ? 1 : -1;

			if (NPC.ai[0] % 150f == 0f && Main.netMode != NetmodeID.MultiplayerClient)
			{
				for (int i = -2; i <= 2; i++)
				{
					Vector2 shot = (target.Center - NPC.Center).RotatedBy(MathHelper.ToRadians(i * 9f));
					shot = shot.Length() > 1f ? Vector2.Normalize(shot) * 6f : Vector2.UnitY * 6f;
					Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, shot, ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.AstralSerpentProjectile>(), 18, 1.2f, Main.myPlayer);
				}
			}

			if (NPC.ai[0] % 220f == 80f && Main.netMode != NetmodeID.MultiplayerClient)
			{
				for (int i = 0; i < 4; i++)
				{
					Vector2 shard = Vector2.UnitX.RotatedBy(NPC.rotation + MathHelper.PiOver2 + MathHelper.ToRadians((i - 1.5f) * 18f)) * 5.2f;
					Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, shard, ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.AstralSerpentProjectile>(), 16, 1f, Main.myPlayer);
				}
			}

			Lighting.AddLight(NPC.Center, 0.18f, 0.22f, 0.28f);
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			NPC.frame.Y = (int)(NPC.frameCounter / 7f) % Main.npcFrameCount[Type] * frameHeight;
		}

		public override void OnKill()
		{
			ShardInvasionSystem.CountShardEnemyKill(10);
			Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), Main.rand.Next(4, 8));
			if (Main.rand.NextBool(2))
			{
				Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), Main.rand.Next(2, 5));
			}
			if (Main.rand.NextBool(10))
			{
				Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.AstralScope>(), 1);
			}
		}
	}
}
