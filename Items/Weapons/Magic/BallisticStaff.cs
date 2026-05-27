using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Magic
{
	public class BallisticStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.staff[Type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 12;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 5;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.BallisticSparklingBall>();
			Item.shootSpeed = 16f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DiamondStaff, 1)
				.AddIngredient(ItemID.Lens, 5)
				.AddIngredient(ItemID.Boulder, 5)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), 10)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();

			Recipe.Create(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardYellow>(), 15)
				.AddIngredient(Type)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarRecycler>())
				.Register();
		}
	}
}
