using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class GoldenEye : ModItem
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
			Item.value = Item.sellPrice(gold: 2); 
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.GetDamage(DamageClass.Melee) *= 1.2f;
				player.GetDamage(DamageClass.Ranged) *= 1.2f;
				player.GetDamage(DamageClass.Magic) *= 1.2f;
				player.GetDamage(DamageClass.Summon) *= 1.2f;
				player.AddBuff(11, 10);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.BlueEyeBall>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.RedEyeBall>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.Robot3000>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardYellow>(), 40)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}