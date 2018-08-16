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
			DisplayName.SetDefault("Shield Of Berserker");
			Tooltip.SetDefault("Allows Dash" + "\n lower health, higher damage, defense, movingspeed");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 8;
			item.accessory = true;
			item.defense = 45;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.statLife <= (player.statLifeMax2 * 0.7f))
			{
				player.meleeSpeed *= 1.2f;
				player.meleeDamage *= 1.15f;
				player.thrownDamage *= 1.15f;
				player.rangedDamage *= 1.15f;
				player.magicDamage *= 1.15f;
				player.minionDamage *= 1.15f;
				player.statDefense += 4;
				player.moveSpeed += 0.3f;
			}
			else if (player.statLife <= (player.statLifeMax2 * 0.5f))
			{
				player.meleeSpeed *= 1.4f;
				player.meleeDamage *= 1.2f;
				player.thrownDamage *= 1.2f;
				player.rangedDamage *= 1.2f;
				player.magicDamage *= 1.2f;
				player.minionDamage *= 1.2f;
				player.statDefense += 6;
				player.moveSpeed += 0.5f;
			}
			else if (player.statLife <= (player.statLifeMax2 * 0.3f))
			{
				player.meleeSpeed *= 1.6f;
				player.meleeDamage *= 1.3f;
				player.thrownDamage *= 1.3f;
				player.rangedDamage *= 1.3f;
				player.magicDamage *= 1.3f;
				player.minionDamage *= 1.3f;
				player.statDefense += 8;
				player.moveSpeed += 0.7f;
			}
			else if (player.statLife <= (player.statLifeMax2 * 0.15f))
			{
				player.meleeSpeed *= 1.8f;
				player.meleeDamage *= 1.3f;
				player.thrownDamage *= 1.3f;
				player.rangedDamage *= 1.3f;
				player.magicDamage *= 1.3f;
				player.minionDamage *= 1.3f;
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