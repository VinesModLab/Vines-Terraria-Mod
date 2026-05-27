using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Bow
{
	public class PrismRepeater : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.damage = 42;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 3.5f;
			Item.value = Item.buyPrice(0, 4, 0, 0);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 13.5f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			Projectile.NewProjectile(source, position, velocity, type, damage, knockBack, player.whoAmI);
			Vector2 prismVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(5f)) * 1.08f;
			Projectile.NewProjectile(source, position, prismVelocity, ModContent.ProjectileType<global::VinesMod.Projectiles.PrismRepeaterBolt>(), (int)(damage * 0.55f), knockBack * 0.5f, player.whoAmI);
			return false;
		}
	}
}
