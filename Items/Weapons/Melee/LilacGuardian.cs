using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class LilacGuardian : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.damage = 17;      
			Item.DamageType = DamageClass.Melee; 
			Item.width = 40; 
			Item.height = 40;           
			Item.useTime = 20;         
			Item.useAnimation = 20; 
			Item.useStyle = ItemUseStyleID.Swing;//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			Item.knockBack = 5;
			Item.value = Item.sellPrice(copper: 30);           //The value of the weapon
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.BladeArtProjectile>();
			Item.shootSpeed = 6.5f;
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			Vector2 left = velocity.RotatedBy(MathHelper.ToRadians(-8f));
			Vector2 right = velocity.RotatedBy(MathHelper.ToRadians(8f));
			Projectile.NewProjectile(source, position, left, type, (int)(damage * 0.45f), knockBack, player.whoAmI, 4f);
			Projectile.NewProjectile(source, position, right, type, (int)(damage * 0.45f), knockBack, player.whoAmI, 4f);
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("IronBar", 5)
				.AddIngredient(ItemID.GoldBar, 2)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), 5)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
				
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
			if (Main.rand.Next(5) == 0)
			{
				target.AddBuff(BuffID.Venom, 60 * 5);
			}
        }

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(15) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<global::VinesMod.Dusts.Sparkle>());
			}
		}
	}
}
