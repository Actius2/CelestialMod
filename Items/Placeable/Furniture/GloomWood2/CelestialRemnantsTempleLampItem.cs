using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Items.Placeable.Furniture.GloomWood2
{
	internal class CelestialRemnantsTempleLampItem : ModItem
	{
		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 99;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.Furniture.GloomWood.CelestialRemnantsTempleLamp>();
			item.width = 10;
			item.height = 24;
			item.value = 5000;
		}
	}
}