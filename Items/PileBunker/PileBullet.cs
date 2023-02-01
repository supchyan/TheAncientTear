using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using YueMod.Items.Yue;
using YueMod.Items.Donner;

namespace YueMod.Items.PileBunker {
	public class PileBullet : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Soft stick");
            Main.projPet[Projectile.type] = true;
        }
        public override void SetDefaults() {
            Projectile.friendly = true;
			Projectile.minion = true;
            Projectile.aiStyle = 0;
			Projectile.width = 16;
			Projectile.height = 32;
			Projectile.hostile = true;
			Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 1;   
            Projectile.damage = 6789;        
		}
        public override bool MinionContactDamage() {
			return true;
		}
        public override void AI() {
            MinionContactDamage();
            Lighting.AddLight(Projectile.Center, 1.5f, 0f, 0f); 
            var dust = Dust.NewDustDirect(Projectile.Center + new Vector2(-6, 10), 0, 0, DustID.LavaMoss, 0f, 0f, 255, default, 0.8f);
            Projectile.velocity.X = 0f;
            Projectile.velocity.Y = Projectile.velocity.Y + 7f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            Main.NewText("[c/c12120:Yue: No mercy.]");
        }
    }
}