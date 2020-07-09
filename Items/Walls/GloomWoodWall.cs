using Terraria.ModLoader;
using Terraria.ID;
using CelestialMod.Walls.GloomBiome;

namespace CelestialMod.Items.Walls
{
    public class GloomWoodWall : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createWall = ModContent.WallType<GloomWoodWallTile>(); //put your CustomBlock Tile name
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gloom Wood Wall");
        }
    }
}
