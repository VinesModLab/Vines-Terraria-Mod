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
            DisplayName.SetDefault("ScytheProjectile");
        }

		public override void SetDefaults()
		{
			projectile.width = 16; 
			projectile.height = 16;
			projectile.timeLeft = 180;
			projectile.penetrate = 8; 
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = true; 
			projectile.ranged = true;
			projectile.aiStyle = 18; //18 is demon scythe AI
		}
		public override void AI()
		{
			projectile.type = 45; //This is the demon scythe projectile ID
		}
	}
}
