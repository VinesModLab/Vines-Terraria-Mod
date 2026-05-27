using Terraria;

namespace VinesMod.NPCs.Hostile.ShardsMonster
{
	internal static class ShardNpcTargeting
	{
		public static void MakeHostileTargetable(NPC npc)
		{
			npc.friendly = false;
			npc.chaseable = true;
			npc.dontTakeDamage = false;
			npc.immortal = false;
		}
	}
}
