using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.RedShardSet
{
	[AutoloadEquip(EquipType.Head)]
	public class RedHelmet : ModItem
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
			Item.defense = 9;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Melee) += 8;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<global::VinesMod.Items.Armor.RedShardSet.RedBreastplate>() && legs.type == ModContent.ItemType<global::VinesMod.Items.Armor.RedShardSet.RedLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.GetDamage(DamageClass.Melee) *= 1.12f;
			player.GetCritChance(DamageClass.Melee) += 10;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("IronBar", 10)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), 10)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}