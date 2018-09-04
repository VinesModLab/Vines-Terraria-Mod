using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.NullSet
{
	[AutoloadEquip(EquipType.Body)]
	public class NullBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Null (Breastplate)");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 12;
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