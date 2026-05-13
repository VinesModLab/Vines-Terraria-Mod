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
    public class WhiteFlyingFishBossSummonItem : ModItem
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
            Item.rare = 1;
            Item.useAnimation = 40;
            Item.useTime = 45;
            Item.consumable = true;

            Item.useStyle = ItemUseStyleID.HoldUp; // Holds up like a summon Item.
        }

        public override bool CanUseItem(Player player)
        {
            // Does NPC Exist
            bool alreadySpawned = NPC.AnyNPCs(ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.WhiteFlyingFishBoss>());

            return !alreadySpawned;
        }

        public override bool? UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.WhiteFlyingFishBoss>()); // Spawn the boss within a range of the player. 
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Roar, player.position); 
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), 20)
                .AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), 3)
                .AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardGreen>(), 3)
                .AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardPurple>(), 3)
                .AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardRed>(), 3)
                .AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardYellow>(), 3)
                .AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
                .Register();
        }
    }
}
