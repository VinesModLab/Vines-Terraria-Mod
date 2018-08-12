using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class Reboot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reboot");
		}

		public override void SetDefaults()
		{
			item.damage = 47;      
			item.melee = true; 
			item.width = 40; 
			item.height = 20;           
			item.useTime = 35;         
			item.useAnimation = 20; 
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = Item.sellPrice(gold: 3);
			item.rare = 4;
			item.scale = 1.5f;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileID.TerrarianBeam;
			item.shootSpeed = 10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddIngredient(ItemID.GoldBar, 15);
			recipe.AddIngredient(mod, "ShardGreen", 15);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = ProjectileID.TerrarianBeam;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
        }

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(15) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("SparkleGreen"));
			}
		}
	}
}
