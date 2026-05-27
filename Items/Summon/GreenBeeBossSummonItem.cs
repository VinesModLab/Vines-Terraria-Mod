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
    public class GreenBeeBossSummonItem : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(0,3,0,0);
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 40;
            Item.useTime = 45;
            Item.consumable = true;

            Item.useStyle = ItemUseStyleID.HoldUp; // Holds up like a summon Item.
        }

        public override bool CanUseItem(Player player)
        {
            // Does NPC Exist
            bool alreadySpawned = NPC.AnyNPCs(ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.GreenBeeBoss>());

            return !alreadySpawned;
        }

        public override bool? UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.GreenBeeBoss>()); // Spawn the boss within a range of the player. 
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Roar, player.position); 
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), 10)
                .AddIngredient(ItemID.Emerald, 1)
                .AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
                .Register();
        }
    }
}
