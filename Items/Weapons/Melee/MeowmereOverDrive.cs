using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class MeowmereOverDrive : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Meowmere OverDrive");
			Tooltip.SetDefault("Unslash the true power of Meowmere.");
		}

		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.Meowmere);
			item.damage = 500;
			item.value = Item.buyPrice(gold: 30); 
			item.rare = 11;
            item.shoot = 502;
            item.shootSpeed *= 1.05f;
			item.autoReuse = true;          //Whether the weapon can use automatically by pressing mousebutton
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Meowmere, 1);
			recipe.AddIngredient(mod, "OverDriveWhite", 1);
			recipe.AddIngredient(ItemID.LargeDiamond, 5);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 9; 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Sparkle"));
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Confused, 15* 60);
		}
	}
}