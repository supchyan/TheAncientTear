using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace YueMod.Items.Donner {
	public class DonnerDeBuff : ModBuff {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Donner's Hell");
			Description.SetDefault("EVERY ENEMY WILL BE BURNED!");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
		public override void Update(NPC target, ref int buffIndex) { 
			target.lifeRegen -= 1000;
			var dust = Dust.NewDustDirect(target.Center, target.width, target.height, DustID.Shadowflame, 0f, 0f, 255, default, 0.9f);
            dust.velocity *= 8f;
			//Main.NewText("Cock");
			int timer = 1000;
            if(--timer <= 0) {
				target.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}
