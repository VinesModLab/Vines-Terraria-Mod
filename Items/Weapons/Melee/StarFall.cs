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
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Starfury);
			Item.shootSpeed *= 1.1f;
			Item.damage = 89;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = 6;
			Item.autoReuse = true;
			Item.scale = 1.7f;
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			type = ModContent.ProjectileType<global::VinesMod.Projectiles.StarFallProjectile>();
			Projectile.NewProjectile(source, position, velocity, type, damage, knockBack, player.whoAmI);
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Starfury)
				.AddRecipeGroup("IronBar", 10)
				.AddIngredient(ItemID.GoldBar, 5)
				.AddIngredient(ItemID.FallenStar, 7)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardYellow>(), 30)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
	
}