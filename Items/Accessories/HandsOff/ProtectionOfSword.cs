using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class ProtectionOfSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Protection Of Sword");
			Tooltip.SetDefault("Summon 5 swords to protect you.");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 300000;
			item.rare = 8;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.statLife <= (player.statLifeMax2 * 0.7f))
			{
				player.moveSpeed += 0.2f;
			}
		}

		public override void UpdateEquip(Player player)
		{
			player.AddBuff(mod.BuffType("FloatingSword"), 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "EnchantedSabre", 1);
			recipe.AddIngredient(mod, "ShardBlue", 70);
			recipe.AddIngredient(mod, "ShardYellow", 70);
			recipe.AddIngredient(mod, "ShardPurple", 70);
			recipe.AddIngredient(mod, "ShardGreen", 70);
			recipe.AddIngredient(mod, "ShardRed", 70);
			recipe.AddIngredient(mod, "ShardWhite", 70);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}