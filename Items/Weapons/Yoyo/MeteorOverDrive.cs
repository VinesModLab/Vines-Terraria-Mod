using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Yoyo
{
	public class MeteorOverDrive : ModItem
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
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.MeteorOverDriveYoyoProjectile>();
			Item.shootSpeed = 30f;
			Item.knockBack = 6f;
			Item.damage = 96;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Purple;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Yoyo.Meteor>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveRed>())
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceRed>(), 2)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceYellow>(), 2)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
