using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class MaliHeart : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 10000;
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.statLifeMax2 += 40;
				player.statManaMax2 += 40;
				player.buffImmune[BuffID.Frozen] = true;
				player.buffImmune[BuffID.Chilled] = true;
				player.buffImmune[BuffID.OnFire] = true;
				player.buffImmune[BuffID.Poisoned] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), 40)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), 40)
				.AddIngredient(ItemID.LifeCrystal, 2)
				.AddIngredient(ItemID.ManaCrystal, 2)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.IcySteel>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.BloodStone>(), 1)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
