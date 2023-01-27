using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
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

		//Transition textline is here.
		private UIText transitionText;
		private UIImage transitionTextNextButton;

		//Greetings textline is here.
		private UIText greetingsText01;
		private UIImage greetingsText01nextButton;
		private UIText greetingsText02;
		private UIImage greetingsText02nextButton;
		private UIText greetingsText03;
		private UIImage greetingsText03nextButton;
		private UIText greetingsText04;
		private UIImage greetingsText04nextButton;
		private UIText greetingsText05;
		private UIImage greetingsText05nextButton;
		private UIText greetingsText06;
		private UIImage greetingsText06nextButton;
		private UIText greetingsText07;
		private UIImage greetingsText07nextButton;
		private UIText greetingsText08;
		private UIImage greetingsText08nextButton;
		private UIText greetingsText09;
		private UIImage greetingsText09nextButton;
		private UIText greetingsText10;
		private UIImage greetingsText10nextButton;

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
			area.Width.Set(450, 0f);
			area.Height.Set(165, 0f);
			area.Top.Set(60, 0f);
			area.Left.Set(0, 0f);
			area.HAlign = 0.5f;
			area.VAlign = 0.5f;
			//Yue name is here COLOR IS f1d485!
			noname = new UIText("[c/fff2d6:???]", 1f); // text to show stat
			noname.Width.Set(0, 0f);
			noname.Height.Set(0, 0f);
			noname.Top.Set(15, 0f);
			noname.Left.Set(28, 0f);

			name = new UIText("[c/f1d485:Yue]", 1.2f); // text to show stat
			name.Width.Set(0, 0f);
			name.Height.Set(0, 0f);
			name.Top.Set(13, 0f);
			name.Left.Set(25, 0f);
			//UI is here
			barFrame = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbar"));
			barFrame.Left.Set(0, 0f);
			barFrame.Top.Set(0, 0f);
			barFrame.Width.Set(0, 0f);
			barFrame.Height.Set(0, 0f);
			//Close button is here
			hideButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonClose"));
			hideButton.Width.Set(20, 0f);
			hideButton.Height.Set(20, 0f);
			hideButton.Left.Set(area.Width.Pixels - hideButton.Width.Pixels - 10, 0f);
			hideButton.Top.Set(16, 0f);
			hideButton.OnClick += new MouseEvent(HideButtonClicked);


			//ALL INFO TEXT COLOR IS fff2d6!


			greetingsText01 = new UIText("[c/fff2d6:Uuuhhhh...]", 1.2f); // text to show stat
			greetingsText01.Width.Set(0, 0f);
			greetingsText01.Height.Set(0, 0f);
			greetingsText01.Top.Set(55, 0f);
			greetingsText01.Left.Set(20, 0f);
			//Next button for switch (need to be original for EVERY PAGE FUCK...)
			greetingsText01nextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			greetingsText01nextButton.Width.Set(20, 0f);
			greetingsText01nextButton.Height.Set(20, 0f);
			greetingsText01nextButton.Left.Set(area.Width.Pixels - greetingsText01nextButton.Width.Pixels - 15, 0f);
			greetingsText01nextButton.Top.Set(area.Height.Pixels - greetingsText01nextButton.Width.Pixels - 10, 0f);
			greetingsText01nextButton.OnClick += new MouseEvent(greetingsText01NextButtonClicked);



			greetingsText02 = new UIText("[c/fff2d6:Where am I?...]\n[c/fff2d6:And what the most important, who're you?]\n[c/fff2d6:Friend, enemy, or...]", 1.2f);
			greetingsText02.Width.Set(0, 0f);
			greetingsText02.Height.Set(0, 0f);
			greetingsText02.Top.Set(55, 0f);
			greetingsText02.Left.Set(20, 0f);

			greetingsText02nextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			greetingsText02nextButton.Width.Set(20, 0f);
			greetingsText02nextButton.Height.Set(20, 0f);
			greetingsText02nextButton.Left.Set(area.Width.Pixels - greetingsText02nextButton.Width.Pixels - 15, 0f);
			greetingsText02nextButton.Top.Set(area.Height.Pixels - greetingsText02nextButton.Width.Pixels - 10, 0f);
			greetingsText02nextButton.OnClick += new MouseEvent(greetingsText02NextButtonClicked);



			greetingsText03 = new UIText("[c/fff2d6:Anyway, you can't beat me, so ha-ha!]\n[c/fff2d6:I'm ][c/f1d485:Yue][c/fff2d6:, the vampire.]", 1.2f);
			greetingsText03.Width.Set(0, 0f);
			greetingsText03.Height.Set(0, 0f);
			greetingsText03.Top.Set(55, 0f);
			greetingsText03.Left.Set(20, 0f);

			greetingsText03nextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			greetingsText03nextButton.Width.Set(20, 0f);
			greetingsText03nextButton.Height.Set(20, 0f);
			greetingsText03nextButton.Left.Set(area.Width.Pixels - greetingsText03nextButton.Width.Pixels - 15, 0f);
			greetingsText03nextButton.Top.Set(area.Height.Pixels - greetingsText03nextButton.Width.Pixels - 10, 0f);
			greetingsText03nextButton.OnClick += new MouseEvent(greetingsText03NextButtonClicked);
			


			greetingsText04 = new UIText("[c/fff2d6:And as I can see, this is not my ][c/ae00ff:dimension][c/fff2d6:.]\n[c/fff2d6:Probably this is because of thing, you are]\n[c/fff2d6:holding in hands.]", 1.2f);
			greetingsText04.Width.Set(0, 0f);
			greetingsText04.Height.Set(0, 0f);
			greetingsText04.Top.Set(55, 0f);
			greetingsText04.Left.Set(20, 0f);

			greetingsText04nextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			greetingsText04nextButton.Width.Set(20, 0f);
			greetingsText04nextButton.Height.Set(20, 0f);
			greetingsText04nextButton.Left.Set(area.Width.Pixels - greetingsText04nextButton.Width.Pixels - 15, 0f);
			greetingsText04nextButton.Top.Set(area.Height.Pixels - greetingsText04nextButton.Width.Pixels - 10, 0f);
			greetingsText04nextButton.OnClick += new MouseEvent(greetingsText04NextButtonClicked);



			greetingsText05 = new UIText("[c/fff2d6:Wait, I know, this item. Is this... A tear?]\n[c/fff2d6:But it's just a shard. A little piece]\n[c/fff2d6:of the… Nevermind.]", 1.2f);
			greetingsText05.Width.Set(0, 0f);
			greetingsText05.Height.Set(0, 0f);
			greetingsText05.Top.Set(55, 0f);
			greetingsText05.Left.Set(20, 0f);

			greetingsText05nextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			greetingsText05nextButton.Width.Set(20, 0f);
			greetingsText05nextButton.Height.Set(20, 0f);
			greetingsText05nextButton.Left.Set(area.Width.Pixels - greetingsText05nextButton.Width.Pixels - 15, 0f);
			greetingsText05nextButton.Top.Set(area.Height.Pixels - greetingsText05nextButton.Width.Pixels - 10, 0f);
			greetingsText05nextButton.OnClick += new MouseEvent(greetingsText05NextButtonClicked);



			greetingsText06 = new UIText("[c/fff2d6:Oh... As I can see, your world has]\n[c/fff2d6:the infection too...]", 1.2f);
			greetingsText06.Width.Set(0, 0f);
			greetingsText06.Height.Set(0, 0f);
			greetingsText06.Top.Set(55, 0f);
			greetingsText06.Left.Set(20, 0f);

			greetingsText06nextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			greetingsText06nextButton.Width.Set(20, 0f);
			greetingsText06nextButton.Height.Set(20, 0f);
			greetingsText06nextButton.Left.Set(area.Width.Pixels - greetingsText06nextButton.Width.Pixels - 15, 0f);
			greetingsText06nextButton.Top.Set(area.Height.Pixels - greetingsText06nextButton.Width.Pixels - 10, 0f);
			greetingsText06nextButton.OnClick += new MouseEvent(greetingsText06NextButtonClicked);
			
			
			
			greetingsText07 = new UIText("[c/fff2d6:I mean... I guess we can try to save this]\n[c/fff2d6:world, isn't it?]", 1.2f);
			greetingsText07.Width.Set(0, 0f);
			greetingsText07.Height.Set(0, 0f);
			greetingsText07.Top.Set(55, 0f);
			greetingsText07.Left.Set(20, 0f);

			greetingsText07nextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			greetingsText07nextButton.Width.Set(20, 0f);
			greetingsText07nextButton.Height.Set(20, 0f);
			greetingsText07nextButton.Left.Set(area.Width.Pixels - greetingsText07nextButton.Width.Pixels - 15, 0f);
			greetingsText07nextButton.Top.Set(area.Height.Pixels - greetingsText07nextButton.Width.Pixels - 10, 0f);
			greetingsText07nextButton.OnClick += new MouseEvent(greetingsText07NextButtonClicked);



			greetingsText08 = new UIText("[c/fff2d6:If something interesting happens,]\n[c/fff2d6:you can always call me by using this item!]", 1.2f);
			greetingsText08.Width.Set(0, 0f);
			greetingsText08.Height.Set(0, 0f);
			greetingsText08.Top.Set(55, 0f);
			greetingsText08.Left.Set(20, 0f);

			greetingsText08nextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			greetingsText08nextButton.Width.Set(20, 0f);
			greetingsText08nextButton.Height.Set(20, 0f);
			greetingsText08nextButton.Left.Set(area.Width.Pixels - greetingsText08nextButton.Width.Pixels - 15, 0f);
			greetingsText08nextButton.Top.Set(area.Height.Pixels - greetingsText08nextButton.Width.Pixels - 10, 0f);
			greetingsText08nextButton.OnClick += new MouseEvent(greetingsText08NextButtonClicked);



			greetingsText09 = new UIText("[c/fff2d6:What's for now, I need a time to think]\n[c/fff2d6:about reasons of transferring me at here]\n[c/fff2d6:and what to do next.]", 1.2f);
			greetingsText09.Width.Set(0, 0f);
			greetingsText09.Height.Set(0, 0f);
			greetingsText09.Top.Set(55, 0f);
			greetingsText09.Left.Set(20, 0f);

			greetingsText09nextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			greetingsText09nextButton.Width.Set(20, 0f);
			greetingsText09nextButton.Height.Set(20, 0f);
			greetingsText09nextButton.Left.Set(area.Width.Pixels - greetingsText09nextButton.Width.Pixels - 15, 0f);
			greetingsText09nextButton.Top.Set(area.Height.Pixels - greetingsText09nextButton.Width.Pixels - 10, 0f);
			greetingsText09nextButton.OnClick += new MouseEvent(greetingsText09NextButtonClicked);



			greetingsText10 = new UIText("[c/fff2d6:See you!]", 1.2f);
			greetingsText10.Width.Set(0, 0f);
			greetingsText10.Height.Set(0, 0f);
			greetingsText10.Top.Set(55, 0f);
			greetingsText10.Left.Set(20, 0f);

			greetingsText10nextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			greetingsText10nextButton.Width.Set(20, 0f);
			greetingsText10nextButton.Height.Set(20, 0f);
			greetingsText10nextButton.Left.Set(area.Width.Pixels - greetingsText10nextButton.Width.Pixels - 15, 0f);
			greetingsText10nextButton.Top.Set(area.Height.Pixels - greetingsText10nextButton.Width.Pixels - 10, 0f);
			greetingsText10nextButton.OnClick += new MouseEvent(greetingsText10NextButtonClicked);



			//if nothing to say for now, transfer this block of text.
			transitionText = new UIText("[c/fff2d6:Sorry, it's nothing to say for now.]", 1.2f);
			transitionText.Width.Set(0, 0f);
			transitionText.Height.Set(0, 0f);
			transitionText.Top.Set(55, 0f);
			transitionText.Left.Set(20, 0f);

			transitionTextNextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			transitionTextNextButton.Width.Set(20, 0f);
			transitionTextNextButton.Height.Set(20, 0f);
			transitionTextNextButton.Left.Set(area.Width.Pixels - transitionTextNextButton.Width.Pixels - 15, 0f);
			transitionTextNextButton.Top.Set(area.Height.Pixels - transitionTextNextButton.Width.Pixels - 10, 0f);
			transitionTextNextButton.OnClick += new MouseEvent(transitionTextNextButtonClicked);



			//When Wall of Flesh has been defeated:
			WofText01 = new UIText("[c/fff2d6:Disgusting creature... I'm calm, you dealt]\n[c/fff2d6:it.]", 1.2f);
			WofText01.Width.Set(0, 0f);
			WofText01.Height.Set(0, 0f);
			WofText01.Top.Set(55, 0f);
			WofText01.Left.Set(20, 0f);

			WofText01NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			WofText01NextButton.Width.Set(20, 0f);
			WofText01NextButton.Height.Set(20, 0f);
			WofText01NextButton.Left.Set(area.Width.Pixels - WofText01NextButton.Width.Pixels - 15, 0f);
			WofText01NextButton.Top.Set(area.Height.Pixels - WofText01NextButton.Width.Pixels - 10, 0f);
			WofText01NextButton.OnClick += new MouseEvent(WofText01NextButtonClicked);


			
			WofText02 = new UIText("[c/fff2d6:Huh?!]", 1.2f);
			WofText02.Width.Set(0, 0f);
			WofText02.Height.Set(0, 0f);
			WofText02.Top.Set(55, 0f);
			WofText02.Left.Set(20, 0f);

			WofText02NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			WofText02NextButton.Width.Set(20, 0f);
			WofText02NextButton.Height.Set(20, 0f);
			WofText02NextButton.Left.Set(area.Width.Pixels - WofText02NextButton.Width.Pixels - 15, 0f);
			WofText02NextButton.Top.Set(area.Height.Pixels - WofText02NextButton.Width.Pixels - 10, 0f);
			WofText02NextButton.OnClick += new MouseEvent(WofText02NextButtonClicked);



			WofText03 = new UIText("[c/fff2d6:...]", 1.2f);
			WofText03.Width.Set(0, 0f);
			WofText03.Height.Set(0, 0f);
			WofText03.Top.Set(55, 0f);
			WofText03.Left.Set(20, 0f);

			WofText03NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			WofText03NextButton.Width.Set(20, 0f);
			WofText03NextButton.Height.Set(20, 0f);
			WofText03NextButton.Left.Set(area.Width.Pixels - WofText03NextButton.Width.Pixels - 15, 0f);
			WofText03NextButton.Top.Set(area.Height.Pixels - WofText03NextButton.Width.Pixels - 10, 0f);
			WofText03NextButton.OnClick += new MouseEvent(WofText03NextButtonClicked);



			WofText04 = new UIText("[c/fff2d6:Wait, this gun... He's alive...]\n[c/fff2d6:Is this because of using this shard again?]\n[c/fff2d6:How interesting.]", 1.2f);
			WofText04.Width.Set(0, 0f);
			WofText04.Height.Set(0, 0f);
			WofText04.Top.Set(55, 0f);
			WofText04.Left.Set(20, 0f);

			WofText04NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			WofText04NextButton.Width.Set(20, 0f);
			WofText04NextButton.Height.Set(20, 0f);
			WofText04NextButton.Left.Set(area.Width.Pixels - WofText04NextButton.Width.Pixels - 15, 0f);
			WofText04NextButton.Top.Set(area.Height.Pixels - WofText04NextButton.Width.Pixels - 10, 0f);
			WofText04NextButton.OnClick += new MouseEvent(WofText04NextButtonClicked);



			WofText05 = new UIText("[c/fff2d6:This revolver is called ][c/ffff00:The Donner][c/fff2d6:.]\n[c/fff2d6:It can burn even high tier enemies!]\n[c/fff2d6:Probably.]", 1.2f);
			WofText05.Width.Set(0, 0f);
			WofText05.Height.Set(0, 0f);
			WofText05.Top.Set(55, 0f);
			WofText05.Left.Set(20, 0f);

			WofText05NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			WofText05NextButton.Width.Set(20, 0f);
			WofText05NextButton.Height.Set(20, 0f);
			WofText05NextButton.Left.Set(area.Width.Pixels - WofText05NextButton.Width.Pixels - 15, 0f);
			WofText05NextButton.Top.Set(area.Height.Pixels - WofText05NextButton.Width.Pixels - 10, 0f);
			WofText05NextButton.OnClick += new MouseEvent(WofText05NextButtonClicked);



			WofText06 = new UIText("[c/fff2d6:The owner uses The Donner in conjunction]\n[c/fff2d6:with Schlag, another revolver.]", 1.2f);
			WofText06.Width.Set(0, 0f);
			WofText06.Height.Set(0, 0f);
			WofText06.Top.Set(55, 0f);
			WofText06.Left.Set(20, 0f);

			WofText06NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			WofText06NextButton.Width.Set(20, 0f);
			WofText06NextButton.Height.Set(20, 0f);
			WofText06NextButton.Left.Set(area.Width.Pixels - WofText06NextButton.Width.Pixels - 15, 0f);
			WofText06NextButton.Top.Set(area.Height.Pixels - WofText06NextButton.Width.Pixels - 10, 0f);
			WofText06NextButton.OnClick += new MouseEvent(WofText06NextButtonClicked);



			WofText07 = new UIText("[c/fff2d6:But somehow we got only one of it...]\n[c/fff2d6:Or it's replica, who knows.]", 1.2f);
			WofText07.Width.Set(0, 0f);
			WofText07.Height.Set(0, 0f);
			WofText07.Top.Set(55, 0f);
			WofText07.Left.Set(20, 0f);

			WofText07NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			WofText07NextButton.Width.Set(20, 0f);
			WofText07NextButton.Height.Set(20, 0f);
			WofText07NextButton.Left.Set(area.Width.Pixels - WofText07NextButton.Width.Pixels - 15, 0f);
			WofText07NextButton.Top.Set(area.Height.Pixels - WofText07NextButton.Width.Pixels - 10, 0f);
			WofText07NextButton.OnClick += new MouseEvent(WofText07NextButtonClicked);



			WofText08 = new UIText("[c/fff2d6:Anyway, continue your adventure.]\n[c/fff2d6:I'll notify you when I'll find more]\n[c/fff2d6:information.]", 1.2f);
			WofText08.Width.Set(0, 0f);
			WofText08.Height.Set(0, 0f);
			WofText08.Top.Set(55, 0f);
			WofText08.Left.Set(20, 0f);

			WofText08NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			WofText08NextButton.Width.Set(20, 0f);
			WofText08NextButton.Height.Set(20, 0f);
			WofText08NextButton.Left.Set(area.Width.Pixels - WofText08NextButton.Width.Pixels - 15, 0f);
			WofText08NextButton.Top.Set(area.Height.Pixels - WofText08NextButton.Width.Pixels - 10, 0f);
			WofText08NextButton.OnClick += new MouseEvent(WofText08NextButtonClicked);



			WofText09 = new UIText("[c/fff2d6:That's all for now!]", 1.2f);
			WofText09.Width.Set(0, 0f);
			WofText09.Height.Set(0, 0f);
			WofText09.Top.Set(55, 0f);
			WofText09.Left.Set(20, 0f);

			WofText09NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			WofText09NextButton.Width.Set(20, 0f);
			WofText09NextButton.Height.Set(20, 0f);
			WofText09NextButton.Left.Set(area.Width.Pixels - WofText09NextButton.Width.Pixels - 15, 0f);
			WofText09NextButton.Top.Set(area.Height.Pixels - WofText09NextButton.Width.Pixels - 10, 0f);
			WofText09NextButton.OnClick += new MouseEvent(WofText09NextButtonClicked);



			BrainText01 = new UIText("[c/fff2d6:Сrumbled!]", 1.2f);
			BrainText01.Width.Set(0, 0f);
			BrainText01.Height.Set(0, 0f);
			BrainText01.Top.Set(55, 0f);
			BrainText01.Left.Set(20, 0f);

			BrainText01NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			BrainText01NextButton.Width.Set(20, 0f);
			BrainText01NextButton.Height.Set(20, 0f);
			BrainText01NextButton.Left.Set(area.Width.Pixels - BrainText01NextButton.Width.Pixels - 15, 0f);
			BrainText01NextButton.Top.Set(area.Height.Pixels - BrainText01NextButton.Width.Pixels - 10, 0f);
			BrainText01NextButton.OnClick += new MouseEvent(BrainText01NextButtonClicked);



			BrainText02 = new UIText("[c/fff2d6:An infection soul is about to be free.]", 1.2f);
			BrainText02.Width.Set(0, 0f);
			BrainText02.Height.Set(0, 0f);
			BrainText02.Top.Set(55, 0f);
			BrainText02.Left.Set(20, 0f);

			BrainText02NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			BrainText02NextButton.Width.Set(20, 0f);
			BrainText02NextButton.Height.Set(20, 0f);
			BrainText02NextButton.Left.Set(area.Width.Pixels - BrainText02NextButton.Width.Pixels - 15, 0f);
			BrainText02NextButton.Top.Set(area.Height.Pixels - BrainText02NextButton.Width.Pixels - 10, 0f);
			BrainText02NextButton.OnClick += new MouseEvent(BrainText02NextButtonClicked);



			BrainText03 = new UIText("[c/fff2d6:You is moving right way!]\n[c/fff2d6:Now I see, we can save this world.]", 1.2f);
			BrainText03.Width.Set(0, 0f);
			BrainText03.Height.Set(0, 0f);
			BrainText03.Top.Set(55, 0f);
			BrainText03.Left.Set(20, 0f);

			BrainText03NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			BrainText03NextButton.Width.Set(20, 0f);
			BrainText03NextButton.Height.Set(20, 0f);
			BrainText03NextButton.Left.Set(area.Width.Pixels - BrainText03NextButton.Width.Pixels - 15, 0f);
			BrainText03NextButton.Top.Set(area.Height.Pixels - BrainText03NextButton.Width.Pixels - 10, 0f);
			BrainText03NextButton.OnClick += new MouseEvent(BrainText03NextButtonClicked);



			BrainText04 = new UIText("[c/fff2d6:And before we'll disperse, I found this]\n[c/fff2d6:into depths of the cave below.]", 1.2f);
			BrainText04.Width.Set(0, 0f);
			BrainText04.Height.Set(0, 0f);
			BrainText04.Top.Set(55, 0f);
			BrainText04.Left.Set(20, 0f);

			BrainText04NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			BrainText04NextButton.Width.Set(20, 0f);
			BrainText04NextButton.Height.Set(20, 0f);
			BrainText04NextButton.Left.Set(area.Width.Pixels - BrainText04NextButton.Width.Pixels - 15, 0f);
			BrainText04NextButton.Top.Set(area.Height.Pixels - BrainText04NextButton.Width.Pixels - 10, 0f);
			BrainText04NextButton.OnClick += new MouseEvent(BrainText04NextButtonClicked);



			BrainText05 = new UIText("[c/fff2d6:Don't ask why it's here, I don't know too,]\n[c/fff2d6:but it's name - ][c/ffff00:Pile Bunker][c/fff2d6:.]", 1.2f);
			BrainText05.Width.Set(0, 0f);
			BrainText05.Height.Set(0, 0f);
			BrainText05.Top.Set(55, 0f);
			BrainText05.Left.Set(20, 0f);

			BrainText05NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			BrainText05NextButton.Width.Set(20, 0f);
			BrainText05NextButton.Height.Set(20, 0f);
			BrainText05NextButton.Left.Set(area.Width.Pixels - BrainText05NextButton.Width.Pixels - 15, 0f);
			BrainText05NextButton.Top.Set(area.Height.Pixels - BrainText05NextButton.Width.Pixels - 10, 0f);
			BrainText05NextButton.OnClick += new MouseEvent(BrainText05NextButtonClicked);



			BrainText06 = new UIText("[c/fff2d6:Strong weapon for... Hellivators~]\n[c/fff2d6:Also, if something will be below of it upon]\n[c/fff2d6:usage, it will be demolished.]", 1.2f);
			BrainText06.Width.Set(0, 0f);
			BrainText06.Height.Set(0, 0f);
			BrainText06.Top.Set(55, 0f);
			BrainText06.Left.Set(20, 0f);

			BrainText06NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			BrainText06NextButton.Width.Set(20, 0f);
			BrainText06NextButton.Height.Set(20, 0f);
			BrainText06NextButton.Left.Set(area.Width.Pixels - BrainText06NextButton.Width.Pixels - 15, 0f);
			BrainText06NextButton.Top.Set(area.Height.Pixels - BrainText06NextButton.Width.Pixels - 10, 0f);
			BrainText06NextButton.OnClick += new MouseEvent(BrainText06NextButtonClicked);



			BrainText07 = new UIText("[c/fff2d6:Use it as you wish and...]", 1.2f);
			BrainText07.Width.Set(0, 0f);
			BrainText07.Height.Set(0, 0f);
			BrainText07.Top.Set(55, 0f);
			BrainText07.Left.Set(20, 0f);

			BrainText07NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			BrainText07NextButton.Width.Set(20, 0f);
			BrainText07NextButton.Height.Set(20, 0f);
			BrainText07NextButton.Left.Set(area.Width.Pixels - BrainText07NextButton.Width.Pixels - 15, 0f);
			BrainText07NextButton.Top.Set(area.Height.Pixels - BrainText07NextButton.Width.Pixels - 10, 0f);
			BrainText07NextButton.OnClick += new MouseEvent(BrainText07NextButtonClicked);



			BrainText08 = new UIText("[c/fff2d6:Get move next!]", 1.2f);
			BrainText08.Width.Set(0, 0f);
			BrainText08.Height.Set(0, 0f);
			BrainText08.Top.Set(55, 0f);
			BrainText08.Left.Set(20, 0f);

			BrainText08NextButton = new UIImage(ModContent.Request<Texture2D>("YueMod/Common/UI/YueUIbuttonNext"));
			BrainText08NextButton.Width.Set(20, 0f);
			BrainText08NextButton.Height.Set(20, 0f);
			BrainText08NextButton.Left.Set(area.Width.Pixels - BrainText08NextButton.Width.Pixels - 15, 0f);
			BrainText08NextButton.Top.Set(area.Height.Pixels - BrainText08NextButton.Width.Pixels - 10, 0f);
			BrainText08NextButton.OnClick += new MouseEvent(BrainText08NextButtonClicked);
			


			area.Append(barFrame);
			area.Append(noname);
			area.Append(hideButton);


			area.Append(greetingsText01);
			area.Append(greetingsText01nextButton);
			

			Append(area);
		}
		bool greetingsCheck = false;
		bool WoFcheck = false;
		bool BrainCheck = false;
		public override void Update(GameTime gameTime) {
			if(greetingsCheck == true) {
				if (DownedBossSystem.Brain && BrainCheck == false) {
					area.RemoveChild(transitionText);
					area.RemoveChild(transitionTextNextButton);
					area.Append(BrainText01);
					area.Append(BrainText01NextButton);
					BrainCheck = true;
				}
				if (DownedBossSystem.WoF && BrainCheck == true && WoFcheck == false) {
					area.RemoveChild(transitionText);
					area.RemoveChild(transitionTextNextButton);
					area.Append(WofText01);
					area.Append(WofText01NextButton);
					WoFcheck = true;
				}
			}
			base.Update(gameTime);
		}
		private void HideButtonClicked(UIMouseEvent evt, UIElement listeningElement) { 
			//ModContent.GetInstance<YueUISystem>().HideMyUI();
			Main.LocalPlayer.ClearBuff(ModContent.BuffType<YueBuff>());
			SoundEngine.PlaySound(hideUI);
			
		}

		//Greetings
		private void greetingsText01NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText01);
			area.RemoveChild(greetingsText01nextButton);
			area.Append(greetingsText02);
			area.Append(greetingsText02nextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText02NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText02);
			area.RemoveChild(greetingsText02nextButton);
			area.RemoveChild(noname);
			area.Append(name);
			area.Append(greetingsText03);
			area.Append(greetingsText03nextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText03NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText03);
			area.RemoveChild(greetingsText03nextButton);
			area.Append(greetingsText04);
			area.Append(greetingsText04nextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText04NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText04);
			area.RemoveChild(greetingsText04nextButton);
			area.Append(greetingsText05);
			area.Append(greetingsText05nextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText05NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText05);
			area.RemoveChild(greetingsText05nextButton);
			area.Append(greetingsText06);
			area.Append(greetingsText06nextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText06NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText06);
			area.RemoveChild(greetingsText06nextButton);
			area.Append(greetingsText07);
			area.Append(greetingsText07nextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText07NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText07);
			area.RemoveChild(greetingsText07nextButton);
			area.Append(greetingsText08);
			area.Append(greetingsText08nextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText08NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText08);
			area.RemoveChild(greetingsText08nextButton);
			area.Append(greetingsText09);
			area.Append(greetingsText09nextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText09NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(greetingsText09);
			area.RemoveChild(greetingsText09nextButton);
			area.Append(greetingsText10);
			area.Append(greetingsText10nextButton);
			SoundEngine.PlaySound(nextSound);
		}
		private void greetingsText10NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			//END OF GREETINGS
			area.RemoveChild(greetingsText10);
			area.RemoveChild(greetingsText10nextButton);
			area.Append(transitionText);
			area.Append(transitionTextNextButton);
			Main.LocalPlayer.ClearBuff(ModContent.BuffType<YueBuff>());
			greetingsCheck = true;
			SoundEngine.PlaySound(endOfTalk);
		}
		private void transitionTextNextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			Main.LocalPlayer.ClearBuff(ModContent.BuffType<YueBuff>());
		}

		//WoF
		private void WofText01NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(WofText01);
			area.RemoveChild(WofText01NextButton);
			area.Append(WofText02);
			area.Append(WofText02NextButton);
			Item.NewItem(Item.GetSource_None(), Main.LocalPlayer.Center, ModContent.ItemType<Donner>());
			SoundEngine.PlaySound(nextSound);
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
		}

		private void BrainText01NextButtonClicked(UIMouseEvent evt, UIElement listeningElement) {
			area.RemoveChild(BrainText01);
			area.RemoveChild(BrainText01NextButton);
			area.Append(BrainText02);
			area.Append(BrainText02NextButton);
			SoundEngine.PlaySound(nextSound);
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
		}





		public override void Draw(SpriteBatch spriteBatch) {
			if (Main.LocalPlayer.HasBuff(ModContent.BuffType<YueBuff>())) {
				base.Draw(spriteBatch);
			}
		}
		protected override void DrawSelf(SpriteBatch spriteBatch) {
			base.DrawSelf(spriteBatch);
			Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
			hitbox.X += 12;
			hitbox.Width -= 24;
			hitbox.Y += 8;
			hitbox.Height -= 16;
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