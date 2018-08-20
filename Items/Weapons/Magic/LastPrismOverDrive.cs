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
	class LastPrismOverDrive : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rainbow Prism");
			Tooltip.SetDefault("Fire a lifeform disintegration rainbow");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LastPrism);
			item.rare = 11;
			item.damage = 485;
			item.value = Item.buyPrice(silver: 30);
			item.mana = 15;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LastPrism, 1);
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