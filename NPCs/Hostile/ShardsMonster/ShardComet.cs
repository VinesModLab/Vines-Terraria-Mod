using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	public class ShardComet : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.width = 64;
			NPC.height = 64;
			NPC.damage = 34;
			NPC.defense = 14;
			NPC.lifeMax = 1050;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.value = 2200f;
			NPC.knockBackResist = 0.05f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.aiStyle = -1;
			NPC.npcSlots = 4f;
			NPC.scale = 1.16f;
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
			float cycle = NPC.ai[0] % 180f;
			if (cycle < 95f)
			{
				Vector2 hover = target.Center + new Vector2((float)System.Math.Sin(NPC.ai[0] / 22f) * 280f, -260f);
				Vector2 move = hover - NPC.Center;
				if (move.Length() > 8f)
				{
					move = Vector2.Normalize(move) * 8f;
				}
				NPC.velocity = (NPC.velocity * 18f + move) / 19f;
			}
			else if (cycle == 95f)
			{
				Vector2 dash = target.Center - NPC.Center;
				NPC.velocity = dash.Length() > 1f ? Vector2.Normalize(dash) * 15f : Vector2.UnitY * 15f;
			}
			else
			{
				NPC.velocity *= 0.985f;
			}

			if (cycle == 130f && Main.netMode != NetmodeID.MultiplayerClient)
			{
				for (int i = -2; i <= 2; i++)
				{
					Vector2 start = target.Center + new Vector2(i * 70f, -360f);
					Projectile.NewProjectile(NPC.GetSource_FromAI(), start, new Vector2(i * 0.45f, 7.2f), ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.ShardCometProjectile>(), 18, 1f, Main.myPlayer);
				}
			}

			if (cycle == 160f && Main.netMode != NetmodeID.MultiplayerClient)
			{
				for (int i = 0; i < 6; i++)
				{
					Vector2 shard = Vector2.UnitX.RotatedBy(MathHelper.TwoPi * i / 6f) * 4.8f;
					Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, shard, ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.ShardCometProjectile>(), 16, 1f, Main.myPlayer);
				}
			}

			NPC.rotation = NPC.velocity.X * 0.025f;
			Lighting.AddLight(NPC.Center, 0.24f, 0.18f, 0.06f);
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.YellowStarDust);
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			NPC.frame.Y = (int)(NPC.frameCounter / 7f) % Main.npcFrameCount[Type] * frameHeight;
		}

		public override void OnKill()
		{
			ShardInvasionSystem.CountShardEnemyKill(8);
			Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardYellow>(), Main.rand.Next(3, 6));
			if (Main.rand.NextBool(3))
			{
				Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.FallenStar, Main.rand.Next(1, 3));
			}
			if (Main.rand.NextBool(10))
			{
				Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Weapons.Gun.CometCarbine>(), 1);
			}
		}
	}
}
