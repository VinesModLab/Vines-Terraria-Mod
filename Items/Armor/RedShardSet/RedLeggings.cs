using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.RedShardSet
{
	[AutoloadEquip(EquipType.Legs)]
	public class RedLeggings : ModItem
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
			Item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetAttackSpeed(DamageClass.Melee) *= 1.08f;
			player.moveSpeed += 0.05f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("IronBar", 8)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), 10)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}