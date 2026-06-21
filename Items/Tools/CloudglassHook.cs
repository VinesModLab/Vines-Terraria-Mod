using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Tools
{
	public class CloudglassHook : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.DualHook);
			Item.width = 28;
			Item.height = 28;
			Item.value = Item.buyPrice(0, 3, 0, 0);
			Item.rare = ItemRarityID.Green;
		}
	}
}
