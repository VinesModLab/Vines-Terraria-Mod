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
			DisplayName.SetDefault("Stone Mirror");
			Tooltip.SetDefault("return home safely!");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.IceMirror);
		}

		public override void UseStyle(Player player)
		{
			if (Main.rand.NextBool(2))
			{
				Dust.NewDust(player.position, player.width, player.height, 15, 0f, 0f, 150, default(Color), 1.1f);
			}
			// This sets up the itemTime correctly.
			if (player.itemTime == 0)
			{
				player.itemTime = (int)(item.useTime / PlayerHooks.TotalUseTimeMultiplier(player, item));
			}
			else if (player.itemTime == (int)(item.useTime / PlayerHooks.TotalUseTimeMultiplier(player, item)) / 2)
			{
				// This code runs once halfway through the useTime of the item. You'll notice with magic mirrors you are still holding the item for a little bit after you've teleported.

				for (int d = 0; d < 70; d++)
				{
					Dust.NewDust(player.position, player.width, player.height, 15, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default(Color), 1.5f);
				}
				// This code releases all grappling hooks and kills them.
				player.grappling[0] = -1;
				player.grapCount = 0;
				for (int p = 0; p < 1000; p++)
				{
					if (Main.projectile[p].active && Main.projectile[p].owner == player.whoAmI && Main.projectile[p].aiStyle == 7)
					{
						Main.projectile[p].Kill();
					}
				}
				// The actual method that moves the player back to bed/spawn.
				player.Spawn();
				for (int d = 0; d < 70; d++)
				{
					Dust.NewDust(player.position, player.width, player.height, 15, 0f, 0f, 150, default(Color), 1.5f);
				}
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 40);
			recipe.AddIngredient(ItemID.SandBlock, 40);
			recipe.AddRecipeGroup("Wood", 40);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
