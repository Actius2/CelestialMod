using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Initializers;
using Terraria.IO;
using Terraria.GameContent;
using Terraria.ModLoader;
using System.Linq;
using Terraria.UI;
using Terraria.GameContent.UI;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Backgrounds
{
	public class VoidUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle() {
			
			return Main.LocalPlayer.GetModPlayer<CelestialModPlayer>().ZoneVoid;
		}

		public override void FillTextureArray(int[] textureSlots) {
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/VoidBiomeUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/VoidBiomeUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/VoidBiomeUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/VoidBiomeUG3");
		}
	}
}