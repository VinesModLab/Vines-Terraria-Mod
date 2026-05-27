using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class ProtectionOfSword : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 300000;
			Item.rare = ItemRarityID.Yellow;
			Item.accessory = true;
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
			player.AddBuff(ModContent.BuffType<global::VinesMod.Buffs.FloatingSword>(), 2);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.EnchantedSabre>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), 70)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardYellow>(), 70)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), 70)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardGreen>(), 70)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), 70)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), 70)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
