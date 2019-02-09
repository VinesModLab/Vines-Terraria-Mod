using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.NPCs
{
	public class VinesGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}

		public bool eFlames = false;
		public bool DirtJavelin = false;

		public override void ResetEffects(NPC npc)
		{
			eFlames = false;
			DirtJavelin = false;
		}

		public override void SetDefaults(NPC npc)
		{
			npc.buffImmune[mod.BuffType<Buffs.DirtJavelin>()] = npc.buffImmune[BuffID.BoneJavelin];
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (DirtJavelin)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				int DirtJavelinCount = 0;
				for (int i = 0; i < 1000; i++)
				{
					Projectile p = Main.projectile[i];
					if (p.active && p.type == mod.ProjectileType<Projectiles.DirtJavelinProjectile>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
					{
						DirtJavelinCount++;
					}
				}
				npc.lifeRegen -= DirtJavelinCount * 2 * 3;
				if (damage < DirtJavelinCount * 3)
				{
					damage = DirtJavelinCount * 3;
				}
				
			}
			if (eFlames)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 16;
				if (damage < 2)
				{
					damage = 2;
				}
			}
		}

		public override void NPCLoot(NPC npc)
		{
			/*
			if (npc.lifeMax > 5 && npc.value > 0f)
			{
				//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ExampleItem"));
				if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExamplePlayer>(mod).ZoneExample)
				{
					//Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BossItem"));
				}
			}
			*/

			if (npc.lifeMax > 10 && npc.value > 0f && npc.lifeMax < 2000)
			{
				if (Main.rand.Next(6) == 0)
				{
					switch (Main.rand.Next(6))
					{
						case 0:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardBlue"), Main.rand.Next(1,3));
						break;
						case 1:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardRed"), Main.rand.Next(1,3));
						break;
						case 2:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardGreen"), Main.rand.Next(1,3));
						break;
						case 3:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardPurple"), Main.rand.Next(1,3));
						break;
						case 4:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardYellow"), Main.rand.Next(1,3));
						break;
						case 5:
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShardWhite"), Main.rand.Next(1,3));
						break;
					}
				}
				
			}

			if (npc.lifeMax > 120 && npc.lifeMax < 3000 && npc.value > 0f)
			{
				if (Main.rand.Next(15) == 0)
				{
					switch (Main.rand.Next(5))
            		{
                	case 0:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlueEyeBossSummonItem"), 1);
                	break;
                	case 1:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GreenBeeBossSummonItem"), 1);
                	break;
                	case 2:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PurpleSlimeBossSummonItem"), 1);
                	break;
                	case 3:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RedBrainBossSummonItem"), 1);
               		break;
                	case 4:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("YellowIchorBossSummonItem"), 1);
                	break;
            		}
				}
			}

			if (npc.lifeMax > 8000 && npc.value > 0f)
			{
				if (Main.rand.Next(4) == 0)
				{
					switch (Main.rand.Next(5))
            		{
                	case 0:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlueShardBag"), 1);
                	break;
                	case 1:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GreenShardBag"), 1);
                	break;
                	case 2:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PurpleShardBag"), 1);
                	break;
                	case 3:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RedShardBag"), 1);
               		break;
                	case 4:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("YellowShardBag"), 1);
                	break;
            		}
				}	
			}

			if (npc.lifeMax > 30000 && npc.value > 0f)
			{
				if (Main.rand.Next(2) == 0)
				{
					switch (Main.rand.Next(5))
            		{
                	case 0:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlueShardBag"), 1);
                	break;
                	case 1:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GreenShardBag"), 1);
                	break;
                	case 2:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PurpleShardBag"), 1);
                	break;
                	case 3:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RedShardBag"), 1);
               		break;
                	case 4:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("YellowShardBag"), 1);
                	break;
            		}
				}	
			}

			if (npc.lifeMax > 50000 && npc.value > 0f)
			{
				if (Main.rand.Next(2) == 0)
				{
					switch (Main.rand.Next(2))
            		{
                	case 0:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkMatter"), 1);
                	break;
                	case 1:
                	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LightMatter"), 1);
                	break;
            		}
				}	
			}
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (eFlames)
			{
				if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("EtherealFlame"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(4) == 0)
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			}
		}

		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			/*
			if (player.GetModPlayer<ExamplePlayer>(mod).ZoneExample)
			{
				spawnRate = (int)(spawnRate * 5f);
				maxSpawns = (int)(maxSpawns * 5f);
			}
			*/
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.Dryad)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.GoodieBags.PetGoodieBag>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Vanity.Lenny>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Accessories.Wings.BeautiflyWing>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Accessories.Wings.PhantomWing>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Accessories.Wings.FairyWing>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Accessories.Wings.FreedomWing>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Accessories.Wings.FadedWing>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Summon.BlueEyeBossSummonItem>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Summon.RedBrainBossSummonItem>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Summon.YellowIchorBossSummonItem>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Summon.GreenBeeBossSummonItem>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Summon.PurpleSlimeBossSummonItem>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Summon.WhiteFlyingFishBossSummonItem>());
				nextSlot++;
			}
            else if (type == NPCID.Wizard)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType<Items.GoodieBags.RedShardBag>());
                nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.GoodieBags.GreenShardBag>());
                nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.GoodieBags.BlueShardBag>());
                nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.GoodieBags.PurpleShardBag>());
                nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.GoodieBags.YellowShardBag>());
                nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType<Items.GoodieBags.WhiteShardBag>());
                nextSlot++;
            }
		}

		public override void GetChat(NPC npc, ref string chat)
		{
			if (Main.LocalPlayer.HasBuff(BuffID.Stinky))
			{
				switch (Main.rand.Next(3))
				{
					case 0:
						chat = "Eugh, you smell of rancid fish!";
						break;
					case 1:
						chat = "What's that horrid smell?!";
						break;
					default:
						chat = "Get away from me, i'm not doing any business with you.";
						break;
				}
			}
		}

		// If the player clicks any chat button and has the stinky debuff, prevent the button from working.
		public override bool PreChatButtonClicked(NPC npc, bool firstButton)
		{
			return !Main.LocalPlayer.HasBuff(BuffID.Stinky);
		}
	}
}
