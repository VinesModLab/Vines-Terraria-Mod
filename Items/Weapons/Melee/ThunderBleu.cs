using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class ThunderBleu : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thunder Bleu");
		}

		public override void SetDefaults()
		{
			item.damage = 17;      
			item.melee = true; 
			item.width = 40; 
			item.height = 40;           
			item.useTime = 20;         
			item.useAnimation = 20; 
			item.useStyle = 1;//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			item.knockBack = 3;
			item.value = Item.sellPrice(copper: 30);           //The value of the weapon
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddIngredient(ItemID.GoldBar, 2);
			recipe.AddIngredient(mod, "ShardBlue", 5);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			if (Main.rand.Next(5) == 0)
			{
				target.AddBuff(BuffID.Chilled, 60 * 5);
			}
        }

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(15) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("SparkleBlue"));
			}
		}
	}
}
