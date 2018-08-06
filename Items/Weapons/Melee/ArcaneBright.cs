using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class ArcaneBright : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Arcane Bright");
			Tooltip.SetDefault("The Unpredictable Light.");
		}

		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.TerraBlade);
			item.damage = 660;           
			item.melee = true;          
			item.width = 40;            
			item.height = 40;           
			item.useTime = 20;          
			item.useAnimation = 20;         //The time span of the using animation of the weapon, suggest set it the same as useTime.
			item.useStyle = 1;          //The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			item.knockBack = 6f;         //The force of knockback of the weapon. Maximum is 20
			item.value = 300000;          
			item.rare = 10;              
			item.UseSound = SoundID.Item1;    
			item.autoReuse = true;       
            item.scale = 1.3f; 
            item.shoot = mod.ProjectileType<Projectiles.ArcaneBrightProjectile>();
            item.shootSpeed = 20f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofLight, 30);
			recipe.AddIngredient(ItemID.SoulofSight, 30);
			recipe.AddIngredient(ItemID.SoulofFlight, 30);
			recipe.AddIngredient(ItemID.FallenStar, 30);
			recipe.AddIngredient(ItemID.LunarBar, 30);
			recipe.AddIngredient(ItemID.LifeCrystal, 10);
			recipe.AddIngredient(ItemID.ManaCrystal, 10);
			recipe.AddIngredient(ItemID.DarkShard, 5);
			recipe.AddIngredient(ItemID.LightShard, 5);
			recipe.AddIngredient(ItemID.TrueExcalibur, 1);
			recipe.AddIngredient(ItemID.TerraBlade, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

         public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 2;
            float rotation = MathHelper.ToRadians(20);

            for (int i = 0; i < numberProjectiles + 1; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }

            int numProjectiles2 = 4;
            float spread = MathHelper.ToRadians(10);
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
            double deltaAngle = spread / (float)numProjectiles2;
            double offsetAngle;

            for (int j = 0; j < numProjectiles2; j++)
            {
                offsetAngle = startAngle + deltaAngle * j;
                Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage, knockBack, player.whoAmI);
            }

            return false;
        }


		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				//Emit dusts when swing the sword
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("SparkleGreen"));
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			// Add Onfire buff to the NPC for 1 second
			// 60 frames = 1 second
			target.AddBuff(BuffID.OnFire, 15 * 60);
			target.AddBuff(BuffID.Bleeding, 15 * 60);
			target.AddBuff(BuffID.Frozen, 15 * 60);
			target.AddBuff(BuffID.Chilled, 15 * 60);
		}
	}
}
