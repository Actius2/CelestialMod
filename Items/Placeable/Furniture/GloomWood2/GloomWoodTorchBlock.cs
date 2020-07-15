using CelestialMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CelestialMod.Items.Placeable.Furniture.GloomWood2
{
	public class GloomWoodTorchBlock : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Acidic Torch");
		}

		public override void SetDefaults() {
			item.width = 10;
			item.height = 12;
			item.maxStack = 99;
			item.holdStyle = 1;
			item.noWet = true;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = TileType<Tiles.Furniture.GloomWood.GloomWoodTorch>();
			item.flame = true;
			item.value = 50;
		}

		public override void HoldItem(Player player) {
			Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
			Lighting.AddLight(position, 0.76f, 1f, 0f);
		}

		public override void PostUpdate() {
			if (!item.wet) {
				Lighting.AddLight((int)((item.position.X + item.width / 2) / 16f), (int)((item.position.Y + item.height / 2) / 16f), 0.76f, 1f, 0f);
			}
		}

		public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick) {
			dryTorch = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 1);
			recipe.AddIngredient(ItemType<Items.Placeable.VoidicWoodBlock>());
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}
	}
}