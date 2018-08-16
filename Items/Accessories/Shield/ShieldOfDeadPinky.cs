using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.Shield
{
	[AutoloadEquip(EquipType.Shield)]
	public class ShieldOfDeadPinky : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shield Of Dead Pinky");
			//Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 5;
			item.accessory = true;
			item.defense = 10;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
		}

		public override void AddRecipes()
		{
		}
	}
}