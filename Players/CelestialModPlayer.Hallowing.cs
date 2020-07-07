using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace CelestialMod.Players
{
    public sealed partial class CelestialModPlayer : ModPlayer
    {
        // Reason I made this class partial is so we can neatly seperate code into more navigateable chunks.
        // Compiler will put this together into one class so we won't create hundreds of modplayer instances like some bad
        // mods do by adding multiple modplayer classes

        public void InitializeHallowing()
        {
            Hallowness = MaxHallowness;
        }

        public void ResetHallowingEffects()
        {
            if (IsHallow)
            {
                player.statLifeMax2 -= HalvedHP;

                if (player.statLife > player.statLifeMax2)
                    player.statLife = player.statLifeMax2;
            }
            else
            {
                HalvedHP = 0;
            }
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            Hallowness--;

            if (IsHallow && HalvedHP == 0)
            {
                HalvedHP = player.statLifeMax2 / 2; // Might work wierd if you die while having life force active
            }
        }

        public void SaveHallowness(TagCompound tag)
        {
            tag.Add("Hallowness", Hallowness);
            tag.Add("HalvedHP", HalvedHP);
        }

        public void LoadHallowness(TagCompound tag)
        {
            Hallowness = tag.GetInt("Hallowness");
            HalvedHP = tag.GetInt("HalvedHP");
        }

        public int HalvedHP { get; set; }

        public bool IsHallow => Hallowness <= 0;

        // I have no idea if you can adjust the amount of your "Hallowness"
        // So I made it a property just in case
        public int MaxHallowness { get; set; } = 5;

        private int _hallowness;
        public int Hallowness
        {
            get => _hallowness;
            set => _hallowness = (int)MathHelper.Clamp(value, 0, MaxHallowness);
        }
    }
}
