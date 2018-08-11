using Terraria;
using Terraria.ModLoader;
using VinesMod.NPCs;

namespace VinesMod.Buffs
{
	public class DirtJavelin : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			// NPC only buff so we'll just assign it a useless buff icon.
			texture = "VinesMod/Buffs/BuffTemplate";
			return base.Autoload(ref name, ref texture);
		}

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Dirt Javelin");
			Description.SetDefault("Losing life");
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<VinesGlobalNPC>().DirtJavelin = true;
		}
	}
}
