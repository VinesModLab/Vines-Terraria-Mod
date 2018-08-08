using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class CrystalBlood : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Crystal Blood");
			Tooltip.SetDefault("Made of many crystals and blood");
		}

		public override void SetDefaults()
		{
			item.damage = 80;          
			item.melee = true;         
			item.width = 40; 
			item.height = 40;  
			item.useTime = 20;          
			item.useAnimation = 20; 
			item.useStyle = 1;  
			item.knockBack = 6;         
			item.value = Item.buyPrice(silver: 30);         
			item.rare = 4;      
			item.UseSound = SoundID.Item1; 
			item.autoReuse = true;         
            item.shoot = 661;
			item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LifeCrystal, 5);
			recipe.AddIngredient(ItemID.ManaCrystal, 7);
			recipe.AddIngredient(ItemID.CrystalShard, 30);
			recipe.AddIngredient(mod, "StarForcePurple", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LifeCrystal, 5);
			recipe.AddIngredient(ItemID.ManaCrystal, 7);
			recipe.AddIngredient(ItemID.CrystalShard, 30);
			recipe.AddIngredient(mod, "StarForcePurple", 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("SampleDust"));
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			target.AddBuff(BuffID.Bleeding, 15 * 60);
			target.AddBuff(BuffID.ShadowFlame, 15* 60);
			target.AddBuff(BuffID.Confused, 15* 60);
			target.AddBuff(BuffID.Ichor, 15* 60);
        }
    }
}