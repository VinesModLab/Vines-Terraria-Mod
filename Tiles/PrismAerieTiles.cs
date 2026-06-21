using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace VinesMod.Tiles
{
	public class PrismstoneBlock : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileMergeDirt[Type] = true;
			TileID.Sets.CanBeClearedDuringGeneration[Type] = true;
			AddMapEntry(new Color(215, 235, 245), CreateMapEntryName());
			DustType = DustID.GemDiamond;
			HitSound = SoundID.Tink;
		}
	}

	public class PrismGrass : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileMergeDirt[Type] = true;
			TileID.Sets.CanBeClearedDuringGeneration[Type] = true;
			AddMapEntry(new Color(185, 235, 245), CreateMapEntryName());
			DustType = DustID.GemSapphire;
			HitSound = SoundID.Grass;
		}
	}

	public class FracturedPrismOre : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileOreFinderPriority[Type] = 340;
			TileID.Sets.Ore[Type] = true;
			AddMapEntry(new Color(180, 245, 255), CreateMapEntryName());
			DustType = DustID.GemDiamond;
			HitSound = SoundID.Tink;
			MinPick = 45;
		}
	}

	public class CloudglassPlatform : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileSolidTop[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.Platforms[Type] = true;
			TileObjectData.newTile.CoordinateHeights = new[] { 16 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 1;
			TileObjectData.newTile.UsesCustomCanPlace = false;
			TileObjectData.addTile(Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
			AddMapEntry(new Color(175, 230, 255), CreateMapEntryName());
			DustType = DustID.GemSapphire;
			HitSound = SoundID.Shatter;
			AdjTiles = new[] { (int)TileID.Platforms };
		}
	}

	public class HangingPrismCrystal : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
			TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 0);
			TileObjectData.newTile.AnchorBottom = AnchorData.Empty;
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.addTile(Type);
			AddMapEntry(new Color(140, 220, 255), CreateMapEntryName());
			DustType = DustID.GemDiamond;
			HitSound = SoundID.Shatter;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.16f;
			g = 0.28f;
			b = 0.36f;
		}
	}

	public class PrismAltar : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileLighted[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileObjectData.addTile(Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			AddMapEntry(new Color(210, 240, 255), CreateMapEntryName());
			DustType = DustID.RainbowMk2;
			HitSound = SoundID.Tink;
			AdjTiles = new[] { (int)TileID.WorkBenches, (int)TileID.Anvils };
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer && Main.rand.NextBool(24))
			{
				int dust = Dust.NewDust(new Vector2(i * 16 + Main.rand.Next(16), j * 16 - 2), 2, 2, DustID.RainbowMk2);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 0.25f;
			}
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.22f;
			g = 0.28f;
			b = 0.36f;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, ModContent.ItemType<Items.Placeable.PrismAltar>());
		}
	}
}
