using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using VinesMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Bow
{
    public class Avalanche : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Avalanche");
            Tooltip.SetDefault("It use snowball as ammo.");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 24;
            item.useTime = 20;
            item.useAnimation = 20;
            item.damage = 40;
            item.useStyle = 5; 
            item.noMelee = true; 
            item.value = Item.buyPrice(0, 0, 30, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item5; 
            item.useAmmo = AmmoID.Snowball;
            item.shoot = mod.ProjectileType<AvalancheProjectile>();
            item.shootSpeed = 45f;
            item.ranged = true;
            item.autoReuse = true;
        }
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 6 + Main.rand.Next(4); 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
				//randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 

				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "ShardWhite", 50);
            recipe.AddIngredient(ItemID.SnowBlock, 400);
            recipe.AddIngredient(ItemID.Cobweb, 15);
            recipe.AddIngredient(ItemID.SnowballCannon, 1);
            recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

    }
    class AvalancheProjectile : ModProjectile // no idea why it is not applied
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AvalancheProjectile");
        }
		public override void SetDefaults()
		{
            projectile.CloneDefaults(ProjectileID.SnowBallFriendly);
            aiType = ProjectileID.SnowBallFriendly;
			projectile.friendly = true;
            projectile.scale = 2f;
            projectile.light = 0.5f;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;      
            projectile.extraUpdates = 1;
		}

		public override string Texture { get { return "Terraria/Projectile_" + ProjectileID.SnowBallFriendly; } }

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			projectile.damage = (int)(projectile.damage * 0.65f);
		}

        public override void AI()
		{
            if (Main.rand.Next(2) == 0)
            {
	            int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 261, 0f, 0f, 200, default(Color), 1f);
	            Main.dust[dust2].velocity *= 0.3f;
                Main.dust[dust2].noGravity = true;
            }
            if (Main.rand.Next(3) == 0)
            {
	            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("Sparkle"), 0f, 0f, 200, default(Color), 1f);
	            Main.dust[dust].velocity *= 0.3f;
                Main.dust[dust].noGravity = true;
            }
		}
	}
}
