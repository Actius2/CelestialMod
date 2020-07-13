﻿using CelestialMod.Items;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Items.Placeable
{
	public class CelestialRemnantsTempleTileBlock : ModItem
	{
		public override void SetStaticDefaults() {
			
			DisplayName.SetDefault("Ra'ketlh Brick");
			Tooltip.SetDefault("The Ashes of An Ancient Civilization");

		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = TileType<Tiles.Blocks.CelestialRemnantsTempleTile>();
		}
	}
}