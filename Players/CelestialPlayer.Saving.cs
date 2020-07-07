using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace CelestialMod.Players
{
    public sealed partial class CelestialModPlayer : ModPlayer
    {
        public override TagCompound Save()
        {
            TagCompound tag = new TagCompound();

            SaveHallowness(tag);

            return tag;
        }

        public override void Load(TagCompound tag)
        {
            LoadHallowness(tag);
        }
    }
}
