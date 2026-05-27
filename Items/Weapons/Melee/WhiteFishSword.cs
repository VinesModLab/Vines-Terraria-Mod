using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class WhiteFishSword : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.damage = 40;      
			Item.DamageType = DamageClass.Melee; 
			Item.width = 40; 
			Item.height = 40;           
			Item.useTime = 20;         
			Item.useAnimation = 20; 
			Item.useStyle = ItemUseStyleID.Swing;//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			Item.knockBack = 5f;
			Item.value = Item.sellPrice(gold: 2);            //The value of the weapon
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.scale = 1f;
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.BladeArtProjectile>();
			Item.shootSpeed = 8f;
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			Vector2 wave = velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-12f, 12f)));
			Projectile.NewProjectile(source, position, wave, type, (int)(damage * 0.6f), knockBack, player.whoAmI, 9f);
			return false;
		}

		public override void AddRecipes()
		{
			/*
			CreateRecipe()
				.AddRecipeGroup("IronBar", 15)
				.AddIngredient(ItemID.GoldBar, 22)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), 5)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
			*/

			Recipe.Create(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), 25)
				.AddIngredient(Type)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarRecycler>())
				.Register();
		}
	}
}
