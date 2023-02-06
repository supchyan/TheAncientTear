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
using YueMod.Items.MetzeleiDisaster;
using YueMod.Systems;
using Terraria.Audio;
using YueMod.Common.UI;
using Terraria.GameContent;
using System.Collections.Generic;
using ReLogic.Content;


namespace YueMod.Common.UI {
	
	internal class YueUIstate : UIState {

		//all sound assets below:
		SoundStyle hideUI = new SoundStyle($"{nameof(YueMod)}/Common/UI/Sounds/hideUI");
		SoundStyle nextSound = new SoundStyle($"{nameof(YueMod)}/Common/UI/Sounds/nextSound");
		SoundStyle endOfTalk = new SoundStyle($"{nameof(YueMod)}/Common/UI/Sounds/endOfTalk");

		//all texture assets below:
		Asset<Texture2D> hideButtonTexture = ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonHide");
		Asset<Texture2D> hideButtonHoveredTexture = ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonHideHover");
		Asset<Texture2D> dragButtonTexture = ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonDrag");
		Asset<Texture2D> dragButtonHoveredTexture = ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonDragHover");
		Asset<Texture2D> NextButtonTexture = ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext");
		Asset<Texture2D> NextButtonHoveredTexture = ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNextHover");
		Asset<Texture2D> EndButtonTexture = ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonEnd");
		Asset<Texture2D> AdviceButtonTexture = ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonAdvice");

		//main frame is here.
		private UIElement area;
		private UIImage barFrame;
		private UIText noname;
		private UIText name;
		private UIImage hideButton;
		private UIImage hideButtonHovered;
		private UIImage dragButton;
		private UIImage dragButtonHovered;

		//Transition textline is here.
		private UIText transitionText;
		private UIImage transitionTextNextButton;

		//Greetings textline is here.
		private UIText greetingsText01;
		private UIImage greetingsText01NextButton;
		private UIImage greetingsText01NextButtonHovered;
		private UIText greetingsText02;
		private UIImage greetingsText02NextButton;
		private UIImage greetingsText02NextButtonHovered;
		private UIText greetingsText03;
		private UIImage greetingsText03NextButton;
		private UIImage greetingsText03NextButtonHovered;
		private UIText greetingsText04;
		private UIImage greetingsText04NextButton;
		private UIImage greetingsText04NextButtonHovered;
		private UIText greetingsText05;
		private UIImage greetingsText05NextButton;
		private UIImage greetingsText05NextButtonHovered;
		private UIText greetingsText06;
		private UIImage greetingsText06NextButton;
		private UIImage greetingsText06NextButtonHovered;
		private UIText greetingsText07;
		private UIImage greetingsText07NextButton;
		private UIImage greetingsText07NextButtonHovered;
		private UIText greetingsText08;
		private UIImage greetingsText08NextButton;
		private UIImage greetingsText08NextButtonHovered;
		private UIText greetingsText09;
		private UIImage greetingsText09NextButton;
		private UIImage greetingsText09NextButtonHovered;
		private UIText greetingsText10;
		private UIImage greetingsText10NextButton;
		private UIImage greetingsText10NextButtonHovered;

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

		//Any Mech textline is here.
		private UIText anyMechText01;
		private UIImage anyMechText01NextButton;
		private UIText anyMechText02;
		private UIImage anyMechText02NextButton;
		private UIText anyMechText03;
		private UIImage anyMechText03NextButton;
		private UIText anyMechText04;
		private UIImage anyMechText04NextButton;
		private UIText anyMechText05;
		private UIImage anyMechText05NextButton;
		private UIText anyMechText06;
		private UIImage anyMechText06NextButton;
		private UIText anyMechText07;
		private UIImage anyMechText07NextButton;
		private UIText anyMechText08;
		private UIImage anyMechText08NextButton;
		
		//Mech textline is here.
		private UIText MechText01;
		private UIImage MechText01NextButton;
		private UIText MechText02;
		private UIImage MechText02NextButton;
		private UIText MechText03;
		private UIImage MechText03NextButton;
		private UIText MechText04;
		private UIImage MechText04NextButton;
		private UIText MechText05;
		private UIImage MechText05NextButton;
		private UIText MechText06;
		private UIImage MechText06NextButton;
		private UIText MechText07;
		private UIImage MechText07NextButton;
		private UIText MechText08;
		private UIImage MechText08NextButton;
		private UIText MechText09;
		private UIImage MechText09NextButton;
		private UIText MechText10;
		private UIImage MechText10NextButton;
		private UIText MechText11;
		private UIImage MechText11NextButton;
		private UIText MechText12;
		private UIImage MechText12NextButton;
		private UIText MechText13;
		private UIImage MechText13NextButton;
		private UIText MechText14;
		private UIImage MechText14NextButton;
		private UIText MechText15;
		private UIImage MechText15NextButton;
		private UIText MechText16;
		private UIImage MechText16NextButton;
		private UIText MechText17;
		private UIImage MechText17NextButton;
		private UIText MechText18;
		private UIImage MechText18NextButton;
		private UIText MechText19;
		private UIImage MechText19NextButton;
		private UIText MechText20;
		private UIImage MechText20NextButton;
		private UIText MechText21;
		private UIImage MechText21NextButton;
		private UIText MechText22;
		private UIImage MechText22NextButton;

		public override void OnInitialize() {

			//Main UI interface parameters
			area = new UIElement();
			SetRectangle(area, 0f, 60f, 450f, 165f);
			area.HAlign = 0.5f;
			area.VAlign = 0.5f;

			//Yue name is here COLOR IS ff5262!

			noname = new UIText("???", 1f);
			SetRectangle(noname, 28f, 15f, 0f, 0f);

			name = new UIText("[c/ff5262:Yue]", 1.2f);
			SetRectangle(name, 25f, 13f, 0f, 0f);

			//UI is here
			barFrame = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbar"));
			SetRectangle(barFrame, 0f, 0f, 0f, 0f);

			//Hide button is here
			hideButton = new UIImage(hideButtonTexture);
			SetRectangle(hideButton, 450f - 31f, 15f, 20f, 20f);

			hideButtonHovered = new UIImage(hideButtonHoveredTexture);
			SetRectangle(hideButtonHovered, 450f - 31f, 15f, 20f, 20f);
			hideButtonHovered.OnClick += new MouseEvent(HideButtonClicked);

			//Drag button is here
			dragButton = new UIImage(dragButtonTexture);
			SetRectangle(dragButton, 450f - 14f*2 - 16f - 22f, 16f, 20f, 20f);
			dragButton.OnMouseDown += new MouseEvent(DragStart);
			dragButton.OnMouseUp += new MouseEvent(DragEnd);

			
			//ALL INFO TEXT COLOR IS fff2d6!


			greetingsText01 = new UIText(Dialogues.gT01, 1.1f);
			SetRectangle(greetingsText01, 20f, 55f, 0, 0);

			greetingsText01NextButton = new UIImage(NextButtonTexture);
			//button box is recalculating into Update() below
			SetRectangle(greetingsText01NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			greetingsText01NextButton.OnClick += new MouseEvent(greetingsText01NextButtonClicked);




			greetingsText02 = new UIText(Dialogues.gT02, 1.1f);
			SetRectangle(greetingsText02, 20f, 55f, 0, 0);

			greetingsText02NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText02NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			greetingsText02NextButton.OnClick += new MouseEvent(greetingsText02NextButtonClicked);



			greetingsText03 = new UIText(Dialogues.gT03, 1.1f);
			SetRectangle(greetingsText03, 20f, 55f, 0, 0);

			greetingsText03NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText03NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			greetingsText03NextButton.OnClick += new MouseEvent(greetingsText03NextButtonClicked);
			


			greetingsText04 = new UIText(Dialogues.gT04, 1.1f);
			SetRectangle(greetingsText04, 20f, 55f, 0, 0);

			greetingsText04NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText04NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			greetingsText04NextButton.OnClick += new MouseEvent(greetingsText04NextButtonClicked);



			greetingsText05 = new UIText(Dialogues.gT05, 1.1f);
			SetRectangle(greetingsText05, 20f, 55f, 0, 0);

			greetingsText05NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText05NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			greetingsText05NextButton.OnClick += new MouseEvent(greetingsText05NextButtonClicked);



			greetingsText06 = new UIText(Dialogues.gT06, 1.1f);
			SetRectangle(greetingsText06, 20f, 55f, 0, 0);

			greetingsText06NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText06NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			greetingsText06NextButton.OnClick += new MouseEvent(greetingsText06NextButtonClicked);
			
			
			
			greetingsText07 = new UIText(Dialogues.gT07, 1.1f);
			SetRectangle(greetingsText07, 20f, 55f, 0, 0);

			greetingsText07NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText07NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			greetingsText07NextButton.OnClick += new MouseEvent(greetingsText07NextButtonClicked);



			greetingsText08 = new UIText(Dialogues.gT08, 1.1f);
			SetRectangle(greetingsText08, 20f, 55f, 0, 0);

			greetingsText08NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText08NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			greetingsText08NextButton.OnClick += new MouseEvent(greetingsText08NextButtonClicked);



			greetingsText09 = new UIText(Dialogues.gT09, 1.1f);
			SetRectangle(greetingsText09, 20f, 55f, 0, 0);

			greetingsText09NextButton = new UIImage(NextButtonTexture);
			SetRectangle(greetingsText09NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			greetingsText09NextButton.OnClick += new MouseEvent(greetingsText09NextButtonClicked);



			greetingsText10 = new UIText(Dialogues.gT10, 1.1f);
			SetRectangle(greetingsText10, 20f, 55f, 0, 0);

			greetingsText10NextButton = new UIImage(EndButtonTexture);
			SetRectangle(greetingsText10NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			greetingsText10NextButton.OnClick += new MouseEvent(greetingsText10NextButtonClicked);



			//if nothing to say for now, transfer this block of text.
			transitionText = new UIText(Dialogues.tT01, 1.1f);
			SetRectangle(transitionText, 20f, 55f, 0, 0);

			transitionTextNextButton = new UIImage(AdviceButtonTexture);
			SetRectangle(transitionTextNextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			transitionTextNextButton.OnClick += new MouseEvent(transitionTextNextButtonClicked);



			//When Worm or Brain has been defeated:
			BrainText01 = new UIText(Dialogues.bT01, 1.1f);
			SetRectangle(BrainText01, 20f, 55f, 0, 0);

			BrainText01NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText01NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			BrainText01NextButton.OnClick += new MouseEvent(BrainText01NextButtonClicked);



			BrainText02 = new UIText(Dialogues.bT02, 1.1f);
			SetRectangle(BrainText02, 20f, 55f, 0, 0);

			BrainText02NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText02NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			BrainText02NextButton.OnClick += new MouseEvent(BrainText02NextButtonClicked);



			BrainText03 = new UIText(Dialogues.bT03, 1.1f);
			SetRectangle(BrainText03, 20f, 55f, 0, 0);

			BrainText03NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText03NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			BrainText03NextButton.OnClick += new MouseEvent(BrainText03NextButtonClicked);



			BrainText04 = new UIText(Dialogues.bT04, 1.1f);
			SetRectangle(BrainText04, 20f, 55f, 0, 0);

			BrainText04NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText04NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			BrainText04NextButton.OnClick += new MouseEvent(BrainText04NextButtonClicked);



			BrainText05 = new UIText(Dialogues.bT05, 1.1f);
			SetRectangle(BrainText05, 20f, 55f, 0, 0);

			BrainText05NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText05NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			BrainText05NextButton.OnClick += new MouseEvent(BrainText05NextButtonClicked);



			BrainText06 = new UIText(Dialogues.bT06, 1.1f);
			SetRectangle(BrainText06, 20f, 55f, 0, 0);

			BrainText06NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText06NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			BrainText06NextButton.OnClick += new MouseEvent(BrainText06NextButtonClicked);



			BrainText07 = new UIText(Dialogues.bT07, 1.1f);
			SetRectangle(BrainText07, 20f, 55f, 0, 0);

			BrainText07NextButton = new UIImage(NextButtonTexture);
			SetRectangle(BrainText07NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			BrainText07NextButton.OnClick += new MouseEvent(BrainText07NextButtonClicked);



			BrainText08 = new UIText(Dialogues.bT08, 1.1f);
			SetRectangle(BrainText08, 20f, 55f, 0, 0);

			BrainText08NextButton = new UIImage(EndButtonTexture);
			SetRectangle(BrainText08NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			BrainText08NextButton.OnClick += new MouseEvent(BrainText08NextButtonClicked);
			


			//When Wall of Flesh has been defeated:
			WofText01 = new UIText(Dialogues.wofT01, 1.1f);
			SetRectangle(WofText01, 20f, 55f, 0, 0);

			WofText01NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText01NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			WofText01NextButton.OnClick += new MouseEvent(WofText01NextButtonClicked);


			
			WofText02 = new UIText(Dialogues.wofT02, 1.1f);
			SetRectangle(WofText02, 20f, 55f, 0, 0);

			WofText02NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText02NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			WofText02NextButton.OnClick += new MouseEvent(WofText02NextButtonClicked);



			WofText03 = new UIText(Dialogues.wofT03, 1.1f);
			SetRectangle(WofText03, 20f, 55f, 0, 0);

			WofText03NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText03NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			WofText03NextButton.OnClick += new MouseEvent(WofText03NextButtonClicked);



			WofText04 = new UIText(Dialogues.wofT04, 1.1f);
			SetRectangle(WofText04, 20f, 55f, 0, 0);

			WofText04NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText04NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			WofText04NextButton.OnClick += new MouseEvent(WofText04NextButtonClicked);



			WofText05 = new UIText(Dialogues.wofT05, 1.1f);
			SetRectangle(WofText05, 20f, 55f, 0, 0);

			WofText05NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText05NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			WofText05NextButton.OnClick += new MouseEvent(WofText05NextButtonClicked);



			WofText06 = new UIText(Dialogues.wofT06, 1.1f);
			SetRectangle(WofText06, 20f, 55f, 0, 0);

			WofText06NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText06NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			WofText06NextButton.OnClick += new MouseEvent(WofText06NextButtonClicked);



			WofText07 = new UIText(Dialogues.wofT07, 1.1f);
			SetRectangle(WofText07, 20f, 55f, 0, 0);

			WofText07NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText07NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			WofText07NextButton.OnClick += new MouseEvent(WofText07NextButtonClicked);



			WofText08 = new UIText(Dialogues.wofT08, 1.1f);
			SetRectangle(WofText08, 20f, 55f, 0, 0);

			WofText08NextButton = new UIImage(NextButtonTexture);
			SetRectangle(WofText08NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			WofText08NextButton.OnClick += new MouseEvent(WofText08NextButtonClicked);



			WofText09 = new UIText(Dialogues.wofT09, 1.1f);
			SetRectangle(WofText09, 20f, 55f, 0, 0);

			WofText09NextButton = new UIImage(EndButtonTexture);
			SetRectangle(WofText09NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			WofText09NextButton.OnClick += new MouseEvent(WofText09NextButtonClicked);



			//Any Mech has been defeated:
			anyMechText01 = new UIText(Dialogues.aMT01, 1.1f);
			SetRectangle(anyMechText01, 20f, 55f, 0, 0);

			anyMechText01NextButton = new UIImage(NextButtonTexture);
			SetRectangle(anyMechText01NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			anyMechText01NextButton.OnClick += new MouseEvent(AnyMechText01NextButtonClicked);



			anyMechText02 = new UIText(Dialogues.aMT02, 1.1f);
			SetRectangle(anyMechText02, 20f, 55f, 0, 0);

			anyMechText02NextButton = new UIImage(NextButtonTexture);
			SetRectangle(anyMechText02NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			anyMechText02NextButton.OnClick += new MouseEvent(AnyMechText02NextButtonClicked);
			


			anyMechText03 = new UIText(Dialogues.aMT03, 1.1f);
			SetRectangle(anyMechText03, 20f, 55f, 0, 0);

			anyMechText03NextButton = new UIImage(NextButtonTexture);
			SetRectangle(anyMechText03NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			anyMechText03NextButton.OnClick += new MouseEvent(AnyMechText03NextButtonClicked);



			anyMechText04 = new UIText(Dialogues.aMT04, 1.1f);
			SetRectangle(anyMechText04, 20f, 55f, 0, 0);

			anyMechText04NextButton = new UIImage(NextButtonTexture);
			SetRectangle(anyMechText04NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			anyMechText04NextButton.OnClick += new MouseEvent(AnyMechText04NextButtonClicked);



			anyMechText05 = new UIText(Dialogues.aMT05, 1.1f);
			SetRectangle(anyMechText05, 20f, 55f, 0, 0);

			anyMechText05NextButton = new UIImage(NextButtonTexture);
			SetRectangle(anyMechText05NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			anyMechText05NextButton.OnClick += new MouseEvent(AnyMechText05NextButtonClicked);



			anyMechText06 = new UIText(Dialogues.aMT06, 1.1f);
			SetRectangle(anyMechText06, 20f, 55f, 0, 0);

			anyMechText06NextButton = new UIImage(NextButtonTexture);
			SetRectangle(anyMechText06NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			anyMechText06NextButton.OnClick += new MouseEvent(AnyMechText06NextButtonClicked);



			anyMechText07 = new UIText(Dialogues.aMT07, 1.1f);
			SetRectangle(anyMechText07, 20f, 55f, 0, 0);

			anyMechText07NextButton = new UIImage(NextButtonTexture);
			SetRectangle(anyMechText07NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			anyMechText07NextButton.OnClick += new MouseEvent(AnyMechText07NextButtonClicked);



			anyMechText08 = new UIText(Dialogues.aMT08, 1.1f);
			SetRectangle(anyMechText08, 20f, 55f, 0, 0);

			anyMechText08NextButton = new UIImage(EndButtonTexture);
			SetRectangle(anyMechText08NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			anyMechText08NextButton.OnClick += new MouseEvent(AnyMechText08NextButtonClicked);




			//Mech has been defeated:
			MechText01 = new UIText(Dialogues.MT01, 1.1f);
			SetRectangle(MechText01, 20f, 55f, 0, 0);

			MechText01NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText01NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText01NextButton.OnClick += new MouseEvent(MechText01NextButtonClicked);



			MechText02 = new UIText(Dialogues.MT02, 1.1f);
			SetRectangle(MechText02, 20f, 55f, 0, 0);

			MechText02NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText02NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText02NextButton.OnClick += new MouseEvent(MechText02NextButtonClicked);



			MechText03 = new UIText(Dialogues.MT03, 1.1f);
			SetRectangle(MechText03, 20f, 55f, 0, 0);

			MechText03NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText03NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText03NextButton.OnClick += new MouseEvent(MechText03NextButtonClicked);



			MechText04 = new UIText(Dialogues.MT04, 1.1f);
			SetRectangle(MechText04, 20f, 55f, 0, 0);

			MechText04NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText04NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText04NextButton.OnClick += new MouseEvent(MechText04NextButtonClicked);



			MechText05 = new UIText(Dialogues.MT05, 1.1f);
			SetRectangle(MechText05, 20f, 55f, 0, 0);

			MechText05NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText05NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText05NextButton.OnClick += new MouseEvent(MechText05NextButtonClicked);



			MechText06 = new UIText(Dialogues.MT06, 1.1f);
			SetRectangle(MechText06, 20f, 55f, 0, 0);

			MechText06NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText06NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText06NextButton.OnClick += new MouseEvent(MechText06NextButtonClicked);



			MechText07 = new UIText(Dialogues.MT07, 1.1f);
			SetRectangle(MechText07, 20f, 55f, 0, 0);

			MechText07NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText07NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText07NextButton.OnClick += new MouseEvent(MechText07NextButtonClicked);



			MechText08 = new UIText(Dialogues.MT08, 1.1f);
			SetRectangle(MechText08, 20f, 55f, 0, 0);

			MechText08NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText08NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText08NextButton.OnClick += new MouseEvent(MechText08NextButtonClicked);



			MechText09 = new UIText(Dialogues.MT09, 1.1f);
			SetRectangle(MechText09, 20f, 55f, 0, 0);

			MechText09NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText09NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText09NextButton.OnClick += new MouseEvent(MechText09NextButtonClicked);



			MechText10 = new UIText(Dialogues.MT10, 1.1f);
			SetRectangle(MechText10, 20f, 55f, 0, 0);

			MechText10NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText10NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText10NextButton.OnClick += new MouseEvent(MechText10NextButtonClicked);



			MechText11 = new UIText(Dialogues.MT11, 1.1f);
			SetRectangle(MechText11, 20f, 55f, 0, 0);

			MechText11NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText11NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText11NextButton.OnClick += new MouseEvent(MechText11NextButtonClicked);



			MechText12 = new UIText(Dialogues.MT12, 1.1f);
			SetRectangle(MechText12, 20f, 55f, 0, 0);

			MechText12NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText12NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText12NextButton.OnClick += new MouseEvent(MechText12NextButtonClicked);



			MechText13 = new UIText(Dialogues.MT13, 1.1f);
			SetRectangle(MechText13, 20f, 55f, 0, 0);

			MechText13NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText13NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText13NextButton.OnClick += new MouseEvent(MechText13NextButtonClicked);



			MechText14 = new UIText(Dialogues.MT14, 1.1f);
			SetRectangle(MechText14, 20f, 55f, 0, 0);

			MechText14NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText14NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText14NextButton.OnClick += new MouseEvent(MechText14NextButtonClicked);



			MechText15 = new UIText(Dialogues.MT15, 1.1f);
			SetRectangle(MechText15, 20f, 55f, 0, 0);

			MechText15NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText15NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText15NextButton.OnClick += new MouseEvent(MechText15NextButtonClicked);



			MechText16 = new UIText(Dialogues.MT16, 1.1f);
			SetRectangle(MechText16, 20f, 55f, 0, 0);

			MechText16NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText16NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText16NextButton.OnClick += new MouseEvent(MechText16NextButtonClicked);



			MechText17 = new UIText(Dialogues.MT17, 1.1f);
			SetRectangle(MechText17, 20f, 55f, 0, 0);

			MechText17NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText17NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText17NextButton.OnClick += new MouseEvent(MechText17NextButtonClicked);



			MechText18 = new UIText(Dialogues.MT18, 1.1f);
			SetRectangle(MechText18, 20f, 55f, 0, 0);

			MechText18NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText18NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText18NextButton.OnClick += new MouseEvent(MechText18NextButtonClicked);



			MechText19 = new UIText(Dialogues.MT19, 1.1f);
			SetRectangle(MechText19, 20f, 55f, 0, 0);

			MechText19NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText19NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText19NextButton.OnClick += new MouseEvent(MechText19NextButtonClicked);



			MechText20 = new UIText(Dialogues.MT20, 1.1f);
			SetRectangle(MechText20, 20f, 55f, 0, 0);

			MechText20NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText20NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText20NextButton.OnClick += new MouseEvent(MechText20NextButtonClicked);



			MechText21 = new UIText(Dialogues.MT21, 1.1f);
			SetRectangle(MechText21, 20f, 55f, 0, 0);

			MechText21NextButton = new UIImage(NextButtonTexture);
			SetRectangle(MechText21NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText21NextButton.OnClick += new MouseEvent(MechText21NextButtonClicked);



			MechText22 = new UIText(Dialogues.MT22, 1.1f);
			SetRectangle(MechText22, 20f, 55f, 0, 0);

			MechText22NextButton = new UIImage(EndButtonTexture);
			SetRectangle(MechText22NextButton, 450f - 31f, 165f - 31f, 20f, 20f);
			MechText22NextButton.OnClick += new MouseEvent(MechText22NextButtonClicked);



			//area.Append(barFrame);
			//area.Append(noname);
			//area.Append(hideButton);
			//area.Append(dragButton);


			//area.Append(greetingsText01);
			//area.Append(greetingsText01NextButton);
			

			Append(area);
		}



		public static bool greetingsCheck = false;
		bool brainCheck = false;
		bool wofCheck = false;
		bool mechCheck = false;
		bool anyMechCheck = false;
		public static bool greetingsFirstTime = true;
		bool brainFirstTime = true;
		bool wofFirstTime = true;
		bool anyMechFirstTime = true;
		bool mechFirstTime = true;
		
		int eventTimer = 0;
		int switcher = -1;
		float anime = 0f;
		public override void Update(GameTime gameTime) {
			

			//Here is the strangest thing in code industry. Downed boss system, that works much different, than need be.
			//I have no idea, why does it's working, but if something is working, better not to touch it, ok?
			if (newCreatedPlayer.newPlayer == true) {

				newCreatedPlayer.newPlayer = false;
				switcher = -1;
				greetingsFirstTime = true;
				greetingsCheck = false;
				brainCheck = false;
				wofCheck = false;
				mechCheck = false;
				area.RemoveAllChildren();
				area.Append(barFrame);
				area.Append(noname);
				area.Append(hideButton);
				area.Append(dragButton);
				area.Append(greetingsText01);
				area.Append(greetingsText01NextButton);
			}

			if (!NPC.downedBoss2) {
				brainFirstTime = true;
				brainCheck = false;
			}
			else if (NPC.downedBoss2 && brainCheck == false) {
				brainCheck = true;
			}



			if (!Main.hardMode) {
				wofFirstTime = true;
				wofCheck = false;
			}
			else if (Main.hardMode && wofCheck == false) {
				wofCheck = true;
			}



			if(!NPC.downedMechBossAny) {
				anyMechFirstTime = true;
				anyMechCheck = false;
			}
			if(NPC.downedMechBossAny && anyMechCheck == false) {
				anyMechCheck = true;
			}



			if (!NPC.downedMechBoss1 || !NPC.downedMechBoss2 || !NPC.downedMechBoss3) {
				mechFirstTime = true;
				mechCheck = false;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && mechCheck == false) {
				mechCheck = true;
			}



			//Switcher system. When some of bosses defeated, UI updating using code below:
			if(greetingsCheck == true) {

				if (brainCheck == true && brainFirstTime == true && switcher == 0) {
					area.RemoveChild(transitionText);
					area.RemoveChild(transitionTextNextButton);
					area.Append(BrainText01);
					area.Append(BrainText01NextButton);
				}



				else if (wofCheck == true && wofFirstTime == true && switcher == 1) {
					area.RemoveChild(transitionText);
					area.RemoveChild(transitionTextNextButton);
					area.Append(WofText01);
					area.Append(WofText01NextButton);

				}



				else if(anyMechCheck == true && anyMechFirstTime == true && switcher == 2) {
					area.RemoveChild(transitionText);
					area.RemoveChild(transitionTextNextButton);
					area.Append(anyMechText01);
					area.Append(anyMechText01NextButton);

				}



				else if (mechCheck == true && mechFirstTime == true && switcher == 3) {
					area.RemoveChild(transitionText);
					area.RemoveChild(transitionTextNextButton);
					area.Append(MechText01);
					area.Append(MechText01NextButton);
				}
			}
			


			//This is kind of notification system. When player doing something wrong, a mod reminds the goal.
			//For now it triggered every 10 seconds, but in the future i'll make around every 15-30 mins.
			base.Update(gameTime);
			while (switcher == 0) {
				eventTimer++;
				if (eventTimer >= 600) {
					Main.NewText("Le Fishe au chocolat 0");
					eventTimer = 0;
				}
				break;
			}
			while (switcher == 1) {
				eventTimer++;
				if (eventTimer >= 600) {
					Main.NewText("Le Fishe au chocolat 1");
					eventTimer = 0;
				}
				break;
			}
			while (switcher == 2) {
				eventTimer++;
				if (eventTimer >= 600) {
					Main.NewText("Le Fishe au chocolat 2");
					eventTimer = 0;
				}
				break;
			}
			while (switcher == 3) {
				eventTimer++;
				if (eventTimer >= 600) {
					Main.NewText("Le Fishe au chocolat 3");
					eventTimer = 0;
				}
				break;
			}
			while (switcher == 4) {
				eventTimer++;
				if (eventTimer >= 1200) {
					Main.NewText("Le Fishe au chocolat 4");
					eventTimer = 0;
				}
				break;
			}
			


			//Timer for arrows animation
			switch (Main.GameUpdateCount / 15 % 2) {

				case 0:

					anime = 2f;

					SetRectangle(transitionTextNextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);

					SetRectangle(greetingsText01NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText02NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText03NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText04NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText05NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText06NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText07NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText08NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText09NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText10NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);

					SetRectangle(BrainText01NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(BrainText02NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(BrainText03NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(BrainText04NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(BrainText05NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(BrainText06NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(BrainText07NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(BrainText08NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					
					SetRectangle(WofText01NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText02NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText03NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText04NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText05NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText06NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText07NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText08NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText09NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);

					SetRectangle(anyMechText01NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(anyMechText02NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(anyMechText03NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(anyMechText04NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(anyMechText05NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(anyMechText06NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(anyMechText07NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(anyMechText08NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);

					SetRectangle(MechText01NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText02NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText03NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText04NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText05NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText06NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText07NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText08NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText09NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText10NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText11NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText12NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText13NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText14NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText15NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText16NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText17NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText18NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText19NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText20NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText21NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText22NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);

					break;
					
				case 1:

					anime = 4f;
					
					SetRectangle(transitionTextNextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);

					SetRectangle(greetingsText01NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText02NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText03NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText04NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText05NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText06NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText07NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText08NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText09NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(greetingsText10NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);

					SetRectangle(BrainText01NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(BrainText02NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(BrainText03NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(BrainText04NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(BrainText05NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(BrainText06NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(BrainText07NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(BrainText08NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					
					SetRectangle(WofText01NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText02NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText03NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText04NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText05NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText06NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText07NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText08NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(WofText09NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);

					SetRectangle(anyMechText01NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(anyMechText02NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(anyMechText03NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(anyMechText04NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(anyMechText05NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(anyMechText06NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(anyMechText07NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(anyMechText08NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);

					SetRectangle(MechText01NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText02NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText03NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText04NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText05NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText06NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText07NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText08NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText09NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText10NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText11NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText12NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText13NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText14NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText15NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText16NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText17NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText18NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText19NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText20NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText21NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);
					SetRectangle(MechText22NextButton, 450f - 35f, 165f - 38f + anime, 22f, 22f);

					break;
			}
			
			//Something for dragging
			if (dragging) {
				area.Left.Set(Main.mouseX - offset.X, 0f);
				area.Top.Set(Main.mouseY - offset.Y, 0f);
				Recalculate();
			}
			if (Main.LocalPlayer.HasBuff(ModContent.BuffType<YueBuff>()) && dragButton.IsMouseHovering) {
				Main.instance.MouseText("Hold to drag window");
    		}

			//Hide button hovering
			if (Main.LocalPlayer.HasBuff(ModContent.BuffType<YueBuff>()) && hideButton.IsMouseHovering) {
				area.RemoveChild(hideButton);
				area.Append(hideButtonHovered);
				Main.instance.MouseText("Hide window");
    		}
			else if (Main.LocalPlayer.HasBuff(ModContent.BuffType<YueBuff>()) && hideButtonHovered.IsMouseHovering) {
				Main.instance.MouseText("Hide window");
			}
			else if (!hideButtonHovered.IsMouseHovering) {
				area.RemoveChild(hideButtonHovered);
				area.Append(hideButton);
			}

			//NextButtons hovering
			if (Main.LocalPlayer.HasBuff(ModContent.BuffType<YueBuff>()) && (
			   greetingsText01NextButton.IsMouseHovering || greetingsText02NextButton.IsMouseHovering || greetingsText03NextButton.IsMouseHovering || greetingsText04NextButton.IsMouseHovering || greetingsText05NextButton.IsMouseHovering || greetingsText06NextButton.IsMouseHovering || greetingsText07NextButton.IsMouseHovering || greetingsText08NextButton.IsMouseHovering || greetingsText09NextButton.IsMouseHovering
			
			|| BrainText01NextButton.IsMouseHovering || BrainText02NextButton.IsMouseHovering || BrainText03NextButton.IsMouseHovering || BrainText04NextButton.IsMouseHovering || BrainText05NextButton.IsMouseHovering || BrainText06NextButton.IsMouseHovering || BrainText07NextButton.IsMouseHovering
			|| WofText01NextButton.IsMouseHovering || WofText02NextButton.IsMouseHovering || WofText03NextButton.IsMouseHovering || WofText04NextButton.IsMouseHovering || WofText05NextButton.IsMouseHovering || WofText06NextButton.IsMouseHovering || WofText07NextButton.IsMouseHovering || WofText08NextButton.IsMouseHovering
			|| MechText01NextButton.IsMouseHovering || MechText02NextButton.IsMouseHovering || MechText03NextButton.IsMouseHovering || MechText04NextButton.IsMouseHovering || MechText05NextButton.IsMouseHovering || MechText06NextButton.IsMouseHovering || MechText07NextButton.IsMouseHovering || MechText08NextButton.IsMouseHovering || MechText09NextButton.IsMouseHovering || MechText10NextButton.IsMouseHovering || MechText11NextButton.IsMouseHovering || MechText12NextButton.IsMouseHovering || MechText13NextButton.IsMouseHovering || MechText14NextButton.IsMouseHovering || MechText15NextButton.IsMouseHovering || MechText16NextButton.IsMouseHovering || MechText17NextButton.IsMouseHovering || MechText18NextButton.IsMouseHovering || MechText19NextButton.IsMouseHovering || MechText20NextButton.IsMouseHovering || MechText21NextButton.IsMouseHovering
			|| anyMechText01NextButton.IsMouseHovering || anyMechText02NextButton.IsMouseHovering || anyMechText03NextButton.IsMouseHovering || anyMechText04NextButton.IsMouseHovering || anyMechText05NextButton.IsMouseHovering || anyMechText06NextButton.IsMouseHovering || anyMechText07NextButton.IsMouseHovering
			)) {
				Main.instance.MouseText("Next");
    		}
			if (Main.LocalPlayer.HasBuff(ModContent.BuffType<YueBuff>()) && (
			   greetingsText10NextButton.IsMouseHovering
			|| transitionTextNextButton.IsMouseHovering
			|| BrainText08NextButton.IsMouseHovering
			|| WofText09NextButton.IsMouseHovering
			|| anyMechText08NextButton.IsMouseHovering
			|| MechText22NextButton.IsMouseHovering
			)) {
				Main.instance.MouseText("Close the topic");
    		}
		}



		//Hide button
		private void HideButtonClicked(UIMouseEvent evt, UIElement listeningElement) { 
			//ModContent.GetInstance<YueUISystem>().HideMyUI();
			Main.LocalPlayer.ClearBuff(ModContent.BuffType<YueBuff>());
			SoundEngine.PlaySound(hideUI);
		}


		//Dragable events below:
		private Vector2 offset;
		private bool dragging;
		private void DragStart(UIMouseEvent evt, UIElement listeningElement) {
			offset = new Vector2(evt.MousePosition.X - area.Left.Pixels, evt.MousePosition.Y - area.Top.Pixels);
			dragging = true;
			Recalculate();
		}
		private void DragEnd(UIMouseEvent evt, UIElement listeningElement) {
			Vector2 endMousePosition = evt.MousePosition;
			dragging = false;
			area.Left.Set(endMousePosition.X - offset.X, 0f);
			area.Top.Set(endMousePosition.Y - offset.Y, 0f);
			Recalculate();
		}



		//Greetings
		private void greetingsText01NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText01);
			area.RemoveChild(greetingsText01NextButton);
			area.Append(greetingsText02);
			area.Append(greetingsText02NextButton);
			SoundEngine.PlaySound(nextSound);
			greetingsFirstTime = false;
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
			if (WorldGen.crimson && brainFirstTime && switcher != 0) {
				switcher = 0;
				Main.NewText("[c/ffcf21:「]" + "[c/ffcf21:System]" + "[c/ffcf21:」]" + "  Defeating The Brain of Cthulhu is required to receive information about the main story.");
				//Main.NewText(switcher);
				if (brainCheck)  {
					Main.NewText("[c/ffcf21:「]" + "[c/ffcf21:System]" + "[c/ffcf21:」]" + "  Game data has been refreshed. Use the Tear's shard when into your inventory to receive information about main story.");
				}
			}
			else if (!WorldGen.crimson && brainFirstTime && switcher != 0) {
				switcher = 0;
				Main.NewText("[c/ffcf21:「]" + "[c/ffcf21:System]" + "[c/ffcf21:」]" + "  Defeating The Eater of Worlds is required to receive information about the main story.");
				//Main.NewText(switcher);
				if (brainCheck)  {
					Main.NewText("[c/ffcf21:「]" + "[c/ffcf21:System]" + "[c/ffcf21:」]" + "  Game data has been refreshed. Use the Tear's shard when into your inventory to receive information about main story.");
				}
			}
			else if (!brainFirstTime && wofFirstTime && switcher != 1) {
				switcher = 1;
				Main.NewText("[c/ffcf21:「]" + "[c/ffcf21:System]" + "[c/ffcf21:」]" + "  Defeating The Wall of Flesh is required to receive information about the main story.");
				//Main.NewText(switcher);
				if (wofCheck)  {
					Main.NewText("[c/ffcf21:「]" + "[c/ffcf21:System]" + "[c/ffcf21:」]" + "  Game data has been refreshed. Use the Tear's shard when into your inventory to receive information about main story.");
				}
			}
			else if (!brainFirstTime && !wofFirstTime && anyMechFirstTime == true && switcher != 2) {
				switcher = 2;
				Main.NewText("[c/ffcf21:「]" + "[c/ffcf21:System]" + "[c/ffcf21:」]" + "  Defeating The Mechanical boss is required to receive information about the main story.");
				//Main.NewText(switcher);
				if (anyMechCheck)  {
					Main.NewText("[c/ffcf21:「]" + "[c/ffcf21:System]" + "[c/ffcf21:」]" + "  Game data has been refreshed. Use the Tear's shard when into your inventory to receive information about main story.");
				}
			}
			else if (!brainFirstTime && !wofFirstTime && !anyMechFirstTime && mechFirstTime && switcher != 3) {
				switcher = 3;
				Main.NewText("[c/ffcf21:「]" + "[c/ffcf21:System]" + "[c/ffcf21:」]" + "  Defeating all The Mechanical Bosses is required to receive information about the main story.");
				//Main.NewText(switcher);
				if (mechCheck)  {
					Main.NewText("[c/ffcf21:「]" + "[c/ffcf21:System]" + "[c/ffcf21:」]" + "  Game data has been refreshed. Use the Tear's shard when into your inventory to receive information about main story.");
				}
			}
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

			switcher = 2;
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
			//wofFirstTime = false;

			switcher = 3;
		}



		//any Mech
		private void AnyMechText01NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(anyMechText01);
			area.RemoveChild(anyMechText01NextButton);
			area.Append(anyMechText02);
			area.Append(anyMechText02NextButton);
			SoundEngine.PlaySound(nextSound);
			anyMechFirstTime = false;
		}
		private void AnyMechText02NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(anyMechText02);
			area.RemoveChild(anyMechText02NextButton);
			area.Append(anyMechText03);
			area.Append(anyMechText03NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void AnyMechText03NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(anyMechText03);
			area.RemoveChild(anyMechText03NextButton);
			area.Append(anyMechText04);
			area.Append(anyMechText04NextButton);
			Item.NewItem(Item.GetSource_None(), Main.LocalPlayer.Center, ModContent.ItemType<MetzeleiDisaster>());
			SoundEngine.PlaySound(nextSound);
		}
		private void AnyMechText04NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(anyMechText04);
			area.RemoveChild(anyMechText04NextButton);
			area.Append(anyMechText05);
			area.Append(anyMechText05NextButton);
			SoundEngine.PlaySound(nextSound);

		}
		private void AnyMechText05NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(anyMechText05);
			area.RemoveChild(anyMechText05NextButton);
			area.Append(anyMechText06);
			area.Append(anyMechText06NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void AnyMechText06NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(anyMechText06);
			area.RemoveChild(anyMechText06NextButton);
			area.Append(anyMechText07);
			area.Append(anyMechText07NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void AnyMechText07NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(anyMechText07);
			area.RemoveChild(anyMechText07NextButton);
			area.Append(anyMechText08);
			area.Append(anyMechText08NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void AnyMechText08NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(anyMechText08);
			area.RemoveChild(anyMechText08NextButton);
			area.Append(transitionText);
			area.Append(transitionTextNextButton);
			SoundEngine.PlaySound(nextSound);
			Main.LocalPlayer.ClearBuff(ModContent.BuffType<YueBuff>());
			SoundEngine.PlaySound(endOfTalk);
			
			switcher = 4;
		}




		//Mech
		private void MechText01NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText01);
			area.RemoveChild(MechText01NextButton);
			area.Append(MechText02);
			area.Append(MechText02NextButton);
			SoundEngine.PlaySound(nextSound);
			mechFirstTime = false;
		}
		private void MechText02NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText02);
			area.RemoveChild(MechText02NextButton);
			area.Append(MechText03);
			area.Append(MechText03NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText03NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText03);
			area.RemoveChild(MechText03NextButton);
			area.Append(MechText04);
			area.Append(MechText04NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText04NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText04);
			area.RemoveChild(MechText04NextButton);
			area.Append(MechText05);
			area.Append(MechText05NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText05NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText05);
			area.RemoveChild(MechText05NextButton);
			area.Append(MechText06);
			area.Append(MechText06NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText06NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText06);
			area.RemoveChild(MechText06NextButton);
			area.Append(MechText07);
			area.Append(MechText07NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText07NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText07);
			area.RemoveChild(MechText07NextButton);
			area.Append(MechText08);
			area.Append(MechText08NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText08NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText08);
			area.RemoveChild(MechText08NextButton);
			area.Append(MechText09);
			area.Append(MechText09NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText09NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText09);
			area.RemoveChild(MechText09NextButton);
			area.Append(MechText10);
			area.Append(MechText10NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText10NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText10);
			area.RemoveChild(MechText10NextButton);
			area.Append(MechText11);
			area.Append(MechText11NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText11NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText11);
			area.RemoveChild(MechText11NextButton);
			area.Append(MechText12);
			area.Append(MechText12NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText12NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText12);
			area.RemoveChild(MechText12NextButton);
			area.Append(MechText13);
			area.Append(MechText13NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText13NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText13);
			area.RemoveChild(MechText13NextButton);
			area.Append(MechText14);
			area.Append(MechText14NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText14NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText14);
			area.RemoveChild(MechText14NextButton);
			area.Append(MechText15);
			area.Append(MechText15NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText15NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText15);
			area.RemoveChild(MechText15NextButton);
			area.Append(MechText16);
			area.Append(MechText16NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText16NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText16);
			area.RemoveChild(MechText16NextButton);
			area.Append(MechText17);
			area.Append(MechText17NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText17NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText17);
			area.RemoveChild(MechText17NextButton);
			area.Append(MechText18);
			area.Append(MechText18NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText18NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText18);
			area.RemoveChild(MechText18NextButton);
			area.Append(MechText19);
			area.Append(MechText19NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText19NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText19);
			area.RemoveChild(MechText19NextButton);
			area.Append(MechText20);
			area.Append(MechText20NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText20NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText20);
			area.RemoveChild(MechText20NextButton);
			area.Append(MechText21);
			area.Append(MechText21NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText21NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(MechText21);
			area.RemoveChild(MechText21NextButton);
			area.Append(MechText22);
			area.Append(MechText22NextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void MechText22NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			//End of mech
			area.RemoveChild(MechText22);
			area.RemoveChild(MechText22NextButton);
			area.Append(transitionText);
			area.Append(transitionTextNextButton);
			SoundEngine.PlaySound(endOfTalk);
			Main.LocalPlayer.ClearBuff(ModContent.BuffType<YueBuff>());
			
			switcher = 5;
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
	
}