using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class BlueEyeBall : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BlueEyeBall");
			Tooltip.SetDefault("increase 10% magic damage");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(gold: 2); 
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.magicDamage *= 1.1f;
		}

		public override void AddRecipes()
		{
		}
	}
}