using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	[AutoloadEquip(EquipType.HandsOff)]
	public class UltStarForce : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ultimate StarForce");
			Tooltip.SetDefault("Dealt damage x3" + "\n +50 liferegen" + "\n +300 mana" + "\n +4 minions" + "\nThe power of stars.");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 300000;
			item.rare = 10;
			item.accessory = true;
			item.lifeRegen = 50;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.meleeDamage *= 3f;
				player.thrownDamage *= 3f;
				player.rangedDamage *= 3f;
				player.magicDamage *= 3f;
				player.minionDamage *= 3f;
				player.statManaMax2 += 300;
				player.moveSpeed += 0.3f;
				player.maxMinions += 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "StarForceBlue", 1);
			recipe.AddIngredient(mod, "StarForceYellow", 1);
			recipe.AddIngredient(mod, "StarForcePurple", 1);
			recipe.AddIngredient(mod, "StarForceGreen", 1);
			recipe.AddIngredient(mod, "StarForceRed", 1);
			recipe.AddIngredient(mod, "StarForceWhite", 1);
			recipe.AddIngredient(mod, "OverDriveCore", 5);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}