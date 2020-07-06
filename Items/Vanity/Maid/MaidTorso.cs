using CelestialMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Items.Vanity.Maid
{
	[AutoloadEquip(EquipType.Body)]
	public class MaidTorso : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Maid Dress");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 3;
			item.defense = 0;
			item.vanity = true;
		}
	}
}