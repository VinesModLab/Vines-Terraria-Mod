using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class EnchantedSabre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Sabre");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.EnchantedSword);
			item.damage = 42;      
			item.melee = true; 
			item.width = 40; 
			item.height = 40;           
			item.useTime = 20;         
			item.useAnimation = 20; 
			item.useStyle = ItemUseStyleID.SwingThrow;//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			item.knockBack = 3f;
			item.value = Item.sellPrice(gold: 15);           //The value of the weapon
			item.rare = ItemRarityID.Pink;
			item.shoot = ProjectileID.EnchantedBeam;
			item.shootSpeed *= 4f;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 2 + Main.rand.Next(6);
			float rotation = MathHelper.ToRadians(15);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EnchantedSword, 1);
			recipe.AddIngredient(mod, "BronzeSculptor", 1);
			recipe.AddIngredient(mod, "FieryWarblade", 1);
			recipe.AddIngredient(mod, "GrassDefender", 1);
			recipe.AddIngredient(mod, "LilacGuardian", 1);
			recipe.AddIngredient(mod, "SteelWarblade", 1);
			recipe.AddIngredient(mod, "ThunderBleu", 1);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 15 * 5);
			target.AddBuff(BuffID.Bleeding, 15 * 5);
			target.AddBuff(BuffID.Chilled, 15 * 5);
			target.AddBuff(BuffID.ShadowFlame, 15* 5);
			target.AddBuff(BuffID.Poisoned, 15* 5);
			target.AddBuff(BuffID.Venom, 15* 5);
			target.AddBuff(BuffID.Confused, 15* 5);
			target.AddBuff(BuffID.Ichor, 15* 5);
        }

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(9) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Sparkle"));
			}
		}
	}
}
