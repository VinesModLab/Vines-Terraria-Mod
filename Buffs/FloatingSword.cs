using Terraria;
using Terraria.ModLoader;

namespace VinesMod.Buffs
{
	public class FloatingSword : ModBuff
	{
		int MinionType = -1;
		int MinionID = -1;

		int MinionType1 = -1;
		int MinionID1 = -1;

        int MinionType2 = -1;
		int MinionID2 = -1;

        int MinionType3 = -1;
		int MinionID3 = -1;

        int MinionType4 = -1;
		int MinionID4 = -1;

		const int Damage = 75;
		const float KB = 1;

		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Floating Swords");
			Description.SetDefault("Summons blades to protect you");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (MinionType == -1)
				MinionType = mod.ProjectileType("FloatYellowSword");
			if (MinionID == -1 || Main.projectile[MinionID].type != MinionType || !Main.projectile[MinionID].active || Main.projectile[MinionID].owner != player.whoAmI)
				MinionID = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, MinionType, (int)(Damage * player.meleeDamage), KB, player.whoAmI);
			else
				Main.projectile[MinionID].timeLeft = 6;

			if (MinionType1 == -1)
				MinionType1 = mod.ProjectileType("FloatBlueSword");
			if (MinionID1 == -1 || Main.projectile[MinionID1].type != MinionType1 || !Main.projectile[MinionID1].active || Main.projectile[MinionID1].owner != player.whoAmI)
				MinionID1 = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, MinionType1, (int)(Damage * player.meleeDamage), KB, player.whoAmI);
			else
				Main.projectile[MinionID1].timeLeft = 6;

            if (MinionType2 == -1)
				MinionType2 = mod.ProjectileType("FloatPurpleSword");
			if (MinionID2 == -1 || Main.projectile[MinionID2].type != MinionType2 || !Main.projectile[MinionID2].active || Main.projectile[MinionID2].owner != player.whoAmI)
				MinionID2 = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, MinionType2, (int)(Damage * player.meleeDamage), KB, player.whoAmI);
			else
				Main.projectile[MinionID2].timeLeft = 6;

            if (MinionType3 == -1)
				MinionType3 = mod.ProjectileType("FloatRedSword");
			if (MinionID3 == -1 || Main.projectile[MinionID3].type != MinionType3 || !Main.projectile[MinionID3].active || Main.projectile[MinionID3].owner != player.whoAmI)
				MinionID3 = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, MinionType3, (int)(Damage * player.meleeDamage), KB, player.whoAmI);
			else
				Main.projectile[MinionID3].timeLeft = 6;

            if (MinionType4 == -1)
				MinionType4 = mod.ProjectileType("FloatGreenSword");
			if (MinionID4 == -1 || Main.projectile[MinionID4].type != MinionType4 || !Main.projectile[MinionID4].active || Main.projectile[MinionID4].owner != player.whoAmI)
				MinionID4 = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, MinionType4, (int)(Damage * player.meleeDamage), KB, player.whoAmI);
			else
				Main.projectile[MinionID4].timeLeft = 6;
		}
	}
}