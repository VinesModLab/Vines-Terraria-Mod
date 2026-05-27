using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	public class VoidQuartzBat : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.width = 26;
			NPC.height = 18;
			NPC.damage = 22;
			NPC.defense = 5;
			NPC.lifeMax = 95;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 260f;
			NPC.knockBackResist = 0.35f;
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
			float dive = NPC.ai[0] % 150f;
			Vector2 targetPoint = target.Center + (dive < 95f ? new Vector2((float)System.Math.Sin(NPC.ai[0] / 28f) * 130f, -150f) : Vector2.Zero);
			Vector2 move = targetPoint - NPC.Center;
			float speed = dive < 95f ? 4.8f : 8.2f;
			if (move.Length() > speed)
			{
				move = Vector2.Normalize(move) * speed;
			}
			NPC.velocity = (NPC.velocity * 24f + move) / 25f;
			NPC.alpha = dive < 75f ? 70 : 5;
			NPC.direction = NPC.spriteDirection = NPC.velocity.X >= 0f ? 1 : -1;
			Lighting.AddLight(NPC.Center, 0.05f, 0.18f, 0.16f);
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			NPC.frame.Y = (int)(NPC.frameCounter / 7f) % Main.npcFrameCount[Type] * frameHeight;
		}

		public override void OnKill()
		{
			ShardInvasionSystem.CountShardEnemyKill();
			if (Main.rand.NextBool(3))
			{
				Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), 1);
			}
		}
	}
}
