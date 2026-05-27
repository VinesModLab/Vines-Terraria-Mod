using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles.Enemy
{
	public abstract class ShardInvasionProjectileBase : ModProjectile
	{
		protected virtual Color GlowColor => Color.White;
		protected virtual int DustType => DustID.GemDiamond;
		protected virtual int Width => 16;
		protected virtual int Height => 16;
		protected virtual int Lifetime => 240;
		protected virtual bool CollidesWithTiles => true;

		public override void SetDefaults()
		{
			Projectile.width = Width;
			Projectile.height = Height;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 1;
			Projectile.timeLeft = Lifetime;
			Projectile.tileCollide = CollidesWithTiles;
			Projectile.ignoreWater = true;
		}

		public override void AI()
		{
			Projectile.alpha = System.Math.Max(0, Projectile.alpha - 24);
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			Lighting.AddLight(Projectile.Center, GlowColor.ToVector3() * 0.35f);
			if (Main.rand.NextBool(4))
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustType, Projectile.velocity.X * 0.08f, Projectile.velocity.Y * 0.08f);
			}
		}

		public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustType);
			}
		}
	}

	public class CosmicWispProjectile : ShardInvasionProjectileBase
	{
		protected override Color GlowColor => new Color(92, 190, 255);
		protected override int DustType => DustID.BlueTorch;
		protected override int Width => 14;
		protected override int Height => 14;
		protected override bool CollidesWithTiles => false;

		public override void AI()
		{
			if (Projectile.localAI[0]++ < 95f)
			{
				Player target = Main.player[Player.FindClosest(Projectile.Center, Projectile.width, Projectile.height)];
				if (target.active && !target.dead)
				{
					float speed = Projectile.velocity.Length();
					Vector2 desired = Projectile.Center.DirectionTo(target.Center) * speed;
					Projectile.velocity = Vector2.Lerp(Projectile.velocity, desired, 0.018f);
				}
			}
			Projectile.velocity *= 0.998f;
			base.AI();
		}
	}

	public class EmeraldBloomProjectile : ShardInvasionProjectileBase
	{
		protected override Color GlowColor => new Color(80, 255, 108);
		protected override int DustType => DustID.GemEmerald;
		protected override int Width => 16;
		protected override int Height => 16;

		public override void AI()
		{
			Projectile.velocity.Y += 0.035f;
			Projectile.rotation += 0.14f * Projectile.direction;
			base.AI();
		}
	}

	public class AmethystMirrorProjectile : ShardInvasionProjectileBase
	{
		protected override Color GlowColor => new Color(184, 92, 255);
		protected override int DustType => DustID.GemAmethyst;
		protected override int Width => 18;
		protected override int Height => 18;

		public override void SetDefaults()
		{
			base.SetDefaults();
			Projectile.penetrate = 2;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				return true;
			}
			if (Projectile.velocity.X != oldVelocity.X)
			{
				Projectile.velocity.X = -oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y)
			{
				Projectile.velocity.Y = -oldVelocity.Y;
			}
			Projectile.netUpdate = true;
			return false;
		}
	}

	public class TopazStormProjectile : ShardInvasionProjectileBase
	{
		protected override Color GlowColor => new Color(255, 220, 72);
		protected override int DustType => DustID.GemTopaz;
		protected override int Width => 12;
		protected override int Height => 24;

		public override void AI()
		{
			Projectile.localAI[0]++;
			Projectile.position.X += (float)System.Math.Sin(Projectile.localAI[0] * 0.55f) * 1.4f;
			Projectile.velocity.Y = System.Math.Min(Projectile.velocity.Y + 0.03f, 10f);
			base.AI();
		}
	}

	public class ShardCometProjectile : ShardInvasionProjectileBase
	{
		protected override Color GlowColor => new Color(255, 118, 44);
		protected override int DustType => DustID.YellowStarDust;
		protected override int Width => 20;
		protected override int Height => 18;

		public override void AI()
		{
			Projectile.velocity.Y = System.Math.Min(Projectile.velocity.Y + 0.075f, 12f);
			Projectile.velocity.X *= 0.998f;
			base.AI();
		}
	}

	public class NullMawProjectile : ShardInvasionProjectileBase
	{
		protected override Color GlowColor => new Color(95, 55, 145);
		protected override int DustType => DustID.ShadowbeamStaff;
		protected override int Width => 22;
		protected override int Height => 22;
		protected override bool CollidesWithTiles => false;

		public override void AI()
		{
			Projectile.localAI[0]++;
			Projectile.velocity *= 0.992f;
			Projectile.scale = 1f + (float)System.Math.Sin(Projectile.localAI[0] * 0.18f) * 0.1f;
			base.AI();
		}
	}

	public class AstralSerpentProjectile : ShardInvasionProjectileBase
	{
		protected override Color GlowColor => new Color(170, 240, 255);
		protected override int DustType => DustID.GemDiamond;
		protected override int Width => 18;
		protected override int Height => 18;

		public override void AI()
		{
			Projectile.localAI[0]++;
			Vector2 normal = Projectile.velocity.SafeNormalize(Vector2.UnitY).RotatedBy(MathHelper.PiOver2);
			Projectile.position += normal * (float)System.Math.Sin(Projectile.localAI[0] * 0.25f) * 0.7f;
			base.AI();
		}
	}

	public class WhitePrismSentinelProjectile : ShardInvasionProjectileBase
	{
		protected override Color GlowColor => new Color(235, 250, 255);
		protected override int DustType => DustID.GemDiamond;
		protected override int Width => 14;
		protected override int Height => 22;

		public override void AI()
		{
			Projectile.velocity *= 1.004f;
			base.AI();
		}
	}

	public class PrismHeraldProjectile : ShardInvasionProjectileBase
	{
		protected override Color GlowColor => new Color(210, 235, 255);
		protected override int DustType => DustID.RainbowMk2;
		protected override int Width => 20;
		protected override int Height => 20;
		protected override bool CollidesWithTiles => false;

		public override void AI()
		{
			Projectile.localAI[0]++;
			Projectile.velocity *= 1.001f;
			base.AI();
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture = TextureAssets.Projectile[Type].Value;
			Vector2 origin = texture.Size() / 2f;
			float hue = (Projectile.localAI[0] * 0.015f + Projectile.ai[0] * 0.13f) % 1f;
			Color tint = Main.hslToRgb(hue, 0.75f, 0.62f);
			Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, tint, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);
			return false;
		}
	}
}
