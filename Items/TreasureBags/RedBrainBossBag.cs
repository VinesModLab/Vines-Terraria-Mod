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
    public class RedBrainBossBag : ModItem
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
            bossBagNPC = mod.NPCType("RedBrainBoss"); // The NPC this bag drops from
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

            if(Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(ItemID.BoneRattle, 1);
            }

            if (Main.rand.Next(4) == 0)
                {
                player.QuickSpawnItem(ItemID.UnholyWater, 1);
                }

                switch (Main.rand.Next(5))
                {
                case 0:
                player.QuickSpawnItem(ItemID.PanicNecklace, 1);
                break;

                case 1:
                player.QuickSpawnItem(ItemID.CrimsonHeart, 1);
                break;

                case 2:
                player.QuickSpawnItem(ItemID.CrimsonRod, 1);
                break;

                case 3:
                player.QuickSpawnItem(ItemID.TheRottedFork, 1);
                break;

                case 4:
                player.QuickSpawnItem(mod.ItemType("RedEyeBall"), 1);
                break;
                }

            player.QuickSpawnItem(ItemID.GoldBar, 5);
            player.QuickSpawnItem(ItemID.IronBar, 7);
            player.QuickSpawnItem(ItemID.SilverOre, Main.rand.Next(10, 20));
            player.QuickSpawnItem(mod.ItemType("ShardRed"), Main.rand.Next(10,20));
            player.QuickSpawnItem(ItemID.LifeCrystal, 1);
            player.QuickSpawnItem(ItemID.ManaCrystal, Main.rand.Next(1, 2));
            player.QuickSpawnItem(ItemID.CrimtaneOre, Main.rand.Next(40, 60));
            player.QuickSpawnItem(ItemID.TissueSample, Main.rand.Next(10, 20));
            player.QuickSpawnItem(ItemID.Ruby, Main.rand.Next(3, 5));
        }
    }
}
