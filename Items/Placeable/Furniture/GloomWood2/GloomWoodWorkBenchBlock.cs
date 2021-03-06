using Terraria.ModLoader;
using Terraria.ID;
namespace CelestialMod.Items.Placeable.Furniture.GloomWood2
{
    public class GloomWoodWorkBenchBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gloomwood Workbench");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 18;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.value = 250;
            item.createTile = ModContent.TileType<Tiles.Furniture.GloomWood.GloomWoodWorkBench>();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VoidicWoodBlock>(), 10);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
}