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
    public class BlueEyeBossSummonItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Summoner : Blue Eye Boss");
            Tooltip.SetDefault("Summons the Blue Eye Boss." + "\nDifferent fightstyle between day and light.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.value = 100;
            item.rare = 1;
            item.useAnimation = 40;
            item.useTime = 45;
            item.consumable = true;

            item.useStyle = 4; // Holds up like a summon item.
        }

        public override bool CanUseItem(Player player)
        {
            // Main Bosses
            bool queenBee = NPC.downedQueenBee; // Downed Queen Bee

            bool bossOne = NPC.downedBoss1; // Downed EoC
            bool bossTwo = NPC.downedBoss2; // Downed EoW or BoC
            bool bossThree = NPC.downedBoss3; // Downed Skeletron

            bool isHardmode = Main.hardMode; // Downed WoF

            bool mechOne = NPC.downedMechBoss1; // Downed The Twins
            bool mechTwo = NPC.downedMechBoss2; // Downed The Destroyer
            bool mechThree = NPC.downedMechBoss3; // Downed Skeletron Prim

            bool plantera = NPC.downedPlantBoss; // Downed Plantera
            bool golem = NPC.downedGolemBoss; // Downed Golem;
            bool cultist = NPC.downedAncientCultist; // Downed Cultist
            bool moonLord = NPC.downedMoonlord; // Downed MoonLord

            // Does NPC Exist
            bool alreadySpawned = NPC.AnyNPCs(mod.NPCType("BlueEyeBoss"));

            // return NPC.downedQueenBee && Main.hardMode && !NPC.AnyNPCs(mod.NPCType("TutorialBoss")); // NPC will spawn if No existing Tutorial Boss, Queen Bee is downed and it is hardmode 
            return !alreadySpawned;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("BlueEyeBoss")); // Spawn the boss within a range of the player. 
            Main.PlaySound(SoundID.Roar, player.position, 0); 
            return true;
        }
    }
}
