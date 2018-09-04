using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.NullSet
{
	[AutoloadEquip(EquipType.Head)]
	public class NullHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Null (Helmet)");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = -12;
			item.defense = 10000;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("NullBreastplate") && legs.type == mod.ItemType("NullLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.meleeDamage *= 5f;
			player.thrownDamage *= 5f;
			player.rangedDamage *= 5f;
			player.magicDamage *= 5f;
			player.minionDamage *= 5f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "NullStar", 1);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}