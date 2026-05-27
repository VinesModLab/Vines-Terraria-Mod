using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles.Enemy
{
	public class ShardInvasionProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = -1;
			Projectile.hostile = true;
			Projectile.friendly = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 240;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
		}

		public override void AI()
		{
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			Projectile.velocity *= 1.002f;
			Lighting.AddLight(Projectile.Center, ElementColor().ToVector3() * 0.35f);

			if (Main.rand.NextBool(4))
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ElementDust(), Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f);
			}
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture = TextureAssets.Projectile[Type].Value;
			Vector2 origin = texture.Size() / 2f;
			Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, ElementColor(), Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);
			return false;
		}

		public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < 6; i++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ElementDust());
			}
		}

		private Color ElementColor()
		{
			return (int)Projectile.ai[0] switch
			{
				1 => new Color(255, 76, 45),
				2 => new Color(80, 255, 108),
				3 => new Color(255, 220, 72),
				4 => new Color(184, 92, 255),
				5 => new Color(240, 250, 255),
				6 => new Color(255, 118, 44),
				_ => new Color(92, 210, 255)
			};
		}

		private int ElementDust()
		{
			return (int)Projectile.ai[0] switch
			{
				1 => DustID.GemRuby,
				2 => DustID.GemEmerald,
				3 => DustID.GemTopaz,
				4 => DustID.GemAmethyst,
				5 => DustID.GemDiamond,
				6 => DustID.YellowStarDust,
				_ => DustID.GemSapphire
			};
		}
	}
}
