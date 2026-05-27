using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VinesMod.Systems;

namespace VinesMod.Items.Summon
{
	public class ShardMonstersInvasionItem : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = Item.buyPrice(0, 0, 35, 0);
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 40;
			Item.useTime = 40;
			Item.consumable = true;
			Item.useStyle = ItemUseStyleID.HoldUp;
		}

		public override bool CanUseItem(Player player)
		{
			return ShardInvasionSystem.CanStart(player);
		}

		public override bool? UseItem(Player player)
		{
			if (Main.netMode == NetmodeID.MultiplayerClient)
			{
				ModPacket packet = Mod.GetPacket();
				packet.Write((byte)global::VinesMod.VinesMod.MessageType.StartShardInvasion);
				packet.Send();
				return true;
			}

			if (!ShardInvasionSystem.Start(player))
			{
				return false;
			}

			Terraria.Audio.SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardBlue>(), 8)
				.AddIngredient(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), 12)
				.AddIngredient(ItemID.Lens, 3)
				.AddTile(ModContent.TileType<global::VinesMod.Tiles.StarForge>())
				.Register();
		}
	}
}
