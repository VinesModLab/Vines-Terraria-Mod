using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class PizzaBadge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PizzaBadge");
			Tooltip.SetDefault("Who doesn't like pizza?" +"\n +10 healthregen");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
			item.lifeRegen = 10;
		}
	}
}