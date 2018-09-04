using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Yoyo
{
    public class RektU3000 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("RektU3000");

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
            item.shoot = mod.ProjectileType<Projectiles.RektU3000>(); 
            item.shootSpeed = 30f; 
            item.knockBack = 6f;
            item.damage = 86;
            item.value = 10000;
            item.rare = 8;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 3 + Main.rand.Next(3);
			float rotation = MathHelper.ToRadians(45);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
	
			recipe.AddIngredient(ItemID.SoulofMight, 3);
            recipe.AddRecipeGroup("IronBar", 10);
            recipe.AddIngredient(ItemID.Amber, 30);
            recipe.AddIngredient(ItemID.Cobweb, 15);
            recipe.AddIngredient(ItemID.Spike, 4);
            recipe.AddIngredient(mod, "StarForceGreen", 1);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}
