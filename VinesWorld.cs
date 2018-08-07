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

        public override void Initialize()
        {
            downedBlueEyeBoss = false;
            downedRedBrainBoss = false;
            downedGreenBeeBoss = false;
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedBlueEyeBoss) downed.Add("BlueEye");
            if (downedRedBrainBoss) downed.Add("RedBrain");
            if (downedGreenBeeBoss) downed.Add("GreenBee");

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
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedBlueEyeBoss;
            flags[1] = downedRedBrainBoss;
            flags[2] = downedGreenBeeBoss;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedBlueEyeBoss = flags[0];
            downedRedBrainBoss = flags[1];
            downedGreenBeeBoss = flags[2];
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
