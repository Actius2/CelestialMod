using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using CelestialMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Tiles.Blocks
{
	public class MysticSoil : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			Main.tileMerge[Type][mod.TileType("MysticStone")] = true;
			Main.tileMerge[Type][mod.TileType("MysticGrass")] = true;
			Main.tileBlendAll[Type] = true;
			AddMapEntry(new Color(0, 191, 255));
			drop = ItemType<Items.Placeable.MysticSoilBlock>();
		}
	}
}