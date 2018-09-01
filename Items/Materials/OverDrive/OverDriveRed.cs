using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Materials.OverDrive
{
	public class OverDriveRed : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("OverDrive Core (Ruby)");
			Tooltip.SetDefault("it stores unknown power.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100000;
			item.rare = 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "OverDriveCore", 1);
			recipe.AddIngredient(mod, "StarForceRed", 5);
            recipe.AddIngredient(ItemID.LargeRuby, 5);
            recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
