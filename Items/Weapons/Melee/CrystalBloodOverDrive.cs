using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class CrystalBloodOverDrive : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Crystal Blood OverDrive");
			Tooltip.SetDefault("unslash the true power of Crystal Blood.");
		}

		public override void SetDefaults()
		{
			item.damage = 560;          
			item.melee = true;         
			item.width = 40; 
			item.height = 40;  
			item.useTime = 10;          
			item.useAnimation = 10; 
			item.useStyle = 1;  
			item.knockBack = 4;         
			item.value = Item.buyPrice(gold: 30);         
			item.rare = 11;      
			item.UseSound = SoundID.Item1; 
			item.autoReuse = true;         
            item.shoot = 661;
			item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "CrystalBlood", 1);
			recipe.AddIngredient(mod, "OverDrivePurple", 1);
			recipe.AddIngredient(ItemID.LargeAmethyst, 5);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 4 + Main.rand.Next(10); 
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
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("SampleDust"));
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 15* 60);
			target.AddBuff(BuffID.ShadowFlame, 15* 60);
		}
    }
}