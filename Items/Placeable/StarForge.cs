using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Placeable
{
	public class StarForge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("StarForge");
			Tooltip.SetDefault("Everything starts here.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 30000;
			item.createTile = mod.TileType("StarForge");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WorkBench);
			recipe.AddIngredient(mod, "ShardBlue", 5);
			recipe.AddIngredient(mod, "ShardGreen", 5);
			recipe.AddIngredient(mod, "ShardPurple", 5);
			recipe.AddIngredient(mod, "ShardYellow", 5);
			recipe.AddIngredient(mod, "ShardWhite", 5);
			recipe.AddIngredient(mod, "ShardRed", 5);
			recipe.AddIngredient(ItemID.FallenStar, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}