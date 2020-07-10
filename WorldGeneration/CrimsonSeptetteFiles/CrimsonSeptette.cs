using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.Utilities;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using BaseMod;
using CelestialMod.Tiles;

namespace CelestialMod.WorldGeneration
{ 
    public class CrimsonSeptetteDelete : MicroBiome
    {

         Texture2D CrimsonSeptetteBegin = null;

         Texture2D CrimsonSeptetteWalls = null;

        public override bool Place(Point origin, StructureMap structures)
        {
            //this handles generating the actual tiles, but you still need to add things like treegen etc. I know next to nothing about treegen so you're on your own there, lol.

            Mod mod = CelestialMod.instance;
            int worldSize = GetWorldSize();
            int biomeRadius = worldSize == 3 ? 400 : worldSize == 2 ? 300 : 200;

            Dictionary<Color, int> colorToTile = new Dictionary<Color, int>();
            colorToTile[new Color(0, 0, 255)] = -2;
            colorToTile[Color.Black] = -1; //don't touch when genning				


            Texture2D yeet = mod.GetTexture("WorldGeneration/CrimsonSeptetteFiles/CrimsonSeptetteDelete");

            if (CrimsonSeptetteBegin == null)
            {
                CrimsonSeptetteBegin = yeet;
            }

            TexGen gen = BaseWorldGenTex.GetTexGenerator(yeet, colorToTile);
            Point newOrigin = new Point(origin.X, origin.Y); //biomeRadius);

            WorldUtils.Gen(newOrigin, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[] //remove all fluids in sphere...
            {
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new Actions.SetLiquid(0, 0)
            }));
            WorldUtils.Gen(new Point(origin.X, origin.Y - 60), new Shapes.Rectangle(gen.width, gen.height), Actions.Chain(new GenAction[] //remove all fluids in the volcano...
            {
                new Actions.SetLiquid(0, 0)
            }));
			
			int genX = origin.X;
            int genY = origin.Y - 60;
            gen.Generate(genX, genY, true, true);

            return true;
        }
        public static int GetWorldSize()
        {
            if (Main.maxTilesX == 4200) { return 1; }
            else if (Main.maxTilesX == 6400) { return 2; }
            else if (Main.maxTilesX == 8400) { return 3; }
            return 1; //unknown size, assume small
        }
    }
    
    public class CrimsonSeptette : MicroBiome
    {
        Texture2D CrimsonSeptetteBegin = null;

        Texture2D CrimsonSeptetteWalls = null;

        public override bool Place(Point origin, StructureMap structures)
        {
            //this handles generating the actual tiles, but you still need to add things like treegen etc. I know next to nothing about treegen so you're on your own there, lol.

            Mod mod = CelestialMod.instance;
            int worldSize = GetWorldSize();
            int biomeRadius = worldSize == 3 ? 400 : worldSize == 2 ? 300 : 200;

            Dictionary<Color, int> colorToTile = new Dictionary<Color, int>();
            colorToTile[new Color(0, 0, 255)] = mod.TileType("VoidicGrass");
            colorToTile[new Color(0, 255, 0)] = mod.TileType("VoidicStone");
			colorToTile[new Color(0, 125, 0)] = mod.TileType("VoidicMud");
			colorToTile[new Color(0, 191, 255)] = mod.TileType("CelestialRemnantsTempleTile");
			colorToTile[new Color(127, 0, 55)] = mod.TileType("GloomWoodPlatform");
			colorToTile[new Color(128, 128, 128)] = TileID.Spikes;
            colorToTile[new Color(255, 0, 0)] = -2; //turn into air
            colorToTile[Color.Black] = -1; //don't touch when genning		

            Dictionary<Color, int> colorToWall = new Dictionary<Color, int>();
            colorToWall[new Color(0, 0, 255)] = mod.WallType("VoidicSoilWall");
			colorToWall[new Color(255, 0, 110)] = mod.WallType("CelestialRemnantsTempleWall");
		
            colorToWall[new Color(255, 0, 0)] = -2;
            colorToWall[Color.Black] = -1; //don't touch when genning				
            

            Texture2D yeet1 = mod.GetTexture("WorldGeneration/CrimsonSeptetteFiles/CrimsonSeptette");
            Texture2D yeet2 = mod.GetTexture("WorldGeneration/CrimsonSeptetteFiles/CrimsonSeptetteWall");

            if (CrimsonSeptetteBegin == null)
            {
                    CrimsonSeptetteBegin = yeet1;

                    CrimsonSeptetteWalls = yeet2;
            }
            
			TexGen gen = BaseWorldGenTex.GetTexGenerator(CrimsonSeptetteBegin, colorToTile, CrimsonSeptetteWalls, colorToWall);
            Point newOrigin = new Point(origin.X, origin.Y); //biomeRadius);
			
			WorldUtils.Gen(newOrigin, new Shapes.Circle(biomeRadius), Actions.Chain(new GenAction[] //remove all fluids in sphere...
            {
                new Modifiers.RadialDither(biomeRadius - 5, biomeRadius),
                new Actions.SetLiquid(0, 0)
            }));
            WorldUtils.Gen(new Point(origin.X, origin.Y - 60), new Shapes.Rectangle(gen.width, gen.height), Actions.Chain(new GenAction[] //remove all fluids in the volcano...
            {
                new Actions.SetLiquid(0, 0)
            }));
			
			int genX = origin.X;
            int genY = origin.Y - 60;
            gen.Generate(genX, genY, true, true);
            
			return true;
        }
        public static int GetWorldSize()
        {
            if (Main.maxTilesX == 4200) { return 1; }
            else if (Main.maxTilesX == 6400) { return 2; }
            else if (Main.maxTilesX == 8400) { return 3; }
            return 2; //unknown size, assume small
        }
    }
    public class RadialDitherTopMiddle3 : GenAction
	{
		private int _width, _height;
		private float _innerRadius, _outerRadius;

		public RadialDitherTopMiddle3(int width, int height, float innerRadius, float outerRadius)
		{
			_width = width;
			_height = height;
			_innerRadius = innerRadius;
			_outerRadius = outerRadius;
		}

		public override bool Apply(Point origin, int x, int y, params object[] args)
		{
			Vector2 value = new Vector2((float)origin.X + (_width / 2), (float)origin.Y);
			Vector2 value2 = new Vector2((float)x, (float)y);
			float num = Vector2.Distance(value2, value);
			float num2 = Math.Max(0f, Math.Min(1f, (num - this._innerRadius) / (this._outerRadius - this._innerRadius)));
			if (_random.NextDouble() > (double)num2)
			{
				return UnitApply(origin, x, y, args);
			}
			return Fail();
		}
	}	
}