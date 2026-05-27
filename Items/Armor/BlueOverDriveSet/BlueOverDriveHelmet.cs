using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.BlueOverDriveSet
{
	[AutoloadEquip(EquipType.Head)]
	public class BlueOverDriveHelmet : ModItem
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
			player.GetCritChance(DamageClass.Magic) += 8;
			player.GetCritChance(DamageClass.Ranged) += 8;
			player.statManaMax2 += 40;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<global::VinesMod.Items.Armor.BlueOverDriveSet.BlueOverDriveBreastplate>() && legs.type == ModContent.ItemType<global::VinesMod.Items.Armor.BlueOverDriveSet.BlueOverDriveLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Magic and ranged hits electrify enemies; the armor emits sapphire charge.";
			player.GetModPlayer<global::VinesMod.Players.ShardOverDriveArmorPlayer>().blueOverDrive = true;
			player.GetDamage(DamageClass.Magic) *= 1.16f;
			player.GetDamage(DamageClass.Ranged) *= 1.16f;
			player.GetDamage(DamageClass.Summon) *= 1.16f;
			player.manaCost *= 0.85f;
			player.manaRegenBonus += 35;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Armor.BlueManaSet.BlueHelmet>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveBlue>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceBlue>())
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
