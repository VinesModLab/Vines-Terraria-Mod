using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	public class AmethystMirror : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 36;
			NPC.height = 46;
			NPC.damage = 18;
			NPC.defense = 10;
			NPC.lifeMax = 180;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 520f;
			NPC.knockBackResist = 0.22f;
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
			Vector2 hover = target.Center + new Vector2((float)System.Math.Sin(NPC.ai[0] / 42f) * 210f, -120f);
			Vector2 move = hover - NPC.Center;
			if (move.Length() > 4.8f)
			{
				move = Vector2.Normalize(move) * 4.8f;
			}
			NPC.velocity = (NPC.velocity * 20f + move) / 21f;
			NPC.alpha = NPC.ai[0] % 180f < 50f ? 35 : 0;

			if (NPC.ai[0] % 125f == 0f && Main.netMode != NetmodeID.MultiplayerClient)
			{
				Vector2 shot = target.Center - NPC.Center;
				if (shot.Length() < 1f)
				{
					shot = Vector2.UnitY;
				}
				shot = Vector2.Normalize(shot) * 5.2f;
				Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, shot, ModContent.ProjectileType<global::VinesMod.Projectiles.Enemy.AmethystMirrorProjectile>(), 15, 1f, Main.myPlayer);
			}

			Lighting.AddLight(NPC.Center, 0.18f, 0.05f, 0.28f);
		}

		public override void ModifyHitByProjectile(Projectile projectile, ref NPC.HitModifiers modifiers)
		{
			if (NPC.ai[0] % 180f < 50f)
			{
				modifiers.FinalDamage *= 0.55f;
				modifiers.Knockback *= 0.4f;
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			NPC.frame.Y = (int)(NPC.frameCounter / 9f) % Main.npcFrameCount[Type] * frameHeight;
		}

		public override void OnKill()
		{
			ShardInvasionSystem.CountShardEnemyKill(2);
			Item.NewItem(NPC.GetSource_Loot(), NPC.getRect(), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), Main.rand.Next(1, 3));
		}
	}
}
