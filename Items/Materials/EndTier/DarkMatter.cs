using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Materials.EndTier
{
	public class DarkMatter : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 300000;
			Item.rare = ItemRarityID.Purple;
		}

		public override void AddRecipes()
		{
		}
	}
}
