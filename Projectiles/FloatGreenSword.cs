using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class FloatGreenSword : ModProjectile
	{
		const float RotationSpeed = 0.1f;
		const float Distance = 100;

		float Rotation;

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 44;
			projectile.timeLeft = 6;
			projectile.melee = true;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
            projectile.scale = 1.3f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Green Sword");
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(3))
			{
				target.AddBuff(31, 180, false);
			}
		}

        public static Vector2 PolarPos(Vector2 Point, float Distance, float Angle, int XOffset = 0, int YOffset = 0)
		{
			Vector2 returnedValue = new Vector2
			{
				X = (Distance * (float)Math.Sin(MathHelper.ToDegrees(Angle)) + Point.X) + XOffset,
				Y = (Distance * (float)Math.Cos(MathHelper.ToDegrees(Angle)) + Point.Y) + YOffset
			};
			return returnedValue;
		}

        public static float rotateBetween2Points(Vector2 A, Vector2 B)
		{
			return (float)Math.Atan2(A.Y - B.Y, A.X - B.X);
		}

		public override void AI()
		{
			Rotation += RotationSpeed;
			projectile.Center = PolarPos(Main.LocalPlayer.Center, Distance, MathHelper.ToRadians(Rotation));
			projectile.rotation = rotateBetween2Points(Main.LocalPlayer.Center, projectile.Center) - MathHelper.ToRadians(90);
		}

		public override bool? CanHitNPC(NPC target)
		{
			return !target.friendly;
		}
	}
}