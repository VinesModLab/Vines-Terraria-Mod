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
    public class AvalancheEx : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AvalancheEx");
            Tooltip.SetDefault("It use snowball as ammo.");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 24;
            item.useTime = 15;
            item.useAnimation = 15;
            item.damage = 100;
            item.useStyle = 5; 
            item.noMelee = true; 
            item.value = Item.buyPrice(0, 0, 30, 0);
            item.rare = 8;
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
		
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "Avalanche", 1);
            recipe.AddIngredient(mod, "StarForceBlue", 1);
            recipe.AddIngredient(ItemID.IceBlock, 400);
            recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

    }
}
