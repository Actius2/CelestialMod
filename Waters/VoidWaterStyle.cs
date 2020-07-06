using CelestialMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Waters
{
	public class VoidWaterStyle : ModWaterStyle
	{
		public override bool ChooseWaterStyle()
			=> Main.bgStyle == mod.GetSurfaceBgStyleSlot("VoidSurfaceBgStyle");

		public override int ChooseWaterfallStyle() 
			=> mod.GetWaterfallStyleSlot("VoidWaterfallStyle");

		public override int GetSplashDust() 
			=> DustType<VoidWaterSplash>();

		public override int GetDropletGore() 
			=> mod.GetGoreSlot("Gores/VoidDroplet");

		public override void LightColorMultiplier(ref float r, ref float g, ref float b) {
			r = 1f;
			g = 1f;
			b = 1f;
		}

		public override Color BiomeHairColor() 
			=> Color.Black;
	}
}