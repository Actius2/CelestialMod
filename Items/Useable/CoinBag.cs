using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Items.Useable
{
	public class CoinBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Coin Pouch");
			Tooltip.SetDefault("Don't spend it all at one place!");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 34;
			item.rare = ItemRarityID.Green;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void RightClick(Player player) {
			player.QuickSpawnItem(ItemID.GoldCoin, 2);
			player.QuickSpawnItem(ItemID.SilverCoin, 67);
			player.QuickSpawnItem(ItemID.SilverCoin, 13);
			
		}
	}
}