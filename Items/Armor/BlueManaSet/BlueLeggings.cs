using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace VinesMod.Items.Armor.BlueManaSet
{
	[AutoloadEquip(EquipType.Legs)]
	public class BlueLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.05f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.ManaCrystal, 2)
				.AddRecipeGroup("IronBar", 8)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), 10)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
