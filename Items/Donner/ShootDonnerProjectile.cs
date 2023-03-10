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
    public class ShootDonnerProjectile : ModProjectile { 

        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Slug");
		}
        public override void SetDefaults() {
            Projectile.aiStyle = 0;
			Projectile.width = 23;
			Projectile.height = 23;
            Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.manualDirectionChange = true;   
            Projectile.netUpdate = true; 
        }
        public override void AI() {
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
            Lighting.AddLight(Projectile.Center, 0.8f, 0.7f, 1f);
            var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Shadowflame, 0f, 0f, 255, default, 0.6f);
            dust.velocity *= 1f;
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