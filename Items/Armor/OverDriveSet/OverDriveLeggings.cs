using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.OverDriveSet
{
	[AutoloadEquip(EquipType.Legs)]
	public class OverDriveLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 100000;
			Item.rare = ItemRarityID.Cyan;
			Item.defense = 20;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.16f;
			player.maxRunSpeed += 1f;
			player.runAcceleration *= 1.15f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveCore>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveBlue>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveGreen>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDrivePurple>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveRed>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveWhite>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveYellow>(), 1)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}