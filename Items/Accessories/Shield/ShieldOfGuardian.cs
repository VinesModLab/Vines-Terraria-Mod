using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.Shield
{
	[AutoloadEquip(EquipType.Shield)]
	public class ShieldOfGuardian : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.defense = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.dash = 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("IronBar", 12)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), 10)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();

			Recipe.Create(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), 8)
				.AddIngredient(Type)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarRecycler>())
				.Register();
		}
	}
}
