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
	class RainbowCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rainbow Cannon");
			Tooltip.SetDefault("Shoots a rainbow that does continuous damage");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.RainbowGun);
			item.rare = 9;
			item.damage = 95;
			item.mana = 15;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RainbowGun, 1);
			recipe.AddIngredient(mod, "StarForceWhite", 1);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}