using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.GoodieBags
{
	public class PetGoodieBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pets' Bag");
			Tooltip.SetDefault("<right> to get a random pet!");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
            item.consumable = true;
			item.value = 50000;
			item.width = 20;
			item.height = 20;
			item.rare = 2;
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
				player.QuickSpawnItem(ItemID.Carrot);
				break;
				case 1:
				player.QuickSpawnItem(ItemID.AmberMosquito);
				break;
				case 2:
				player.QuickSpawnItem(ItemID.Fish);
				break;
				case 3:
				player.QuickSpawnItem(ItemID.BoneRattle);
				break;
				case 4:
				player.QuickSpawnItem(ItemID.BoneKey);
				break;
				case 5:
				player.QuickSpawnItem(ItemID.ParrotCracker);
				break;
				case 6:
				player.QuickSpawnItem(ItemID.Seaweed);
				break;
				case 7:
				player.QuickSpawnItem(ItemID.StrangeGlowingMushroom);
				break;
				case 8:
				player.QuickSpawnItem(ItemID.ToySled);
				break;
				case 9:
				player.QuickSpawnItem(ItemID.EatersBone);
				break;
				case 10:
				player.QuickSpawnItem(ItemID.Nectar);
				break;
				case 11:
				player.QuickSpawnItem(ItemID.LizardEgg);
				break;
				case 12:
				player.QuickSpawnItem(ItemID.Seedling);
				break;
				case 13:
				player.QuickSpawnItem(ItemID.TikiTotem);
				break;
				case 14:
				player.QuickSpawnItem(ItemID.EyeSpring);
				break;
				case 15:
				player.QuickSpawnItem(ItemID.MagicalPumpkinSeed);
				break;
				case 16:
				player.QuickSpawnItem(ItemID.UnluckyYarn);
				break;
				case 17:
				player.QuickSpawnItem(ItemID.CursedSapling);
				break;
				case 18:
				player.QuickSpawnItem(ItemID.SpiderEgg);
				break;
				case 19:
				player.QuickSpawnItem(ItemID.DogWhistle);
				break;
				case 20:
				player.QuickSpawnItem(ItemID.BabyGrinchMischiefWhistle);
				break;
				case 21:
				player.QuickSpawnItem(ItemID.TartarSauce);
				break;
				case 22:
				player.QuickSpawnItem(ItemID.ZephyrFish);
				break;
				case 23:
				player.QuickSpawnItem(ItemID.CompanionCube);
				break;
				case 24:
				player.QuickSpawnItem(ItemID.DD2PetGato);
				break;
				case 25:
				player.QuickSpawnItem(ItemID.DD2PetDragon);
				break;
				case 26:
				player.QuickSpawnItem(ItemID.ShadowOrb);
				break;
				case 27:
				player.QuickSpawnItem(ItemID.CrimsonHeart);
				break;
				case 28:
				player.QuickSpawnItem(ItemID.MagicLantern);
				break;
				case 29:
				player.QuickSpawnItem(ItemID.FairyBell);
				break;
				case 30:
				player.QuickSpawnItem(ItemID.DD2PetGhost);
				break;
				case 31:
				player.QuickSpawnItem(ItemID.WispinaBottle);
				break;
				case 32:
				player.QuickSpawnItem(ItemID.SuspiciousLookingTentacle);
				break;
			}

		}
	}
}