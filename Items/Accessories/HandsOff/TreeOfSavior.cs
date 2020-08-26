using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class TreeOfSavior : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tree Of Savior");
			Tooltip.SetDefault("immune to most debuffs" + "\n +100 Life and Mana" + "\n +15 Life regen");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = Item.sellPrice(gold: 2); item.value = 10000;
			item.rare = 8;
			item.lifeRegen = 15;
			item.accessory = true;
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
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "MaliHeart", 1);
			recipe.AddIngredient(mod, "StarForceGreen", 1);
			recipe.AddIngredient(mod, "PreciousJewel", 1);
			recipe.AddIngredient(ItemID.LifeCrystal, 5);
			recipe.AddIngredient(ItemID.ManaCrystal, 5);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}