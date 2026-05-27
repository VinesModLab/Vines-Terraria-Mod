using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.GreenShardSet
{
	[AutoloadEquip(EquipType.Legs)]
	public class GreenLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.08f;
			player.lifeRegen += 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("IronBar", 8)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardGreen>(), 10)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}