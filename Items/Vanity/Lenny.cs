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
			DisplayName.SetDefault("( ͡° ͜ʖ ͡°)");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = Item.buyPrice(0,5,0,0);
			item.rare = 10;
			item.vanity = true;
		}
		
		public override bool DrawHead()
		{
			return false;
		}
	}
}