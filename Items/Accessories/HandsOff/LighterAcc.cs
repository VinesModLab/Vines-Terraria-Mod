using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class LighterAcc : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lighter Matter");
			Tooltip.SetDefault("+4 MaxMinions"+"\n+ 200 Life" + "\n+ 100 Mana" +"\n...");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 300000;
			item.rare = 10;
			item.accessory = true;
			item.lifeRegen = 20;
			item.defense = 15;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 200;
			player.statManaMax2 += 100;
			player.maxMinions += 4;
			player.moveSpeed += +0.4f;
			player.AddBuff(11, 10);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "LightMatter", 1);
			recipe.AddIngredient(mod, "DarkMatter", 1);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}