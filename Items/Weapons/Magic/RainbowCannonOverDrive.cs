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

namespace VinesMod.Items.Weapons.Magic
{
	class RainbowCannonOverDrive : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rainbow Cannon OverDrive");
			Tooltip.SetDefault("Shoots 3 rainbows that does continuous damage");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.RainbowGun);
			item.rare = 10;
			item.damage = 465;
			item.value = Item.buyPrice(gold: 30);
			item.mana = 40;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians(15);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 10f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "RainbowCannon", 1);
			recipe.AddIngredient(mod, "OverDriveWhite", 1);
			recipe.AddIngredient(mod, "StarForceBlue", 1);
			recipe.AddIngredient(mod, "StarForceGreen", 1);
			recipe.AddIngredient(mod, "StarForceYellow", 1);
			recipe.AddIngredient(mod, "StarForceRed", 1);
			recipe.AddIngredient(mod, "StarForcePurple", 1);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}