using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class ThunderBleuOverDrive : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.damage = 72;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.5f;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.scale = 1f;
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.BladeArtProjectile>();
			Item.shootSpeed = 12f;
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			Projectile.NewProjectile(source, position, velocity, type, (int)(damage * 0.75f), knockBack, player.whoAmI, 1f);
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.ThunderBleu>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveBlue>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceBlue>(), 3)
				.AddIngredient(ItemID.LargeSapphire, 3)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Electrified, 180);
		}
	}
}