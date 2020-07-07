using CelestialMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace CelestialMod.Items.Vanity.Paladin
{
	[AutoloadEquip(EquipType.Body)]
	public class PaladinTorso : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lawlyi's Breastplate");
			Tooltip.SetDefault("Great for impersonating mod devs!");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 50000;
			item.rare = ItemRarityID.Cyan;
			item.defense = 0;
			item.vanity = true;
		}
	}
}