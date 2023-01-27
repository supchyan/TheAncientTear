using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using YueMod.Systems;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent;
using System;
namespace YueMod.Items.Yue {
	public class YueProjectile : ModProjectile {
		//короче, тут надо будет ещё один projectile сделать для idle анимации,
		//а этот файл заменить на анимацию появления
		//т.е. надо тут будет картиночки заменить наверное только, всё остальное оставить,
		//а остатки скопипастить в idle code.
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Yue");
			Main.projFrames[Projectile.type] = 8;
			Main.projPet[Projectile.type] = true;
		}
		public override void SetDefaults() {
			AnimeProjectile();
			Projectile.Opacity = 1f;
			Projectile.height = 41;
			Projectile.width = 41;
			Projectile.scale = 1.2f;
		}
		public override Color? GetAlpha(Color lightColor) {
			return new Color(1f, 1f, 1f, 255) * Projectile.Opacity;
		}
		public void AnimeProjectile() {
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 4) {
				Projectile.frame++;
				Projectile.frame %= 8;
				Projectile.frameCounter = 0;
			}
			Lighting.AddLight(Projectile.Center, 1.5f, 1.5f, 1.5f);
		}
		public override void AI() {
			Player owner = Main.player[Projectile.owner];
			YueGeneral(owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition, Projectile);
			YueMovement(owner, distanceToIdlePosition, vectorToIdlePosition);
			AnimeProjectile();
			Projectile.tileCollide = false;
			if (!owner.dead && owner.HasBuff(ModContent.BuffType<YueBuff>())) {
				Projectile.timeLeft = 2;
			}
		}
		private void YueGeneral(Player owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition, Projectile projectile) {
			Vector2 idlePosition = owner.Center;
			vectorToIdlePosition = idlePosition - Projectile.Center;
			distanceToIdlePosition = vectorToIdlePosition.Length();
		}
		private void YueMovement(Player owner, float distanceToIdlePosition, Vector2 vectorToIdlePosition) {
			Vector2 idlePosition = owner.Center;
			idlePosition.Y -= 40f;
			idlePosition.X += 40f*owner.direction;
			Projectile.velocity = Vector2.Lerp(Projectile.velocity, idlePosition - Projectile.Center, 0.08f);
			vectorToIdlePosition = idlePosition - Projectile.Center;
			distanceToIdlePosition = vectorToIdlePosition.Length();
			float speed = 10f;
			vectorToIdlePosition.Normalize();
			vectorToIdlePosition *= speed;
			if(distanceToIdlePosition <= 100f) {
				Projectile.velocity = Vector2.Lerp(Projectile.velocity, Vector2.Zero, 0.08f);
			}
			else {
				Projectile.velocity = (Projectile.velocity + vectorToIdlePosition);
			}
		}
		public override void OnSpawn(IEntitySource source) {
			Player owner = Main.player[Projectile.owner];
			SoundStyle Aweaking = new SoundStyle($"{nameof(YueMod)}/Items/Yue/Sounds/aweaking");
			SoundEngine.PlaySound(Aweaking);
			base.OnSpawn(source);
        }	
	}
}