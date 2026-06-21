using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Materials
{
	public class PrismSeeds : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.PrismGrass>();
			Item.value = 200;
			Item.rare = ItemRarityID.Blue;
		}
	}

	public class PrismAerieKey : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 0, 50, 0);
			Item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Items.Materials.Shards.ShardBlue>(), 3)
				.AddIngredient(ModContent.ItemType<Items.Materials.Shards.ShardGreen>(), 3)
				.AddIngredient(ModContent.ItemType<Items.Materials.Shards.ShardPurple>(), 3)
				.AddIngredient(ModContent.ItemType<Items.Materials.Shards.ShardWhite>(), 3)
				.AddTile(ModContent.TileType<Tiles.PrismAltar>())
				.Register();
		}
	}
}
