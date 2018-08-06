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
        public static bool downedBlueEyeBoss = false; // Downed Tutorial Boss

        public override void Initialize()
        {
            downedBlueEyeBoss = false;
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedBlueEyeBoss) downed.Add("BlueEye");

            return new TagCompound
            {
                {"downed", downed }
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedBlueEyeBoss = downed.Contains("BlueEye");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if(loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedBlueEyeBoss = flags[0];
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedBlueEyeBoss;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedBlueEyeBoss = flags[0];
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
