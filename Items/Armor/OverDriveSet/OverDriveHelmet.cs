using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.OverDriveSet
{
	[AutoloadEquip(EquipType.Head)]
	public class OverDriveHelmet : ModItem
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
			Item.defense = 22;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Melee) += 10;
			player.GetCritChance(DamageClass.Ranged) += 10;
			player.GetCritChance(DamageClass.Magic) += 10;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<global::VinesMod.Items.Armor.OverDriveSet.OverDriveBreastplate>() && legs.type == ModContent.ItemType<global::VinesMod.Items.Armor.OverDriveSet.OverDriveLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.GetDamage(DamageClass.Melee) *= 1.25f;
			player.GetDamage(DamageClass.Ranged) *= 1.25f;
			player.GetDamage(DamageClass.Magic) *= 1.25f;
			player.GetDamage(DamageClass.Summon) *= 1.25f;
			player.GetCritChance(DamageClass.Melee) += 8;
			player.GetCritChance(DamageClass.Ranged) += 8;
			player.GetCritChance(DamageClass.Magic) += 8;
			player.maxMinions += 2;
			player.manaCost *= 0.85f;
			player.moveSpeed += 0.10f;
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