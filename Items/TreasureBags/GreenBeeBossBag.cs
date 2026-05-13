using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
namespace VinesMod.Items.TreasureBags
{
    public class GreenBeeBossBag : ModItem
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

            switch (Main.rand.Next(3))
            {
                case 0:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.BeeKeeper, 1);
                    break;
                case 1:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.BeeGun, 1);
                    break;
                case 2:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.BeesKnees, 1);
                    break;
            }

            if (Main.rand.Next(6) == 0)
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Nectar, 1);
            if (Main.rand.Next(6) == 0)
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.HoneyedGoggles, 1);

            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardGreen>(), Main.rand.Next(12, 21));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.BeeWax, Main.rand.Next(10, 21));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Emerald, Main.rand.Next(2, 5));
            
        }
    }
}
