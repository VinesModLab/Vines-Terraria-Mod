using Terraria;
using Terraria.ModLoader;
using VinesMod.NPCs;

namespace VinesMod.Buffs
{
	public class DirtJavelin : ModBuff
	{
		public override string Texture => "VinesMod/Buffs/DebuffTemplate";

		public override void SetStaticDefaults()
		{
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<VinesGlobalNPC>().DirtJavelin = true;
		}
	}
}
