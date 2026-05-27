using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.PurpleOverDriveSet
{
	[AutoloadEquip(EquipType.Head)]
	public class PurpleOverDriveHelmet : ModItem
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
			player.GetCritChance(DamageClass.Summon) += 8;
			player.GetDamage(DamageClass.Magic) *= 1.08f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<global::VinesMod.Items.Armor.PurpleOverDriveSet.PurpleOverDriveBreastplate>() && legs.type == ModContent.ItemType<global::VinesMod.Items.Armor.PurpleOverDriveSet.PurpleOverDriveLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Magic and summon hits restore mana and inflict shadowflame.";
			player.GetModPlayer<global::VinesMod.Players.ShardOverDriveArmorPlayer>().purpleOverDrive = true;
			player.GetDamage(DamageClass.Magic) *= 1.18f;
			player.GetDamage(DamageClass.Summon) *= 1.18f;
			player.maxMinions++;
			player.GetCritChance(DamageClass.Magic) += 10;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Armor.PurpleManaSet.PurpleHelmet>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDrivePurple>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForcePurple>())
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
