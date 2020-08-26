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
    public class WhiteFlyingFishBossBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override int BossBagNPC => mod.NPCType("WhiteFlyingFishBoss");

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = 9;
            item.expert = false;
            //bossBagNPC = mod.NPCType("WhiteFlyingFishBoss"); // The NPC this bag drops from
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

                switch (Main.rand.Next(5))
                {
                    case 0:
                    player.QuickSpawnItem(ItemID.StarCannon, 1);
                    break;
                    case 1:
                    player.QuickSpawnItem(ItemID.LargeDiamond, 1);
                    break;
                    case 2:
                    player.QuickSpawnItem(ItemID.LargeRuby, 1);
                    break;
                    case 3:
                    player.QuickSpawnItem(ItemID.LargeSapphire, 1);
                    break;
                    case 4:
                    player.QuickSpawnItem(mod.ItemType("WhiteFishSword"),1);
                    break;
                }

            player.QuickSpawnItem(ItemID.GoldBar, Main.rand.Next(5, 15));
            player.QuickSpawnItem(ItemID.IronBar, Main.rand.Next(7, 20));
            player.QuickSpawnItem(mod.ItemType("ShardWhite"), Main.rand.Next(10,20));
            player.QuickSpawnItem(ItemID.Diamond, Main.rand.Next(10, 15));
            player.QuickSpawnItem(ItemID.SilverOre, Main.rand.Next(15, 20));
            player.QuickSpawnItem(ItemID.ManaCrystal, Main.rand.Next(1, 2));
            player.QuickSpawnItem(ItemID.LifeCrystal, Main.rand.Next(1, 2));
        }
    }
}
