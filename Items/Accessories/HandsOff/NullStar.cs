using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class NullStar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Power of Null");
			Tooltip.SetDefault("It is not used to hurt people.");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 12;
			item.accessory = true;
			item.lifeRegen = 1000;
			item.defense = 10000;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 9500;
			player.statManaMax2 += 500;
			player.moveSpeed *= 2f;
			player.AddBuff(11, 10);
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

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "WeaponNull", 1);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}