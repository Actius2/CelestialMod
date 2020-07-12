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
using Terraria.Utilities;

namespace CelestialMod.WorldGeneration
{
	public class ImmortalSmoke : MicroBiome
    {
		public override bool Place(Point origin, StructureMap structures)
        {
				Mod mod = CelestialMod.instance;
				Texture2D ObjectTex = mod.GetTexture("WorldGeneration/ImmortalSmokeFiles/ImmortalSmokeObjects");

				Dictionary<Color, int> colorToObj = new Dictionary<Color, int>
				{
					[new Color(1, 0, 0)] = TileID.AmberGemspark,
					[new Color(2, 0, 0)] = TileID.AmethystGemspark,
					[new Color(3, 0, 0)] = TileID.AmethystGemsparkOff,
					[new Color(4, 0, 0)] = TileID.DiamondGemspark,
					[new Color(5, 0, 0)] = TileID.EmeraldGemspark,
					[new Color(6, 0, 0)] = TileID.EmeraldGemsparkOff,
					[new Color(7, 0, 0)] = TileID.RubyGemspark,
					[new Color(8, 0, 0)] = TileID.RubyGemsparkOff,
					[new Color(9, 0, 0)] = TileID.SapphireGemspark,
					[new Color(10, 0, 0)] = TileID.TopazGemspark,
					[new Color(11, 0, 0)] = TileID.TopazGemsparkOff,
					[new Color(12, 0, 0)] = TileID.AmberGemsparkOff,
					[new Color(13, 0, 0)] = TileID.DiamondGemsparkOff,
					[new Color(14, 0, 0)] = TileID.SapphireGemsparkOff,
					[new Color(15, 0, 0)] = TileID.TeamBlockBlue,
					[new Color(16, 0, 0)] = TileID.TeamBlockGreen,
					[new Color(17, 0, 0)] = TileID.TeamBlockPink,
					[new Color(18, 0, 0)] = TileID.TeamBlockRed,
					[new Color(19, 0, 0)] = TileID.TeamBlockWhite,
					[new Color(20, 0, 0)] = TileID.TeamBlockYellow,
					[new Color(21, 0, 0)] = TileID.GrayStucco,
					[Color.Black] = -1
				};

				TexGen gen3 = BaseWorldGenTex.GetTexGenerator(ObjectTex, colorToObj, null, null, mod.GetTexture
				("WorldGeneration/ImmortalSmokeFiles/ImmortalSmokeObjects"), null);
				gen3.Generate(0, 0, true, true);

				int x2;
				int y2;

				for (x2 = 0; x2 < 0 + ObjectTex.Width; x2++)
				{
					for (y2 = 0; y2 < 0 + ObjectTex.Height; y2++)
					{
						if (Main.tile[x2, y2].type == TileID.AmberGemspark)
						{
							Main.tile[x2, y2].ClearTile();
							GenUtils.ObjectPlace(x2, y2, ModContent.TileType<Tiles.Furniture.GloomWood.GloomWoodBed>());
						}
						if (Main.tile[x2, y2].type == TileID.AmethystGemspark)
						{
							Main.tile[x2, y2].ClearTile();
							GenUtils.ObjectPlace(x2, y2, ModContent.TileType<Tiles.Furniture.GloomWood.GloomWoodChair>());
						}
						if (Main.tile[x2, y2].type == TileID.AmethystGemsparkOff)
						{
							Main.tile[x2, y2].ClearTile();
							GenUtils.ObjectPlace(x2, y2, ModContent.TileType<Tiles.Furniture.GloomWood.GloomWoodDoorClosed>());
						}
						if (Main.tile[x2, y2].type == TileID.DiamondGemspark)
						{
							Main.tile[x2, y2].ClearTile();
							GenUtils.ObjectPlace(x2, y2, ModContent.TileType<Tiles.Furniture.GloomWood.GloomWoodTable>());
						}
					}
				}

				Dictionary<Color, int> colorToTile2 = new Dictionary<Color, int>
				{
					[new Color(67, 0, 0)] = TileID.RedStucco,
					[new Color(0, 67, 0)] = TileID.YellowStucco,
					[new Color(0, 0, 67)] = TileID.GreenStucco,
					[new Color(0, 0, 76)] = TileID.Cog,
					[Color.Black] = -1 //don't touch when genning
				};

				Texture2D platTex = mod.GetTexture("WorldGeneration/ImmortalSmokeFiles/ImmortalSmokePlatforms");

				TexGen gen2 = BaseWorldGenTex.GetTexGenerator(platTex, colorToTile2, null, null, null, null);
				gen2.Generate(0, 0, true, true);
				


				int x;
				int y;

				for (x = 0; x < 0 + platTex.Width; x++)
				{
					for (y = 0; y < 0 + platTex.Height; y++)
					{
						if (Main.tile[x, y].type == TileID.RedStucco)
						{
							Main.tile[x, y].ClearTile();
							WorldGen.PlaceTile(x, y, TileID.MinecartTrack, true, false, -1, 0);
							WorldGen.SlopeTile(x, y, 1);
						}
						if (Main.tile[x, y].type == TileID.YellowStucco)
						{
							Main.tile[x, y].ClearTile();
							WorldGen.PlaceTile(x, y, TileID.MinecartTrack, true, false, -1, 0);
							WorldGen.SlopeTile(x, y, 2);
						}
						if (Main.tile[x, y].type == TileID.Cog)
						{
							Main.tile[x, y].ClearTile();
							WorldGen.PlaceTile(x, y, ModContent.TileType<Tiles.Furniture.GloomWood.GloomWoodPlatform>(), true, false, -1, 0);
						}
					}
				}
				return true;
				EvergloomChest(1000, 1000, 0);
			}
					
			public void EvergloomChest(int x, int y, int chestID)
			{
				Mod mod = CelestialMod.instance;
				int PlacementSuccess = WorldGen.PlaceChest(x, y, (ushort)ModContent.TileType<Tiles.Furniture.GloomWood.GloomWoodChest>(), false);

				int[] SpookChestLoot = new int[]
				{
					ModContent.ItemType<Items.Vanity.Paladin.PaladinHead>()
				};
				int[] SpookChestLoot2 = new int[]
				{
					ModContent.ItemType<Items.Vanity.Paladin.PaladinHead>()
				};
				int[] SpookChestLoot3 = new int[]
				{
					ModContent.ItemType<Items.Vanity.Paladin.PaladinHead>()
				};
				int[] SpookChestLoot4 = new int[]
				{
					ModContent.ItemType<Items.Vanity.Paladin.PaladinHead>()
				};
				int[] SpookChestLoot5 = new int[]
				{
					ModContent.ItemType<Items.Vanity.Paladin.PaladinHead>()
				};
				if (PlacementSuccess >= 0)
				{
					Chest chest = Main.chest[PlacementSuccess];

					Item item0 = chest.item[0];
					UnifiedRandom genRand0 = WorldGen.genRand;
					int[] array0 = new int[]
					{ ModContent.ItemType<Items.Vanity.Paladin.PaladinHead>(), ModContent.ItemType<Items.Vanity.Paladin.PaladinHead>() };
					item0.SetDefaults(Utils.Next(genRand0, array0), false);

					chest.item[1].SetDefaults(Utils.Next(WorldGen.genRand, SpookChestLoot2));
					chest.item[1].stack = WorldGen.genRand.Next(1, 3);

					chest.item[2].SetDefaults(Utils.Next(WorldGen.genRand, SpookChestLoot3));
					chest.item[2].stack = WorldGen.genRand.Next(8, 12);

					chest.item[3].SetDefaults(Utils.Next(WorldGen.genRand, SpookChestLoot5));
					chest.item[3].stack = WorldGen.genRand.Next(1, 4);

					if (WorldGen.genRand.Next(2) == 0)
					{
						chest.item[4].SetDefaults(Utils.Next(WorldGen.genRand, SpookChestLoot4));
						chest.item[4].stack = WorldGen.genRand.Next(100, 600);
					}
					if (WorldGen.genRand.Next(6) == 0)
					{
						chest.item[5].SetDefaults(Utils.Next(WorldGen.genRand, SpookChestLoot));
					}
				}
			}
        }
	}
