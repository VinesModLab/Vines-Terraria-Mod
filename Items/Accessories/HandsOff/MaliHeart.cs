using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class MaliHeart : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MaliHeart");
			Tooltip.SetDefault("immune to various effect" + "\n +20 Life and Mana");
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
				player.statLifeMax2 += 40;
				player.statManaMax2 += 40;
				player.buffImmune[BuffID.Frozen] = true;
				player.buffImmune[BuffID.Chilled] = true;
				player.buffImmune[BuffID.OnFire] = true;
				player.buffImmune[BuffID.Poisoned] = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "ShardBlue", 40);
			recipe.AddIngredient(mod, "ShardRed", 40);
			recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.AddIngredient(ItemID.ManaCrystal, 2);
			recipe.AddIngredient(mod, "IcySteel", 1);
			recipe.AddIngredient(mod, "BloodStone", 1);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}