using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Materials.Shards
{
	public class ShardWhite : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 100;
			Item.rare = ItemRarityID.Blue;
		}
	}
}
