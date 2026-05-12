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
        }


        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 24;
            Item.height = 24;
            Item.rare = 9;
            
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            player.TryGettingDevArmor(player.GetSource_OpenItem(Type)); // This will have a chance to spawn the Dev Armour.
            if(Main.rand.Next(3) == 0)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.LifeCrystal, Main.rand.Next(1, 3));
			    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.ManaCrystal, Main.rand.Next(3, 5));
            }

                switch (Main.rand.Next(5))
                {
                    case 0:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.StarCannon, 1);
                    break;
                    case 1:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.LargeDiamond, 1);
                    break;
                    case 2:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.LargeRuby, 1);
                    break;
                    case 3:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.LargeSapphire, 1);
                    break;
                    case 4:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.WhiteFishSword>(),1);
                    break;
                }

            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.GoldBar, Main.rand.Next(5, 15));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.IronBar, Main.rand.Next(7, 20));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), Main.rand.Next(10,20));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Diamond, Main.rand.Next(10, 15));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.SilverOre, Main.rand.Next(15, 20));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.ManaCrystal, Main.rand.Next(1, 2));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.LifeCrystal, Main.rand.Next(1, 2));
        }
    }
}
