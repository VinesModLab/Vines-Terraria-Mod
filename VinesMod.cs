using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod
{
	public class VinesMod : Mod
	{
		internal enum MessageType : byte
		{
			StartShardInvasion
		}

		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			MessageType messageType = (MessageType)reader.ReadByte();
			switch (messageType)
			{
				case MessageType.StartShardInvasion:
					if (Main.netMode == NetmodeID.Server && whoAmI >= 0 && whoAmI < Main.maxPlayers)
					{
						ShardInvasionSystem.Start(Main.player[whoAmI]);
					}
					break;
			}
		}
	}
}
