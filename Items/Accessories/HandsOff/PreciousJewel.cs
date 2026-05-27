using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class PreciousJewel : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = Item.sellPrice(gold: 2); 
			Item.rare = ItemRarityID.LightPurple;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.statMana < 100)
			{
				player.buffImmune[BuffID.Frozen] = true;
				player.buffImmune[BuffID.Chilled] = true;
				player.buffImmune[BuffID.Frostburn] = true;
				player.buffImmune[BuffID.Poisoned] = true;
				player.buffImmune[BuffID.Darkness] = true;
				player.buffImmune[BuffID.OnFire] = true;
				player.buffImmune[BuffID.Cursed] = true;
				player.buffImmune[BuffID.Bleeding] = true;
				player.buffImmune[BuffID.Confused] = true;
				player.buffImmune[BuffID.Slow] = true;
				player.buffImmune[BuffID.Weak] = true;
				player.buffImmune[BuffID.Silenced] = true;
				player.buffImmune[BuffID.BrokenArmor] = true;
				player.buffImmune[BuffID.Ichor] = true;
				player.buffImmune[BuffID.Venom] = true;
				player.buffImmune[BuffID.Weak] = true;
				player.buffImmune[BuffID.Blackout] = true;
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.BloodStone>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.IcySteel>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), 20)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), 40)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), 40)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
