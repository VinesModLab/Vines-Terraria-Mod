using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod
{
    class VinesMod : Mod
    {
        public VinesMod()
        {
            // Default is all true
            /*
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
            */
        }

        // Log stuff for testing
        public static void Log(Array array)
        {
            foreach (var item in array)
            {
                ErrorLogger.Log(item.ToString());
            }
        }
    }
}