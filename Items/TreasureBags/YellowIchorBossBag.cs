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
    public class YellowIchorBossBag : ModItem
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
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.AmberMosquito, 1);
            }

                switch (Main.rand.Next(4))
                {
                    case 0:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Weapons.Magic.BallisticStaff>(), 1);
                    break;
                    case 1:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Weapons.DualUse.GoldenGunBlade>(), 1);
                    break;
                    case 2:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Accessories.Shield.ShieldOfFlag>(), 1);
                    break;
                    case 3:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Accessories.HandsOff.PizzaBadge>(), 1);
                    break;
                }


                if (Main.rand.Next(3) == 0)
                {
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.EatersBone, 1);
                }

            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.GoldBar, Main.rand.Next(5, 15));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.IronBar, Main.rand.Next(7, 20));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardYellow>(), Main.rand.Next(10,20));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Amber, Main.rand.Next(5, 7));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Topaz, Main.rand.Next(3, 5));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.SilverOre, Main.rand.Next(15, 20));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.ManaCrystal, Main.rand.Next(1, 2));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.LifeCrystal, Main.rand.Next(1, 2));
        }
    }
}
