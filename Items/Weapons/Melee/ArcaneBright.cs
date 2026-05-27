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
	public class ArcaneBright : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
            Item.CloneDefaults(ItemID.TerraBlade);
			Item.damage = 660;           
			Item.DamageType = DamageClass.Melee;          
			Item.width = 40;            
			Item.height = 40;           
			Item.useTime = 20;          
			Item.useAnimation = 20;         //The time span of the using animation of the weapon, suggest set it the same as useTime.
			Item.useStyle = ItemUseStyleID.Swing;          //The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			Item.knockBack = 3f;         //The force of knockback of the weapon. Maximum is 20
			Item.value = Item.buyPrice(gold: 30);          
			Item.rare = ItemRarityID.Purple;              
			Item.UseSound = SoundID.Item1;    
			Item.autoReuse = true;       
			Item.noUseGraphic = false;
			Item.noMelee = false;
            Item.scale = 1.3f; 
            Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.ArcaneBrightProjectile>();
            Item.shootSpeed = 20f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SoulofLight, 30)
				.AddIngredient(ItemID.SoulofSight, 30)
				.AddIngredient(ItemID.SoulofFlight, 30)
				.AddIngredient(ItemID.FallenStar, 30)
				.AddIngredient(ItemID.LunarBar, 30)
				.AddIngredient(ItemID.LifeCrystal, 10)
				.AddIngredient(ItemID.ManaCrystal, 10)
				.AddIngredient(ItemID.DarkShard, 5)
				.AddIngredient(ItemID.LightShard, 5)
				.AddIngredient(ItemID.TrueExcalibur, 1)
				.AddIngredient(ItemID.TerraBlade, 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDriveGreen>(), 1)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}

         public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
        {
            int numberProjectiles = 2;
            float rotation = MathHelper.ToRadians(20);

            for (int i = 0; i < numberProjectiles + 1; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }

            int numProjectiles2 = 4;
            float spread = MathHelper.ToRadians(10);
            float baseSpeed = velocity.Length();
            double startAngle = Math.Atan2(velocity.X, velocity.Y) - spread / 2;
            double deltaAngle = spread / (float)numProjectiles2;
            double offsetAngle;

            for (int j = 0; j < numProjectiles2; j++)
            {
                offsetAngle = startAngle + deltaAngle * j;
                Projectile.NewProjectile(source, position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage, knockBack, player.whoAmI);
            }

            return false;
        }


		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				//Emit dusts when swing the sword
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<global::VinesMod.Dusts.SparkleGreen>());
			}
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(BuffID.Chilled, 15 * 60);
			target.AddBuff(BuffID.Venom, 15* 60);
			target.AddBuff(BuffID.Confused, 15* 60);
			target.AddBuff(BuffID.Ichor, 15* 60);
        }
	}
}
