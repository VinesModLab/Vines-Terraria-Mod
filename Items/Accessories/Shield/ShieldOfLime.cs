using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.Shield
{
	[AutoloadEquip(EquipType.Shield)]
	public class ShieldOfLime : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shield Of Lime");
			Tooltip.SetDefault("+10 healthregen" + "\nslightly increase damage when above 50% health");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 4;
			item.accessory = true;
			item.defense = 8;
			item.lifeRegen = 10;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.statLife >= (player.statLifeMax2 * 0.5f))
			{
				player.meleeSpeed *= 1.2f;
				player.meleeDamage *= 1.15f;
				player.thrownDamage *= 1.15f;
				player.rangedDamage *= 1.15f;
				player.magicDamage *= 1.15f;
				player.minionDamage *= 1.15f;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(mod, "ShardGreen", 25);
			recipe.AddRecipeGroup("Wood", 15);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}