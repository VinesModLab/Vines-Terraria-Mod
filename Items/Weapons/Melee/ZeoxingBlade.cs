using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class ZeoxingBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
		}
		public override void SetDefaults()
		{
			Item.damage = 1500;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 1f;
			Item.value = 3000000;
			Item.rare = ItemRarityID.Expert;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.ZeoxingProjectile>();
			Item.shootSpeed = 60f; 
			Item.scale = 0.75f;
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			float numberProjectiles = 7;
			float rotation = MathHelper.ToRadians(45);
			position += Vector2.Normalize(velocity) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage*5, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
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
			CreateRecipe()
				.AddIngredient(ItemID.FallenStar, 999)
				.AddIngredient(ItemID.LunarBar, 90)
				.AddIngredient(ItemID.Cloud, 999)
				.AddIngredient(ItemID.RainCloud, 100)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.EndTier.DarkMatter>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.EndTier.LightMatter>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Gun.StarForceCannonOverDrive>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.StarWrathOverDrive>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDrivePurple>(), 5)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveRed>(), 5)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveBlue>(), 5)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveWhite>(), 5)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveGreen>(), 5)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveYellow>(), 5)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<global::VinesMod.Dusts.SparkleYellow>());
			}
		}
	}
}
