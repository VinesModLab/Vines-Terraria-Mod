using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class Lenny : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = Item.buyPrice(0,5,0,0);
			Item.rare = ItemRarityID.Red;
			Item.vanity = true;
		}
		
		}
}
