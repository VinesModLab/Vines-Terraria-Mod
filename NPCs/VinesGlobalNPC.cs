using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using VinesMod.Systems;

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
			npc.buffImmune[ModContent.BuffType<Buffs.DirtJavelin>()] = npc.buffImmune[BuffID.BoneJavelin];
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
					if (p.active && p.type == ModContent.ProjectileType<global::VinesMod.Projectiles.DirtJavelinProjectile>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
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

		/// <summary>
		/// Ordinary raw shard drops for weak/mid NPCs.
		/// Boss-specific drops (summon items, goodie bags, end-tier mats) stay in OnKill
		/// because they depend on runtime conditions not expressible as static rules.
		/// </summary>
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			// White Shards are the common raw material. Colored shards are charged upgrades.
			if (npc.lifeMax > 10 && npc.value > 0f && npc.lifeMax < 2000)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<global::VinesMod.Items.Materials.Shards.ShardWhite>(), 3, 1, 3));
			}
		}

		public override void OnKill(NPC npc)
		{
			/*
			if (npc.lifeMax > 5 && npc.value > 0f)
			{
				//Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ExampleItem>());
				if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExamplePlayer>(mod).ZoneExample)
				{
					//Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BossItem>());
				}
			}
			*/

			// NOTE: Common shard drops (lifeMax 10–2000) have been moved to ModifyNPCLoot above.

			if (npc.lifeMax > 50 && npc.lifeMax < 3000 && npc.value > 0f)
			{
				if (Main.rand.Next(15) == 0)
				{
					switch (Main.rand.Next(6))
            		{
                	case 0:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.Summon.BlueEyeBossSummonItem>(), 1);
                	break;
                	case 1:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.Summon.GreenBeeBossSummonItem>(), 1);
                	break;
                	case 2:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.Summon.PurpleSlimeBossSummonItem>(), 1);
                	break;
                	case 3:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.Summon.RedBrainBossSummonItem>(), 1);
               		break;
                	case 4:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.Summon.YellowIchorBossSummonItem>(), 1);
					break;
					case 5:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.Summon.WhiteFlyingFishBossSummonItem>(), 1);
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
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.GoodieBags.BlueShardBag>(), 1);
                	break;
                	case 1:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.GoodieBags.GreenShardBag>(), 1);
                	break;
                	case 2:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.GoodieBags.PurpleShardBag>(), 1);
                	break;
                	case 3:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.GoodieBags.RedShardBag>(), 1);
               		break;
                	case 4:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.GoodieBags.YellowShardBag>(), 1);
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
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.GoodieBags.BlueShardBag>(), 2);
                	break;
                	case 1:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.GoodieBags.GreenShardBag>(), 2);
                	break;
                	case 2:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.GoodieBags.PurpleShardBag>(), 2);
                	break;
                	case 3:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.GoodieBags.RedShardBag>(), 2);
               		break;
                	case 4:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.GoodieBags.YellowShardBag>(), 2);
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
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.Materials.EndTier.DarkMatter>(), 1);
                	break;
                	case 1:
                	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<global::VinesMod.Items.Materials.EndTier.LightMatter>(), 1);
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
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<global::VinesMod.Dusts.EtherealFlame>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
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
			if (ShardInvasionSystem.Active && ShardInvasionSystem.CanSpawnFor(player))
			{
				spawnRate = 18;
				maxSpawns = 12;
			}
		}

		public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
		{
			if (ShardInvasionSystem.Active && ShardInvasionSystem.CanSpawnFor(spawnInfo.Player))
			{
				pool.Clear();
				pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.BlueFlyingEye>()] = 0.35f;
				pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.PrismaticShardling>()] = 0.85f;
				pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.FallenStarMite>()] = 0.60f;

				if (ShardInvasionSystem.Defeated >= 12)
				{
					pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.CosmicWisp>()] = 0.32f;
					pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.ShardCrawler>()] = 0.55f;
					pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.VoidQuartzBat>()] = 0.35f;
				}

				if (ShardInvasionSystem.Defeated >= 24)
				{
					pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.RubyShardKnight>()] = 0.42f;
					pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.EmeraldShardBloom>()] = 0.30f;
					pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.TopazStormcaller>()] = 0.28f;
					pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.AmethystMirror>()] = 0.24f;
				}

				if (ShardInvasionSystem.Defeated >= 45)
				{
					pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.WhitePrismSentinel>()] = 0.22f;
					pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.PrismHerald>()] = 0.06f;
					pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.ShardComet>()] = 0.04f;
				}

				if (ShardInvasionSystem.Defeated >= 70 || ShardInvasionSystem.Remaining <= 20)
				{
					pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.PrismHerald>()] = 0.08f;
					pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.ShardComet>()] = 0.06f;
					pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.NullCrystalMaw>()] = 0.05f;
					pool[ModContent.NPCType<global::VinesMod.NPCs.Hostile.ShardsMonster.AstralShardSerpent>()] = 0.04f;
				}
			}
		}

		public override void ModifyShop(NPCShop shop)
		{
			if (shop.NpcType == NPCID.Dryad)
			{
				shop.Add<global::VinesMod.Items.GoodieBags.PetGoodieBag>();
				shop.Add<global::VinesMod.Items.Vanity.Lenny>();
				shop.Add<global::VinesMod.Items.Accessories.Wings.BeautiflyWing>();
				shop.Add<global::VinesMod.Items.Accessories.Wings.PhantomWing>();
				shop.Add<global::VinesMod.Items.Accessories.Wings.FairyWing>();
				shop.Add<global::VinesMod.Items.Accessories.Wings.FreedomWing>();
				shop.Add<global::VinesMod.Items.Accessories.Wings.FadedWing>();
				shop.Add<global::VinesMod.Items.Summon.ShardMonstersInvasionItem>();
				shop.Add<global::VinesMod.Items.Summon.BlueEyeBossSummonItem>();
				shop.Add<global::VinesMod.Items.Summon.RedBrainBossSummonItem>();
				shop.Add<global::VinesMod.Items.Summon.YellowIchorBossSummonItem>();
				shop.Add<global::VinesMod.Items.Summon.GreenBeeBossSummonItem>();
				shop.Add<global::VinesMod.Items.Summon.PurpleSlimeBossSummonItem>();
				shop.Add<global::VinesMod.Items.Summon.WhiteFlyingFishBossSummonItem>();
            }
            else if (shop.NpcType == NPCID.Wizard)
            {
				shop.Add<global::VinesMod.Items.GoodieBags.WhiteShardBag>();
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
