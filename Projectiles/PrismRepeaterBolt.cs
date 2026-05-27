using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class PrismRepeaterBolt : ModProjectile
	{
		public override string Texture => "VinesMod/Projectiles/BladeArtProjectile";

		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[Type] = 6;
			ProjectileID.Sets.TrailingMode[Type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 90;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.extraUpdates = 1;
			Projectile.DamageType = DamageClass.Ranged;
		}

		public override void AI()
		{
			Projectile.rotation = Projectile.velocity.ToRotation();
			Projectile.light = 0.45f;
			if (Main.rand.NextBool(2))
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GemAmethyst, Projectile.velocity.X * 0.08f, Projectile.velocity.Y * 0.08f);
			}
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture = TextureAssets.Projectile[Type].Value;
			Rectangle frame = texture.Frame(1, 11, 0, 4);
			Vector2 origin = frame.Size() / 2f;
			Color color = Main.DiscoColor;
			for (int i = Projectile.oldPos.Length - 1; i > 0; i--)
			{
				Vector2 oldCenter = Projectile.oldPos[i] + Projectile.Size / 2f - Main.screenPosition;
				Main.EntitySpriteDraw(texture, oldCenter, frame, color * (0.06f * (Projectile.oldPos.Length - i)), Projectile.rotation, origin, 0.85f, SpriteEffects.None, 0);
			}
			Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, frame, color, Projectile.rotation, origin, 0.9f, SpriteEffects.None, 0);
			return false;
		}
	}
}
