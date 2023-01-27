using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using YueMod.MainMenu;

public class TATMainMenu : ModMenu
{
	public class Cinder
	{
		public int Time;

		public int Lifetime;

		public int IdentityIndex;

		public float Scale;

		public float Depth;

		public Color DrawColor;

		public Vector2 Velocity;

		public Vector2 Center;

		public Cinder(int lifetime, int identity, float depth, Color color, Vector2 startingPosition, Vector2 startingVelocity)
		{
			this.Lifetime = lifetime;
			this.IdentityIndex = identity;
			this.Depth = depth;
			this.DrawColor = color;
			this.Center = startingPosition;
			this.Velocity = startingVelocity;
		}
	}

	public static List<Cinder> Cinders { get; internal set; } = new List<Cinder>();


	public override string DisplayName => "The Ancient Tear";

	public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>($"{nameof(YueMod)}/MainMenu/Logo");
	public override int Music => MusicLoader.GetMusicSlot($"{nameof(YueMod)}/MainMenu/Music/AnyOldTimes");
	public override void OnSelected() {
			SoundStyle Transition = new SoundStyle($"{nameof(YueMod)}/MainMenu/Music/Transition");
			SoundEngine.PlaySound(Transition);
		}
	public override Asset<Texture2D> SunTexture => ModContent.Request<Texture2D>($"{nameof(YueMod)}/MainMenu/BlankPixel");

	public override Asset<Texture2D> MoonTexture => ModContent.Request<Texture2D>($"{nameof(YueMod)}/MainMenu/BlankPixel");

	public override ModSurfaceBackgroundStyle MenuBackgroundStyle => ModContent.GetInstance<NullSurfaceBackground>();

	public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
	{
		Texture2D texture = ModContent.Request<Texture2D>($"{nameof(YueMod)}/MainMenu/Backgrounds/BackgroundGray").Value;
		Vector2 drawOffset = Vector2.Zero;
		float xScale = (float)Main.screenWidth / (float)texture.Width;
		float yScale = (float)Main.screenHeight / (float)texture.Height;
		float scale = xScale;
		if (xScale != yScale)
		{
			if (yScale > xScale)
			{
				scale = yScale;
				drawOffset.X -= ((float)texture.Width * scale - (float)Main.screenWidth) * 0.5f;
			}
			else
			{
				drawOffset.Y -= ((float)texture.Height * scale - (float)Main.screenHeight) * 0.5f;
			}
		}
		spriteBatch.Draw(texture, drawOffset, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
		for (int k = 0; k < 5; k++)
		{
			if (Main.rand.NextBool(4))
			{
				int lifetime = Main.rand.Next(0, 500);
				float depth = Main.rand.NextFloat(1.8f, 5f);
				Vector2 startingPosition = new Vector2((float)Main.screenWidth * Main.rand.NextFloat(-0.1f, 1.1f), (float)Main.screenHeight * 1.05f);
				Vector2 startingVelocity = -Vector2.UnitY.RotatedBy(Main.rand.NextFloat(-0.9f, 0.9f)) * 4f;
				Color cinderColor = selectCinderColor();
				TATMainMenu.Cinders.Add(new Cinder(lifetime, TATMainMenu.Cinders.Count, depth, cinderColor, startingPosition, startingVelocity));
			}
		}
		for (int j = 0; j < TATMainMenu.Cinders.Count; j++)
		{
			TATMainMenu.Cinders[j].Scale = Utils.GetLerpValue(TATMainMenu.Cinders[j].Lifetime, TATMainMenu.Cinders[j].Lifetime / 3, TATMainMenu.Cinders[j].Time, clamped: true);
			TATMainMenu.Cinders[j].Scale *= MathHelper.Lerp(0.4f, 0.7f, (float)TATMainMenu.Cinders[j].IdentityIndex % 6f / 6f);
			if (TATMainMenu.Cinders[j].IdentityIndex % 13 == 12)
			{
				TATMainMenu.Cinders[j].Scale *= 0.5f;
			}
			float flySpeed = MathHelper.Lerp(1f, 2f, (float)TATMainMenu.Cinders[j].IdentityIndex % 21f / 21f);
			Vector2 idealVelocity = -Vector2.UnitY.RotatedBy(MathHelper.Lerp(-0.44f, 0.44f, (float)Math.Sin((float)TATMainMenu.Cinders[j].Time / 16f + (float)TATMainMenu.Cinders[j].IdentityIndex) * 0.5f + 0.5f));
			idealVelocity = (idealVelocity + Vector2.UnitX).SafeNormalize(Vector2.UnitY) * flySpeed;
			float movementInterpolant = MathHelper.Lerp(0.01f, 0.08f, Utils.GetLerpValue(45f, 145f, TATMainMenu.Cinders[j].Time, clamped: true));
			TATMainMenu.Cinders[j].Velocity = Vector2.Lerp(TATMainMenu.Cinders[j].Velocity, idealVelocity, movementInterpolant);
			TATMainMenu.Cinders[j].Time++;
			TATMainMenu.Cinders[j].Center += TATMainMenu.Cinders[j].Velocity;
		}
		TATMainMenu.Cinders.RemoveAll((Cinder c) => c.Time >= c.Lifetime);
		Texture2D cinderTexture = ModContent.Request<Texture2D>($"{nameof(YueMod)}/MainMenu/Cinder").Value;
		for (int i = 0; i < TATMainMenu.Cinders.Count; i++)
		{
			Vector2 drawPosition = TATMainMenu.Cinders[i].Center;
			spriteBatch.Draw(cinderTexture, drawPosition, null, TATMainMenu.Cinders[i].DrawColor, 0f, cinderTexture.Size() * 0.5f, TATMainMenu.Cinders[i].Scale, SpriteEffects.None, 0f);
		}
		drawColor = Color.White;
		Main.time = 27000.0;
		Main.dayTime = true;
		Vector2 drawPos = new Vector2((float)Main.screenWidth / 2f, 100f);
		spriteBatch.End();
		spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.LinearClamp, DepthStencilState.None, Main.Rasterizer, null, Main.UIScaleMatrix);
		spriteBatch.Draw(this.Logo.Value, drawPos, null, drawColor, logoRotation, this.Logo.Value.Size() * 0.5f, logoScale, SpriteEffects.None, 0f);
		spriteBatch.End();
		spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, Main.Rasterizer, null, Main.UIScaleMatrix);
		return false;
		static Color selectCinderColor()
		{
			if (Main.rand.NextBool(3))
			{
				return Color.Lerp(Color.DarkGray, Color.LightGray, Main.rand.NextFloat());
			}
			return Color.Lerp(Color.DarkGray, Color.LightGray, Main.rand.NextFloat(0.9f));
		}
	}
}