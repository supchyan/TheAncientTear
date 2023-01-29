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


namespace YueMod.Items.MetzeleiDisaster {
	public class MetzeleiDisaster : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Metzelei Disaster");
			Tooltip.SetDefault("Cock");
		}
		public override void SetDefaults() {
			Item.width = 39; 
			Item.height = 18;
			Item.scale = 1.7f;
			Item.autoReuse = false;
			Item.damage = 333; 
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 10f; 
			Item.noMelee = true; 
			Item.rare = ItemRarityID.Yellow; 
			Item.shootSpeed = 20f; 
			Item.useAnimation = 10; 
            Item.autoReuse = true;
			Item.useTime = 10; 
			Item.UseSound = new SoundStyle($"{nameof(YueMod)}/Items/MetzeleiDisaster/rocketLaunch");
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.sellPrice(1, 0, 0, 0);
			Item.shoot = ModContent.ProjectileType<MetzeleiDisasterRocket>();
			//Item.useAmmo = ModContent.ItemType<DonnerAmmo>();
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f + new Vector2(-10, -9);
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
				position += muzzleOffset;
			}
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(-25f, -4f);
		}
        public override bool CanUseItem(Player player) {
            //add cooldown after 9 shots.
			return true;
		}
		public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {

			Texture2D texture = TextureAssets.Item[Item.type].Value;

			Rectangle frame;
			frame = texture.Frame();

			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2((Item.width - 0.4f) / 2 - frameOrigin.X, Item.height - frame.Height + 10);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;	

			spriteBatch.Draw(texture, drawPos, frame, new Color(255, 255, 255, 255), rotation, frameOrigin, scale* 1.7f, SpriteEffects.None, 0);

			return false;
		}
	}
}