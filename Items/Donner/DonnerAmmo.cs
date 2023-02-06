using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace YueMod.Items.Donner
{
	public class DonnerAmmo : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Slug");
			Tooltip.SetDefault("As strong as high level fire spells."); 
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults() {
			Item.width = 23;
			Item.height = 23;

			Item.damage = 125;
			Item.DamageType = DamageClass.Ranged;

			Item.maxStack = 9999;
			Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible
			Item.knockBack = 2f;
			Item.value = Item.sellPrice(0, 1, 0, 0); // Item price in copper coins (can be converted with Item.sellPrice/Item.buyPrice)
			Item.rare = ItemRarityID.Red;
			Item.shoot = ModContent.ProjectileType<ShootDonnerProjectile>(); // The projectile that weapons fire when using this item as ammunition.

			Item.ammo = Item.type; // Important. The first item in an ammo class sets the AmmoID to its type
		}

		public override void AddRecipes() {
			CreateRecipe(12)
				.AddIngredient(ItemID.Hellstone, 180)
				.AddIngredient(ItemID.Obsidian, 180)
				.Register();
		}
	}
}