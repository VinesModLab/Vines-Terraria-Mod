using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Magic
{
	public class SlimeHexStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.staff[Type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 32;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 12;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4.5f;
			Item.value = Item.sellPrice(gold: 1, silver: 40);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.SlimeHexProjectile>();
			Item.shootSpeed = 7.5f;
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			Projectile.NewProjectile(source, position, velocity, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(source, position, velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextBool() ? 11f : -11f)) * 0.9f, type, (int)(damage * 0.75f), knockBack, player.whoAmI);
			return false;
		}

		public override void AddRecipes()
		{
			Recipe.Create(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), 18)
				.AddIngredient(Type)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarRecycler>())
				.Register();
		}
	}
}
