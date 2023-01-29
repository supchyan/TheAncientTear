using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent;


namespace YueMod.Items.Donner {
	public class Donner : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("The Donner");
			Tooltip.SetDefault("Unlike any other weapon, this prototype shoots fire ammunition," + "\nthe strength of which can be equal to strong magic spells." + "\nLight weight and high rate of fire, the best gun to deal with the great forces of this world.");
		}
		public override void SetDefaults() {
			Item.width = 64; 
			Item.height = 35;
			Item.scale = 0.6f;

			Item.autoReuse = false;
			Item.damage = 125; 
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 4f; 
			Item.noMelee = true; 
			Item.rare = ItemRarityID.Yellow; 
			Item.shootSpeed = 35f; 
			Item.useAnimation = 25; 
			Item.useTime = 25; 
			Item.UseSound = new SoundStyle($"{nameof(YueMod)}/Items/Donner/DonnerShoot");
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.sellPrice(5, 0, 0, 0);

			Item.shoot = ModContent.ProjectileType<ShootDonnerProjectile>();
			Item.useAmmo = ModContent.ItemType<DonnerAmmo>();
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f + new Vector2(3, -5);
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
				position += muzzleOffset;
			}
        }
		public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {

			Texture2D texture = TextureAssets.Item[Item.type].Value;

			Rectangle frame;
			frame = texture.Frame();

			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2((Item.width - 0.4f) / 2 - frameOrigin.X, Item.height - frame.Height + 10);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;	

			spriteBatch.Draw(texture, drawPos, frame, new Color(255, 255, 255, 255), rotation, frameOrigin, scale - 0.4f, SpriteEffects.None, 0);

			return false;
		}
	}
}