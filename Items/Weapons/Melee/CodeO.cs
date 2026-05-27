using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class CodeO : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.damage = 26;      
			Item.DamageType = DamageClass.Melee; 
			Item.width = 40; 
			Item.height = 40;
			Item.scale = 2f;     
			Item.useTime = 30;         
			Item.useAnimation = 30; 
			Item.useStyle = ItemUseStyleID.Swing;//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(silver: 30);           //The value of the weapon
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.ShurikenProjectile>();
            Item.shootSpeed = 10f;
		}

		public override void AddRecipes()
		{
			Recipe.Create(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), 15)
				.AddIngredient(Type)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarRecycler>())
				.Register();
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(BuffID.Chilled, 60 * 5);
        }

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(15) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<global::VinesMod.Dusts.SparkleBlue>());
			}
		}
	}
}
