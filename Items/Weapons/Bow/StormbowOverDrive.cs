using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Bow
{
    public class StormbowOverDrive : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Daedalus Stormbow OverDrive");
            Tooltip.SetDefault("Only the OverDrive Arrow can unslash the full power of Daedalus Stormbow.");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.DaedalusStormbow);
            item.width = 16;
            item.height = 24;
            item.useTime = 20;
            item.useAnimation = 20;
            item.damage = 500;
            item.useStyle = 5; 
            item.noMelee = true; 
            item.value = Item.buyPrice(0, 3, 0, 0);
            item.rare = 10;
            item.UseSound = SoundID.Item5; 
            item.useAmmo = mod.ItemType("OverDriveArrow");
            item.shoot = 1;
            item.shootSpeed = 300f;
            item.ranged = true;
            //item.autoReuse = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 10 + Main.rand.Next(15);
			float rotation = MathHelper.ToRadians(45);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
        
		
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
	        recipe.AddIngredient(ItemID.DaedalusStormbow);
            recipe.AddIngredient(ItemID.LifeCrystal, 10);
			recipe.AddIngredient(ItemID.LargeRuby, 1);
            recipe.AddIngredient(mod, "OverDriveRed", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

            recipe = new ModRecipe(mod);
	        recipe.AddIngredient(ItemID.DaedalusStormbow);
            recipe.AddIngredient(ItemID.LifeCrystal, 10);
			recipe.AddIngredient(ItemID.LargeRuby, 1);
            recipe.AddIngredient(mod, "OverDriveRed", 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}

    }
}
