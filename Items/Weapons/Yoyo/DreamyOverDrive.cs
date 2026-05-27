using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Yoyo
{
	public class DreamyOverDrive : ModItem
	{
		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.width = 24;
			Item.height = 24;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.channel = true;
			Item.UseSound = SoundID.Item1;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.DreamyOverDriveYoyoProjectile>();
			Item.shootSpeed = 30f;
			Item.knockBack = 5.5f;
			Item.damage = 92;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Purple;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Yoyo.Dreamy>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDrivePurple>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForcePurple>(), 2)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceBlue>(), 2)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
