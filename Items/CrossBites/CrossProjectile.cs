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

namespace YueMod.Items.CrossBites {
	public class CrossProjectile : ModProjectile {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Bite");
			Main.projFrames[Projectile.type] = 1;

			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
		}

		public override bool PreDraw(ref Color lightColor) {
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (Projectile.spriteDirection == -1) {
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int startY = frameHeight * Projectile.frame;
			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
			Vector2 origin = sourceRectangle.Size() / 2f;
			float offsetX = 10f;
			origin.X = (float)(Projectile.spriteDirection == 1 ? sourceRectangle.Width - offsetX : offsetX);
			Color drawColor = Projectile.GetAlpha(lightColor);
			Main.EntitySpriteDraw(texture,
				Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
				sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);
			return false;
		}
		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.Retanimini);
			Projectile.Opacity = 1f;
			Projectile.height = 32;
			Projectile.width = 32;
			Projectile.scale = 1.5f;
			Projectile.DamageType = DamageClass.Ranged; 
			Projectile.minionSlots = 1f;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			
		}
		public override bool MinionContactDamage() {
			return false;
		}
		public float Timer {
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}
		public override void AI() {
			Player owner = Main.player[Projectile.owner];
			if (!CheckActive(owner)) {
				return;
			}
			GeneralBehavior(owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition, Projectile);
			SearchForTargets(owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
			Movement(owner, foundTarget, distanceFromTarget, targetCenter, distanceToIdlePosition, vectorToIdlePosition);
			var dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.LavaMoss, 0f, -3f, 255, default, 0.8f);
			AnimateProjectile();
			dust.velocity *= 1f;
			Projectile.tileCollide = false;
			Vector2 velocity = (Projectile.Center - targetCenter).SafeNormalize(Vector2.Zero)*(1000);
		}
		private void GeneralBehavior(Player owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition, Projectile projectile) {
			Vector2 idlePosition = owner.Center;
			idlePosition.Y -= 40f;
			float minionPositionOffsetX = (10 + Projectile.minionPos * 400) * -owner.direction;
			idlePosition.X += minionPositionOffsetX; 
			vectorToIdlePosition = idlePosition - Projectile.Center;
			distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == owner.whoAmI && distanceToIdlePosition > 2000f) {
				Projectile.position = idlePosition;
				Projectile.rotation = Projectile.velocity.Y*0.15f + Projectile.velocity.X*0.15f + MathHelper.ToRadians(-90);
				Projectile.velocity *= 1f;
				Projectile.netUpdate = true;
			}
			float overlapVelocity = 0.1f;
			for (int i = 0; i < Main.maxProjectiles; i++) {
				Projectile other = Main.projectile[i];
				if (i != Projectile.whoAmI && other.active && other.owner == Projectile.owner && Math.Abs(Projectile.position.X - other.position.X) + Math.Abs(Projectile.position.Y - other.position.Y) < Projectile.width) {
					if (Projectile.position.X < other.position.X) {
						Projectile.velocity.X -= overlapVelocity;
					}
					else {
						Projectile.velocity.X += overlapVelocity;
					}

					if (Projectile.position.Y < other.position.Y) {
						Projectile.velocity.Y -= overlapVelocity;
					}
					else {
						Projectile.velocity.Y += overlapVelocity;
					}
				}
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
			Projectile.friendly = foundTarget;
		}
		private void Movement(Player owner, bool foundTarget, float distanceFromTarget, Vector2 targetCenter, float distanceToIdlePosition, Vector2 vectorToIdlePosition) {
			float speed = 14f;
			float inertia = 20f;
			if (foundTarget) {
				Vector2 direction = targetCenter - Projectile.Center;
				direction.Normalize();
				direction *= speed;
				Projectile.rotation = direction.ToRotation() + MathHelper.ToRadians(180);
				if (distanceFromTarget < 2000f && distanceFromTarget >= 150f) {
					direction.Normalize();
					direction *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
				}	
				if (distanceFromTarget < 150f) {
					direction.Normalize();
					direction *= speed;
					Projectile.velocity = Vector2.Lerp(Projectile.velocity, Vector2.Zero, 0.05f);
					Vector2 velocity = (direction).SafeNormalize(Vector2.Zero)*(255);
					Timer++;
					if (Timer > 90) {
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, velocity, ModContent.ProjectileType<ShootProjectile>(), Projectile.damage, Projectile.knockBack, Main.myPlayer);
						Timer = 0;
					}
				}
			}
			else {
				Projectile.rotation = Projectile.velocity.Y*0.15f + Projectile.velocity.X*0.15f + MathHelper.ToRadians(-90);
				if (distanceToIdlePosition < 2000f && distanceToIdlePosition > 150f) {
					speed = 14f;
					inertia = 60f;	
				}
				else {
					speed = 6f;
					inertia = 80f;
				}
				if (distanceToIdlePosition <= 150f) {
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;	
				}
				else if (Projectile.velocity == Vector2.Zero) {
					Projectile.velocity.X = 0.15f;
				}
			}
		}
		private bool CheckActive(Player owner) {
			if (owner.dead || !owner.active) {
				owner.ClearBuff(ModContent.BuffType<CrossBuff>());
				return false;
			}
			if (owner.HasBuff(ModContent.BuffType<CrossBuff>())) {
				Projectile.timeLeft = 2;
			}
			return true;
		}
		public void AnimateProjectile() {
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 3) {
				Projectile.frame++;
				Projectile.frame %= 1;
				Projectile.frameCounter = 0;
			}
			Lighting.AddLight(Projectile.Center, 1f, 0f, 0f);
		}
	}
}
