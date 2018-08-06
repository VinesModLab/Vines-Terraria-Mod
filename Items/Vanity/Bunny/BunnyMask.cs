using Terraria.ModLoader;
using Terraria.ID;

namespace VinesMod.Items.Vanity.Bunny
{
	[AutoloadEquip(EquipType.Head)]
	public class BunnyMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.rare = 1;
			item.vanity = true;
		}

		public override bool DrawHead()
		{
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}