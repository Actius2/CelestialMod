using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using CelestialMod.Dusts;
using static Terraria.ModLoader.ModContent;
namespace CelestialMod.Walls.GloomBiome
{
    public class CelestialRemnantsTempleWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(79, 140, 36));
			soundType = SoundID.Tink;
            dustType = 2;
			drop = ModContent.ItemType<Items.Walls.CelestialRemnantsTempleWallBlock>();
        }
    }
}