using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using YueMod.Common.UI;

namespace YueMod.Systems {
    internal class newCreatedPlayer : ModPlayer {
        public bool holdingMyItem = false;
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
			ModPacket packet = Mod.GetPacket();
			packet.Write((bool)holdingMyItem);
			packet.Write((byte)Player.whoAmI);
			packet.Send(toWho, fromWho);
		}
        public void ReceivePlayerSync(BinaryReader reader) {
			holdingMyItem = reader.ReadBoolean();
		}
        public override void clientClone(ModPlayer clientClone) {
			newCreatedPlayer clone = clientClone as newCreatedPlayer;
			clone.holdingMyItem = holdingMyItem;
		}

		public override void SendClientChanges(ModPlayer clientPlayer) {
			newCreatedPlayer clone = clientPlayer as newCreatedPlayer;

			if (holdingMyItem != clone.holdingMyItem)
				SyncPlayer(toWho: -1, fromWho: Main.myPlayer, newPlayer: false);
		}
        public override void SaveData(TagCompound tag) {
			tag["holdingMyItem"] = holdingMyItem;
		}

		public override void LoadData(TagCompound tag) {
			holdingMyItem = tag.GetBool("holdingMyItem");
		}
    }
}