using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Ammo
{
	public class Wisp : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.damage = 1;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 14;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 1f;
			Item.value = Item.sellPrice(0, 0, 1, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.shoot = ModContent.ProjectileType<global::VinesMod.Projectiles.Wisp>();
			Item.ammo = Item.type; // The first item in an ammo class sets the AmmoID to it's type
		}

		public override void AddRecipes()
		{
			CreateRecipe(50)
				.AddIngredient(ItemID.Ectoplasm)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.AddCondition(new Condition("Requires Spectre Book", () => Main.LocalPlayer.HasItem(ModContent.ItemType<global::VinesMod.Items.Weapons.Gun.SpectreBook>())))
				// Restored from WispRecipe.ConsumeItem: 50% chance to not consume Ectoplasm
				.AddConsumeIngredientCallback((Recipe recipe, int type, ref int amount, bool isDecrafting) =>
				{
					if (!isDecrafting && type == ItemID.Ectoplasm && Main.rand.NextBool())
						amount = 0;
				})
				// Restored from WispRecipe.ConsumeItem: play Wooo sound when crafting
				.AddOnCraftCallback((item, recipe, consumedItems, destinationStack) =>
				{
					SoundEngine.PlaySound(new SoundStyle("VinesMod/Sounds/Item/Wooo"));
				})
				.Register();
		}
	}
}
