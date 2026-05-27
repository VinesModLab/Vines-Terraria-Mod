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
		}

		public override void SetDefaults()
		{
			Item.damage = 80;          
			Item.DamageType = DamageClass.Melee;         
			Item.width = 40; 
			Item.height = 40;  
			Item.useTime = 20;          
			Item.useAnimation = 20; 
			Item.useStyle = ItemUseStyleID.Swing;  
			Item.knockBack = 3f;         
			Item.value = Item.buyPrice(silver: 30);         
			Item.rare = ItemRarityID.Yellow;      
			Item.UseSound = SoundID.Item1; 
			Item.autoReuse = true;         
            Item.shoot = ProjectileID.BlackBolt;
			Item.shootSpeed = 8f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.LifeCrystal, 5)
				.AddIngredient(ItemID.ManaCrystal, 7)
				.AddIngredient(ItemID.CrystalShard, 400)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForcePurple>(), 1)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
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
			target.AddBuff(BuffID.Bleeding, 15 * 60);
			target.AddBuff(BuffID.ShadowFlame, 15* 60);
			target.AddBuff(BuffID.Confused, 15* 60);
			target.AddBuff(BuffID.Ichor, 15* 60);
        }
    }
}
