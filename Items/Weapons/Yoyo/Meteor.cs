using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Yoyo
{
    public class Meteor : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

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
            Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.MeteorYoyoProjectile>(); 
            Item.shootSpeed = 30f; 
            Item.knockBack = 5f;
            Item.damage = 26;
            Item.value = 10000;
            Item.rare = 3;
        }

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddRecipeGroup("IronBar", 7)
				.AddIngredient(ItemID.Cobweb, 15)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), 5)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardYellow>(), 5)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), 3)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
        }
    }
}
