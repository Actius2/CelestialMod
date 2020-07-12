using Terraria;
using Terraria.ModLoader;
namespace CelestialMod.Dusts
{
    class GloomWoodDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noLight = true;
            dust.scale = 1.184211f;
            dust.noGravity = false;
            dust.velocity /= 2f;
			dust.fadeIn = 0.9078947f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X;
 
            return false;
        }
    }
}