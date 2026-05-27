using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Materials.OverDrive
{
	public class OverDriveCore : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 100000;
			Item.rare = ItemRarityID.Cyan;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.FallenStar, 15)
				.AddIngredient(ItemID.MeteoriteBar, 10)
				.AddIngredient(ItemID.Obsidian, 50)
				.AddIngredient(ItemID.FragmentVortex, 25)
				.AddIngredient(ItemID.FragmentNebula, 25)
				.AddIngredient(ItemID.FragmentSolar, 25)
				.AddIngredient(ItemID.FragmentStardust, 25)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
