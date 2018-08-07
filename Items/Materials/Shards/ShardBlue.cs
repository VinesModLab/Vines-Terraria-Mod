using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Materials.Shards
{
	public class ShardBlue : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Shard");
			Tooltip.SetDefault("Good-looking crystal shard.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 1;
		}
	}
}
