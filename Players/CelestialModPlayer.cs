using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CelestialMod.Players
{
	public sealed partial class CelestialModPlayer : ModPlayer
	{
		public override void Initialize()
		{
			InitializeHallowing();
		}

		public override void UpdateBiomeVisuals() 
		{
			player.ManageSpecialBiomeVisuals("CelestialMod:VoidSky", ZoneVoid, player.Center);
		
		}
		// Why does this exist? What purpose does this serve?
		//public bool mediumcoreDeath = false;

		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath) {
			Item item5 = new Item();
            item5.SetDefaults(mod.ItemType("CoinBag"));
            item5.stack = 1;
            items.Add(item5);
		}

		public override void ResetEffects()
		{
			ResetHallowingEffects();
		}

		//Perhaps not useful now, will be later
		// Allows us to get reference to modplayer by doing CelestialModPlayer.Get()
		public static CelestialModPlayer Get() => Main.LocalPlayer.GetModPlayer<CelestialModPlayer>();

		public static CelestialModPlayer Get(Player player) => player.GetModPlayer<CelestialModPlayer>();

		public bool ZoneVoid => CelestialModWorld.VoidTiles > 50;
		public bool ZoneMystic => CelestialModWorld.MysticTiles > 50;
	}
}
