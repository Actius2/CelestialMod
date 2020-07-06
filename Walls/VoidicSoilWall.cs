using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CelestialMod.Walls
{
    public class VoidicSoilWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = false;
            AddMapEntry(new Color(79, 140, 36));
            soundType = 6;
            dustType = 2;
        }
    }
}