using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class NullStar : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 10000;
			Item.rare = 13;
			Item.accessory = true;
			Item.lifeRegen = 1000;
			Item.defense = 10000;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 9500;
			player.statManaMax2 += 500;
			player.moveSpeed *= 2f;
			player.AddBuff(BuffID.Shine, 10);
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
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.WeaponNull>(), 5)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
