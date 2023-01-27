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
	public class PileBunkerProjectile03 : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pile03");
            Main.projPet[Projectile.type] = true;
        }
        public override void SetDefaults() {
            Projectile.aiStyle = 0;
			Projectile.Opacity = 1f;
			Projectile.width = 24;
			Projectile.height = 56;
			Projectile.scale = 1.5f;
			Projectile.DamageType = DamageClass.Ranged; 
            Projectile.damage = 6789;
			Projectile.friendly = true;
            Projectile.hostile = true;
			Projectile.penetrate = 1;
            Projectile.tileCollide = true;
		}
        public override void AI() {
            var dust = Dust.NewDustDirect(Projectile.Center + new Vector2(-10, -5), 0, 0, DustID.LavaMoss, 0f, -5f, 255, default, 1.6f);
            var dust2 = Dust.NewDustDirect(Projectile.Center + new Vector2(-10, 0), 0, 0, DustID.Shadowflame, 0f, -10f, 255, new Color(252, 3, 82), 1f);
            
            Lighting.AddLight(Projectile.Center, 1.5f, 0f, 0f);
            Projectile.velocity.X = Projectile.velocity.X + 0.3f;
            if (Projectile.velocity.X >= 1f) {
                Projectile.velocity.X = -Projectile.velocity.X + 0.3f;
            }
            Projectile.velocity.Y = Projectile.velocity.Y + 0.4f; // 0.1f for arrow gravity, 0.4f for knife gravity
            if (Projectile.velocity.Y > 16f) {
                Projectile.velocity.Y = 16f;
            }
            Projectile.ai[0]++;
            if(Projectile.ai[0] > 240) {
                Projectile.timeLeft = 0;
                Projectile.ai[0] = 0;
                
            }
            if (Projectile.timeLeft == 0) {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + new Vector2 (-5, 10), default, ModContent.ProjectileType<PileBullet>(), default, Projectile.knockBack, Main.myPlayer);
                while (Projectile.ai[0] < 360) {
                    Projectile.ai[0]++;
                    Point tileLocation = (Projectile.Center + new Vector2(-10, 0)).ToTileCoordinates();
                    Tile tile = Main.tile[tileLocation.X, tileLocation.Y];
                    WorldGen.KillTile(tileLocation.X, tileLocation.Y + (int)Projectile.ai[0], false, false, false);
                    WorldGen.KillTile(tileLocation.X - 1, tileLocation.Y + (int)Projectile.ai[0], false, false, false);
                    WorldGen.KillTile(tileLocation.X + 1, tileLocation.Y + (int)Projectile.ai[0], false, false, false);
                }              
            }
        }
    }
}