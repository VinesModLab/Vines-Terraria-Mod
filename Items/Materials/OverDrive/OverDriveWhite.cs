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
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "OverDriveCore", 1);
            recipe.AddIngredient(ItemID.LargeDiamond, 1);
            recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
