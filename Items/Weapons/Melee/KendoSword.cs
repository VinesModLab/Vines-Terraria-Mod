using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class KendoSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kendo Sword");
		}

		public override void SetDefaults()
		{
			item.damage = 15;      
			item.melee = true; 
			item.width = 40; 
			item.height = 40;           
			item.useTime = 20;         
			item.useAnimation = 20; 
			item.useStyle = 1;//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			item.knockBack = 20f;
			item.value = Item.sellPrice(copper: 30);           //The value of the weapon
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.scale = 0.7f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 50);
			recipe.AddIngredient(mod, "ShardYellow", 5);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
