using Terraria;
using Terraria.ModLoader;
using YueMod.Common.UI;

namespace YueMod.Systems {
    internal class newCreatedPlayer : ModPlayer {
        public static bool newPlayer = true;
        public override void OnEnterWorld(Player player) {
            if(YueUIstate.greetingsFirstTime == true) {
                newPlayer = true;
            }
        }
    }
}