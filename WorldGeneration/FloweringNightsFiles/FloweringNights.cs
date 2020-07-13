using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace CelestialMod.WorldGeneration
{
    public class FloweringNightsDelete : MicroBiome
    {

         Texture2D FloweringNightsBegin = null;
         Texture2D FloweringNightsWalls = null;

        public override bool Place(Point origin, StructureMap structures)
        {
            //this handles generating the actual tiles, but you still need to add things like treegen etc. I know next to nothing about treegen so you're on your own there, lol.

            Mod mod = CelestialMod.instance;
            int worldSize = GetWorldSize();
            int biomeRadius = worldSize == 3 ? 400 : worldSize == 2 ? 300 : 200;

            Dictionary<Color, int> colorToTile = new Dictionary<Color, int>();
            colorToTile[new Color(0, 0, 255)] = -2;
            colorToTile[Color.Black] = -1; //don't touch when genning				


            Texture2D yeet = mod.GetTexture("WorldGeneration/FloweringNightsFiles/FloweringNightsDelete");

            if (FloweringNightsBegin == null)
            {
                FloweringNightsBegin = yeet;
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
    
    public class FloweringNights : MicroBiome
    {
        Texture2D FloweringNightsBegin = null;

        Texture2D FloweringNightsWalls = null;

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
            colorToTile[new Color(255, 0, 0)] = -2; //turn into air
            colorToTile[Color.Black] = -1; //don't touch when genning		

            Dictionary<Color, int> colorToWall = new Dictionary<Color, int>();
            colorToWall[new Color(0, 0, 255)] = mod.WallType("VoidicSoilWall");
            colorToWall[new Color(255, 0, 0)] = -2;
            colorToWall[Color.Black] = -1; //don't touch when genning				
            

            Texture2D yeet1 = mod.GetTexture("WorldGeneration/FloweringNightsFiles/FloweringNights");
            Texture2D yeet2 = mod.GetTexture("WorldGeneration/FloweringNightsFiles/FloweringNightsWall");

            if (FloweringNightsBegin == null)
            {
                    FloweringNightsBegin = yeet1;

                    FloweringNightsWalls = yeet2;
            }
            
			TexGen gen = BaseWorldGenTex.GetTexGenerator(FloweringNightsBegin, colorToTile, FloweringNightsWalls, colorToWall);
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
    public class RadialDitherTopMiddle4 : GenAction
	{
		private int _width, _height;
		private float _innerRadius, _outerRadius;

		public RadialDitherTopMiddle4(int width, int height, float innerRadius, float outerRadius)
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