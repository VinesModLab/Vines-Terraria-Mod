using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class BladeArtProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Type] = 5;
			ProjectileID.Sets.TrailingMode[Type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.friendly = true;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 75;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.extraUpdates = 1;
		}

		public override void AI()
		{
			int style = (int)Projectile.ai[0];
			Projectile.rotation = Projectile.velocity.ToRotation();
			Projectile.light = style switch
			{
				1 => 0.45f,
				2 => 0.55f,
				10 => 0.65f,
				_ => 0.25f
			};

			if (style == 3 || style == 4 || style == 8)
			{
				NPC target = FindTarget(260f);
				if (target != null)
				{
					Vector2 desiredVelocity = Projectile.DirectionTo(target.Center) * Projectile.velocity.Length();
					Projectile.velocity = Vector2.Lerp(Projectile.velocity, desiredVelocity, 0.035f);
				}
			}

			if (style == 7)
			{
				Projectile.velocity *= 0.985f;
				Projectile.scale = 1.15f;
			}

			if (style == 9)
			{
				Projectile.velocity.Y += (float)System.Math.Sin(Projectile.localAI[0]++ / 8f) * 0.08f;
			}

			SpawnDust(style);
		}

		public override bool PreDraw(ref Color lightColor)
		{
			int style = (int)Projectile.ai[0];
			float rotation = Projectile.velocity.ToRotation();
			float fade = Utils.GetLerpValue(0f, 12f, Projectile.timeLeft, true);
			Texture2D texture = TextureAssets.Projectile[Type].Value;
			Rectangle frame = texture.Frame(1, 11, 0, Utils.Clamp(style, 0, 10));
			Vector2 origin = frame.Size() * 0.5f;
			float scale = style switch
			{
				5 => 0.85f,
				7 => 1.15f,
				10 => 1.1f,
				_ => 1f
			};

			for (int i = Projectile.oldPos.Length - 1; i > 0; i--)
			{
				Vector2 oldCenter = Projectile.oldPos[i] + Projectile.Size * 0.5f - Main.screenPosition;
				float trailOpacity = (Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length * 0.28f * fade;
				Main.EntitySpriteDraw(texture, oldCenter, frame, GetColor(style) * trailOpacity, rotation, origin, scale, SpriteEffects.None, 0);
			}

			Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, frame, GetColor(style) * fade, rotation, origin, scale, SpriteEffects.None, 0);
			return false;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			switch ((int)Projectile.ai[0])
			{
				case 1:
					target.AddBuff(BuffID.Electrified, 120);
					break;
				case 2:
				case 10:
					target.AddBuff(BuffID.OnFire, 240);
					break;
				case 3:
				case 8:
					target.AddBuff(BuffID.Poisoned, 300);
					break;
				case 4:
					target.AddBuff(BuffID.Venom, 180);
					break;
				case 6:
					target.AddBuff(BuffID.Ichor, 180);
					break;
				case 9:
					target.AddBuff(BuffID.Wet, 300);
					break;
			}
		}

		private NPC FindTarget(float maxRange)
		{
			NPC closest = null;
			float closestDistance = maxRange;

			for (int i = 0; i < Main.maxNPCs; i++)
			{
				NPC npc = Main.npc[i];
				if (!npc.CanBeChasedBy(Projectile))
				{
					continue;
				}

				float distance = Projectile.Distance(npc.Center);
				if (distance < closestDistance)
				{
					closest = npc;
					closestDistance = distance;
				}
			}

			return closest;
		}

		private void SpawnDust(int style)
		{
			if (!Main.rand.NextBool(2))
			{
				return;
			}

			int dustType = style switch
			{
				1 => DustID.Electric,
				2 => DustID.Torch,
				3 => DustID.Grass,
				4 => DustID.PurpleTorch,
				5 => DustID.Smoke,
				6 => DustID.GoldCoin,
				7 => DustID.Stone,
				8 => DustID.Poisoned,
				9 => DustID.Water,
				10 => DustID.Flare,
				_ => DustID.SilverCoin
			};

			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustType, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 120, default, 0.9f);
			Main.dust[dust].noGravity = true;
		}

		private static Color GetColor(int style)
		{
			return style switch
			{
				1 => new Color(150, 220, 255),
				2 => new Color(255, 180, 90),
				3 => new Color(170, 255, 130),
				4 => new Color(235, 180, 255),
				5 => new Color(255, 235, 170),
				6 => new Color(255, 205, 95),
				7 => new Color(220, 230, 235),
				8 => new Color(165, 255, 120),
				9 => new Color(190, 245, 255),
				10 => new Color(255, 145, 75),
				_ => Color.White
			};
		}


	}
}
