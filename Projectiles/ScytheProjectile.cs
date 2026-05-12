using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{	
	public class ScytheProjectile : ModProjectile 
	{
		public override void SetStaticDefaults()
        {
        }

		public override void SetDefaults()
		{
			Projectile.width = 16; 
			Projectile.height = 16;
			Projectile.timeLeft = 180;
			Projectile.penetrate = 8; 
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true; 
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.aiStyle = 18; //18 is demon scythe AI
		}
		public override void AI()
		{
			Projectile.type = 45; //This is the demon scythe projectile ID
		}
	}
}
