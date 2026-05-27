using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.YellowOverDriveSet
{
	[AutoloadEquip(EquipType.Head)]
	public class YellowOverDriveHelmet : ModItem
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
			player.GetCritChance(DamageClass.Ranged) += 12;
			player.GetDamage(DamageClass.Ranged) *= 1.08f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<global::VinesMod.Items.Armor.YellowOverDriveSet.YellowOverDriveBreastplate>() && legs.type == ModContent.ItemType<global::VinesMod.Items.Armor.YellowOverDriveSet.YellowOverDriveLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Ranged hits coat enemies in ichor and trigger a short speed surge.";
			player.GetModPlayer<global::VinesMod.Players.ShardOverDriveArmorPlayer>().yellowOverDrive = true;
			player.GetDamage(DamageClass.Ranged) *= 1.22f;
			player.GetCritChance(DamageClass.Ranged) += 12;
			player.moveSpeed += 0.12f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Armor.YellowShardSet.YellowHelmet>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveYellow>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceYellow>())
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
