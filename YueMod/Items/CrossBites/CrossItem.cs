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


namespace YueMod.Items.CrossBites {
	public class CrossItem : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Decontamination Crosses");
			Tooltip.SetDefault("Transfers the strong flying unit from The Beyond." + "\nDesigned to hunt on something" + $"[c/808080: unusual]" + ".");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;			
		}
		public override Color? GetAlpha(Color lightColor) {
			return Color.White;
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			var line = new TooltipLine(Mod, "Verbose:RemoveMe", "\nPosition! Aim! Fire!") {
				OverrideColor = new Color(255, 25, 0)
			};
			tooltips.Add(line);
		}
		
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.scale = 0.3f;
			Item.useStyle = ItemUseStyleID.Guitar;
			Item.useTime = 40;
			Item.useAnimation = 20;
			Item.autoReuse = false;
			Item.DamageType = DamageClass.Ranged;
			Item.damage = 2023;
			Item.crit = 25;
			Item.UseSound = SoundID.NPCDeath58;
			Item.shootSpeed = 10;
			Item.knockBack = 11;
			Item.noMelee = true;
			Item.buffType = ModContent.BuffType<CrossBuff>();
			Item.shoot = ModContent.ProjectileType<CrossProjectile>();
			Item.rare = ItemRarityID.Red;

		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			// This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
			player.AddBuff(Item.buffType, 2);
			// Minions have to be spawned manually, then have originalDamage assigned to the damage of the summon item
			var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
			projectile.originalDamage = Item.damage;
			// Since we spawned the projectile manually already, we do not need the game to spawn it for ourselves anymore, so return false
			return false;
		}
	}
}