using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.RedOverDriveSet
{
	[AutoloadEquip(EquipType.Head)]
	public class RedOverDriveHelmet : ModItem
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
			Item.defense = 18;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Melee) += 12;
			player.GetDamage(DamageClass.Melee) *= 1.08f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<global::VinesMod.Items.Armor.RedOverDriveSet.RedOverDriveBreastplate>() && legs.type == ModContent.ItemType<global::VinesMod.Items.Armor.RedOverDriveSet.RedOverDriveLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Melee hits ignite enemies with cursed flame; thorns burn attackers.";
			player.GetModPlayer<global::VinesMod.Players.ShardOverDriveArmorPlayer>().redOverDrive = true;
			player.GetDamage(DamageClass.Melee) *= 1.22f;
			player.GetCritChance(DamageClass.Melee) += 12;
			player.thorns += 0.25f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Armor.RedShardSet.RedHelmet>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveRed>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceRed>())
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
