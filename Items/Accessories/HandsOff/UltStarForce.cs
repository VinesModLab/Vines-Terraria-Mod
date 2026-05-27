using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class UltStarForce : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 300000;
			Item.rare = 13;
			Item.accessory = true;
			Item.lifeRegen = 50;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.GetAttackSpeed(DamageClass.Melee) *= 1.5f;
				player.GetDamage(DamageClass.Melee) *= 3f;
				player.GetDamage(DamageClass.Ranged) *= 3f;
				player.GetDamage(DamageClass.Magic) *= 3f;
				player.GetDamage(DamageClass.Summon) *= 3f;
				player.statManaMax2 += 300;
				player.moveSpeed += 0.3f;
				player.maxMinions += 4;
				player.GetCritChance(DamageClass.Ranged) += 25;
				player.GetCritChance(DamageClass.Melee) += 25;
				player.GetCritChance(DamageClass.Magic) += 25;
				player.AddBuff(BuffID.Shine, 10);
		}

		public override void UpdateEquip(Player player)
		{
			player.AddBuff(ModContent.BuffType<global::VinesMod.Buffs.FloatingSword>(), 2);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.TriForce>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.TreeOfSavior>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveBlue>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveYellow>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDrivePurple>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveGreen>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveRed>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveWhite>(), 1)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
