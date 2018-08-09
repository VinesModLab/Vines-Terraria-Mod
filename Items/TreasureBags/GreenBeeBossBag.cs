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
    public class GreenBeeBossBag : ModItem
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
            bossBagNPC = mod.NPCType("GreenBeeBoss"); // The NPC this bag drops from
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
                player.QuickSpawnItem(ItemID.LifeCrystal, Main.rand.Next(1, 3));
			    player.QuickSpawnItem(ItemID.ManaCrystal, Main.rand.Next(3, 5));
            }

            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(ItemID.HoneyedGoggles, 1);
            }

            if (Main.rand.Next(8) == 0)
            {
                player.QuickSpawnItem(ItemID.Nectar, 1);
            }

            switch (Main.rand.Next(3))
            {
                case 0:
                player.QuickSpawnItem(ItemID.BeeKeeper, 1);
                break;

                case 1:
                player.QuickSpawnItem(ItemID.BeeGun, 1);
                break;

                case 2:
                player.QuickSpawnItem(ItemID.BeesKnees, 1);
                break;

            }

            if(Main.rand.Next(4) == 0)
            {
                player.QuickSpawnItem(ItemID.Nectar, 1);
            }

            if(Main.rand.Next(6) == 0)
            {
                player.QuickSpawnItem(ItemID.HoneyedGoggles, 1);
            }
            player.QuickSpawnItem(ItemID.GoldBar, Main.rand.Next(5, 8));
            player.QuickSpawnItem(ItemID.IronBar, Main.rand.Next(5, 10));
            player.QuickSpawnItem(ItemID.SilverOre, Main.rand.Next(15, 20));
            player.QuickSpawnItem(mod.ItemType("ShardGreen"), Main.rand.Next(10,20));
            player.QuickSpawnItem(ItemID.LifeCrystal, Main.rand.Next(1, 2));
            player.QuickSpawnItem(ItemID.ManaCrystal, Main.rand.Next(1, 3));

            player.QuickSpawnItem(ItemID.HiveBackpack, 1);
            player.QuickSpawnItem(ItemID.BottledHoney, Main.rand.Next(15, 30));
            player.QuickSpawnItem(ItemID.BeeWax, Main.rand.Next(10, 20));
            player.QuickSpawnItem(ItemID.Emerald, Main.rand.Next(3, 5));
            player.QuickSpawnItem(ItemID.Beenade, Main.rand.Next(30, 45));
            
        }
    }
}
