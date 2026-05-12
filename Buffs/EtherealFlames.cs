using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.NPCs;

namespace VinesMod.Buffs
{
	public class EtherealFlames : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = true;
		}
	}
}
