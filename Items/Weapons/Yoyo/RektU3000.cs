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
            Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.RektU3000>(); 
            Item.shootSpeed = 30f; 
            Item.knockBack = 6f;
            Item.damage = 86;
            Item.value = 10000;
            Item.rare = ItemRarityID.Yellow;
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			float numberProjectiles = 3 + Main.rand.Next(3);
			float rotation = MathHelper.ToRadians(45);
			position += Vector2.Normalize(velocity) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.SoulofMight, 3)
				.AddRecipeGroup("IronBar", 10)
				.AddIngredient(ItemID.Amber, 30)
				.AddIngredient(ItemID.Cobweb, 15)
				.AddIngredient(ItemID.Spike, 4)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceGreen>(), 1)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
        }
    }
}
