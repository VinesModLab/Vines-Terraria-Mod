using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Materials.StarForce
{
	public class StarForceRed : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Star");
			Tooltip.SetDefault("Stored the shard power.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "ShardRed", 250);
            recipe.AddIngredient(ItemID.LargeRuby, 1);
			recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
