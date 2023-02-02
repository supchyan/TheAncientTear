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
	internal class YueUIstate : UIState {
		SoundStyle hideUI = new SoundStyle($"{nameof(YueMod)}/Common/UI/Sounds/hideUI");
		SoundStyle nextSound = new SoundStyle($"{nameof(YueMod)}/Common/UI/Sounds/nextSound");
		SoundStyle endOfTalk = new SoundStyle($"{nameof(YueMod)}/Common/UI/Sounds/endOfTalk");

		//main frame is here.
		private UIElement area;
		private UIImage barFrame;
		private UIText noname;
		private UIText name;
		private UIImage hideButton;
		Asset<Texture2D> hideButtonTexture = ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonHide");
		Asset<Texture2D> hideButtonDownTexture = ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonHide");
		Asset<Texture2D> NextButtonTexture = ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext");
		Asset<Texture2D> NextButtonDownTexture = ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNextDown");

		//Transition textline is here.
		private UIText transitionText;
		private UIImage transitionTextNextButton;

		//Greetings textline is here.
		private UIText greetingsText01;
		private UIImage greetingsText01NextButton;
		private UIText greetingsText02;
		private UIImage greetingsText02NextButton;
		private UIText greetingsText03;
		private UIImage greetingsText03NextButton;
		private UIText greetingsText04;
		private UIImage greetingsText04NextButton;
		private UIText greetingsText05;
		private UIImage greetingsText05NextButton;
		private UIText greetingsText06;
		private UIImage greetingsText06NextButton;
		private UIText greetingsText07;
		private UIImage greetingsText07NextButton;
		private UIText greetingsText08;
		private UIImage greetingsText08NextButton;
		private UIText greetingsText09;
		private UIImage greetingsText09NextButton;
		private UIText greetingsText10;
		private UIImage greetingsText10NextButton;

		//Brain (or worm...) textline is here.
		private UIText BrainText01;
		private UIImage BrainText01NextButton;
		private UIText BrainText02;
		private UIImage BrainText02NextButton;
		private UIText BrainText03;
		private UIImage BrainText03NextButton;
		private UIText BrainText04;
		private UIImage BrainText04NextButton;
		private UIText BrainText05;
		private UIImage BrainText05NextButton;
		private UIText BrainText06;
		private UIImage BrainText06NextButton;
		private UIText BrainText07;
		private UIImage BrainText07NextButton;
		private UIText BrainText08;
		private UIImage BrainText08NextButton;

		//WoF textline is here.
		private UIText WofText01;
		private UIImage WofText01NextButton;
		private UIText WofText02;
		private UIImage WofText02NextButton;
		private UIText WofText03;
		private UIImage WofText03NextButton;
		private UIText WofText04;
		private UIImage WofText04NextButton;
		private UIText WofText05;
		private UIImage WofText05NextButton;
		private UIText WofText06;
		private UIImage WofText06NextButton;
		private UIText WofText07;
		private UIImage WofText07NextButton;
		private UIText WofText08;
		private UIImage WofText08NextButton;
		private UIText WofText09;
		private UIImage WofText09NextButton;

		public override void OnInitialize() {

			//Main UI interface parameters
			area = new UIElement();
			SetRectangle(area, 0f, 60f, 450f, 165f);
			area.HAlign = 0.5f;
			area.VAlign = 0.5f;

			//Yue name is here COLOR IS f1d485!

			noname = new UIText("[c/fff2d6:???]", 1f);
			SetRectangle(noname, 28f, 15f, 0f, 0f);

			name = new UIText("[c/f1d485:Yue]", 1.2f);
			SetRectangle(name, 25f, 13f, 0f, 0f);

			//UI is here
			barFrame = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbar"));
			SetRectangle(barFrame, 0f, 0f, 0f, 0f);

			//Hide button is here
			hideButton = new UIImage(hideButtonTexture);
			SetRectangle(hideButton, 450f - 14f - 16f, 16f, 20f, 20f);
			hideButton.OnClick += new MouseEvent(HideButtonClicked);

			
			//ALL INFO TEXT COLOR IS fff2d6!


			greetingsText01 = new UIText("[c/fff2d6:Uuuhhhh...]", 1.2f);
			SetRectangle(greetingsText01, 20f, 55f, 0, 0);

			greetingsText01NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText01NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			greetingsText01NextButton.OnClick += new MouseEvent(greetingsText01NextButtonClicked);



			greetingsText02 = new UIText("[c/fff2d6:Where am I?...]\n[c/fff2d6:And what the most important, who're you?]\n[c/fff2d6:Friend, enemy, or...]", 1.2f);
			SetRectangle(greetingsText02, 20f, 55f, 0, 0);

			greetingsText02NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText02NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			greetingsText02NextButton.OnClick += new MouseEvent(greetingsText02NextButtonClicked);



			greetingsText03 = new UIText("[c/fff2d6:Anyway, you can't beat me, so ha-ha!]\n[c/fff2d6:I'm ][c/f1d485:Yue][c/fff2d6:, the vampire.]", 1.2f);
			SetRectangle(greetingsText03, 20f, 55f, 0, 0);

			greetingsText03NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText03NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			greetingsText03NextButton.OnClick += new MouseEvent(greetingsText03NextButtonClicked);
			


			greetingsText04 = new UIText("[c/fff2d6:And as I can see, this is not my ][c/b47aff:dimension][c/fff2d6:.]\n[c/fff2d6:Probably this is because of thing, you are]\n[c/fff2d6:holding in hands.]", 1.2f);
			SetRectangle(greetingsText04, 20f, 55f, 0, 0);

			greetingsText04NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText04NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			greetingsText04NextButton.OnClick += new MouseEvent(greetingsText04NextButtonClicked);



			greetingsText05 = new UIText("[c/fff2d6:Wait, I know, this item. Is this... A tear?]\n[c/fff2d6:But it's just a shard. A little piece]\n[c/fff2d6:of the… Nevermind.]", 1.2f);
			SetRectangle(greetingsText05, 20f, 55f, 0, 0);

			greetingsText05NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText05NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			greetingsText05NextButton.OnClick += new MouseEvent(greetingsText05NextButtonClicked);



			greetingsText06 = new UIText("[c/fff2d6:Oh... As I can see, your world has]\n[c/fff2d6:the infection too...]", 1.2f);
			SetRectangle(greetingsText06, 20f, 55f, 0, 0);

			greetingsText06NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText06NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			greetingsText06NextButton.OnClick += new MouseEvent(greetingsText06NextButtonClicked);
			
			
			
			greetingsText07 = new UIText("[c/fff2d6:I mean... I guess we can try to save this]\n[c/fff2d6:world, isn't it?]", 1.2f);
			SetRectangle(greetingsText07, 20f, 55f, 0, 0);

			greetingsText07NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText07NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			greetingsText07NextButton.OnClick += new MouseEvent(greetingsText07NextButtonClicked);



			greetingsText08 = new UIText("[c/fff2d6:If something interesting happens,]\n[c/fff2d6:you can always call me by using this item!]", 1.2f);
			SetRectangle(greetingsText08, 20f, 55f, 0, 0);

			greetingsText08NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText08NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			greetingsText08NextButton.OnClick += new MouseEvent(greetingsText08NextButtonClicked);



			greetingsText09 = new UIText("[c/fff2d6:What's for now, I need a time to think]\n[c/fff2d6:about reasons of transferring me at here]\n[c/fff2d6:and what to do next.]", 1.2f);
			SetRectangle(greetingsText09, 20f, 55f, 0, 0);

			greetingsText09NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText09NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			greetingsText09NextButton.OnClick += new MouseEvent(greetingsText09NextButtonClicked);



			greetingsText10 = new UIText("[c/fff2d6:See you!]", 1.2f);
			SetRectangle(greetingsText10, 20f, 55f, 0, 0);

			greetingsText10NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText10NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			greetingsText10NextButton.OnClick += new MouseEvent(greetingsText10NextButtonClicked);



			//if nothing to say for now, transfer this block of text.
			transitionText = new UIText("[c/fff2d6:Sorry, it's nothing to say for now.]", 1.2f);
			SetRectangle(transitionText, 20f, 55f, 0, 0);

			transitionTextNextButton = new UIImage(NextButtonTexture);
			SetRectangle(transitionTextNextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			transitionTextNextButton.OnClick += new MouseEvent(transitionTextNextButtonClicked);



			//When Worm or Brain has been defeated:
			BrainText01 = new UIText("[c/fff2d6:Crumbled!]", 1.2f);
			SetRectangle(BrainText01, 20f, 55f, 0, 0);

			BrainText01NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText01NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			BrainText01NextButton.OnClick += new MouseEvent(BrainText01NextButtonClicked);



			BrainText02 = new UIText("[c/fff2d6:An infection soul is about to be free.]", 1.2f);
			SetRectangle(BrainText02, 20f, 55f, 0, 0);

			BrainText02NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText02NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			BrainText02NextButton.OnClick += new MouseEvent(BrainText02NextButtonClicked);



			BrainText03 = new UIText("[c/fff2d6:You is moving right way!]\n[c/fff2d6:Now I see, we can save this world.]", 1.2f);
			SetRectangle(BrainText03, 20f, 55f, 0, 0);

			BrainText03NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText03NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			BrainText03NextButton.OnClick += new MouseEvent(BrainText03NextButtonClicked);



			BrainText04 = new UIText("[c/fff2d6:And before we'll disperse, I found this]\n[c/fff2d6:into depths of the cave below.]", 1.2f);
			SetRectangle(BrainText04, 20f, 55f, 0, 0);

			BrainText04NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText04NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			BrainText04NextButton.OnClick += new MouseEvent(BrainText04NextButtonClicked);



			BrainText05 = new UIText("[c/fff2d6:Don't ask why it's here, I don't know too,]\n[c/fff2d6:but it's name - ][c/ff214e:Pile Bunker][c/fff2d6:.]", 1.2f);
			SetRectangle(BrainText05, 20f, 55f, 0, 0);

			BrainText05NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText05NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			BrainText05NextButton.OnClick += new MouseEvent(BrainText05NextButtonClicked);



			BrainText06 = new UIText("[c/fff2d6:Strong weapon for... Hellivators~]\n[c/fff2d6:Also, if something will be below of it upon]\n[c/fff2d6:usage, it will be demolished.]", 1.2f);
			SetRectangle(BrainText06, 20f, 55f, 0, 0);

			BrainText06NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText06NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			BrainText06NextButton.OnClick += new MouseEvent(BrainText06NextButtonClicked);



			BrainText07 = new UIText("[c/fff2d6:Use it as you wish and...]", 1.2f);
			SetRectangle(BrainText07, 20f, 55f, 0, 0);

			BrainText07NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText07NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			BrainText07NextButton.OnClick += new MouseEvent(BrainText07NextButtonClicked);



			BrainText08 = new UIText("[c/fff2d6:Get move next!]", 1.2f);
			SetRectangle(BrainText08, 20f, 55f, 0, 0);

			BrainText08NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText08NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			BrainText08NextButton.OnClick += new MouseEvent(BrainText08NextButtonClicked);
			


			//When Wall of Flesh has been defeated:
			WofText01 = new UIText("[c/fff2d6:Disgusting creature... I'm calm, you dealt]\n[c/fff2d6:it.]", 1.2f);
			SetRectangle(WofText01, 20f, 55f, 0, 0);

			WofText01NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText01NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			WofText01NextButton.OnClick += new MouseEvent(WofText01NextButtonClicked);


			
			WofText02 = new UIText("[c/fff2d6:Huh?!]", 1.2f);
			SetRectangle(WofText02, 20f, 55f, 0, 0);

			WofText02NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText02NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			WofText02NextButton.OnClick += new MouseEvent(WofText02NextButtonClicked);



			WofText03 = new UIText("[c/fff2d6:...]", 1.2f);
			SetRectangle(WofText03, 20f, 55f, 0, 0);

			WofText03NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText03NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			WofText03NextButton.OnClick += new MouseEvent(WofText03NextButtonClicked);



			WofText04 = new UIText("[c/fff2d6:Wait, this gun... He's alive...]\n[c/fff2d6:Is this because of using this shard again?]\n[c/fff2d6:How interesting.]", 1.2f);
			SetRectangle(WofText04, 20f, 55f, 0, 0);

			WofText04NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText04NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			WofText04NextButton.OnClick += new MouseEvent(WofText04NextButtonClicked);



			WofText05 = new UIText("[c/fff2d6:This revolver is called ][c/ff214e:The Donner][c/fff2d6:.]\n[c/fff2d6:It can burn even high tier enemies!]\n[c/fff2d6:Probably.]", 1.2f);
			SetRectangle(WofText05, 20f, 55f, 0, 0);

			WofText05NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText05NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			WofText05NextButton.OnClick += new MouseEvent(WofText05NextButtonClicked);



			WofText06 = new UIText("[c/fff2d6:The owner uses The Donner in conjunction]\n[c/fff2d6:with Schlag, another revolver.]", 1.2f);
			SetRectangle(WofText06, 20f, 55f, 0, 0);

			WofText06NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText06NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			WofText06NextButton.OnClick += new MouseEvent(WofText06NextButtonClicked);



			WofText07 = new UIText("[c/fff2d6:But somehow we got only one of it...]\n[c/fff2d6:Or it's replica, who knows.]", 1.2f);
			SetRectangle(WofText07, 20f, 55f, 0, 0);

			WofText07NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText07NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			WofText07NextButton.OnClick += new MouseEvent(WofText07NextButtonClicked);



			WofText08 = new UIText("[c/fff2d6:Anyway, continue your adventure.]\n[c/fff2d6:I'll notify you when I'll find more]\n[c/fff2d6:information.]", 1.2f);
			SetRectangle(WofText08, 20f, 55f, 0, 0);

			WofText08NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText08NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			WofText08NextButton.OnClick += new MouseEvent(WofText08NextButtonClicked);



			WofText09 = new UIText("[c/fff2d6:That's all for now!]", 1.2f);
			SetRectangle(WofText09, 20f, 55f, 0, 0);

			WofText09NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText09NextButton, 450f - 14f - 17f, 165f - 14f - 17f, 20f, 20f);
			WofText09NextButton.OnClick += new MouseEvent(WofText09NextButtonClicked);



			area.Append(barFrame);
			area.Append(noname);
			area.Append(hideButton);


			area.Append(greetingsText01);
			area.Append(greetingsText01NextButton);
			

			Append(area);
		}



		bool greetingsCheck = false;
		bool brainCheck = false;
		bool wofCheck = false;
		bool wofFirstTime = true;
		bool brainFirstTime = true;
		int switcher = 0;
		public override void Update(GameTime gameTime) {
			if (DownedBossSystem.Brain && brainCheck == false) {
				brainCheck = true;
			}	
			if (DownedBossSystem.WoF && wofCheck == false) {
				wofCheck = true;
			}	
			if(greetingsCheck == true) {
				if ((brainCheck == true && wofCheck == true && brainFirstTime == true && switcher == 0) || (brainCheck == true && wofCheck == false && brainFirstTime == true)) {
					area.RemoveChild(transitionText);
					area.RemoveChild(transitionTextNextButton);
					area.Append(BrainText01);
					area.Append(BrainText01NextButton);
				}
				else if ((wofCheck == true && brainCheck == true && wofFirstTime == true && switcher == 1) || (wofCheck == true && brainCheck == false && wofFirstTime == true) ) {
					area.RemoveChild(transitionText);
					area.RemoveChild(transitionTextNextButton);
					area.Append(WofText01);
					area.Append(WofText01NextButton);
				}
			}
			base.Update(gameTime);
			if (Main.LocalPlayer.HasBuff(ModContent.BuffType<YueBuff>()) && hideButton.IsMouseHovering) {
				Main.instance.MouseText("Hide window");
    		}
			if (Main.LocalPlayer.HasBuff(ModContent.BuffType<YueBuff>()) && (greetingsText01NextButton.IsMouseHovering || greetingsText02NextButton.IsMouseHovering || greetingsText03NextButton.IsMouseHovering || greetingsText04NextButton.IsMouseHovering || greetingsText05NextButton.IsMouseHovering || greetingsText06NextButton.IsMouseHovering || greetingsText07NextButton.IsMouseHovering || greetingsText08NextButton.IsMouseHovering || greetingsText09NextButton.IsMouseHovering || greetingsText10NextButton.IsMouseHovering
			|| transitionTextNextButton.IsMouseHovering
			|| BrainText01NextButton.IsMouseHovering || BrainText02NextButton.IsMouseHovering || BrainText03NextButton.IsMouseHovering || BrainText04NextButton.IsMouseHovering || BrainText05NextButton.IsMouseHovering || BrainText06NextButton.IsMouseHovering || BrainText07NextButton.IsMouseHovering || BrainText08NextButton.IsMouseHovering
			|| WofText01NextButton.IsMouseHovering || WofText02NextButton.IsMouseHovering || WofText03NextButton.IsMouseHovering || WofText04NextButton.IsMouseHovering || WofText05NextButton.IsMouseHovering || WofText06NextButton.IsMouseHovering || WofText07NextButton.IsMouseHovering || WofText08NextButton.IsMouseHovering || WofText09NextButton.IsMouseHovering
			)) {
				Main.instance.MouseText("Next");
    		}
		}



		//Hide button
		private void HideButtonClicked(UIMouseEvent evt, UIElement listeningElement) { 
			//ModContent.GetInstance<YueUISystem>().HideMyUI();
			Main.LocalPlayer.ClearBuff(ModContent.BuffType<YueBuff>());
			SoundEngine.PlaySound(hideUI);
		}



		//Greetings
		private void greetingsText01NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText01);
			area.RemoveChild(greetingsText01NextButton);
			area.Append(greetingsText02);
			area.Append(greetingsText02NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText02NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText02);
			area.RemoveChild(greetingsText02NextButton);
			area.RemoveChild(noname);
			area.Append(name);
			area.Append(greetingsText03);
			area.Append(greetingsText03NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText03NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText03);
			area.RemoveChild(greetingsText03NextButton);
			area.Append(greetingsText04);
			area.Append(greetingsText04NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText04NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText04);
			area.RemoveChild(greetingsText04NextButton);
			area.Append(greetingsText05);
			area.Append(greetingsText05NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText05NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText05);
			area.RemoveChild(greetingsText05NextButton);
			area.Append(greetingsText06);
			area.Append(greetingsText06NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText06NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText06);
			area.RemoveChild(greetingsText06NextButton);
			area.Append(greetingsText07);
			area.Append(greetingsText07NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText07NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText07);
			area.RemoveChild(greetingsText07NextButton);
			area.Append(greetingsText08);
			area.Append(greetingsText08NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText08NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText08);
			area.RemoveChild(greetingsText08NextButton);
			area.Append(greetingsText09);
			area.Append(greetingsText09NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText09NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText09);
			area.RemoveChild(greetingsText09NextButton);
			area.Append(greetingsText10);
			area.Append(greetingsText10NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText10NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			//END OF GREETINGS
			area.RemoveChild(greetingsText10);
			area.RemoveChild(greetingsText10NextButton);
			area.Append(transitionText);
			area.Append(transitionTextNextButton);
			Main.LocalPlayer.ClearBuff(ModContent.BuffType<YueBuff>());
			greetingsCheck = true;
			SoundEngine.PlaySound(endOfTalk);
		}



		//Transition
		private void transitionTextNextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			Main.LocalPlayer.ClearBuff(ModContent.BuffType<YueBuff>());
		}



		//Brain
		private void BrainText01NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(BrainText01);
			area.RemoveChild(BrainText01NextButton);
			area.Append(BrainText02);
			area.Append(BrainText02NextButton);
			SoundEngine.PlaySound(nextSound);
			brainFirstTime = false;
		}
		private void BrainText02NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(BrainText02);
			area.RemoveChild(BrainText02NextButton);
			area.Append(BrainText03);
			area.Append(BrainText03NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void BrainText03NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(BrainText03);
			area.RemoveChild(BrainText03NextButton);
			area.Append(BrainText04);
			area.Append(BrainText04NextButton);
			Item.NewItem(Item.GetSource_None(), Main.LocalPlayer.Center, ModContent.ItemType<PileBunkerItem>());
			SoundEngine.PlaySound(nextSound);
		}
		private void BrainText04NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(BrainText04);
			area.RemoveChild(BrainText04NextButton);
			area.Append(BrainText05);
			area.Append(BrainText05NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void BrainText05NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(BrainText05);
			area.RemoveChild(BrainText05NextButton);
			area.Append(BrainText06);
			area.Append(BrainText06NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void BrainText06NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(BrainText06);
			area.RemoveChild(BrainText06NextButton);
			area.Append(BrainText07);
			area.Append(BrainText07NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void BrainText07NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(BrainText07);
			area.RemoveChild(BrainText07NextButton);
			area.Append(BrainText08);
			area.Append(BrainText08NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void BrainText08NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			//END OF BRAIN
			area.RemoveChild(BrainText08);
			area.RemoveChild(BrainText08NextButton);
			area.Append(transitionText);
			area.Append(transitionTextNextButton);
			Main.LocalPlayer.ClearBuff(ModContent.BuffType<YueBuff>());
			SoundEngine.PlaySound(endOfTalk);

			
			if (wofCheck == false) {
				switcher = 1;
			}
			else if (wofCheck == true && wofFirstTime == true) {
				switcher = 1;
			}
			else if (wofCheck == true && wofFirstTime == false) {
				switcher = -1;
			}
		}



		//WoF
		private void WofText01NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(WofText01);
			area.RemoveChild(WofText01NextButton);
			area.Append(WofText02);
			area.Append(WofText02NextButton);
			Item.NewItem(Item.GetSource_None(), Main.LocalPlayer.Center, ModContent.ItemType<Donner>());
			SoundEngine.PlaySound(nextSound);
			wofFirstTime = false;
		}
		private void WofText02NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(WofText02);
			area.RemoveChild(WofText02NextButton);
			area.Append(WofText03);
			area.Append(WofText03NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void WofText03NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(WofText03);
			area.RemoveChild(WofText03NextButton);
			area.Append(WofText04);
			area.Append(WofText04NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void WofText04NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(WofText04);
			area.RemoveChild(WofText04NextButton);
			area.Append(WofText05);
			area.Append(WofText05NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void WofText05NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(WofText05);
			area.RemoveChild(WofText05NextButton);
			area.Append(WofText06);
			area.Append(WofText06NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void WofText06NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(WofText06);
			area.RemoveChild(WofText06NextButton);
			area.Append(WofText07);
			area.Append(WofText07NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void WofText07NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(WofText07);
			area.RemoveChild(WofText07NextButton);
			area.Append(WofText08);
			area.Append(WofText08NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void WofText08NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(WofText08);
			area.RemoveChild(WofText08NextButton);
			area.Append(WofText09);
			area.Append(WofText09NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void WofText09NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			//END OF WOF
			area.RemoveChild(WofText09);
			area.RemoveChild(WofText09NextButton);
			area.Append(transitionText);
			area.Append(transitionTextNextButton);
			Main.LocalPlayer.ClearBuff(ModContent.BuffType<YueBuff>());
			SoundEngine.PlaySound(endOfTalk);
			wofFirstTime = false;
			if (brainCheck == false) {
				switcher = 0;
			}
			else if (brainCheck == true && brainFirstTime == false) {
				switcher = -1;
			}
		}


		
		private void SetRectangle(UIElement uiElement, float left, float top, float width, float height) {
			uiElement.Left.Set(left, 0f);
			uiElement.Top.Set(top, 0f);
			uiElement.Width.Set(width, 0f);
			uiElement.Height.Set(height, 0f);
		}
		public override void Draw(SpriteBatch spriteBatch) {
			if (Main.LocalPlayer.HasBuff(ModContent.BuffType<YueBuff>())) {
				base.Draw(spriteBatch);
			}
		}
		protected override void DrawSelf(SpriteBatch spriteBatch) {
			if (Main.LocalPlayer.HasBuff(ModContent.BuffType<YueBuff>())) {
				base.DrawSelf(spriteBatch);
				Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
				hitbox.X += 12;
				hitbox.Width -= 24;
				hitbox.Y += 8;
				hitbox.Height -= 16;
			}
		}
	}


	//can be ported into other code file if needed.
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