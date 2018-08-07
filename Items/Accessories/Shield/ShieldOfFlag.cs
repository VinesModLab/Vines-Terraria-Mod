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
			DisplayName.SetDefault("Shield of Flag");
			Tooltip.SetDefault("A Shield used in army." + "\n small healthregen" +"\n slightly increase all stats");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
			item.defense = 3;
			item.lifeRegen = 3;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.meleeDamage *= 1.01f;
				player.thrownDamage *= 1.01f;
				player.rangedDamage *= 1.01f;
				player.magicDamage *= 1.01f;
				player.minionDamage *= 1.01f;
				//player.endurance = 1f - 0.1f * (1f - player.endurance);
				//player.GetModPlayer<ExamplePlayer>(mod).exampleShield = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.AddRecipeGroup("Wood", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}