using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.GreenShardSet
{
	[AutoloadEquip(EquipType.Head)]
	public class GreenHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Summon) *= 1.08f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<global::VinesMod.Items.Armor.GreenShardSet.GreenBreastplate>() && legs.type == ModContent.ItemType<global::VinesMod.Items.Armor.GreenShardSet.GreenLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.maxMinions++;
			player.GetDamage(DamageClass.Summon) *= 1.12f;
			player.lifeRegen += 2;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("IronBar", 10)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardGreen>(), 10)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}