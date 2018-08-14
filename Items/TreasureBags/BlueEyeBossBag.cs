using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace VinesMod.Items.TreasureBags
{
    public class BlueEyeBossBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = 9;
            item.expert = false;
            bossBagNPC = mod.NPCType("BlueEyeBoss"); // The NPC this bag drops from
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            player.TryGettingDevArmor(); // This will have a chance to spawn the Dev Armour.

            if(Main.rand.Next(3) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("BlueEyeBall"),1);
            }

            if(Main.rand.Next(3) == 0)
            {
                player.QuickSpawnItem(ItemID.LifeCrystal, Main.rand.Next(1, 3));
            }

            if(Main.rand.Next(5) == 0)
            {
                player.QuickSpawnItem(ItemID.BlackLens, 1);
            }

            if(Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(ItemID.Binoculars, 1);
            }
            player.QuickSpawnItem(ItemID.GoldBar, 5);
            player.QuickSpawnItem(ItemID.IronBar, 7);
            player.QuickSpawnItem(mod.ItemType("ShardBlue"), Main.rand.Next(10,20));
            player.QuickSpawnItem(ItemID.ManaCrystal, Main.rand.Next(2, 4));

            player.QuickSpawnItem(ItemID.DemoniteOre, Main.rand.Next(20, 40));
            player.QuickSpawnItem(ItemID.CrimtaneOre, Main.rand.Next(20, 40));
            player.QuickSpawnItem(ItemID.CorruptSeeds, Main.rand.Next(1, 2));
            player.QuickSpawnItem(ItemID.CrimsonSeeds, Main.rand.Next(1, 2));
            player.QuickSpawnItem(ItemID.Lens, Main.rand.Next(3, 5));
            player.QuickSpawnItem(ItemID.GoldBar, Main.rand.Next(3, 5));
            player.QuickSpawnItem(ItemID.SilverOre, Main.rand.Next(10, 20));
            player.QuickSpawnItem(ItemID.IronBar, Main.rand.Next(3, 7));

            player.QuickSpawnItem(ItemID.Sapphire, Main.rand.Next(3, 5));
        }
    }
}
