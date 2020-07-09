using Terraria.ID;
using Terraria.ModLoader;
namespace CelestialMod.Items.Placeable.Furniture.GloomWood2
{
    public class GloomWoodBedBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gloomwood Bed");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 32;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.value = 250;
            item.createTile = ModContent.TileType<Tiles.Furniture.GloomWood.GloomWoodBed>();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VoidicWoodBlock>(), 15);
			recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.Sawmill);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
}