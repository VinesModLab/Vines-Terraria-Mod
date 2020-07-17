using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class DeathStormOverDrive : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Death Storm OverDrive");
			Tooltip.SetDefault("unslash the true power of Death Storm.");
		}

		public override void SetDefaults()
		{
            item.CloneDefaults(ItemID.DeathSickle);
			item.damage = 500;
			item.value = Item.buyPrice(gold: 10); 
			item.rare = 11;
            item.shoot = ModContent.ProjectileType<Projectiles.ODDeathStormProjectile>();
            item.shootSpeed *= 1.5f;
			item.autoReuse = true;          //Whether the weapon can use automatically by pressing mousebutton
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "DeathStorm", 1);
			recipe.AddIngredient(mod, "OverDriveBlue", 1);
			recipe.AddIngredient(ItemID.LargeSapphire, 5);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 1 + Main.rand.Next(2); 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(50));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X * Main.rand.Next(1,3), perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
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
			target.AddBuff(BuffID.ShadowFlame, 15* 60);
		}
	}
}