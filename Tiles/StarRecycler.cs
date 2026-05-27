using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace VinesMod.Tiles
{
	public class StarRecycler : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
			TileObjectData.addTile(Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			AddMapEntry(new Color(80, 210, 230), CreateMapEntryName());
			DustType = DustID.Electric;
			TileID.Sets.DisableSmartCursor[Type] = true;
			AdjTiles = new int[] { TileID.WorkBenches };
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (!closer || Main.rand.NextBool(18))
			{
				return;
			}

			Vector2 position = new Vector2(i * 16 + Main.rand.Next(32), j * 16 - 4);
			int dust = Dust.NewDust(position, 2, 2, DustID.GemDiamond);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity = new Vector2(Main.rand.NextFloat(-0.25f, 0.25f), Main.rand.NextFloat(-1.3f, -0.4f));
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.16f;
			g = 0.42f;
			b = 0.5f;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 16, ModContent.ItemType<global::VinesMod.Items.Placeable.StarRecycler>());
		}
	}
}
