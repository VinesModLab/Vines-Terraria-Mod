using VinesMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Throw
{
	public class DirtJavelin : ModItem
	{
		public override void SetDefaults()
		{
			Item.shootSpeed = 10f;
			Item.damage = 10;
			Item.knockBack = 5f;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.width = 30;
			Item.height = 30;
			Item.maxStack = 999;
			Item.rare = 0;

			Item.consumable = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Ranged;

			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(copper: 1);
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.DirtJavelinProjectile>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DirtBlock, 10)
				.AddIngredient(ItemID.StoneBlock, 5)
				.AddRecipeGroup("Wood", 5)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}

}
