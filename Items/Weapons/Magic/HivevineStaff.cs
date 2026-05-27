using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Magic
{
	public class HivevineStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.staff[Type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 28;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 10;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 3.5f;
			Item.value = Item.sellPrice(gold: 1, silver: 20);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.HivevineStingerProjectile>();
			Item.shootSpeed = 9f;
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			for (int i = -1; i <= 1; i++)
			{
				Vector2 shotVelocity = velocity.RotatedBy(MathHelper.ToRadians(i * 9f));
				Projectile.NewProjectile(source, position, shotVelocity, type, damage, knockBack, player.whoAmI);
			}

			return false;
		}

		public override void AddRecipes()
		{
			Recipe.Create(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardGreen>(), 18)
				.AddIngredient(Type)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarRecycler>())
				.Register();
		}
	}
}
