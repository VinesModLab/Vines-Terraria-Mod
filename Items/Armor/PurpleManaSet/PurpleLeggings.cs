using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace VinesMod.Items.Armor.PurpleManaSet
{
	[AutoloadEquip(EquipType.Legs)]
	public class PurpleLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Mana Legging");
			Tooltip.SetDefault("5% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 1;
			item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ManaCrystal, 2);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddIngredient(mod, "ShardPurple", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ManaCrystal, 2);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddIngredient(mod, "ShardPurple", 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}