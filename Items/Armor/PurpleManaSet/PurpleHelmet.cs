using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.PurpleManaSet
{
	[AutoloadEquip(EquipType.Head)]
	public class PurpleHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("Purple Mana Helmet");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 1;
			item.defense = 8;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("PurpleBreastplate") && legs.type == mod.ItemType("PurpleLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.meleeDamage *= 1.1f;
			player.thrownDamage *= 1.1f;
			player.rangedDamage *= 1.1f;
			player.magicDamage *= 1.1f;
			player.minionDamage *= 1.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ManaCrystal, 3);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(mod, "ShardPurple", 10);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}