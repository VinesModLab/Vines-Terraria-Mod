using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class FrostPain : ModItem
	{
		public override void SetStaticDefaults()
		{
		}
		public override void SetDefaults()
		{
			Item.damage = 640;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3f;
			Item.value = Item.buyPrice(gold: 30);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.scale = 1.2f;
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.FrostBeam>();
			Item.shootSpeed = 60f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.IceMirror, 5)
				.AddIngredient(ItemID.IceBlade, 1)
				.AddIngredient(ItemID.IceBow, 1)
				.AddIngredient(ItemID.IceSickle, 1)
				.AddIngredient(ItemID.IceFeather, 1)
				.AddIngredient(ItemID.IceBrick, 1000)
				.AddIngredient(ItemID.SoulofMight, 100)
				.AddIngredient(ItemID.SoulofFright, 100)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveBlue>(), 1)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(BuffID.Bleeding, 15 * 60);
			target.AddBuff(BuffID.Frozen, 15 * 60);
			target.AddBuff(BuffID.Chilled, 15 * 60);
			target.AddBuff(BuffID.Confused, 15* 60);
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

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<global::VinesMod.Dusts.SparkleBlue>());
			}
		}
	}
}
