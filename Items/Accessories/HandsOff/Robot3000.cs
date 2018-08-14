using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	[AutoloadEquip(EquipType.HandsOff)]
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
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.minionDamage *= 1.2f;
		}

		public override void AddRecipes()
		{
		}
	}
}