using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Materials.Shards
{
	public class ShardPurple : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 100;
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes()
		{
			CreateRecipe(5)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), 5)
				.AddIngredient(ItemID.Amethyst)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
