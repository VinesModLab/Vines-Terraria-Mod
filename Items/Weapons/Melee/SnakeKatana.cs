using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class SnakeKatana : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snake Katana");
		}

		public override void SetDefaults()
		{
			item.damage = 35;      
			item.melee = true; 
			item.width = 40; 
			item.height = 40;           
			item.useTime = 20;         
			item.useAnimation = 20; 
			item.useStyle = 1;//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			item.knockBack = 5;
			item.value = Item.sellPrice(copper: 60);           //The value of the weapon
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.scale = 0.7f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(ItemID.Emerald, 2);
			recipe.AddIngredient(mod, "GrassDefender", 1);
			recipe.AddIngredient(mod, "ShardGreen", 15);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			if (Main.rand.Next(5) == 0)
			{
				target.AddBuff(BuffID.Poisoned, 60 * 5);
			}
        }

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(15) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("SparkleGreen"));
			}
		}
	}
}
