using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialMod.Items.Useable.Critters
{
    public class VoidMothItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acidic Moth");
		}


        public override void SetDefaults()
        {
            item.width = 24;
			item.height = 22;
            item.rare = ItemRarityID.Orange;
            item.maxStack = 99;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.useTime = item.useAnimation = 20;
			item.bait = 50;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("VoidMoth"));
            return true;
        }

        }
}
