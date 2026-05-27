using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Gun
{
	public class VoidQuartzRifle : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 46;
			Item.height = 18;
			Item.damage = 72;
			Item.DamageType = DamageClass.Ranged;
			Item.useTime = 38;
			Item.useAnimation = 38;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 7f;
			Item.value = Item.buyPrice(0, 6, 0, 0);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item40;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 18f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<global::VinesMod.Projectiles.VoidQuartzShot>(), damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
