using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Players
{
	public class ShardOverDriveArmorPlayer : ModPlayer
	{
		public bool blueOverDrive;
		public bool greenOverDrive;
		public bool purpleOverDrive;
		public bool redOverDrive;
		public bool yellowOverDrive;
		public bool whiteOverDrive;

		private int greenHealCooldown;
		private int purpleManaCooldown;

		public override void ResetEffects()
		{
			blueOverDrive = false;
			greenOverDrive = false;
			purpleOverDrive = false;
			redOverDrive = false;
			yellowOverDrive = false;
			whiteOverDrive = false;
		}

		public override void PostUpdate()
		{
			if (greenHealCooldown > 0)
			{
				greenHealCooldown--;
			}

			if (purpleManaCooldown > 0)
			{
				purpleManaCooldown--;
			}

			if (Player.whoAmI != Main.myPlayer || Player.miscCounter % 18 != 0)
			{
				return;
			}

			if (blueOverDrive)
			{
				ArmorDust(DustID.Electric, new Color(90, 180, 255));
			}

			if (greenOverDrive)
			{
				ArmorDust(DustID.GreenTorch, new Color(80, 255, 120));
			}

			if (purpleOverDrive)
			{
				ArmorDust(DustID.PurpleTorch, new Color(190, 110, 255));
			}

			if (redOverDrive)
			{
				ArmorDust(DustID.Torch, new Color(255, 80, 60));
			}

			if (yellowOverDrive)
			{
				ArmorDust(DustID.YellowTorch, new Color(255, 230, 80));
			}

			if (whiteOverDrive)
			{
				ArmorDust(DustID.WhiteTorch, new Color(235, 250, 255));
			}
		}

		public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
		{
			ApplyShardHitEffects(item.DamageType, target);
		}

		public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
		{
			ApplyShardHitEffects(proj.DamageType, target);
		}

		private void ApplyShardHitEffects(DamageClass damageType, NPC target)
		{
			if (redOverDrive && CountsAs(damageType, DamageClass.Melee))
			{
				target.AddBuff(BuffID.OnFire3, 240);
			}

			if (yellowOverDrive && CountsAs(damageType, DamageClass.Ranged))
			{
				target.AddBuff(BuffID.Ichor, 180);
				Player.AddBuff(BuffID.Swiftness, 180);
			}

			if (blueOverDrive && (CountsAs(damageType, DamageClass.Magic) || CountsAs(damageType, DamageClass.Ranged)))
			{
				target.AddBuff(BuffID.Electrified, 180);
			}

			if (whiteOverDrive && CountsAs(damageType, DamageClass.Magic))
			{
				target.AddBuff(BuffID.Frostburn2, 180);
			}

			if (greenOverDrive && CountsAs(damageType, DamageClass.Summon) && greenHealCooldown <= 0)
			{
				greenHealCooldown = 120;
				int heal = 3;
				Player.statLife = Utils.Clamp(Player.statLife + heal, 0, Player.statLifeMax2);
				Player.HealEffect(heal);
			}

			if (purpleOverDrive && (CountsAs(damageType, DamageClass.Magic) || CountsAs(damageType, DamageClass.Summon)) && purpleManaCooldown <= 0)
			{
				purpleManaCooldown = 90;
				int mana = 8;
				Player.statMana = Utils.Clamp(Player.statMana + mana, 0, Player.statManaMax2);
				Player.ManaEffect(mana);
				target.AddBuff(BuffID.ShadowFlame, 180);
			}
		}

		private static bool CountsAs(DamageClass actual, DamageClass expected)
		{
			return actual == expected || actual.CountsAsClass(expected);
		}

		private void ArmorDust(int dustId, Color color)
		{
			int dust = Dust.NewDust(Player.position, Player.width, Player.height, dustId);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 0.2f;
			Main.dust[dust].color = color;
		}
	}
}
