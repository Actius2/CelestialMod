using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;

namespace CelestialMod.Tiles.Blocks
{
	public class VoidicGrass : ModTile
	{
		public Texture2D glowTex;
        public bool glow = true;
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = false;
			Main.tileSolid[Type] = true;
			Main.tileMerge[Type][mod.TileType("VoidicStone")] = true;
			Main.tileMerge[Type][mod.TileType("VoidicSoil")] = true;
			Main.tileBlendAll[this.Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			TileID.Sets.JungleSpecial[Type] = true;
			Main.tileLighted[Type] = false;
			AddMapEntry(new Color(86, 60, 58));
			drop = mod.ItemType("VoidicGrassBlock");
			SetModTree(new Trees.VoidTree());
		}
		
		
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            int height = tile.frameY == 36 ? 18 : 16;
            Main.spriteBatch.Draw(mod.GetTexture("Glowmasks/VoidicGrass_Glow"), new Vector2((i * 16) - (int)Main.screenPosition.X, (j * 16) - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
		
		public static bool PlaceObject(int x, int y, int type, bool mute = false, int style = 0, int alternate = 0, int random = -1, int direction = -1)
		{
			TileObject toBePlaced;
			if (!TileObject.CanPlace(x, y, type, style, direction, out toBePlaced, false))
			{
				return false;
			}
			toBePlaced.random = random;
			if (TileObject.Place(toBePlaced) && !mute)
			{
				WorldGen.SquareTileFrame(x, y, true);
				//   Main.PlaySound(0, x * 16, y * 16, 1, 1f, 0f);
			}
			return false;
		}

		public override void RandomUpdate(int i, int j)
		{
			if (!Framing.GetTileSafely(i, j-1).active() && Main.rand.Next(10) == 0)
			{
				switch (Main.rand.Next(7))
				{
					case 0:
						VoidicGrass.PlaceObject(i, j-1, mod.TileType("VoidGrassA1"));
						NetMessage.SendObjectPlacment(-1, i, j-1, mod.TileType("VoidGrassA1"), 0, 0, -1, -1);
						break;
					case 1:
						VoidicGrass.PlaceObject(i, j-1, mod.TileType("VoidGrassA2"));
						NetMessage.SendObjectPlacment(-1, i, j-1, mod.TileType("VoidGrassA2"), 0, 0, -1, -1);
						break;
					case 2:
						VoidicGrass.PlaceObject(i, j-1, mod.TileType("VoidGrassA3"));
						NetMessage.SendObjectPlacment(-1, i, j-1, mod.TileType("VoidGrassA3"), 0, 0, -1, -1);
						break;
					case 3:
						VoidicGrass.PlaceObject(i, j-1, mod.TileType("VoidGrassA4"));
						NetMessage.SendObjectPlacment(-1, i, j-1, mod.TileType("VoidGrassA4"), 0, 0, -1, -1);
						break;
					case 4:
						VoidicGrass.PlaceObject(i, j-1, mod.TileType("VoidGrassA5"));
						NetMessage.SendObjectPlacment(-1, i, j-1, mod.TileType("VoidGrassA5"), 0, 0, -1, -1);
						break;
					case 5:
						VoidicGrass.PlaceObject(i, j-1, mod.TileType("VoidGrassA6"));
						NetMessage.SendObjectPlacment(-1, i, j-1, mod.TileType("VoidGrassA6"), 0, 0, -1, -1);
						break;

					default:
						VoidicGrass.PlaceObject(i, j-1, mod.TileType("VoidGrassA7"));
						NetMessage.SendObjectPlacment(-1, i, j-1, mod.TileType("VoidGrassA7"), 0, 0, -1, -1);
						break;
				}

			}


		}

		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return mod.TileType("VoidSapling");
		}
	}
}


