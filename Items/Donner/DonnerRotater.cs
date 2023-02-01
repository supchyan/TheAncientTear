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
using System;
using YueMod.Items.Donner;

namespace YueMod.Items.Donner {
    public class DonnerRotater : ModProjectile { 

        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Rotater");
		}
        public override void SetDefaults() {
            Projectile.aiStyle = 0;
			Projectile.width = 64;
			Projectile.height = 35;
            Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.scale = 0.8f;
        }
        public override void AI() {
            Player owner = Main.player[Projectile.owner];
            Vector2 cock = owner.Center - Projectile.Center;
            cock.Normalize();
            Projectile.ai[0]++;
            Projectile.velocity = Projectile.velocity + cock;
            if(Projectile.ai[0] > 15) {
                //Main.NewText("Cock");
                Projectile.velocity.X = -Projectile.velocity.X;
                Projectile.velocity.Y = -Projectile.velocity.Y;
                Projectile.ai[0] = 0;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit) {
            Projectile.Kill();
            base.OnHitPlayer(target, damage, crit);
        }
        public override Color? GetAlpha(Color lightColor) {
			return Color.White;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            //Main.NewText("Cock");
            target.AddBuff(ModContent.BuffType<DonnerDeBuff>(), 120, false);
        }
	}
}