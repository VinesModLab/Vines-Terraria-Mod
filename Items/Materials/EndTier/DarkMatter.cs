using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Materials.EndTier
{
	public class DarkMatter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter");
			Tooltip.SetDefault("it stores unknown power.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 11;
		}

		public override void AddRecipes()
		{
		}
	}
}
