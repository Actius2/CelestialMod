using CelestialMod.Items;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Items.Placeable
{
	public class MysticStoneBlock : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("This is a modded block.");

		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = TileType<Tiles.Blocks.MysticStone>();
		}
	}
}
