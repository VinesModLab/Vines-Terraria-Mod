using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Tools
{
	public class FossilYellowPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("FossilYellow Pickaxe");
		}

		public override void SetDefaults()
		{
			item.damage = 15;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.pick = 55;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DesertFossil, 30);
			recipe.AddIngredient(ItemID.Topaz, 5);
			recipe.AddRecipeGroup("IronBar", 7);
			recipe.AddRecipeGroup("Wood", 20);
			recipe.AddIngredient(mod, "ShardRed", 15);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(10) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("SparkleBlue"));
			}
		}
	}
}