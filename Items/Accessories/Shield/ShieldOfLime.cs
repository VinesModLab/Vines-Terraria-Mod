using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.Shield
{
	[AutoloadEquip(EquipType.Shield)]
	public class ShieldOfLime : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 10000;
			Item.rare = 4;
			Item.accessory = true;
			Item.defense = 8;
			Item.lifeRegen = 10;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.statLife >= (player.statLifeMax2 * 0.5f))
			{
				player.GetAttackSpeed(DamageClass.Melee) *= 1.2f;
				player.GetDamage(DamageClass.Melee) *= 1.15f;
				player.GetDamage(DamageClass.Ranged) *= 1.15f;
				player.GetDamage(DamageClass.Magic) *= 1.15f;
				player.GetDamage(DamageClass.Summon) *= 1.15f;
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("IronBar", 10)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardGreen>(), 25)
				.AddRecipeGroup("Wood", 15)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}