using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.GoodieBags
{
	public class PurpleShardBag : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.maxStack = 999;
            Item.consumable = true;
			Item.value = Item.buyPrice(0,5,0,0);
			Item.width = 20;
			Item.height = 20;
			Item.rare = ItemRarityID.Green;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), Main.rand.Next(50, 100));
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Summon.PurpleSlimeBossSummonItem>(), 2)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
