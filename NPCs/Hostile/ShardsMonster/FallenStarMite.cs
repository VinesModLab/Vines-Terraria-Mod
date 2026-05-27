using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	public class FallenStarMite : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.width = 18;
			NPC.height = 18;
			NPC.damage = 20;
			NPC.defense = 3;
			NPC.lifeMax = 65;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 170f;
			NPC.knockBackResist = 0.65f;
			NPC.noGravity = true;
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
			Vector2 desired = target.Center + new Vector2((float)System.Math.Sin(NPC.ai[0] / 24f) * 80f, -35f) - NPC.Center;
			if (desired.Length() > 1f)
			{
				float burst = NPC.ai[0] % 120f > 82f ? 6.2f : 3.2f;
				desired = Vector2.Normalize(desired) * burst;
				NPC.velocity = (NPC.velocity * 26f + desired) / 27f;
			}
			NPC.rotation = NPC.velocity.ToRotation() + MathHelper.PiOver2;
			NPC.direction = NPC.spriteDirection = NPC.velocity.X >= 0f ? 1 : -1;
			Lighting.AddLight(NPC.Center, 0.22f, 0.18f, 0.05f);
			if (Main.rand.NextBool(5))
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.YellowTorch, -NPC.velocity.X * 0.2f, -NPC.velocity.Y * 0.2f);
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			NPC.frame.Y = (int)(NPC.frameCounter / 8f) % Main.npcFrameCount[Type] * frameHeight;
		}

		public override void OnKill()
		{
			ShardInvasionSystem.CountShardEnemyKill();
			for (int i = 0; i < 12; i++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.YellowStarDust);
			}
			if (Main.rand.NextBool(5))
			{
				Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ItemID.FallenStar, 1);
			}
		}
	}
}
