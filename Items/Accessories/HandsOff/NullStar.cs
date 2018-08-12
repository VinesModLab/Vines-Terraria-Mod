using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	[AutoloadEquip(EquipType.HandsOff)]
	public class NullStar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Power of Null");
			Tooltip.SetDefault("+9500 Health"+ "\n+1000 liferegen" + "\n400 MaxMana" +"\n It is not used to hurt people.");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 10;
			item.accessory = true;
			item.lifeRegen = 1000;
			item.defense = 10000;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statLifeMax2 += 9500;
			player.statManaMax2 += 500;
			player.moveSpeed *= 2f;
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