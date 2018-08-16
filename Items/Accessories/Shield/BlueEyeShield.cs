using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.Shield
{
	[AutoloadEquip(EquipType.Shield)]
	public class BlueEyeShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shield of BlueEye");
			Tooltip.SetDefault("Allows dash" + "\n+40 Max Mana");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 3;
			item.accessory = true;
			item.defense = 4;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 40;
			player.dash = 1;
		}

		public override void AddRecipes()
		{
		}
	}
}