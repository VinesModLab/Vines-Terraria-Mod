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
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.EnchantedSword);
			Item.damage = 42;      
			Item.DamageType = DamageClass.Melee; 
			Item.width = 40; 
			Item.height = 40;           
			Item.useTime = 20;         
			Item.useAnimation = 20; 
			Item.useStyle = ItemUseStyleID.Swing;//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(gold: 15);           //The value of the weapon
			Item.rare = ItemRarityID.Pink;
			Item.shoot = ProjectileID.EnchantedBeam;
			Item.shootSpeed *= 4f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			float numberProjectiles = 2 + Main.rand.Next(6);
			float rotation = MathHelper.ToRadians(15);
			position += Vector2.Normalize(velocity) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.EnchantedSword, 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.BronzeSculptor>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.FieryWarblade>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.GrassDefender>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.LilacGuardian>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.SteelWarblade>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.ThunderBleu>(), 1)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
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
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<global::VinesMod.Dusts.Sparkle>());
			}
		}
	}
}
