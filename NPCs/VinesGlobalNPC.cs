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
		//public bool exampleJavelin = false;

		public override void ResetEffects(NPC npc)
		{
			eFlames = false;
			//exampleJavelin = false;
		}

		public override void SetDefaults(NPC npc)
		{
			// We want our ExampleJavelin buff to follow the same immunities as BoneJavelin
			//npc.buffImmune[mod.BuffType<Buffs.ExampleJavelin>()] = npc.buffImmune[BuffID.BoneJavelin];
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			/* 
			if (exampleJavelin)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				int exampleJavelinCount = 0;
				for (int i = 0; i < 1000; i++)
				{
					Projectile p = Main.projectile[i];
					if (p.active && p.type == mod.ProjectileType<Projectiles.ExampleJavelinProjectile>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
					{
						exampleJavelinCount++;
					}
				}
				npc.lifeRegen -= exampleJavelinCount * 2 * 3;
				if (damage < exampleJavelinCount * 3)
				{
					damage = exampleJavelinCount * 3;
				}
				
			}*/
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
				if (Main.rand.Next(10) == 0)
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


			/*
			if (npc.type == NPCID.DukeFishron && !Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Bubble"), Main.rand.Next(5, 8));
			}
			if (npc.type == NPCID.Bunny && npc.AnyInteractions())
			{
				int left = (int)(npc.position.X / 16f);
				int top = (int)(npc.position.Y / 16f);
				int right = (int)((npc.position.X + npc.width) / 16f);
				int bottom = (int)((npc.position.Y + npc.height) / 16f);
				bool flag = false;
				for (int i = left; i <= right; i++)
				{
					for (int j = top; j <= bottom; j++)
					{
						Tile tile = Main.tile[i, j];
						if (tile.active() && tile.type == mod.TileType("ElementalPurge") && !NPC.AnyNPCs(mod.NPCType("PuritySpirit")))
						{
							i -= Main.tile[i, j].frameX / 18;
							j -= Main.tile[i, j].frameY / 18;
							i = (i * 16) + 16;
							j = (j * 16) + 24 + 60;
							for (int k = 0; k < 255; k++)
							{
								Player player = Main.player[k];
								if (player.active && player.position.X > i - NPC.sWidth / 2 && player.position.X + player.width < i + NPC.sWidth / 2 && player.position.Y > j - NPC.sHeight / 2 && player.position.Y < j + NPC.sHeight / 2)
								{
									flag = true;
									break;
								}
							}
							if (flag)
							{
								NPC.NewNPC(i, j, mod.NPCType("PuritySpirit"));
								break;
							}
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
			*/
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
