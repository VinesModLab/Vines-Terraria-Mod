using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Systems
{
	public class ShardRecyclingRecipes : ModSystem
	{
		public override void AddRecipes()
		{
			int blueShard = ModContent.ItemType<Items.Materials.Shards.ShardBlue>();
			int greenShard = ModContent.ItemType<Items.Materials.Shards.ShardGreen>();
			int purpleShard = ModContent.ItemType<Items.Materials.Shards.ShardPurple>();
			int redShard = ModContent.ItemType<Items.Materials.Shards.ShardRed>();
			int whiteShard = ModContent.ItemType<Items.Materials.Shards.ShardWhite>();
			int yellowShard = ModContent.ItemType<Items.Materials.Shards.ShardYellow>();

			// Blue Eye boss vanilla drops.
			AddRecycle(ItemID.BlackLens, blueShard, 8);

			// Green Bee boss vanilla drops.
			AddRecycle(ItemID.HoneyedGoggles, greenShard, 18);
			AddRecycle(ItemID.Nectar, greenShard, 12);
			AddRecycle(ItemID.BeeKeeper, greenShard, 12);
			AddRecycle(ItemID.BeeGun, greenShard, 12);
			AddRecycle(ItemID.BeesKnees, greenShard, 12);

			// Purple Slime boss vanilla drops.
			AddRecycle(ItemID.Vilethorn, purpleShard, 12);
			AddRecycle(ItemID.BallOHurt, purpleShard, 12);
			AddRecycle(ItemID.BandofStarpower, purpleShard, 12);
			AddRecycle(ItemID.Solidifier, purpleShard, 8);
			AddRecycle(ItemID.SlimeStaff, purpleShard, 24);

			// Red Brain boss vanilla drops.
			AddRecycle(ItemID.PanicNecklace, redShard, 12);
			AddRecycle(ItemID.CrimsonRod, redShard, 12);
			AddRecycle(ItemID.TheRottedFork, redShard, 12);
			AddRecycle(ItemID.BoneRattle, redShard, 18);

			// White Flying Fish boss vanilla drops.
			AddRecycle(ItemID.StarCannon, whiteShard, 18);
			AddRecycle(ItemID.LargeDiamond, whiteShard, 10);
			AddRecycle(ItemID.LargeRuby, whiteShard, 6);
			AddRecycle(ItemID.LargeSapphire, whiteShard, 6);

			// Yellow Ichor boss vanilla drops.
			AddRecycle(ItemID.AmberMosquito, yellowShard, 18);

			// Shard Monsters Invasion ranged drops.
			AddRecycle(ModContent.ItemType<Items.Weapons.Bow.PrismRepeater>(), purpleShard, 18);
			AddRecycle(ModContent.ItemType<Items.Weapons.Gun.CometCarbine>(), yellowShard, 18);
			AddRecycle(ModContent.ItemType<Items.Weapons.Gun.VoidQuartzRifle>(), purpleShard, 16);
			AddRecycle(ModContent.ItemType<Items.Accessories.HandsOff.AstralScope>(), whiteShard, 18);
			AddRecycle(ModContent.ItemType<Items.Accessories.HandsOff.AstralScope>(), blueShard, 8);
		}

		private static void AddRecycle(int ingredientType, int shardType, int shardCount)
		{
			Recipe.Create(shardType, shardCount)
				.AddIngredient(ingredientType)
				.AddTile(ModContent.TileType<Tiles.StarRecycler>())
				.Register();
		}
	}
}
