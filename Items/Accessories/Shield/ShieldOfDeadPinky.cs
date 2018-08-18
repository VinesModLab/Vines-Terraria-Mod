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
			Tooltip.SetDefault("+5 healthregen" + "\n more defense when above 70% health");
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
			if (player.statLife >= (player.statLifeMax2 * 0.7f))
			{
				player.statDefense += 4;
				player.moveSpeed += 0.1f;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(ItemID.PinkGel, 5);
			recipe.AddIngredient(mod, "ShardRed", 40);
			recipe.AddRecipeGroup("Wood", 15);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}