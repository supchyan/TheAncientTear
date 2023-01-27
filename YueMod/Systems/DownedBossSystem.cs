using System.Collections;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace YueMod.Systems
{
	public class DownedBossSystem : ModSystem
	{
		public static bool WoF = false;
		public static bool Brain = false;
        public override void OnWorldLoad() {
			Main.hardMode = false;
			WoF = false;
			Brain = false;
			// downedOtherBoss = false;
		}

		public override void OnWorldUnload() {
			Main.hardMode = false;
			WoF = false;
			Brain = false;
			// downedOtherBoss = false;
		}
		public override void SaveWorldData(TagCompound tag) {
			if (WoF) {
				tag["WoF"] = true;
			}
			if(Brain) {
				tag["Brain"] = true;
			}
		}
		public override void LoadWorldData(TagCompound tag) {
			WoF = tag.ContainsKey("WoF");
			Brain = tag.ContainsKey("Brain");
			// downedOtherBoss = tag.ContainsKey("downedOtherBoss");
		}
		public override void NetSend(BinaryWriter writer) {
			// Order of operations is important and has to match that of NetReceive
			var flags = new BitsByte();
			flags[0] = WoF;
			flags[1] = Brain;
			// flags[1] = downedOtherBoss;
			writer.Write(flags);
		}
		public override void NetReceive(BinaryReader reader) {
			// Order of operations is important and has to match that of NetSend
			BitsByte flags = reader.ReadByte();
			WoF = flags[0];
			Brain = flags[1];
		}
	}
}
