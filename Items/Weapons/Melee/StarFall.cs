using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class StarFall : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("StarFall");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Starfury);
			item.shootSpeed *= 1.1f;
			item.damage = 89;
			item.value = Item.sellPrice(gold: 3);
			item.rare = 6;
			item.autoReuse = true;
			item.scale = 1.7f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("StarFallProjectile");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(ItemID.Starfury);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(ItemID.GoldBar, 5);
			recipe.AddIngredient(ItemID.FallenStar, 7);
			recipe.AddIngredient(mod, "ShardYellow", 30);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	
}