using VinesMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Throw
{
	public class DirtJavelin : ModItem
	{
		public override void SetDefaults()
		{
			item.shootSpeed = 10f;
			item.damage = 10;
			item.knockBack = 5f;
			item.useStyle = 1;
			item.useAnimation = 25;
			item.useTime = 25;
			item.width = 30;
			item.height = 30;
			item.maxStack = 999;
			item.rare = 0;

			item.consumable = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 5);
			item.shoot = mod.ProjectileType<DirtJavelinProjectile>();
		}
	}
}
