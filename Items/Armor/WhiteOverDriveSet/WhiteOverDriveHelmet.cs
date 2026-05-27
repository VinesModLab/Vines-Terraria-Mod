using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.WhiteOverDriveSet
{
	[AutoloadEquip(EquipType.Head)]
	public class WhiteOverDriveHelmet : ModItem
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
			Item.defense = 17;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Magic) += 12;
			player.manaCost *= 0.92f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<global::VinesMod.Items.Armor.WhiteOverDriveSet.WhiteOverDriveBreastplate>() && legs.type == ModContent.ItemType<global::VinesMod.Items.Armor.WhiteOverDriveSet.WhiteOverDriveLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Magic hits inflict frostburn; the armor glows with stabilized shard light.";
			player.GetModPlayer<global::VinesMod.Players.ShardOverDriveArmorPlayer>().whiteOverDrive = true;
			player.GetDamage(DamageClass.Magic) *= 1.24f;
			player.manaCost *= 0.82f;
			player.manaRegenBonus += 40;
			player.endurance += 0.08f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Armor.WhiteShardSet.WhiteHelmet>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveWhite>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceWhite>())
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
