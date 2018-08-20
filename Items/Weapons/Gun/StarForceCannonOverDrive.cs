using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Gun
{
	public class StarForceCannonOverDrive : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("StarForce Cannon OverDrive");
			Tooltip.SetDefault("33% not consume ammo" + "\n Anger of stars");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.StarCannon);
			item.damage = 500;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 16f;
			item.value = Item.buyPrice(gold: 30);
			item.rare = 11;
			item.autoReuse = true;
			item.shootSpeed *= 1.5f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 9; 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(22));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .33f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "StarForceCannon", 1);
			recipe.AddIngredient(ItemID.IllegalGunParts, 15);
			recipe.AddIngredient(mod, "OverDriveYellow", 1);
			recipe.AddIngredient(mod, "OverDriveWhite", 1);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 15* 60);
			target.AddBuff(BuffID.ShadowFlame, 15* 60);
		}
	}
}
