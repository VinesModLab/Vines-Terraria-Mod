using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.YellowShardSet
{
	[AutoloadEquip(EquipType.Head)]
	public class YellowHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Ranged) += 8;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<global::VinesMod.Items.Armor.YellowShardSet.YellowBreastplate>() && legs.type == ModContent.ItemType<global::VinesMod.Items.Armor.YellowShardSet.YellowLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.GetDamage(DamageClass.Ranged) *= 1.12f;
			player.GetCritChance(DamageClass.Ranged) += 8;
			player.moveSpeed += 0.05f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("IronBar", 10)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardYellow>(), 10)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}