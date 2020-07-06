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
	public class VoidicMud : ModTile
	{
		public override void SetDefaults() {
			
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			Main.tileMerge[Type][mod.TileType("VoidicStone")] = true;
			Main.tileMerge[Type][mod.TileType("VoidicGrass")] = true;
			Main.tileMergeDirt[Type] = true;
			AddMapEntry(new Color(86, 60, 58));
			drop = ItemType<Items.Placeable.VoidicMudBlock>();
		}
	}
}