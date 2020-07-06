using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialMod.Items.Weapons.Thrown
{
	public class WeebKnife : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kitchen Knives");
			Tooltip.SetDefault("Flies straight, ignoring gravity");
		}


        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.width = 34;
            item.height = 34;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("WeebKnifeProjectile");
            item.useAnimation = 30;
            item.useTime = 10;
            item.consumable = false;
            item.shootSpeed = 14f;
            item.damage = 100;
            item.knockBack = 10f;
			item.value = Item.sellPrice(0, 7, 0, 0);
            item.crit = 16;
            item.rare = 2;
            item.autoReuse = true;
        }
    }
}