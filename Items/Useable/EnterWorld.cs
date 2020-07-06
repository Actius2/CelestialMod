using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.GameContent.Events;
using Terraria.Utilities;
using Terraria.Graphics.Effects;
using Terraria.Localization;
using SubworldLibrary;
using Terraria.World.Generation;
using BaseMod;
using CelestialMod.Tiles;
using CelestialMod.Items;
using CelestialMod;
using static CelestialMod.CelestialModSubworld;
namespace CelestialMod
{
	public class EnterWorld : ModItem
	{
		public override string Texture => "Terraria/Item_" + ItemID.Extractinator;

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Use to enter a subworld. Only works with 'SubworldLibrary' Mod enabled");
		}

		public override void SetDefaults()
		{
			item.maxStack = 1;
			item.width = 34;
			item.height = 38;
			item.rare = 12;
			item.useStyle = 4;
			item.useTime = 30;
			item.useAnimation = 30;
			item.UseSound = SoundID.Item1;
		}

		public override bool UseItem(Player player)
		{
			Subworld.Enter<CelestialModSubworld>();
			return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
