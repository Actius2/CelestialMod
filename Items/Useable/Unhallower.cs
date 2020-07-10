using CelestialMod.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace CelestialMod.Items.Useable
{
    public class Unhallower : ModItem
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Essence of Humanity");
            Tooltip.SetDefault("Completely replenishes your humanity");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
			item.color = Color.White;
			
        }

        public override bool UseItem(Player player)
        {
            CelestialModPlayer.Get(player).Hallowness = 5;
			
			//todo; add a part that doesn't allow the usage of the item when hallownessis at 0
            return true;
			
			
        }

        public override string Texture => "CelestialMod/Items/Useable/Unhallower";
    }
}
