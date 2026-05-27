using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Tools
{
	class StoneMirror : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.IceMirror);
		}

		public override bool? UseItem(Player player)
		{
			// Emit dust during use (visual only; teleport is handled by CloneDefaults(IceMirror))
			if (Main.rand.NextBool(2))
			{
				Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default(Color), 1.1f);
			}
			return null;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.StoneBlock, 40)
				.AddIngredient(ItemID.SandBlock, 40)
				.AddRecipeGroup("Wood", 40)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
