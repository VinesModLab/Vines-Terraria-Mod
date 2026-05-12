using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class DarkerAcc : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 300000;
			Item.rare = ItemRarityID.Red;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.GetAttackSpeed(DamageClass.Melee) *= 1.2f;
				player.GetDamage(DamageClass.Melee) *= 2f;
				player.GetDamage(DamageClass.Ranged) *= 2f;
				player.GetDamage(DamageClass.Magic) *= 2f;
				player.GetDamage(DamageClass.Summon) *= 2f;
				player.moveSpeed += 0.3f;
				player.GetCritChance(DamageClass.Ranged) += 5;
				player.GetCritChance(DamageClass.Melee) += 5;
				player.GetCritChance(DamageClass.Magic) += 5;
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