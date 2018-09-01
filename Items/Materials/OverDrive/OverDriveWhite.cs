using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Materials.OverDrive
{
	public class OverDriveWhite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("OverDrive Core (Diamond)");
			Tooltip.SetDefault("it stores unknown power.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 11;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "OverDriveCore", 1);
			recipe.AddIngredient(mod, "StarForceWhite", 5);
            recipe.AddIngredient(ItemID.LargeDiamond, 5);
            recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
