using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Placeable
{
	public class PrismstoneBlock : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.PrismstoneBlock>());
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 9999;
			Item.value = 20;
		}
	}

	public class CloudglassPlatform : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.CloudglassPlatform>());
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 9999;
			Item.value = 30;
		}

		public override void AddRecipes()
		{
			CreateRecipe(2)
				.AddIngredient<PrismstoneBlock>()
				.Register();
		}
	}

	public class HangingPrismCrystal : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.HangingPrismCrystal>());
			Item.width = 16;
			Item.height = 28;
			Item.maxStack = 9999;
			Item.value = 100;
		}
	}

	public class FracturedPrismOre : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.FracturedPrismOre>());
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 9999;
			Item.value = 150;
			Item.rare = ItemRarityID.Blue;
		}
	}

	public class PrismAltar : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.PrismAltar>());
			Item.width = 34;
			Item.height = 28;
			Item.maxStack = 99;
			Item.value = Item.buyPrice(0, 1, 50, 0);
			Item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<PrismstoneBlock>(40)
				.AddIngredient<FracturedPrismOre>(12)
				.AddIngredient(ModContent.ItemType<Items.Materials.Shards.ShardWhite>(), 5)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
