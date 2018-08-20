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
    public class Phantom : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantom");
            Tooltip.SetDefault("It use wasp as ammo.");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 24;
            item.useTime = 15;
            item.useAnimation = 15;
            item.damage = 140;
            item.useStyle = 5; 
            item.noMelee = true; 
            item.value = Item.buyPrice(0, 0, 30, 0);
            item.rare = 5;
            item.ranged = true;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Wooo");
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Wisp");
			item.shootSpeed = 22f;
			item.useAmmo = mod.ItemType("Wisp");
        }
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 2 + Main.rand.Next(2); 
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
            recipe.AddIngredient(mod, "ShardWhite", 35);
            recipe.AddIngredient(ItemID.SpectreBar, 25);
            recipe.AddIngredient(ItemID.Cobweb, 15);
            recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

    }
}
