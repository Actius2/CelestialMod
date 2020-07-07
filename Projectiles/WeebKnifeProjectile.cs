using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialMod.Projectiles
{
	public class WeebKnifeProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Weeb Knife");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(14);
			projectile.penetrate = 7;
			projectile.width = 16;
			projectile.height = 16;
            projectile.ranged = true;
            projectile.friendly = true;
			projectile.timeLeft = 300;
			projectile.alpha = 0;
			projectile.aiStyle = 1;
			aiType = 14;
		}

		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation() + (float)(Math.PI/2);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
				target.AddBuff(BuffID.Bleeding, 180);
				projectile.Kill();
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			return true;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 7);
			
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 6, projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 33, new Color(0,0,0), 1f);
				dust.noGravity = true;
				dust.shader = GameShaders.Armor.GetSecondaryShader(56, Main.LocalPlayer);

			}
		}
	}