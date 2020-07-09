using Terraria.ModLoader;
using Terraria.ID;

namespace CelestialMod.Items.Placeable.Furniture.GloomWood2

{
    public class GloomWoodPlatformBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Gloomwood Platform");
		}

		public override void SetDefaults()
		{
			item.width = 8;
			item.height = 10;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.Furniture.GloomWood.GloomWoodPlatform>();
		}

		public override void AddRecipes()
        {
             ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.VoidicWoodBlock>(), 1);
            //recipe.AddIngredient(ItemID.Torch, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
