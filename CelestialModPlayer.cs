using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using CelestialMod;
using CelestialMod.Backgrounds;

namespace CelestialMod
{
	public class CelestialModPlayer : ModPlayer
	{
		public bool ZoneVoid = false;
		public bool ZoneMystic = false;
		
		public override void UpdateBiomes()
        {    
            ZoneVoid = CelestialModWorld.VoidTiles > 50;
			ZoneMystic = CelestialModWorld.MysticTiles > 50;
        }
		public override void UpdateBiomeVisuals() 
		{
			player.ManageSpecialBiomeVisuals("CelestialMod:VoidSky", ZoneVoid, player.Center);
		
		}
		public bool mediumcoreDeath = false;
		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath) {
			Item item5 = new Item();
            item5.SetDefaults(mod.ItemType("CoinBag"));
            item5.stack = 1;
            items.Add(item5);
		}
	}
}
