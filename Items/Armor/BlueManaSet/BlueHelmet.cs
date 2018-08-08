using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Armor.BlueManaSet
{
	[AutoloadEquip(EquipType.Head)]
	public class BlueHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("Blue Mana Helmet");
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
			return body.type == mod.ItemType("BlueBreastplate") && legs.type == mod.ItemType("BlueLeggings");
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
			recipe.AddIngredient(mod, "ShardBlue", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ManaCrystal, 3);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(mod, "ShardBlue", 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}