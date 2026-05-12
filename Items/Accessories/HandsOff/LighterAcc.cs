using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class LighterAcc : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 300000;
			Item.rare = 10;
			Item.accessory = true;
			Item.lifeRegen = 20;
			Item.defense = 15;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 200;
			player.statManaMax2 += 100;
			player.maxMinions += 4;
			player.moveSpeed += +0.4f;
			player.AddBuff(11, 10);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.EndTier.LightMatter>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.EndTier.DarkMatter>(), 1)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}