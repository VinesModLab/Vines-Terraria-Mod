using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class Robot3000 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Robot3000");
			Tooltip.SetDefault("calculated."+"\nincrease 20% minion damage");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = Item.sellPrice(gold: 2); 
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.minionDamage *= 1.2f;
				player.AddBuff(11, 10);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 3);
			recipe.AddIngredient(ItemID.GoldBar, 3);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}