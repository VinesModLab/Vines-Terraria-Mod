using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.GoodieBags
{
	public class PetGoodieBag : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.maxStack = 999;
            Item.consumable = true;
			Item.value = Item.buyPrice(0,10,0,0);
			Item.width = 20;
			Item.height = 20;
			Item.rare = 2;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			switch (Main.rand.Next(33))
			{
				case 0:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Carrot);
				break;
				case 1:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.AmberMosquito);
				break;
				case 2:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Fish);
				break;
				case 3:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.BoneRattle);
				break;
				case 4:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.BoneKey);
				break;
				case 5:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.ParrotCracker);
				break;
				case 6:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Seaweed);
				break;
				case 7:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.StrangeGlowingMushroom);
				break;
				case 8:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.ToySled);
				break;
				case 9:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.EatersBone);
				break;
				case 10:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Nectar);
				break;
				case 11:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.LizardEgg);
				break;
				case 12:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.Seedling);
				break;
				case 13:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.TikiTotem);
				break;
				case 14:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.EyeSpring);
				break;
				case 15:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.MagicalPumpkinSeed);
				break;
				case 16:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.UnluckyYarn);
				break;
				case 17:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.CursedSapling);
				break;
				case 18:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.SpiderEgg);
				break;
				case 19:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.DogWhistle);
				break;
				case 20:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.BabyGrinchMischiefWhistle);
				break;
				case 21:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.TartarSauce);
				break;
				case 22:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.ZephyrFish);
				break;
				case 23:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.CompanionCube);
				break;
				case 24:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.DD2PetGato);
				break;
				case 25:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.DD2PetDragon);
				break;
				case 26:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.ShadowOrb);
				break;
				case 27:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.CrimsonHeart);
				break;
				case 28:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.MagicLantern);
				break;
				case 29:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.FairyBell);
				break;
				case 30:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.DD2PetGhost);
				break;
				case 31:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.WispinaBottle);
				break;
				case 32:
				player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.SuspiciousLookingTentacle);
				break;
			}

		}
	}
}