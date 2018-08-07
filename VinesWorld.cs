using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using System.Collections.Generic;

using System;
using Terraria.ModLoader.IO;
using System.IO;

namespace VinesMod
{
    public class VinesWorld : ModWorld
    {
        public static int biomeTiles = 0;
        // Stuff added with the Boss
        public static bool downedBlueEyeBoss = false;
        public static bool downedRedBrainBoss = false;
        public static bool downedGreenBeeBoss = false;
        public static bool downedPurpleSlimeBoss = false;
        public static bool downedYellowIchorBoss = false;

        public override void Initialize()
        {
            downedBlueEyeBoss = false;
            downedRedBrainBoss = false;
            downedGreenBeeBoss = false;
            downedPurpleSlimeBoss = false;
            downedYellowIchorBoss = false;
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedBlueEyeBoss) downed.Add("BlueEye");
            if (downedRedBrainBoss) downed.Add("RedBrain");
            if (downedGreenBeeBoss) downed.Add("GreenBee");
            if (downedPurpleSlimeBoss) downed.Add("PurpleSlime");
            if (downedYellowIchorBoss) downed.Add("YellowIchor");

            return new TagCompound
            {
                {"downed", downed }
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedBlueEyeBoss = downed.Contains("BlueEye");
            downedRedBrainBoss = downed.Contains("RedBrain");
            downedGreenBeeBoss = downed.Contains("GreenBee");
            downedPurpleSlimeBoss = downed.Contains("PurpleSlime");
            downedYellowIchorBoss = downed.Contains("YellowIchor");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if(loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedBlueEyeBoss = flags[0];
                downedRedBrainBoss = flags[1];
                downedGreenBeeBoss = flags[2];
                downedPurpleSlimeBoss = flags[3];
                downedYellowIchorBoss = flags[4];
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedBlueEyeBoss;
            flags[1] = downedRedBrainBoss;
            flags[2] = downedGreenBeeBoss;
            flags[3] = downedPurpleSlimeBoss;
            flags[4] = downedYellowIchorBoss;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedBlueEyeBoss = flags[0];
            downedRedBrainBoss = flags[1];
            downedGreenBeeBoss = flags[2];
            downedPurpleSlimeBoss = flags[3];
            downedYellowIchorBoss = flags[4];
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            //not going to mess with world gen
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
        }

        public override void ResetNearbyTileEffects()
        {
            biomeTiles = 0;
        }
    }
}
