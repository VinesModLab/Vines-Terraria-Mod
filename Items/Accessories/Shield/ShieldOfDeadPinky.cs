using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.Shield
{
	[AutoloadEquip(EquipType.Shield)]
	public class ShieldOfDeadPinky : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shield Of Dead Pinky");
			Tooltip.SetDefault("+5 healthregen");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 4;
			item.accessory = true;
			item.defense = 12;
			item.lifeRegen = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(ItemID.PinkGel, 5);
			recipe.AddIngredient(mod, "ShardRed", 15);
			recipe.AddRecipeGroup("Wood", 15);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}