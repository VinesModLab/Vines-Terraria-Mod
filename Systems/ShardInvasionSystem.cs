using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace VinesMod.Systems
{
	public class ShardInvasionSystem : ModSystem
	{
		public const int RequiredKills = 100;
		private const int NoSpawnEndDelay = 60 * 10;

		public static bool Active;
		public static int Defeated;
		private static int noSpawnTicks;

		public static int Remaining => Utils.Clamp(RequiredKills - Defeated, 0, RequiredKills);

		public override void OnWorldLoad()
		{
			Active = false;
			Defeated = 0;
			noSpawnTicks = 0;
		}

		public override void SaveWorldData(TagCompound tag)
		{
			if (Active)
			{
				tag["ShardInvasionActive"] = true;
				tag["ShardInvasionDefeated"] = Defeated;
			}
		}

		public override void LoadWorldData(TagCompound tag)
		{
			Active = tag.ContainsKey("ShardInvasionActive");
			Defeated = Active ? tag.GetInt("ShardInvasionDefeated") : 0;
		}

		public override void NetSend(System.IO.BinaryWriter writer)
		{
			writer.Write(Active);
			writer.Write(Defeated);
			writer.Write(noSpawnTicks);
		}

		public override void NetReceive(System.IO.BinaryReader reader)
		{
			bool wasActive = Active;
			Active = reader.ReadBoolean();
			Defeated = reader.ReadInt32();
			noSpawnTicks = reader.ReadInt32();

			if (wasActive && !Active)
			{
				ClearProgress();
			}
		}

		public override void PostUpdateInvasions()
		{
			if (Active)
			{
				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					if (Defeated >= RequiredKills)
					{
						End(success: true);
						return;
					}

					if (!HasValidInvasionPlayer())
					{
						noSpawnTicks++;
						if (noSpawnTicks >= NoSpawnEndDelay)
						{
							End(success: false);
							return;
						}
					}
					else
					{
						noSpawnTicks = 0;
					}
				}

				ReportProgress();
			}
		}

		public static bool CanStart(Player player)
		{
			return !Active && player.active && !player.dead && player.ZoneOverworldHeight;
		}

		public static bool Start(Player player)
		{
			if (Main.netMode == NetmodeID.MultiplayerClient)
			{
				return false;
			}

			if (!CanStart(player))
			{
				return false;
			}

			Active = true;
			Defeated = 0;
			noSpawnTicks = 0;
			ReportProgress();
			Main.NewText("A Shard Monsters Invasion gathers nearby!", 80, 180, 255);
			SyncWorld();
			return true;
		}

		public static void CountShardEnemyKill(int progress = 1)
		{
			if (!Active || Main.netMode == NetmodeID.MultiplayerClient)
			{
				return;
			}

			Defeated += progress;

			if (Defeated >= RequiredKills)
			{
				End(success: true);
				return;
			}

			ReportProgress();

			if (Remaining == 50 || Remaining == 20)
			{
				Main.NewText($"{Remaining} shard monsters remain.", 80, 180, 255);
			}

			SyncWorld();
		}

		public static bool CanSpawnFor(Player player)
		{
			return player.active && !player.dead && player.ZoneOverworldHeight;
		}

		private static void End(bool success)
		{
			Active = false;
			Defeated = 0;
			noSpawnTicks = 0;
			ClearProgress();
			Main.NewText(success ? "The Shard Monsters Invasion has been repelled." : "The Shard Monsters Invasion has scattered.", 80, 180, 255);
			SyncWorld();
		}

		private static void ReportProgress()
		{
			Main.ReportInvasionProgress(
				Utils.Clamp(Defeated, 0, RequiredKills),
				RequiredKills,
				ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.PrismaticShardling>(),
				0);
		}

		private static void ClearProgress()
		{
			Main.ReportInvasionProgress(
				0,
				1,
				ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.PrismaticShardling>(),
				0);
		}

		private static bool HasValidInvasionPlayer()
		{
			for (int i = 0; i < Main.maxPlayers; i++)
			{
				if (CanSpawnFor(Main.player[i]))
				{
					return true;
				}
			}

			return false;
		}

		private static void SyncWorld()
		{
			if (Main.netMode == NetmodeID.Server)
			{
				NetMessage.SendData(MessageID.WorldData);
			}
		}
	}
}
