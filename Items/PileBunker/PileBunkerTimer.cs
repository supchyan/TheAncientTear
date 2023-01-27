using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using YueMod.Common.UI;
using Terraria.ModLoader;

namespace YueMod.Items.PileBunker
{
	public class PileBunkerTimer : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cooldown");
			Description.SetDefault("You can't use a Pile Bunker for now.");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
		}
    }
}