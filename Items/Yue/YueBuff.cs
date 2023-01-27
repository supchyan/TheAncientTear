using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using YueMod.Common.UI;
using Terraria.ModLoader;

namespace YueMod.Items.Yue
{
	public class YueBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vampire Perversity");
			Description.SetDefault("The strange girl is talking to you");

			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) { 
			player.buffTime[buffIndex] = 18000;

			int projType = ModContent.ProjectileType<YueProjectile>();

			
			if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0) {
				var entitySource = player.GetSource_Buff(buffIndex);
				
				Projectile.NewProjectile(entitySource, player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
			}
		}
	}
}