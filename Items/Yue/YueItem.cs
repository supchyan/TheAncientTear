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

namespace YueMod.Items.Yue
{
	public class YueItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Strange item");
			Tooltip.SetDefault("Can be used to contact with...\n");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			var line = new TooltipLine(Mod, "Strange item", "\nYou can't understand what is this.") {
				OverrideColor = new Color(255, 0, 120)
			};
			tooltips.Add(line);
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
			Item.useStyle = ItemUseStyleID.Shoot;
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

			if(Main.hardMode && !DownedBossSystem.WoF) {
				NPC.SetEventFlagCleared(ref DownedBossSystem.WoF, -1);
			}
			if(NPC.downedBoss2 && !DownedBossSystem.Brain) {
				NPC.SetEventFlagCleared(ref DownedBossSystem.Brain, -1);
			}
            base.UseAnimation(myPlayer);
        }
	}
}
