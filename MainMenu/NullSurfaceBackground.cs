using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace YueMod.MainMenu
{
	internal class NullSurfaceBackground : ModSurfaceBackgroundStyle
	{
		private static readonly string TexPath = $"{nameof(YueMod)}/Assets/BlankPixel";

		public override void ModifyFarFades(float[] fades, float transitionSpeed)
		{
			for (int i = 0; i < fades.Length; i++)
			{
				if (i == base.Slot)
				{
					fades[i] += transitionSpeed;
					if (fades[i] > 1f)
					{
						fades[i] = 1f;
					}
				}
				else
				{
					fades[i] -= transitionSpeed;
					if (fades[i] < 0f)
					{
						fades[i] = 0f;
					}
				}
			}
		}

		public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
		{
			return BackgroundTextureLoader.GetBackgroundSlot(NullSurfaceBackground.TexPath);
		}

		public override int ChooseFarTexture()
		{
			return BackgroundTextureLoader.GetBackgroundSlot(NullSurfaceBackground.TexPath);
		}

		public override int ChooseMiddleTexture()
		{
			return BackgroundTextureLoader.GetBackgroundSlot(NullSurfaceBackground.TexPath);
		}

		public override bool PreDrawCloseBackground(SpriteBatch spriteBatch)
		{
			return false;
		}
	}
}