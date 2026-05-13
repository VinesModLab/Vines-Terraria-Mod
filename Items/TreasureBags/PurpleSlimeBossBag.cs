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

            switch (Main.rand.Next(4))
            {
                case 0:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Vilethorn, 1);
                    break;
                case 1:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.BallOHurt, 1);
                    break;
                case 2:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.BandofStarpower, 1);
                    break;
                case 3:
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Solidifier, 1);
                    break;
            }

            if (Main.rand.Next(20) == 0)
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.SlimeStaff, 1);

            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), Main.rand.Next(12, 21));
            player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Amethyst, Main.rand.Next(2, 5));
        }
    }
}
