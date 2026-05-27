using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class RedEyeBall : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = Item.sellPrice(gold: 2); 
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.GetDamage(DamageClass.Ranged) *= 1.1f;
		}

		public override void AddRecipes()
		{
			Recipe.Create(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), 12)
				.AddIngredient(Type)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarRecycler>())
				.Register();
		}
	}
}
