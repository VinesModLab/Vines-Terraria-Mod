using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace VinesMod.Items.Weapons.Ammo
{
    public class OverDriveArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 1.5f;
            Item.value = 10;
            Item.rare = 6;
            Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.OverDriveArrow>();
            Item.shootSpeed *= 1.1f;
            Item.ammo = Item.type;
        }

        public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Ruby, 5)
				.AddRecipeGroup("Wood", 15)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), 15)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
    }
}
