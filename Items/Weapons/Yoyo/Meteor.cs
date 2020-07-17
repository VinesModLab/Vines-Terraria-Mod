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
            DisplayName.SetDefault("Meteor");

        }

        public override void SetDefaults()
        {
            item.useStyle = 5; 
            item.width = 24;
            item.height = 24;
            item.noUseGraphic = true; 
            item.melee = true; 
            item.noMelee = true; 
            item.channel = true; 
            item.UseSound = SoundID.Item1;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shoot = ModContent.ProjectileType<Projectiles.MeteorYoyoProjectile>(); 
            item.shootSpeed = 30f; 
            item.knockBack = 5f;
            item.damage = 26;
            item.value = 10000;
            item.rare = 3;
        }

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("IronBar", 7);
            recipe.AddIngredient(ItemID.Cobweb, 15);
            recipe.AddIngredient(mod, "ShardRed", 5);
            recipe.AddIngredient(mod, "ShardYellow", 5);
            recipe.AddIngredient(mod, "ShardWhite", 3);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}
