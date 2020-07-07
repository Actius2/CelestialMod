using CelestialMod.Backgrounds;
using CelestialMod.Players;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace CelestialMod
{
	public class CelestialMod : Mod
	{
		internal static CelestialMod instance;
        public static CelestialMod self = null;
		public static Dictionary<string, Texture2D> Textures = null;
        public static Dictionary<string, Texture2D> precachedTextures = new Dictionary<string, Texture2D>();
		
		public CelestialMod()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
            instance = this;
        }
		
		public override void Load()
		{
			VoidSky rkSky = new VoidSky();
			Filters.Scene["CelestialMod:VoidSky"] = new Filter(new VoidSkyData("FilterMiniTower").UseColor(0.25f, 0.1f, 0.01f).UseOpacity(0.5f), EffectPriority.VeryHigh);
			SkyManager.Instance["CelestialMod:VoidSky"] = rkSky;
		}
	
		public override void UpdateMusic(ref int music, ref MusicPriority priority)
		{
			if (Main.gameMenu)
				return;
			if (priority > MusicPriority.Event)
				return;
			Player player = Main.LocalPlayer;
			if (!player.active)
				return;
			CelestialModPlayer Gamer = CelestialModPlayer.get(player);
			
			if (Gamer.ZoneVoid)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/VoidMusic");
				priority = MusicPriority.BiomeHigh;
			}
		}
	
	}
}