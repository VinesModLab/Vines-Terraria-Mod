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
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.BlueEyeBall>(),1);
            }

            if(Main.rand.Next(3) == 0)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.LifeCrystal, Main.rand.Next(1, 3));
            }

            if (Main.rand.Next(4) == 0)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.CodeO>(), 1);
            }

            if(Main.rand.Next(5) == 0)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.BlackLens, 1);
            }

            if(Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Binoculars, 1);
            }
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.GoldBar, 5);
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.IronBar, 7);
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), Main.rand.Next(10,20));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.ManaCrystal, Main.rand.Next(2, 4));

            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.DemoniteOre, Main.rand.Next(20, 40));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.CrimtaneOre, Main.rand.Next(20, 40));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.CorruptSeeds, Main.rand.Next(1, 2));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.CrimsonSeeds, Main.rand.Next(1, 2));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Lens, Main.rand.Next(3, 5));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.GoldBar, Main.rand.Next(3, 5));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.SilverOre, Main.rand.Next(10, 20));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.IronBar, Main.rand.Next(3, 7));

            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Sapphire, Main.rand.Next(3, 5));
        }
    }
}
