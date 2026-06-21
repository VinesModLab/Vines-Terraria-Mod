using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace VinesMod.Systems
{
	public class PrismAeriePlayer : ModPlayer
	{
		public bool ZonePrismAerie;
		private int scanTimer;

		public override void PostUpdateMiscEffects()
		{
			if (++scanTimer < 30)
			{
				return;
			}
			scanTimer = 0;

			ZonePrismAerie = Player.ZoneSkyHeight && CountNearbyPrismTiles() >= 40;
		}

		private int CountNearbyPrismTiles()
		{
			int centerX = (int)(Player.Center.X / 16f);
			int centerY = (int)(Player.Center.Y / 16f);
			int count = 0;
			int prismstone = ModContent.TileType<Tiles.PrismstoneBlock>();
			int grass = ModContent.TileType<Tiles.PrismGrass>();
			int ore = ModContent.TileType<Tiles.FracturedPrismOre>();
			int altar = ModContent.TileType<Tiles.PrismAltar>();

			for (int x = centerX - 45; x <= centerX + 45; x++)
			{
				if (x < 10 || x >= Main.maxTilesX - 10)
				{
					continue;
				}

				for (int y = centerY - 30; y <= centerY + 30; y++)
				{
					if (y < 10 || y >= Main.maxTilesY - 10)
					{
						continue;
					}

					Tile tile = Main.tile[x, y];
					if (!tile.HasTile)
					{
						continue;
					}

					if (tile.TileType == prismstone || tile.TileType == grass || tile.TileType == ore || tile.TileType == altar)
					{
						count++;
					}
				}
			}

			return count;
		}
	}

	public class PrismAerieSpawns : GlobalNPC
	{
		public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
		{
			if (ShardInvasionSystem.Active || !spawnInfo.Player.GetModPlayer<PrismAeriePlayer>().ZonePrismAerie)
			{
				return;
			}

			pool.Clear();
			pool[ModContent.NPCType<NPCs.Hostile.ShardsMonster.CosmicWisp>()] = Main.dayTime ? 0.45f : 0.55f;
			pool[ModContent.NPCType<NPCs.Hostile.ShardsMonster.PrismaticShardling>()] = 0.35f;
			pool[ModContent.NPCType<NPCs.Hostile.ShardsMonster.FallenStarMite>()] = Main.dayTime ? 0.08f : 0.28f;
			pool[ModContent.NPCType<NPCs.Hostile.ShardsMonster.AmethystMirror>()] = Main.dayTime ? 0.07f : 0.16f;
			pool[ModContent.NPCType<NPCs.Hostile.ShardsMonster.WhitePrismSentinel>()] = Main.hardMode ? 0.12f : 0.04f;
		}

		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			if (ShardInvasionSystem.Active || !player.GetModPlayer<PrismAeriePlayer>().ZonePrismAerie)
			{
				return;
			}

			spawnRate = (int)(spawnRate * 0.72f);
			maxSpawns += 1;
		}
	}

	public class PrismAerieWorldGen : ModSystem
	{
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
		{
			int skyLakesIndex = tasks.FindIndex(pass => pass.Name == "Floating Islands");
			if (skyLakesIndex == -1)
			{
				return;
			}

			tasks.Insert(skyLakesIndex + 1, new PassLegacy("Prism Aerie", GeneratePrismAerie));
		}

		private static void GeneratePrismAerie(GenerationProgress progress, GameConfiguration configuration)
		{
			progress.Message = "Refracting a Prism Aerie";

			if (!TryFindAerieSite(out int centerX, out int centerY))
			{
				return;
			}

			PlaceIsland(centerX, centerY, 34, 13, mainIsland: true);
			PlaceIsland(centerX - WorldGen.genRand.Next(42, 58), centerY + WorldGen.genRand.Next(-8, 8), 12, 6, mainIsland: false);
			PlaceIsland(centerX + WorldGen.genRand.Next(44, 62), centerY + WorldGen.genRand.Next(-6, 10), 14, 7, mainIsland: false);
			PlaceShrine(centerX, centerY - 10);
			PlaceAerieChest(centerX + 10, centerY - 14);
		}

		private static bool TryFindAerieSite(out int centerX, out int centerY)
		{
			int minX = (int)(Main.maxTilesX * 0.18f);
			int maxX = (int)(Main.maxTilesX * 0.82f);
			int minY = 90;
			int maxY = Math.Max(minY + 20, Math.Min((int)Main.worldSurface - 120, 240));

			for (int attempt = 0; attempt < 220; attempt++)
			{
				int x = WorldGen.genRand.Next(minX, maxX);
				int y = WorldGen.genRand.Next(minY, maxY);

				if (IsAerieSiteClear(x, y))
				{
					centerX = x;
					centerY = y;
					return true;
				}
			}

			centerX = 0;
			centerY = 0;
			return false;
		}

		private static bool IsAerieSiteClear(int centerX, int centerY)
		{
			int solidTiles = 0;
			int protectedTiles = 0;
			int chestTiles = 0;

			for (int x = centerX - 95; x <= centerX + 95; x++)
			{
				if (x < 20 || x >= Main.maxTilesX - 20)
				{
					return false;
				}

				for (int y = centerY - 42; y <= centerY + 34; y++)
				{
					if (y < 20 || y >= Main.maxTilesY - 20)
					{
						return false;
					}

					Tile tile = Main.tile[x, y];
					if (!tile.HasTile)
					{
						continue;
					}

					if (tile.TileType == TileID.Containers || tile.TileType == TileID.Containers2 || tile.TileType == TileID.Dressers)
					{
						chestTiles++;
					}

					if (Main.tileFrameImportant[tile.TileType])
					{
						protectedTiles++;
					}

					if (Main.tileSolid[tile.TileType] && tile.TileType != TileID.Cloud && tile.TileType != TileID.RainCloud)
					{
						solidTiles++;
					}
				}
			}

			return chestTiles == 0 && protectedTiles < 8 && solidTiles < 30;
		}

		private static void PlaceIsland(int centerX, int centerY, int radiusX, int radiusY, bool mainIsland)
		{
			ushort prismstone = (ushort)ModContent.TileType<Tiles.PrismstoneBlock>();
			ushort grass = (ushort)ModContent.TileType<Tiles.PrismGrass>();
			ushort ore = (ushort)ModContent.TileType<Tiles.FracturedPrismOre>();
			ushort crystal = (ushort)ModContent.TileType<Tiles.HangingPrismCrystal>();

			for (int x = centerX - radiusX; x <= centerX + radiusX; x++)
			{
				for (int y = centerY - radiusY; y <= centerY + radiusY + 8; y++)
				{
					float nx = (x - centerX) / (float)radiusX;
					float ny = (y - centerY) / (float)radiusY;
					float shape = nx * nx + ny * ny;
					if (shape > 1f + WorldGen.genRand.NextFloat(-0.08f, 0.13f))
					{
						continue;
					}

					WorldGen.KillTile(x, y, noItem: true);
					WorldGen.PlaceTile(x, y, WorldGen.genRand.NextBool(mainIsland ? 18 : 26) ? ore : prismstone, mute: true, forced: true);
				}
			}

			for (int x = centerX - radiusX + 2; x <= centerX + radiusX - 2; x++)
			{
				int topY = FindTopSolid(x, centerY - radiusY - 6, centerY + radiusY);
				if (topY <= 0)
				{
					continue;
				}

				WorldGen.KillTile(x, topY, noItem: true);
				WorldGen.PlaceTile(x, topY, grass, mute: true, forced: true);

				for (int y = topY - 4; y < topY; y++)
				{
					WorldGen.KillTile(x, y, noItem: true);
				}

				if (WorldGen.genRand.NextBool(18))
				{
					WorldGen.PlaceTile(x, topY - 1, TileID.Sunflower, mute: true);
				}
				else if (WorldGen.genRand.NextBool(5))
				{
					WorldGen.PlaceTile(x, topY - 1, TileID.Plants, mute: true);
				}

				int underside = FindBottomSolid(x, centerY, centerY + radiusY + 10);
				if (underside > 0 && WorldGen.genRand.NextBool(mainIsland ? 5 : 8))
				{
					WorldGen.PlaceObject(x, underside + 1, crystal, mute: true);
				}
			}
		}

		private static void PlaceShrine(int centerX, int y)
		{
			ushort platform = (ushort)ModContent.TileType<Tiles.CloudglassPlatform>();
			for (int x = centerX - 8; x <= centerX + 8; x++)
			{
				WorldGen.KillTile(x, y, noItem: true);
				WorldGen.PlaceTile(x, y, platform, mute: true, forced: true);
			}

			WorldGen.PlaceObject(centerX, y - 2, ModContent.TileType<Tiles.PrismAltar>(), mute: true);
			WorldGen.PlaceTile(centerX - 6, y - 1, TileID.Torches, mute: true, style: 8);
			WorldGen.PlaceTile(centerX + 6, y - 1, TileID.Torches, mute: true, style: 8);
		}

		private static void PlaceAerieChest(int x, int y)
		{
			for (int i = x - 2; i <= x + 3; i++)
			{
				for (int j = y - 3; j <= y + 1; j++)
				{
					WorldGen.KillTile(i, j, noItem: true);
				}
			}

			int chestIndex = WorldGen.PlaceChest(x, y, TileID.Containers, notNearOtherChests: false, style: 13);
			if (chestIndex < 0)
			{
				return;
			}

			Chest chest = Main.chest[chestIndex];
			AddChestItem(chest, ModContent.ItemType<Items.Materials.PrismAerieKey>(), 1, 0);
			AddChestItem(chest, ModContent.ItemType<Items.Weapons.Bow.SkyPrismBow>(), 1, 1);
			AddChestItem(chest, ModContent.ItemType<Items.Accessories.HandsOff.PrismGlider>(), 1, 2);
			AddChestItem(chest, ModContent.ItemType<Items.Accessories.HandsOff.AerieLens>(), 1, 3);
			AddChestItem(chest, ModContent.ItemType<Items.Tools.CloudglassHook>(), 1, 4);
			AddChestItem(chest, ModContent.ItemType<Items.Placeable.FracturedPrismOre>(), WorldGen.genRand.Next(12, 22), 5);
			AddChestItem(chest, ModContent.ItemType<Items.Materials.PrismSeeds>(), WorldGen.genRand.Next(4, 9), 6);
			AddChestItem(chest, ItemID.FallenStar, WorldGen.genRand.Next(3, 8), 7);
		}

		private static void AddChestItem(Chest chest, int type, int stack, int slot)
		{
			chest.item[slot].SetDefaults(type);
			chest.item[slot].stack = stack;
		}

		private static int FindTopSolid(int x, int startY, int endY)
		{
			for (int y = Math.Max(10, startY); y <= Math.Min(Main.maxTilesY - 10, endY); y++)
			{
				if (Main.tile[x, y].HasTile && Main.tileSolid[Main.tile[x, y].TileType])
				{
					return y;
				}
			}

			return -1;
		}

		private static int FindBottomSolid(int x, int startY, int endY)
		{
			for (int y = Math.Min(Main.maxTilesY - 10, endY); y >= Math.Max(10, startY); y--)
			{
				if (Main.tile[x, y].HasTile && Main.tileSolid[Main.tile[x, y].TileType])
				{
					return y;
				}
			}

			return -1;
		}
	}
}
