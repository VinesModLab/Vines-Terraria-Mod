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
    public class PurpleSlimeBossBag : ModItem
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
                if (Main.rand.Next(4) == 0)
                {
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.BloodWater, 1);
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.UnholyWater, 1);
                }

                switch (Main.rand.Next(5))
                {
                case 0:
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.ShadowOrb, 1);
                break;

                case 1:
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Vilethorn, 1);
                break;

                case 2:
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.BallOHurt, 1);
                break;

                case 3:
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.BandofStarpower, 1);
                break;

                case 4:
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.SlimeStaff, 1);
                break;
                }
            

            if(Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.RoyalGel, 1);
            }
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.GoldBar, 5);
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.IronBar, 7);
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), Main.rand.Next(10,20));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.LifeCrystal, 1);
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.ManaCrystal, Main.rand.Next(1, 2));

            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.DemoniteOre, Main.rand.Next(40, 60));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.ShadowScale, Main.rand.Next(10, 20));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Amethyst, Main.rand.Next(3, 5));
                            
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.GoldBar, Main.rand.Next(3, 5));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.IronBar, Main.rand.Next(3, 7));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.SilverOre, Main.rand.Next(10, 20));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Solidifier, 1);
        }
    }
}
