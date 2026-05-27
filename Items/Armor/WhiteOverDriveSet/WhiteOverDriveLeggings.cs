using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.WhiteOverDriveSet
{
	[AutoloadEquip(EquipType.Legs)]
	public class WhiteOverDriveLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 100000;
			Item.rare = ItemRarityID.Red;
			Item.defense = 16;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.08f;
			player.statManaMax2 += 40;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Armor.WhiteShardSet.WhiteLeggings>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveWhite>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceWhite>())
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}