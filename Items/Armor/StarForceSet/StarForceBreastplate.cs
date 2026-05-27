using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.StarForceSet
{
	[AutoloadEquip(EquipType.Body)]
	public class StarForceBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			ArmorIDs.Body.Sets.HidesTopSkin[Item.bodySlot] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 100000;
			Item.rare = ItemRarityID.Lime;
			Item.defense = 18;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Melee) *= 1.08f;
			player.GetDamage(DamageClass.Ranged) *= 1.08f;
			player.GetDamage(DamageClass.Magic) *= 1.08f;
			player.GetDamage(DamageClass.Summon) *= 1.08f;
			player.statManaMax2 += 40;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceBlue>(), 3)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceGreen>(), 3)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForcePurple>(), 3)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceRed>(), 3)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceWhite>(), 3)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceYellow>(), 3)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}