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
	public class PileBunkerProjectile00 : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pile");
            Main.projPet[Projectile.type] = true;
        }
        public override void SetDefaults() {
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
        public override void AI() {
            Player owner = Main.player[Projectile.owner];
            PileGeneral(owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition, Projectile);
            PileSpawn(owner, distanceToIdlePosition, vectorToIdlePosition);
        }
        private void PileGeneral(Player owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition, Projectile projectile) {
			Vector2 spawnPosition = owner.Center;
			vectorToIdlePosition = spawnPosition - Projectile.Center;
			distanceToIdlePosition = vectorToIdlePosition.Length();
		}
        private void PileSpawn(Player owner, float distanceToIdlePosition, Vector2 vectorToIdlePosition) {
			Vector2 idlePosition = owner.Center;
			idlePosition.Y -= 50f;
			idlePosition.X += 50f*owner.direction;
			Projectile.velocity = Vector2.Lerp(Projectile.velocity, idlePosition - Projectile.Center, 0.2f);
            if (Projectile.velocity != Vector2.Zero) {
                Projectile.ai[0]++;
                if(Projectile.ai[0] > 60) {
                    Projectile.timeLeft = 0;
                    Projectile.ai[0] = 0;
                }
            }
            if (Projectile.timeLeft == 0) {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<PileBunkerProjectile01>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
            }
        }        
    }
}