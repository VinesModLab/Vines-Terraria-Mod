using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.GoodieBags
{
	public class GreenShardBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Green Shard Bag");
			Tooltip.SetDefault("<right> to get random amount of shards!");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
            item.consumable = true;
			item.value = Item.buyPrice(0,5,0,0);
			item.width = 20;
			item.height = 20;
			item.rare = 2;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
				player.QuickSpawnItem(mod.ItemType("ShardGreen"), Main.rand.Next(50, 100));
		}
	}
}