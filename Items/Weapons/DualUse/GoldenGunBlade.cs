using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.DualUse
{
	public class GoldenGunBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5f;
			Item.value = Item.sellPrice(gold: 2); 
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.GoldenBullet;
			Item.shootSpeed = 5f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.GoldBroadsword, 1)
				.AddIngredient(ItemID.GoldBow, 1)
				.AddRecipeGroup("IronBar", 5)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardYellow>(), 15)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), 15)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();

			Recipe.Create(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardYellow>(), 15)
				.AddIngredient(Type)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarRecycler>())
				.Register();
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useStyle = ItemUseStyleID.Thrust;
				Item.useTime = 20;
				Item.useAnimation = 20;
				Item.damage = 25;
				Item.shoot = ProjectileID.GoldenBullet;
			}
			else
			{
				Item.useStyle = ItemUseStyleID.Swing;
				Item.useTime = 40;
				Item.useAnimation = 40;
				Item.damage = 25;
				Item.shoot = ProjectileID.None;
			}
			return base.CanUseItem(player);
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (player.altFunctionUse == 2)
			{
				target.AddBuff(BuffID.Ichor, 60 * 5);
			}
			else
			{
				target.AddBuff(BuffID.OnFire, 60 * 5);
			}
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				if (player.altFunctionUse == 2)
				{
					int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.IchorTorch, 0f, 0f, 100, default(Color), 2f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity.X += player.direction * 2f;
					Main.dust[dust].velocity.Y += 0.2f;
				}
				else
				{
					int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
					Main.dust[dust].noGravity = true;
				}
			}
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			// Rotate velocity randomly for spread
			Vector2 speed = velocity.RotatedByRandom(MathHelper.ToRadians(30));
			// Change the damage since it is based off the weapons damage and is too high
			damage = (int)(damage * .8f);
			velocity = speed;
			return true;
		}
	}
}
