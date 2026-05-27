using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Bow
{
    public class StormbowOverDrive : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.DaedalusStormbow);
            Item.width = 16;
            Item.height = 24;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.damage = 500;
            Item.useStyle = ItemUseStyleID.Shoot; 
            Item.noMelee = true; 
            Item.value = Item.buyPrice(gold: 30);
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item5; 
            Item.useAmmo = ModContent.ItemType<global::VinesMod.Items.Weapons.Ammo.OverDriveArrow>();
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 300f;
            Item.DamageType = DamageClass.Ranged;
            //Item.autoReuse = true;
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			float numberProjectiles = 10 + Main.rand.Next(15);
			float rotation = MathHelper.ToRadians(45);
			position += Vector2.Normalize(velocity) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 Projectile.
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
        
		
        public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DaedalusStormbow)
				.AddIngredient(ItemID.LifeCrystal, 10)
				.AddIngredient(ItemID.LargeRuby, 5)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveRed>(), 1)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}

    }
}
