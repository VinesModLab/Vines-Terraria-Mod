using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Materials.OverDrive
{
	public class OverDriveCore : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("OverDrive Core");
			Tooltip.SetDefault("it stores unknown power.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar, 1);
			recipe.AddIngredient(ItemID.MeteoriteBar, 1);
			recipe.AddIngredient(ItemID.Obsidian, 5);
			recipe.AddIngredient(ItemID.Diamond, 1);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddIngredient(ItemID.Obsidian, 50);
			recipe.AddIngredient(ItemID.Diamond, 10);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}
