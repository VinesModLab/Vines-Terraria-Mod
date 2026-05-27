using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.PurpleManaSet
{
	[AutoloadEquip(EquipType.Head)]
	public class PurpleHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{

		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 8;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<global::VinesMod.Items.Armor.PurpleManaSet.PurpleBreastplate>() && legs.type == ModContent.ItemType<global::VinesMod.Items.Armor.PurpleManaSet.PurpleLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.GetDamage(DamageClass.Melee) *= 1.1f;
			player.GetDamage(DamageClass.Ranged) *= 1.1f;
			player.GetDamage(DamageClass.Magic) *= 1.1f;
			player.GetDamage(DamageClass.Summon) *= 1.1f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.ManaCrystal, 3)
				.AddRecipeGroup("IronBar", 10)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), 10)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
