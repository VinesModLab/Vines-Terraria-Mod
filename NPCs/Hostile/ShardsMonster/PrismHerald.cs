using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	public class PrismHerald : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.width = 58;
			NPC.height = 68;
			NPC.damage = 30;
			NPC.defense = 12;
			NPC.lifeMax = 1250;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 2500f;
			NPC.knockBackResist = 0.05f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.aiStyle = -1;
			NPC.npcSlots = 4f;
			NPC.scale = 1.15f;
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
				NPC.velocity.Y -= 0.12f;
				NPC.timeLeft = 10;
				return;
			}

			NPC.ai[0]++;
			float phase = NPC.ai[0] / 50f;
			Vector2 hoverPoint = target.Center + new Vector2((float)System.Math.Sin(phase) * 260f, -210f + (float)System.Math.Cos(phase * 1.4f) * 55f);
			Vector2 move = hoverPoint - NPC.Center;
			float speed = 8.5f;
			if (move.Length() > speed)
			{
				move = Vector2.Normalize(move) * speed;
			}
			NPC.velocity = (NPC.velocity * 20f + move) / 21f;
			NPC.direction = NPC.spriteDirection = NPC.Center.X < target.Center.X ? 1 : -1;

			if (NPC.ai[0] % 72f == 0f && Main.netMode != NetmodeID.MultiplayerClient)
			{
				ShootSpread(target, 3, 5.7f);
			}

			if (NPC.ai[0] % 210f == 0f && Main.netMode != NetmodeID.MultiplayerClient)
			{
				ShootRing();
			}

			int dustType = (int)(NPC.ai[0] / 45f) % 4 switch
			{
				0 => DustID.GemSapphire,
				1 => DustID.GemRuby,
				2 => DustID.GemEmerald,
				_ => DustID.GemAmethyst
			};
			Lighting.AddLight(NPC.Center, 0.18f, 0.12f, 0.28f);
			if (Main.rand.NextBool(10))
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType, NPC.velocity.X * 0.1f, NPC.velocity.Y * 0.1f);
			}
		}

		private void ShootSpread(Player target, int spread, float speed)
		{
			Vector2 velocity = target.Center - NPC.Center;
			if (velocity.Length() < 1f)
			{
				velocity = Vector2.UnitY;
			}
			velocity = Vector2.Normalize(velocity) * speed;
			int type = ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.PrismHeraldProjectile>();
			for (int i = -spread; i <= spread; i++)
			{
				float element = i < 0 ? 0f : i > 0 ? 4f : 5f;
				Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity.RotatedBy(MathHelper.ToRadians(i * 10f)), type, 18, 1.5f, Main.myPlayer, element);
			}
		}

		private void ShootRing()
		{
			int type = ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.PrismHeraldProjectile>();
			for (int i = 0; i < 8; i++)
			{
				Vector2 velocity = Vector2.UnitX.RotatedBy(MathHelper.TwoPi * i / 8f) * 4.2f;
				Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity, type, 15, 1f, Main.myPlayer, i % 6);
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			NPC.frame.Y = (int)(NPC.frameCounter / 8f) % Main.npcFrameCount[Type] * frameHeight;
		}

		public override void OnKill()
		{
			ShardInvasionSystem.CountShardEnemyKill(8);
			Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), Main.rand.Next(3, 6));
			Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), Main.rand.Next(5, 9));
			if (Main.rand.NextBool(3))
			{
				Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Summon.BlueEyeBossSummonItem>(), 1);
			}
			if (Main.rand.NextBool(4))
			{
				Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Weapons.Bow.PrismRepeater>(), 1);
			}
		}
	}
}
