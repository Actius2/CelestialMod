using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CelestialMod.Tiles.Ambient.VoidGrass
{
	public class VoidGrassA3 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileCut[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = true;
			//Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(Type);
			dustType = 2;
			soundType = 6;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 2;
		}



	}
}