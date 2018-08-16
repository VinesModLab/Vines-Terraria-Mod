using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class GoldenEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("GoldenEye");
			Tooltip.SetDefault("increase 20% damage");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 4;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.meleeDamage *= 1.2f;
				player.thrownDamage *= 1.2f;
				player.rangedDamage *= 1.2f;
				player.magicDamage *= 1.2f;
				player.minionDamage *= 1.2f;
				player.AddBuff(11, 10);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "BlueEyeBall", 1);
			recipe.AddIngredient(mod, "RedEyeBall", 1);
			recipe.AddIngredient(mod, "Robot3000", 1);
			recipe.AddIngredient(mod, "ShardYellow", 25);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}