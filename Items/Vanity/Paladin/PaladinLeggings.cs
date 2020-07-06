using CelestialMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Items.Vanity.Paladin
{
	[AutoloadEquip(EquipType.Legs)]
	public class PaladinLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lawlyi's Leggings");
			Tooltip.SetDefault("Great for impersonating mod devs!");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 50000;
			item.rare = 9;
			item.defense = 0;
			item.vanity = true;
		}
	}
}