using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace VinesMod
{
    /// <summary>
    /// Tracks per-world boss defeat flags for VinesMod.
    /// Migrated from ModWorld (1.3) to ModSystem (1.4).
    /// Save/Load use TagCompound; legacy binary save is no longer supported.
    /// </summary>
    public class VinesWorld : ModSystem
    {
        public static int biomeTiles = 0;

        // Boss defeat flags
        public static bool downedBlueEyeBoss = false;
        public static bool downedRedBrainBoss = false;
        public static bool downedGreenBeeBoss = false;
        public static bool downedPurpleSlimeBoss = false;
        public static bool downedYellowIchorBoss = false;
        public static bool downedWhiteFlyingFishBoss = false;

        public override void OnWorldLoad()
        {
            downedBlueEyeBoss = false;
            downedRedBrainBoss = false;
            downedGreenBeeBoss = false;
            downedPurpleSlimeBoss = false;
            downedYellowIchorBoss = false;
            downedWhiteFlyingFishBoss = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            if (downedBlueEyeBoss)         tag["BlueEye"] = true;
            if (downedRedBrainBoss)         tag["RedBrain"] = true;
            if (downedGreenBeeBoss)         tag["GreenBee"] = true;
            if (downedPurpleSlimeBoss)      tag["PurpleSlime"] = true;
            if (downedYellowIchorBoss)      tag["YellowIchor"] = true;
            if (downedWhiteFlyingFishBoss)  tag["WhiteFlyingFish"] = true;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            downedBlueEyeBoss        = tag.ContainsKey("BlueEye");
            downedRedBrainBoss       = tag.ContainsKey("RedBrain");
            downedGreenBeeBoss       = tag.ContainsKey("GreenBee");
            downedPurpleSlimeBoss    = tag.ContainsKey("PurpleSlime");
            downedYellowIchorBoss    = tag.ContainsKey("YellowIchor");
            downedWhiteFlyingFishBoss = tag.ContainsKey("WhiteFlyingFish");
        }

        public override void NetSend(System.IO.BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedBlueEyeBoss;
            flags[1] = downedRedBrainBoss;
            flags[2] = downedGreenBeeBoss;
            flags[3] = downedPurpleSlimeBoss;
            flags[4] = downedYellowIchorBoss;
            flags[5] = downedWhiteFlyingFishBoss;
            writer.Write(flags);
        }

        public override void NetReceive(System.IO.BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedBlueEyeBoss        = flags[0];
            downedRedBrainBoss       = flags[1];
            downedGreenBeeBoss       = flags[2];
            downedPurpleSlimeBoss    = flags[3];
            downedYellowIchorBoss    = flags[4];
            downedWhiteFlyingFishBoss = flags[5];
        }

        public override void ResetNearbyTileEffects()
        {
            biomeTiles = 0;
        }
    }
}
