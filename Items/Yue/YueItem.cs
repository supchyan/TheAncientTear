using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using YueMod.Systems;
using YueMod.Common.UI;
using Terraria.DataStructures;

namespace YueMod.Items.Yue
{
	public class YueItem : ModItem
	{
		public override void SetStaticDefaults() {

			DisplayName.SetDefault("Tear's shard");
			Tooltip.SetDefault("The power of this item literally oozing out. You recognising, this item shouldn't be here... Never." + 
			"\nLeft click and..." + "\n[c/520c0c:. . .]" +
			"\n[c/c12020:'We can't control it anymore, prepare yourself!']" + "\n[c/520c0c:. . .]" +
			"\n[c/c12020:'The world's structure is under threat! It was a bad idea!']" + "\n[c/520c0c:. . .]" +
			"\n[c/c12020:'Press an emergency button,] [c/e61515:RIGHT NOW!] [c/c12120:Wait, why do you...][c/520c0c:#?&@%#']" + "\n[c/520c0c:. . .]" +
			"\n[c/520c0c:S0M3ON3 H3LP U$]"
			);
			
			//Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(30, 4));
			//ItemID.Sets.AnimatesAsSoul[Item.type] = true;

			ItemID.Sets.ItemNoGravity[Item.type] = true;

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}	
		public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
			Texture2D texture = TextureAssets.Item[Item.type].Value;
			Rectangle frame;
			if (Main.itemAnimations[Item.type] != null) {
				frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
			}
			else {
				frame = texture.Frame();
			}

			Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

			float time = Main.GlobalTimeWrappedHourly;
			float timer = Item.timeSinceItemSpawned / 240f + time * 0.04f;

			time %= 4f;
			time /= 2f;

			if (time >= 1f) {
				time = 2f - time;
			}

			time = time * 0.5f + 0.5f;

			for (float i = 0f; i < 1f; i += 0.25f) {
				float radians = (i + timer) * MathHelper.TwoPi;
				spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(90, 70, 255, 50), rotation, frameOrigin, scale, SpriteEffects.None, 0);
			}

			for (float i = 0f; i < 1f; i += 0.34f) {
				float radians = (i + timer) * MathHelper.TwoPi;
				spriteBatch.Draw(texture, drawPos + new Vector2(0f, 4f).RotatedBy(radians) * time, frame, new Color(140, 120, 255, 77), rotation, frameOrigin, scale, SpriteEffects.None, 0);
			}
			return true;
		}
		public override void SetDefaults() {
			Item.rare = ItemRarityID.Master;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.scale = 0.7f;
		}
		public override bool CanUseItem(Player player) {
			if(player.HasBuff<YueBuff>()){
				return false;
			}
			else {
				return true;
			}
		}
		public override void UseStyle(Player player, Rectangle heldItemFrame) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(Item.buffType, 3600);
			}
		}
        public override void UseAnimation(Player myPlayer) {
			if(!myPlayer.HasBuff(ModContent.BuffType<YueBuff>())) {
				Item.buffType = ModContent.BuffType<YueBuff>();
			}
			
		}
		public static bool wipe = false; 
		public override void HoldItem(Player player) {
			if(!player.GetModPlayer<newCreatedPlayer>().holdingMyItem && player.HasItem(ModContent.ItemType<YueItem>())) {
				player.GetModPlayer<newCreatedPlayer>().holdingMyItem = true;
				wipe = true;
			}
			else if (player.GetModPlayer<newCreatedPlayer>().holdingMyItem) {
				wipe = false;
			}
            base.HoldItem(player);
		}
	}
}
