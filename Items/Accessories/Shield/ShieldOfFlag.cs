using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.Shield
{
	[AutoloadEquip(EquipType.Shield)]
	public class ShieldOfFlag : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 10000;
			Item.rare = 2;
			Item.accessory = true;
			Item.defense = 3;
			Item.lifeRegen = 3;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.GetDamage(DamageClass.Melee) *= 1.05f;
				player.GetDamage(DamageClass.Ranged) *= 1.05f;
				player.GetDamage(DamageClass.Magic) *= 1.05f;
				player.GetDamage(DamageClass.Summon) *= 1.05f;
				player.dash = 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("IronBar", 8)
				.AddIngredient(ItemID.LifeCrystal, 2)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardYellow>(), 25)
				.AddRecipeGroup("Wood", 15)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}