using Terraria;
using Terraria.ModLoader;
using VinesMod.NPCs;

namespace VinesMod.Buffs
{
	public class EtherealFlames : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Ethereal Flames");
			Description.SetDefault("Losing life");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}
	}
}
