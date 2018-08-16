using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class RedEyeBall : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("RedEyeBall");
			Tooltip.SetDefault("increase 10% ranaged damage");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.rangedDamage *= 1.1f;
		}

		public override void AddRecipes()
		{
		}
	}
}