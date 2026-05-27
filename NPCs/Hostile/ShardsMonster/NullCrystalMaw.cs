using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	public class NullCrystalMaw : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 8;
		}

		public override void SetDefaults()
		{
			NPC.width = 72;
			NPC.height = 56;
			NPC.damage = 36;
			NPC.defense = 18;
			NPC.lifeMax = 1350;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath10;
			NPC.value = 2600f;
			NPC.knockBackResist = 0.03f;
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
			float cycle = NPC.ai[0] % 210f;
			Vector2 offset = cycle < 130f ? new Vector2(NPC.Center.X < target.Center.X ? -210f : 210f, -80f) : Vector2.Zero;
			Vector2 move = target.Center + offset - NPC.Center;
			float speed = cycle < 130f ? 7f : 10.5f;
			if (move.Length() > speed)
			{
				move = Vector2.Normalize(move) * speed;
			}
			NPC.velocity = (NPC.velocity * 18f + move) / 19f;
			NPC.direction = NPC.spriteDirection = NPC.Center.X < target.Center.X ? 1 : -1;

			if (cycle > 145f && cycle < 185f)
			{
				Vector2 pull = NPC.Center - target.Center;
				if (pull.Length() < 420f && pull.Length() > 1f)
				{
					target.velocity += Vector2.Normalize(pull) * 0.12f;
				}
			}

			if (cycle == 185f && Main.netMode != NetmodeID.MultiplayerClient)
			{
				Vector2 shot = target.Center - NPC.Center;
				shot = shot.Length() > 1f ? Vector2.Normalize(shot) * 6.3f : Vector2.UnitY * 6.3f;
				for (int i = -1; i <= 1; i++)
				{
					Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, shot.RotatedBy(MathHelper.ToRadians(i * 15f)), ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.NullMawProjectile>(), 20, 1.5f, Main.myPlayer);
				}
			}

			Lighting.AddLight(NPC.Center, 0.04f, 0.18f, 0.16f);
			if (Main.rand.NextBool(10))
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.GemAmethyst);
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			NPC.frame.Y = (int)(NPC.frameCounter / 6f) % Main.npcFrameCount[Type] * frameHeight;
		}

		public override void OnKill()
		{
			ShardInvasionSystem.CountShardEnemyKill(9);
			Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), Main.rand.Next(3, 6));
			Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), Main.rand.Next(1, 4));
			if (Main.rand.NextBool(4))
			{
				Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Weapons.Gun.VoidQuartzRifle>(), 1);
			}
		}
	}
}
