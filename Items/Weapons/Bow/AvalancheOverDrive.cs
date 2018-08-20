using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using VinesMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Bow
{
    public class AvalancheOverDrive : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Avalanche OverDrive");
            Tooltip.SetDefault("66% not consume ammo." + "\n Anger of Snow");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 24;
            item.useTime = 10;
            item.useAnimation = 10;
            item.damage = 500;
            item.useStyle = 5; 
            item.noMelee = true; 
            item.value = Item.buyPrice(0, 30, 0, 0);
            item.rare = 11;
            item.UseSound = SoundID.Item5; 
            item.useAmmo = AmmoID.Snowball;
            item.shoot = ProjectileID.SnowBallFriendly;
            item.shootSpeed = 45f;
            item.ranged = true;
            item.autoReuse = true;
        }
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 6 + Main.rand.Next(4); 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
				//randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 

				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

        public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .66f;
		}

		
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "AvalancheEx", 1);
            recipe.AddIngredient(mod, "OverDriveWhite", 1);
			recipe.AddIngredient(ItemID.LargeDiamond, 5);
            recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

    }
}
