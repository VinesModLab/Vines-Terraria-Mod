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
		}

		public override void SetDefaults()
		{
			Item.damage = 560;          
			Item.DamageType = DamageClass.Melee;         
			Item.width = 40; 
			Item.height = 40;  
			Item.useTime = 10;          
			Item.useAnimation = 10; 
			Item.useStyle = ItemUseStyleID.Swing;  
			Item.knockBack = 3f;         
			Item.value = Item.buyPrice(gold: 30);         
			Item.rare = ItemRarityID.Purple;      
			Item.UseSound = SoundID.Item1; 
			Item.autoReuse = true;         
            Item.shoot = ProjectileID.BlackBolt;
			Item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.CrystalBlood>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.OverDrive.OverDrivePurple>(), 1)
				.AddIngredient(ItemID.LargeAmethyst, 5)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}

		public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			int numberProjectiles = 4 + Main.rand.Next(10); 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(30));
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<global::VinesMod.Dusts.SampleDust>());
			}
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.OnFire, 15* 60);
			target.AddBuff(BuffID.ShadowFlame, 15* 60);
		}
    }
}
