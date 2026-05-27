using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.StarForceSet
{
	[AutoloadEquip(EquipType.Legs)]
	public class StarForceLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 100000;
			Item.rare = ItemRarityID.Lime;
			Item.defense = 14;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.10f;
			player.maxRunSpeed += 0.5f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceBlue>(), 2)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceGreen>(), 2)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForcePurple>(), 2)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceRed>(), 2)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceWhite>(), 2)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceYellow>(), 2)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}