using Terraria.ID;
using Terraria.ModLoader;
using CelestialMod.Tiles.Furniture.GloomWood;
namespace CelestialMod.Items.Placeable.Furniture.GloomWood2
{
    public class GloomWoodTableBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gloomwood Table");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 26;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.value = 250;
            item.createTile = ModContent.TileType<Tiles.Furniture.GloomWood.GloomWoodTable>();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VoidicWoodBlock>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
}