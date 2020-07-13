using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Items
{
    public class lob : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lob");
            Tooltip.SetDefault("Everything has to be magical.");
        }

		public override void SetDefaults() {
			item.damage = 108;
            item.ranged = true;
            item.width = 58;
            item.height = 30;
            item.useTime = 32;
            item.useAnimation = 32;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
            item.knockBack = 2;
            item.value = 90000;
			item.rare = ItemRarityID.Quest;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/a123");
			item.autoReuse = true;
			item.autoReuse = false;
            item.useAmmo = AmmoID.Bullet;
			item.shoot = ProjectileID.Bullet;
            //item.shoot = mod.ProjectileType("lobProj");
            item.shootSpeed = .05f;     //Restrict the type of ammo the weapon can use, so that the weapon cannot use other ammos
		}

		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
        
		public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(235, 139, 0);
                }
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			
			Main.PlaySound(mod.GetSoundSlot(SoundType.Item, "Sounds/Item/a123"), (int)player.Center.X, (int)player.Center.Y);
            
			if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("lobProj");
            }
            if (type == ProjectileID.BulletDeadeye)
            {
                type = mod.ProjectileType("lobProj");
            }
            if (type == ProjectileID.BulletHighVelocity)
            {
                type = mod.ProjectileType("lobProj");
            }
            if (type == ProjectileID.ChlorophyteBullet)
            {
                type = mod.ProjectileType("lobProj");
            }
            if (type == ProjectileID.CrystalBullet)
            {
                type = mod.ProjectileType("lobProj");
            }
            if (type == ProjectileID.CursedBullet)
            {
                type = mod.ProjectileType("lobProj");
            }
            if (type == ProjectileID.ExplosiveBullet)
            {
                type = mod.ProjectileType("lobProj");
            }
            if (type == ProjectileID.GoldenBullet)
            {
                type = mod.ProjectileType("lobProj");
            }
            if (type == ProjectileID.IchorBullet)
            {
                type = mod.ProjectileType("lobProj");
            }
            if (type == ProjectileID.MoonlordBullet)
            {
                type = mod.ProjectileType("lobProj");
            }
            if (type == ProjectileID.NanoBullet)
            {
                type = mod.ProjectileType("lobProj");
            }
            if (type == ProjectileID.PartyBullet)
            {
                type = mod.ProjectileType("lobProj");
            }
            if (type == ProjectileID.RainbowRodBullet)
            {
                type = mod.ProjectileType("lobProj");
            }
            if (type == ProjectileID.SniperBullet)
            {
                type = mod.ProjectileType("lobProj");
            }
            if (type == ProjectileID.VenomBullet)
            {
                type = mod.ProjectileType("lobProj");
            }
            return true;
        }
		
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 600);
        }
    }
}