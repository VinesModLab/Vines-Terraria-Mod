using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class LilacGuardianOverDrive : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.damage = 82;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.5f;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.scale = 1f;
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.BladeArtProjectile>();
			Item.shootSpeed = 9f;
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			Projectile.NewProjectile(source, position, velocity.RotatedBy(MathHelper.ToRadians(-12f)), type, (int)(damage * 0.65f), knockBack, player.whoAmI, 4f);
			Projectile.NewProjectile(source, position, velocity.RotatedBy(MathHelper.ToRadians(12f)), type, (int)(damage * 0.65f), knockBack, player.whoAmI, 4f);
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.LilacGuardian>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDrivePurple>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForcePurple>(), 3)
				.AddIngredient(ItemID.LargeAmethyst, 3)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Venom, 240);
		}
	}
}