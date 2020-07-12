using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.GameContent.Events;
using Terraria.Utilities;
using Terraria.Graphics.Effects;
using Terraria.Localization;
using SubworldLibrary;
using Terraria.World.Generation;


namespace CelestialMod
 {
	 public class GenUtils
		{
			public static void ObjectPlace(Point Origin, int x, int y, int TileType)
			{
				WorldGen.PlaceObject(Origin.X + x, Origin.Y + y, TileType);
				NetMessage.SendObjectPlacment(-1, Origin.X + x, Origin.Y + y, TileType, 0, 0, -1, -1);
			}
			public static void ObjectPlace(int x, int y, int TileType)
			{
				WorldGen.PlaceObject(x, y, TileType);
				NetMessage.SendObjectPlacment(-1, x, y, TileType, 0, 0, -1, -1);
			}
			public static void ObjectPlaceRand1(Point Origin, int x, int y, int TileType)
			{
				WorldGen.PlaceObject(Origin.X + x, Origin.Y + y, TileType, false, WorldGen.genRand.Next(3));
				NetMessage.SendObjectPlacment(-1, Origin.X + x, Origin.Y + y, TileType, WorldGen.genRand.Next(3), 0, -1, -1);
			}
			public static void ObjectPlaceRand1(int x, int y, int TileType)
			{
				WorldGen.PlaceObject(x, y, TileType, false, WorldGen.genRand.Next(3));
				NetMessage.SendObjectPlacment(-1, x, y, TileType, WorldGen.genRand.Next(3), 0, -1, -1);
			}
		}
 }