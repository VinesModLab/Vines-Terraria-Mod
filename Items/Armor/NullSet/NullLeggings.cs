using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace VinesMod.Items.Armor.NullSet
{
	[AutoloadEquip(EquipType.Legs)]
	public class NullLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Null (Legging)");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 11;
			item.defense = 10000;
		}

		public override void UpdateEquip(Player player)
		{
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "NullStar", 1);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}