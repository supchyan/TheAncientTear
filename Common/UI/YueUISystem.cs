using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameInput;
using YueMod.Items.Yue;
using YueMod.Items.Donner;
using YueMod.Items.PileBunker;
using YueMod.Systems;
using Terraria.Audio;
using YueMod.Common.UI;
using Terraria.GameContent;
using System.Collections.Generic;
using ReLogic.Content;
namespace YueMod.Common.UI {
    class YueUISystem : ModSystem
	{
		private UserInterface YueUserInterface;

		internal YueUIstate YueUI;
		public void ShowMyUI() {
			YueUserInterface?.SetState(YueUI);
		}
		public void HideMyUI() {
			YueUserInterface?.SetState(null);
		}
		public override void Load() {
			if (!Main.dedServ) {
				YueUI = new();
				YueUserInterface = new();
				YueUserInterface.SetState(YueUI);
			}
		}
		public override void UpdateUI(GameTime gameTime) {
			YueUserInterface?.Update(gameTime);
		}
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
			int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if (resourceBarIndex != -1) {
				layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
					"YueMod: YueUIbar",
					delegate {
						YueUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
	}
}