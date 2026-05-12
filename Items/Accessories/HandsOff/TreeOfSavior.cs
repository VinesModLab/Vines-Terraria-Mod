using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class TreeOfSavior : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = Item.sellPrice(gold: 2); Item.value = 10000;
			Item.rare = 8;
			Item.lifeRegen = 15;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.statLifeMax2 += 100;
				player.statManaMax2 += 100;
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
				player.AddBuff(11, 10);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.MaliHeart>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.StarForce.StarForceGreen>(), 1)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.PreciousJewel>(), 1)
				.AddIngredient(ItemID.LifeCrystal, 5)
				.AddIngredient(ItemID.ManaCrystal, 5)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}