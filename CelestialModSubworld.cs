using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using SubworldLibrary;
using Terraria.World.Generation;
using BaseMod;
using CelestialMod.WorldGeneration;

namespace CelestialMod
{
    public class CelestialModSubworld : Subworld
		{
			public override int width => 1800;
			public override int height => 1800;
			public override ModWorld modWorld => ModContent.GetInstance<ModWorld>();
			public override bool noWorldUpdate => true;
			public override bool saveSubworld => false;
			public override List<GenPass> tasks => new List<GenPass>()
			{
				new SubworldGenPass(1f, progress =>
				{
					progress.Message = "Loading";
					Main.spawnTileY = 100;
					Main.spawnTileX = 100;
					Main.worldSurface = 550;
					Main.rockLayer = 550;
					ChineseTeaHouse();
					AddTrees();
					
				}),
			};

			
			public static void ChineseTeaHouse()
			{
				Mod mod = CelestialMod.instance;
				Dictionary<Color, int> colorToTile = new Dictionary<Color, int>();
				colorToTile[new Color(0, 0, 255)] = mod.TileType("VoidicGrass");
				colorToTile[new Color(0, 255, 0)] = mod.TileType("VoidicStone");
				colorToTile[new Color(0, 125, 0)] = mod.TileType("VoidicMud");
				colorToTile[new Color(255, 0, 0)] = -2; //turn into air
				colorToTile[Color.Black] = -1; //don't touch when genning

				Dictionary<Color, int> colorToWall = new Dictionary<Color, int>();
				colorToWall[new Color(0, 0, 255)] = mod.WallType("VoidicSoilWall");
				colorToWall[new Color(255, 0, 0)] = -2;
				colorToWall[Color.Black] = -1; //don't touch when genning				
				
				TexGen gen = BaseWorldGenTex.GetTexGenerator(mod.GetTexture("WorldGeneration/ChineseTeaHouseFiles/ChineseTeaHouse"), colorToTile, mod.GetTexture("WorldGeneration/ChineseTeaHouseFiles/ChineseTeaHouseWalls"), colorToWall, mod.GetTexture("WorldGeneration/ChineseTeaHouseFiles/ChineseTeaHouseLiquids"), mod.GetTexture("WorldGeneration/ChineseTeaHouseFiles/ChineseTeaHouseSlopes"));
				gen.Generate(0, 0, true, true);
			}
			
			public static void AddTrees() {
				for (int i = 1; i < Main.maxTilesX - 1; i++) {
					for (int j = 20; (double)j < Main.worldSurface; j++) {
						WorldGen.GrowTree(i, j);
						if ((i < 380 || i > Main.maxTilesX - 380) && WorldGen.genRand.Next(3) == 0)
						WorldGen.GrowPalmTree(i, j);
					}
					
					if (WorldGen.genRand.Next(3) == 0)
						i++;
					
					if (WorldGen.genRand.Next(4) == 0)
						i++;
			
			
				}
			}


			public override void Load()
			{
				Main.dayTime = true;
				Main.time = 27000;
			}
	}
}