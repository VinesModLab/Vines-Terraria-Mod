using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Bow
{
	public class SkyPrismBow : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.damage = 24;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2.5f;
			Item.value = Item.buyPrice(0, 2, 20, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 11.5f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			Projectile.NewProjectile(source, position, velocity, type, damage, knockBack, player.whoAmI);
			if (Main.rand.NextBool(2))
			{
				Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(7f)) * 0.9f, ModContent.ProjectileType<Projectiles.PrismRepeaterBolt>(), (int)(damage * 0.42f), knockBack * 0.5f, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<Placeable.FracturedPrismOre>(12)
				.AddIngredient<Placeable.CloudglassPlatform>(20)
				.AddIngredient(ItemID.FallenStar, 3)
				.AddTile(ModContent.TileType<Tiles.PrismAltar>())
				.Register();
		}
	}
}
