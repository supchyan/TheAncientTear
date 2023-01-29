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
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
            Player owner = Main.player[Projectile.owner];
           // var dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare, 0f, 0f, 100, default, 0.4f);
           // dust2.velocity *= 10f;
            Projectile.friendly = true;
            Lighting.AddLight(Projectile.Center, 1f, 1f, 1f);
            SearchForTargets(owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
            Movement(foundTarget, distanceFromTarget, targetCenter);
			Projectile.ai[0]++;
			if(Projectile.ai[0] > 120) {
				Projectile.Kill();
				Projectile.ai[0] = 0;
			}
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
        public override void OnSpawn(IEntitySource source) {
            //SoundStyle Shoot = new SoundStyle($"{nameof(YueMod)}/Items/CrossBites/Shoot");
            //SoundEngine.PlaySound(Shoot, Projectile.position);
            base.OnSpawn(source);
        }
        private void Movement(bool foundTarget, float distanceFromTarget, Vector2 targetCenter) {

			float speed = 1f;

			Vector2 direction = targetCenter - Projectile.Center;
            direction.Normalize();
            direction *= speed;
            if (foundTarget) {
				Projectile.velocity = Projectile.velocity + direction;
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