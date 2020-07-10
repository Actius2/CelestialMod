using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using BaseMod;
using CelestialMod.Tiles;
using CelestialMod.WorldGeneration;
using CelestialMod.Items;

namespace CelestialMod
{
    public class CelestialModWorld : ModWorld
    {
        private const int saveVersion = 0;
        public static bool downedBoss01 = false;
        public static bool Vulcanite;
        public static int VoidTiles = 0;
		public static int MysticTiles = 0;
        public static int NearVulcanite = 0;
        private Vector2 OvergrowthPos = new Vector2(0, 0);
		private Vector2 OvergrowthPos2 = new Vector2(0, 0);

        public override void Initialize()
        {
            downedBoss01 = false;
            Vulcanite = downedBoss01;
        }
        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedBoss01) downed.Add("WORMHEAD1");

            return new TagCompound {
                {"downed", downed}};
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedBoss01 = downed.Contains("WORMHEAD1");
            Vulcanite = downedBoss01;
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedBoss01 = flags[0];
            }
            else
            {
                mod.Logger.Info("I think we fucked up");
            }
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            VoidTiles = tileCounts[mod.TileType("VoidicStone")]+ tileCounts[mod.TileType("VoidicGrass")];
			
			MysticTiles = tileCounts[mod.TileType("MysticStone")]+ tileCounts[mod.TileType("MysticGrass")];

        }
	

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			int terrainIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Jungle"));
            int shiniesIndex2 = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
            
			
			tasks.Insert(shiniesIndex, new PassLegacy("FloweringNights", delegate (GenerationProgress progress)
                {
                    FloweringNights(progress);
                }));
			
			tasks.Insert(terrainIndex, new PassLegacy("CrimsonSeptette", delegate (GenerationProgress progress)
                {
                    CrimsonSeptette(progress);
                }));
        }

       private void FloweringNights(GenerationProgress progress)
        {
            int q1 = (int)WorldGen.rockLayer  - 10;
            OvergrowthPos.X = Main.maxTilesX * 0.71f;
            OvergrowthPos.Y = q1;
            progress.Message = "TEXT HERE!";
            FloweringNightsBegin();
        }

        public void FloweringNightsBegin()
        {
            Point origin = new Point((int)((int)OvergrowthPos.X), ((int)OvergrowthPos.Y)); ;
            origin.Y = BaseWorldGen.GetFirstTileFloor(origin.X, origin.Y, true);
            FloweringNightsDelete delete = new FloweringNightsDelete();
            FloweringNights biome = new FloweringNights();
            delete.Place(origin, WorldGen.structures);
            biome.Place(origin, WorldGen.structures);
		}
	   private void CrimsonSeptette(GenerationProgress progress)
        {
            int q2 = (int)WorldGen.worldSurface + 1;
            OvergrowthPos2.X = Main.maxTilesX * 0.50f;
            OvergrowthPos2.Y = q2;
            progress.Message = "TEXT HERE!2";
            CrimsonSeptetteBegin();
        }

        public void CrimsonSeptetteBegin()
        {
            Point origin = new Point((int)((int)OvergrowthPos2.X), ((int)OvergrowthPos2.Y)); ;
            origin.Y = BaseWorldGen.GetFirstTileFloor(origin.X, origin.Y, true);
			CrimsonSeptetteDelete delete = new CrimsonSeptetteDelete();
			CrimsonSeptette biome = new CrimsonSeptette();
            delete.Place(origin, WorldGen.structures);
            biome.Place(origin, WorldGen.structures);
        }
        
		public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedBoss01;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedBoss01 = flags[0];
        }

        public override void PostUpdate()
        {
            if (downedBoss01 == true)
            {
                if (Vulcanite == false)
                {
                    Vulcanite = true;
                    Main.NewText("A roar of flames quivers in the distance...", Color.OrangeRed.R, Color.OrangeRed.G, Color.Yellow.B);
                    for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
                    {
                        WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 300), WorldGen.genRand.Next(7, 10), WorldGen.genRand.Next(11, 12), (ushort)mod.TileType("VoidicSoil"));
                    }
                }
            }
        }
        // A helper method that draws a bordered rectangle. 
        public static void DrawBorderedRect(SpriteBatch spriteBatch, Color color, Color borderColor, Vector2 position, Vector2 size, int borderWidth)
        {
            spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), color);
            spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X - borderWidth, (int)position.Y - borderWidth, (int)size.X + borderWidth * 2, borderWidth), borderColor);
            spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X - borderWidth, (int)position.Y + (int)size.Y, (int)size.X + borderWidth * 2, borderWidth), borderColor);
            spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X - borderWidth, (int)position.Y, (int)borderWidth, (int)size.Y), borderColor);
            spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X + (int)size.X, (int)position.Y, (int)borderWidth, (int)size.Y), borderColor);
        }
    }
}
