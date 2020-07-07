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
	public class VoidicStone : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			soundType = SoundID.Tink;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			Main.tileMerge[Type][mod.TileType("VoidicMud")] = true;
			Main.tileMerge[Type][mod.TileType("VoidicGrass")] = true;
			Main.tileMergeDirt[Type] = true;
			AddMapEntry(new Color(96, 96, 96));
			drop = ItemType<Items.Placeable.VoidicStoneBlock>();
		}
	}
}