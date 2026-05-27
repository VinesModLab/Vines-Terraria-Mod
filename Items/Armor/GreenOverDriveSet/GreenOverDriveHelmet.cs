using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.GreenOverDriveSet
{
	[AutoloadEquip(EquipType.Head)]
	public class GreenOverDriveHelmet : ModItem
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
			Item.defense = 15;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) *= 1.12f;
			player.maxMinions++;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<global::VinesMod.Items.Armor.GreenOverDriveSet.GreenOverDriveBreastplate>() && legs.type == ModContent.ItemType<global::VinesMod.Items.Armor.GreenOverDriveSet.GreenOverDriveLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Summon hits periodically restore life; the armor sheds living green sparks.";
			player.GetModPlayer<global::VinesMod.Players.ShardOverDriveArmorPlayer>().greenOverDrive = true;
			player.GetDamage(DamageClass.Summon) *= 1.24f;
			player.maxMinions += 2;
			player.lifeRegen += 6;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Armor.GreenShardSet.GreenHelmet>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveGreen>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceGreen>())
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
