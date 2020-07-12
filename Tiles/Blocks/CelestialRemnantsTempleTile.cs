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
	public class CelestialRemnantsTempleTile : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMerge[Type][mod.TileType("VoidicGrass")] = true;
			Main.tileMerge[Type][mod.TileType("VoidicStone")] = true;
			Main.tileMerge[Type][mod.TileType("VoidicMud")] = true;
			Main.tileMergeDirt[Type] = true;
			AddMapEntry(new Color(0, 191, 255));
			drop = ItemType<Items.Placeable.CelestialRemnantsTempleTileBlock>();
		}
	}
}