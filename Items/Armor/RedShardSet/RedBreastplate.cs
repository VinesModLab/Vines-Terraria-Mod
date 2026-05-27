using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.RedShardSet
{
	[AutoloadEquip(EquipType.Body)]
	public class RedBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			ArmorIDs.Body.Sets.HidesTopSkin[Item.bodySlot] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.defense = 11;
		}

		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.OnFire] = true;
			player.GetDamage(DamageClass.Melee) *= 1.08f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("IronBar", 15)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), 15)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}