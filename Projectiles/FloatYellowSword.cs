using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles
{
	public class FloatYellowSword : ModProjectile
	{
		const float RotationSpeed = 0.08f;
		const float Distance = 100;

		float Rotation;

		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 44;
			Projectile.timeLeft = 6;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.aiStyle = -1;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
            Projectile.scale = 1.3f;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.NextBool(4))
			{
				target.AddBuff(BuffID.Midas, 180, false);
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
			Projectile.Center = PolarPos(Main.LocalPlayer.Center, Distance, MathHelper.ToRadians(Rotation));
			Projectile.rotation = rotateBetween2Points(Main.LocalPlayer.Center, Projectile.Center) - MathHelper.ToRadians(90);
		}

		public override bool? CanHitNPC(NPC target)
		{
			return !target.friendly;
		}
	}
}
