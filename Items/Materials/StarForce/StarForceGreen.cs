using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Materials.StarForce
{
	public class StarForceGreen : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 10000;
			Item.rare = ItemRarityID.Lime;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardGreen>(), 250)
				.AddIngredient(ItemID.LargeEmerald, 1)
				.AddIngredient(ItemID.FallenStar, 10)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
