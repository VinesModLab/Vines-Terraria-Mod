using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class BloodStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BloodStone");
			Tooltip.SetDefault("immune fire and poison");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.buffImmune[BuffID.OnFire] = true;
				player.buffImmune[BuffID.Poisoned] = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "ShardRed", 5);
			recipe.AddIngredient(ItemID.StoneBlock, 30);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}