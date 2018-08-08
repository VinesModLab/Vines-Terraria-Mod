using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using VinesMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class InfernoSpike : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inferno Spike");
			Tooltip.SetDefault("A Spike from Inferno");
		}

		public override void SetDefaults()
		{
			item.damage = 50;
			item.useStyle = 5;
			item.useAnimation = 18;
			item.useTime = 24;
			item.shootSpeed = 3.7f;
			item.knockBack = 6.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = 3;
			item.value = 10000;

			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType<InfernoSpikeProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1; 
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 15 * 60);
			target.AddBuff(BuffID.Bleeding, 15 * 60);
			target.AddBuff(BuffID.ShadowFlame, 15* 60);
			target.AddBuff(BuffID.Venom, 15* 60);
			target.AddBuff(BuffID.Confused, 15* 60);
			target.AddBuff(BuffID.Ichor, 15* 60);
        }

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 40);
			recipe.AddIngredient(ItemID.Obsidian, 40);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 40);
			recipe.AddIngredient(ItemID.Obsidian, 40);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}
