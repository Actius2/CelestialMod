using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialMod.Walls.GloomBiome
{
    public class WaterfallWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = false;
            AddMapEntry(new Color(79, 140, 36));
            soundType = 6;
            dustType = 2;
			drop = ModContent.ItemType<Items.Walls.WaterfallWallBlock>();
        }
	
		public override void AnimateWall(ref byte frame, ref byte frameCounter)
        {
            frame = (byte)Main.tileFrame[TileID.Waterfall];
			frameCounter = (byte)Main.tileFrameCounter[TileID.Waterfall];
		}
	}
}





 