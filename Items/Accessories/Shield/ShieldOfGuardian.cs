using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.Shield
{
	[AutoloadEquip(EquipType.Shield)]
	public class ShieldOfGuardian : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shield Of Guardian");
			Tooltip.SetDefault("Allows dash");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 1;
			item.accessory = true;
			item.defense = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.dash = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 12);
			recipe.AddIngredient(mod, "ShardPurple", 10);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}