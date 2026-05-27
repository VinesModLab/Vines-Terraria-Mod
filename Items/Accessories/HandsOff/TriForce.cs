using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class TriForce : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 300000;
			Item.rare = ItemRarityID.Red;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.GetAttackSpeed(DamageClass.Melee) *= 1.3f;
				player.GetDamage(DamageClass.Melee) *= 1.5f;
				player.GetDamage(DamageClass.Ranged) *= 1.5f;
				player.GetDamage(DamageClass.Magic) *= 1.5f;
				player.GetDamage(DamageClass.Summon) *= 1.5f;
				player.moveSpeed += 0.3f;
				player.GetCritChance(DamageClass.Ranged) += 15;
				player.GetCritChance(DamageClass.Melee) += 15;
				player.GetCritChance(DamageClass.Magic) += 15;
				player.AddBuff(BuffID.Shine, 10);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.DarkerAcc>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.LighterAcc>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceBlue>(), 5)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceYellow>(), 5)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForcePurple>(), 5)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveCore>(), 3)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
