using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.Shield
{
	[AutoloadEquip(EquipType.Shield)]
	public class ShieldOfFlag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shield of Flag");
			Tooltip.SetDefault("Allows Dash" + "\n +3 healthregen" +"\n slightly increase damage" + "\nA Shield used in army." );
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
			item.defense = 3;
			item.lifeRegen = 3;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.meleeDamage *= 1.05f;
				player.thrownDamage *= 1.05f;
				player.rangedDamage *= 1.05f;
				player.magicDamage *= 1.05f;
				player.minionDamage *= 1.05f;
				player.dash = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.AddIngredient(mod, "ShardYellow", 10);
			recipe.AddRecipeGroup("Wood", 15);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}