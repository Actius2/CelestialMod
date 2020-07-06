using CelestialMod.Dusts;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Tiles.Trees
{
	public class VoidTree : ModTree
	{
		private Mod mod => ModLoader.GetMod("CelestialMod");
		
		public override int GrowthFXGore() {
			return mod.GetGoreSlot("Gores/VoidTreeFX");
		}

		public override int DropWood() {
			return ItemType<Items.Placeable.VoidicWoodBlock>();
		}

		public override Texture2D GetTexture() {
			return mod.GetTexture("Tiles/Trees/VoidTree");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset) {
			return mod.GetTexture("Tiles/Trees/VoidTree_Tops");
		}
		
		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame) {
			return mod.GetTexture("Tiles/Trees/VoidTree_Branches");
		}
	}
} 