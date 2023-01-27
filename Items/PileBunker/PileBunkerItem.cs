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
using YueMod.Items.Donner;

namespace YueMod.Items.PileBunker {
    public class PileBunkerItem : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pile Bunker");
			Tooltip.SetDefault("Using this item is calling the Pile Bunker for destroy any ground and enemies under of it."+"\nCan create fast transfer to hell."+"\n\nGround? AHAHAHAHA!" + $"[c/808080: unusual]" + ".");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;			
        }
        public override Color? GetAlpha(Color lightColor) {
			return Color.White;
		}
        public override void SetDefaults() {
			Item.width = 20;
			Item.height = 25;
			Item.scale = 1.3f;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.useTime = 40;
			Item.useAnimation = 20;
			Item.autoReuse = false;
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 6789;
			Item.crit = 25;
			Item.UseSound = SoundID.NPCDeath58;
			Item.shootSpeed = 10;
			Item.knockBack = 11;
			Item.noMelee = true;
			Item.buffType = ModContent.BuffType<PileBunkerTimer>();
			//Item.shoot = ModContent.ProjectileType<PileBunkerProjectile00>();
			Item.rare = ItemRarityID.Red;
			Item.shoot = ModContent.ProjectileType<PileBunkerProjectile00>();
		}
		public override bool CanUseItem(Player player) {
			if(player.HasBuff<PileBunkerTimer>()){
				return false;
			}
			else {
				return true;
			}
		}
		public override void UseStyle(Player myPlayer, Rectangle heldItemFrame) {
			if(!Main.LocalPlayer.HasBuff<PileBunkerTimer>()) {
				Main.LocalPlayer.AddBuff(Item.buffType, 720);
			}
		}
	}
}