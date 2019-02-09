using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace VinesMod.Items.Summon
{
    public class YellowIchorBossSummonItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Summoner : Yellow Ichor Boss");
            Tooltip.SetDefault("Summons the Yellow Ichor Boss.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.value = Item.buyPrice(0,3,0,0);
            item.rare = 1;
            item.useAnimation = 40;
            item.useTime = 45;
            item.consumable = true;

            item.useStyle = 4; // Holds up like a summon item.
        }

        public override bool CanUseItem(Player player)
        {
            // Does NPC Exist
            bool alreadySpawned = NPC.AnyNPCs(mod.NPCType("YellowIchorBoss"));

            return !alreadySpawned;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("YellowIchorBoss")); // Spawn the boss within a range of the player. 
            Main.PlaySound(SoundID.Roar, player.position, 0); 
            return true;
        }
    }
}
