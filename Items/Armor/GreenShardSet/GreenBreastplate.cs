using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.GreenShardSet
{
	[AutoloadEquip(EquipType.Body)]
	public class GreenBreastplate : ModItem
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
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 9;
		}

		public override void UpdateEquip(Player player)
		{
			player.maxMinions++;
			player.lifeRegen += 2;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("IronBar", 15)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardGreen>(), 15)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}