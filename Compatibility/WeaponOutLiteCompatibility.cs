using System;
using Terraria.ModLoader;

namespace VinesMod.Compatibility
{
	public class WeaponOutLiteCompatibility : ModSystem
	{
		public override void PostSetupContent()
		{
			if (!ModLoader.TryGetMod("WeaponOutLite", out Mod weaponOutLite))
			{
				return;
			}

			TryRegister(weaponOutLite, "RegisterYoyo", new int[]
			{
				ModContent.ItemType<global::VinesMod.Items.Weapons.Yoyo.Dreamy>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Yoyo.Meteor>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Yoyo.RektU3000>()
			});

			TryRegister(weaponOutLite, "RegisterBow", new int[]
			{
				ModContent.ItemType<global::VinesMod.Items.Weapons.Bow.Avalanche>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Bow.AvalancheEx>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Bow.AvalancheOverDrive>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Bow.Phantom>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Bow.StormbowOverDrive>()
			});

			TryRegister(weaponOutLite, "RegisterGun", new int[]
			{
				ModContent.ItemType<global::VinesMod.Items.Weapons.Gun.BedGun>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Gun.SpectreBook>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Gun.StarForceCannon>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Gun.StarForceCannonOverDrive>()
			});

			TryRegister(weaponOutLite, "RegisterMagicBook", new int[]
			{
				ModContent.ItemType<global::VinesMod.Items.Weapons.Magic.LaserBook>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Magic.RainbowCannon>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Magic.RainbowCannonOverDrive>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Magic.RainbowPrism>()
			});

			TryRegister(weaponOutLite, "RegisterStaff", new int[]
			{
				ModContent.ItemType<global::VinesMod.Items.Weapons.Magic.BallisticStaff>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Magic.FirebeamStaff>()
			});

			TryRegister(weaponOutLite, "RegisterSpear", new int[]
			{
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.InfernoSpike>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Throw.DirtJavelin>()
			});

			TryRegister(weaponOutLite, "RegisterLargeMelee", new int[]
			{
				ModContent.ItemType<global::VinesMod.Items.Weapons.DualUse.GoldenGunBlade>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.ArcaneBright>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.Claymore>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.CodeO>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.CodeOOverDrive>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.CrystalBlood>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.CrystalBloodOverDrive>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.DeathStorm>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.DeathStormOverDrive>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.FrostPain>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.GrassDefender>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.MeowmereOverDrive>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.Reboot>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.RebootOverDrive>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.StarFall>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.StarWrathOverDrive>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.WeaponNull>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.ZeoxingBlade>()
			});

			TryRegister(weaponOutLite, "RegisterSmallMelee", new int[]
			{
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.BronzeSculptor>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.EnchantedSabre>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.FieryWarblade>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.GiantPenis>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.KendoSword>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.LilacGuardian>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.MoonlightGreatSword>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.SnakeKatana>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.SteelWarblade>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.ThunderBleu>(),
				ModContent.ItemType<global::VinesMod.Items.Weapons.Melee.WhiteFishSword>()
			});
		}

		private void TryRegister(Mod weaponOutLite, string method, int[] itemTypes)
		{
			try
			{
				weaponOutLite.Call(method, itemTypes);
			}
			catch (Exception ex)
			{
				Mod.Logger.Warn($"WeaponOutLite compatibility call '{method}' failed: {ex.Message}");
			}
		}
	}
}
