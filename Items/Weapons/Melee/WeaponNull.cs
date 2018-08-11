using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class WeaponNull : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Null");
			Tooltip.SetDefault("0");
		}
		public override void SetDefaults()
		{
			item.damage = 0;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 100;
			item.useAnimation = 100;
			item.useStyle = 1;
			item.knockBack = 1f;
			item.value = 3000000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType<Projectiles.NullProjectile>();
			item.shootSpeed = 60f; 
			item.scale = 0.75f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			damage += 10000;
			Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			for (int i = 0; i < 15; i++)
			{
				position = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
				position.Y -= (100 * i);
				Vector2 heading = target - position;
				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}
				if (heading.Y < 20f)
				{
					heading.Y = 20f;
				}
				heading.Normalize();
				heading *= new Vector2(speedX, speedY).Length();
				speedX = heading.X;
				speedY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage*damage* Main.rand.Next(1,11), knockBack, player.whoAmI, 0f, ceilingLimit);
			}
			return false;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 15 * 60);
			target.AddBuff(BuffID.Bleeding, 15 * 60);
			target.AddBuff(BuffID.Frozen, 15 * 60);
			target.AddBuff(BuffID.Chilled, 15 * 60);
			target.AddBuff(BuffID.ShadowFlame, 15* 60);
			target.AddBuff(BuffID.Poisoned, 15* 60);
			target.AddBuff(BuffID.Venom, 15* 60);
			target.AddBuff(BuffID.Confused, 15* 60);
			target.AddBuff(BuffID.Ichor, 15* 60);
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
	
			recipe.AddIngredient(mod, "ZeoxingBlade", 1);
			recipe.AddIngredient(mod, "OverDrivePurple", 999);
			recipe.AddIngredient(mod, "OverDriveRed", 999);
			recipe.AddIngredient(mod, "OverDriveBlue", 999);
			recipe.AddIngredient(mod, "OverDriveWhite", 999);
			recipe.AddIngredient(mod, "OverDriveGreen", 999);
			recipe.AddIngredient(mod, "OverDriveYellow", 999);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(15) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Sparkle"));
			}
		}
	}
}
