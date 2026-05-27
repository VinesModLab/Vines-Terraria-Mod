using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.Shield
{
	[AutoloadEquip(EquipType.Shield)]
	public class ShieldOfBerserker : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.value = 10000;
			Item.rare = ItemRarityID.Yellow;
			Item.accessory = true;
			Item.defense = 15;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.statLife <= (player.statLifeMax2 * 0.7f))
			{
				player.GetAttackSpeed(DamageClass.Melee) *= 1.2f;
				player.GetDamage(DamageClass.Melee) *= 1.15f;
				player.GetDamage(DamageClass.Ranged) *= 1.15f;
				player.GetDamage(DamageClass.Magic) *= 1.15f;
				player.GetDamage(DamageClass.Summon) *= 1.15f;
				player.statDefense += 4;
				player.moveSpeed += 0.3f;
			}
			else if (player.statLife <= (player.statLifeMax2 * 0.5f))
			{
				player.GetAttackSpeed(DamageClass.Melee) *= 1.4f;
				player.GetDamage(DamageClass.Melee) *= 1.2f;
				player.GetDamage(DamageClass.Ranged) *= 1.2f;
				player.GetDamage(DamageClass.Magic) *= 1.2f;
				player.GetDamage(DamageClass.Summon) *= 1.2f;
				player.statDefense += 6;
				player.moveSpeed += 0.5f;
			}
			else if (player.statLife <= (player.statLifeMax2 * 0.3f))
			{
				player.GetAttackSpeed(DamageClass.Melee) *= 1.6f;
				player.GetDamage(DamageClass.Melee) *= 1.3f;
				player.GetDamage(DamageClass.Ranged) *= 1.3f;
				player.GetDamage(DamageClass.Magic) *= 1.3f;
				player.GetDamage(DamageClass.Summon) *= 1.3f;
				player.statDefense += 8;
				player.moveSpeed += 0.7f;
			}
			else if (player.statLife <= (player.statLifeMax2 * 0.2f))
			{
				player.GetAttackSpeed(DamageClass.Melee) *= 1.8f;
				player.GetDamage(DamageClass.Melee) *= 1.3f;
				player.GetDamage(DamageClass.Ranged) *= 1.3f;
				player.GetDamage(DamageClass.Magic) *= 1.3f;
				player.GetDamage(DamageClass.Summon) *= 1.3f;
				player.statDefense += 16;
				player.moveSpeed += 1f;
			}
				player.dash = 1;
		}

		public override void AddRecipes()
		{
		}
	}
}
