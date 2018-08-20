using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace VinesMod.Items.Weapons.Magic
{
	public class LaserBook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser Book");
			Tooltip.SetDefault("Shoot a laser beam that can eliminate anything...");
		}

		public override void SetDefaults()
		{
			item.damage = 67;
			item.noMelee = true;
			item.magic = true;
			item.channel = true; //Channel so that you can held the weapon [Important]
			item.mana = 7;
			item.rare = 5;
			item.width = 28;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = 5;
			item.shootSpeed = 14f;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("LaserBeamBlue");
			item.value = Item.sellPrice(gold: 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpellTome, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 8);
			recipe.AddIngredient(ItemID.Lens, 5);
			recipe.AddIngredient(ItemID.CrystalShard, 3);
			recipe.AddIngredient(mod, "ShardBlue", 50);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
