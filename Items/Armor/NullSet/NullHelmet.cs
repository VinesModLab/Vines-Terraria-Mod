using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.NullSet
{
	[AutoloadEquip(EquipType.Head)]
	public class NullHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Expert;
			Item.defense = 10000;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<global::VinesMod.Items.Armor.NullSet.NullBreastplate>() && legs.type == ModContent.ItemType<global::VinesMod.Items.Armor.NullSet.NullLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.GetDamage(DamageClass.Melee) *= 5f;
			player.GetDamage(DamageClass.Ranged) *= 5f;
			player.GetDamage(DamageClass.Magic) *= 5f;
			player.GetDamage(DamageClass.Summon) *= 5f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.NullStar>(), 1)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
