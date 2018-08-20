using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class UltStarForce : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ultimate StarForce");
			Tooltip.SetDefault("Dealt damage x3" + "\n45% increased critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 300000;
			item.rare = 10;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.meleeSpeed *= 1.3f;
				player.meleeDamage *= 3f;
				player.thrownDamage *= 3f;
				player.rangedDamage *= 3f;
				player.magicDamage *= 3f;
				player.minionDamage *= 3f;
				player.moveSpeed += 0.3f;
				player.rangedCrit += 15;
				player.meleeCrit += 15;
				player.magicCrit += 15;
				player.thrownCrit += 15;
				player.AddBuff(11, 10);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "StarForceBlue", 5);
			recipe.AddIngredient(mod, "StarForceYellow", 5);
			recipe.AddIngredient(mod, "StarForcePurple", 5);
			recipe.AddIngredient(mod, "OverDriveCore", 3);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}