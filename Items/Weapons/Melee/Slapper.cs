using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class Slapper : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slapper");
			Tooltip.SetDefault("Slap U");
		}
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.SlapHand);
			item.damage = 70;
			item.useTime = 15;          
			item.useAnimation = 15; 
			item.rare = 7;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SlapHand, 1);
			recipe.AddIngredient(mod, "ShardBlue", 30);
			recipe.AddIngredient(mod, "ShardWhite", 30);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
