using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using VinesMod.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Bow
{
    public class Phantom : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 24;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.damage = 140;
            Item.useStyle = ItemUseStyleID.Shoot; 
            Item.noMelee = true; 
            Item.value = Item.buyPrice(0, 0, 30, 0);
            Item.rare = 5;
            Item.DamageType = DamageClass.Ranged;
            Item.UseSound = new SoundStyle("VinesMod/Sounds/Item/Wooo");
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.Wisp>();
			Item.shootSpeed = 22f;
			Item.useAmmo = ModContent.ItemType<global::VinesMod.Items.Weapons.Ammo.Wisp>();
        }
        
        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			int numberProjectiles = 2 + Main.rand.Next(2); 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(15));
				//randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 

				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		
        public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), 35)
				.AddIngredient(ItemID.SpectreBar, 25)
				.AddIngredient(ItemID.Cobweb, 15)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}

    }
}
