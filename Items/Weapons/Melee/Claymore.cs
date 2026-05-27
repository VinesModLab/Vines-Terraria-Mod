using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class Claymore : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.damage = 25;      
			Item.DamageType = DamageClass.Melee; 
			Item.width = 40; 
			Item.height = 40;           
			Item.useTime = 20;         
			Item.useAnimation = 20; 
			Item.useStyle = ItemUseStyleID.Swing;//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			Item.knockBack = 7f;
			Item.value = Item.sellPrice(copper: 10);           //The value of the weapon
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.scale = 1.2f;
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.BladeArtProjectile>();
			Item.shootSpeed = 5.5f;
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			Projectile.NewProjectile(source, position, velocity, type, (int)(damage * 0.8f), knockBack + 1f, player.whoAmI, 7f);
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("IronBar", 15)
				.AddIngredient(ItemID.GoldBar, 22)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), 5)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
