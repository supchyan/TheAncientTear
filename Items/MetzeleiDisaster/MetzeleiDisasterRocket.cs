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

namespace YueMod.Items.MetzeleiDisaster {
	public class MetzeleiDisasterRocket : ModProjectile {
		public override void SetStaticDefaults() {
            Main.projFrames[Projectile.type] = 1;
			DisplayName.SetDefault("Rocket");
		}

		public override void SetDefaults() {
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.damage = 333;
			Projectile.height = 26;
			Projectile.width = 26;
        }
        public override void AI() {
			
            Player owner = Main.player[Projectile.owner];
            var dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Ash, 0f, 0f, 100, default, 0.8f);
            //dust2.velocity *= 10f;
            Lighting.AddLight(Projectile.Center, 1f, 1f, 0f);
            SearchForTargets(owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
            Movement(foundTarget, distanceFromTarget, targetCenter);
			Projectile.ai[0]++;
			if(Projectile.ai[0] > 240) {
				Projectile.Kill();
				Projectile.ai[0] = 0;
			}
        }
		public override bool OnTileCollide(Vector2 oldVelocity) {
			if (Projectile.velocity.X != oldVelocity.X) {
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y) {
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				Projectile.velocity *= 0.75f;
				SoundEngine.PlaySound(SoundID.Tink, Projectile.position);
			return false;
		}
		public override void Kill(int timeLeft) {
			Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ProjectileID.SolarWhipSwordExplosion, Projectile.damage, Projectile.knockBack, Main.myPlayer);
		}
        private void SearchForTargets(Player owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter) {
			distanceFromTarget = 700f;
			targetCenter = Projectile.position;
			foundTarget = false;
			if (owner.HasMinionAttackTargetNPC) {
				NPC npc = Main.npc[owner.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, Projectile.Center);
				if (between < 2000f) {
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget) {
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
        }
        private void Movement(bool foundTarget, float distanceFromTarget, Vector2 targetCenter) {

			float speed = 1f;

			Vector2 direction = targetCenter - Projectile.Center;
            direction.Normalize();
            direction *= speed;
            if (foundTarget) {
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
				Projectile.velocity = Projectile.velocity + direction;
				SoundStyle detectedShort = new SoundStyle($"{nameof(YueMod)}/Items/MetzeleiDisaster/detectedShort") {
					MaxInstances = 9,
					SoundLimitBehavior = SoundLimitBehavior.IgnoreNew
				};
				SoundEngine.PlaySound(detectedShort, Projectile.position);
			}
			else if (!foundTarget) {
				SoundStyle detectedFar = new SoundStyle($"{nameof(YueMod)}/Items/MetzeleiDisaster/detectedFar") {
					SoundLimitBehavior = SoundLimitBehavior.IgnoreNew
				};
				SoundEngine.PlaySound(detectedFar, Projectile.position);
				Projectile.rotation += Projectile.velocity.X*0.15f + Projectile.velocity.Y*0.15f;
			}
			if(Projectile.velocity.X > 20f) {
				Projectile.velocity.X = 20f;
			}
			if(Projectile.velocity.Y > 20f) {
				Projectile.velocity.Y = 20f;
			}
		}
        
	}
}