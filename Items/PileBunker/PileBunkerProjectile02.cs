using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using YueMod.Items.Yue;

namespace YueMod.Items.PileBunker {
	public class PileBunkerProjectile02 : ModProjectile {
        public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 12;
            DisplayName.SetDefault("Pile");
            Main.projPet[Projectile.type] = true;
        }
        public override void SetDefaults() {
            AnimeProjectile();
            Projectile.aiStyle = 0;
			Projectile.Opacity = 1f;
			Projectile.width = 24;
			Projectile.height = 56;
			Projectile.scale = 1.5f;
			Projectile.DamageType = DamageClass.Ranged; 
			Projectile.friendly = true;
			Projectile.penetrate = 1;
            Projectile.tileCollide = true;
            
		}
        public void AnimeProjectile() {
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 11) {
				Projectile.frame++;
				Projectile.frame %= 12;
				Projectile.frameCounter = 0;
			}
			Lighting.AddLight(Projectile.Center, 1.5f, 0f, 0f);
		}
        public override void AI() {
            AnimeProjectile(); 
            var dust = Dust.NewDustDirect(Projectile.Center + new Vector2(-10, -5), 0, 0, DustID.LavaMoss, 0f, -5f, 255, default, 1.6f);
            var dust2 = Dust.NewDustDirect(Projectile.Center + new Vector2(-10, 0), 0, 0, DustID.Shadowflame, 0f, -10f, 255, new Color(252, 3, 82), 1f);
            
            Projectile.velocity.X = 0f;
            Projectile.velocity.Y = Projectile.velocity.Y + 0.4f; // 0.1f for arrow gravity, 0.4f for knife gravity
            if (Projectile.velocity.Y > 16f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
            {
                Projectile.velocity.Y = 16f;
            }
            Projectile.ai[0]++;
            if(Projectile.ai[0] > 120) {
                Projectile.timeLeft = 0;
                Projectile.ai[0] = 0;
            }
            if (Projectile.timeLeft == 0) {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<PileBunkerProjectile03>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
            }
        }
    }
}