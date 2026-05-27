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
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.accessory = true;
			Item.defense = 4;
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
