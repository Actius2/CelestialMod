using CelestialMod.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialMod.Items.Useable
{
    public class Unhallower : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Completely replenishes your humanity");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.LightPurple;
            item.useStyle = ItemUseStyleID.EatingUsing;
        }

        public override bool UseItem(Player player)
        {
            CelestialModPlayer.Get(player).Hallowness = 5;

            return true;
        }

        public override string Texture => "CelestialMod/Items/Useable/CoinBag";
    }
}
