using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CelestialMod.Walls.GloomBiome
{
    public class GloomWoodWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(79, 140, 36));
            soundType = 6;
            dustType = 2;
			drop = ModContent.ItemType<Items.Walls.GloomWoodWallBlock>();
        }
    }
}