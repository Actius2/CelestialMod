using CelestialMod.Players;
using Terraria.ModLoader;

namespace CelestialMod.Backgrounds
{
	public class VoidUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle() {
			
			return CelestialModPlayer.Get().ZoneVoid;
		}

		public override void FillTextureArray(int[] textureSlots) {
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/VoidBiomeUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/VoidBiomeUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/VoidBiomeUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/VoidBiomeUG3");
		}
	}
}