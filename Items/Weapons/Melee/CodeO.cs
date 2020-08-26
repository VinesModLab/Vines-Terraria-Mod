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
			DisplayName.SetDefault("Code : O");
		}

		public override void SetDefaults()
		{
			item.damage = 26;      
			item.melee = true; 
			item.width = 40; 
			item.height = 40;
			item.scale = 2f;     
			item.useTime = 30;         
			item.useAnimation = 30; 
			item.useStyle = 1;//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			item.knockBack = 3f;
			item.value = Item.sellPrice(silver: 30);           //The value of the weapon
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Projectiles.ShurikenProjectile>();
            item.shootSpeed = 10f;
		}

		public override void AddRecipes()
		{
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			target.AddBuff(BuffID.Chilled, 60 * 5);
        }

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(15) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("SparkleBlue"));
			}
		}
	}
}
