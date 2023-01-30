using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using YueMod.Common.UI;
using Terraria.ModLoader;

namespace YueMod.Items.MetzeleiDisaster {
	public class MetzeleiDisasterTimer : ModBuff {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("On Reload");
			Description.SetDefault("Metzelei Disaster is on reloading.");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
		}
    }
}