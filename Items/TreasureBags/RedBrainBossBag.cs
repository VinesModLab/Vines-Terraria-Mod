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
        }

        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Cyan;
            
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

            if(Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.BoneRattle, 1);
            }

            if (Main.rand.Next(4) == 0)
                {
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.UnholyWater, 1);
                }

                switch (Main.rand.Next(5))
                {
                case 0:
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.PanicNecklace, 1);
                break;

                case 1:
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.CrimsonHeart, 1);
                break;

                case 2:
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.CrimsonRod, 1);
                break;

                case 3:
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.TheRottedFork, 1);
                break;

                case 4:
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.RedEyeBall>(), 1);
                break;
                }

            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.GoldBar, 5);
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.IronBar, 7);
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.SilverOre, Main.rand.Next(10, 20));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), Main.rand.Next(10,20));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.LifeCrystal, 1);
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.ManaCrystal, Main.rand.Next(1, 2));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.CrimtaneOre, Main.rand.Next(40, 60));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.TissueSample, Main.rand.Next(10, 20));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Ruby, Main.rand.Next(3, 5));
        }
    }
}
