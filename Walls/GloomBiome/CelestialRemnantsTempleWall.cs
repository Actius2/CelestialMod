using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CelestialMod.Walls.GloomBiome
{
    public class CelestialRemnantsTempleWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(79, 140, 36));
            soundType = 21;
            dustType = 2;
        }
    }
}