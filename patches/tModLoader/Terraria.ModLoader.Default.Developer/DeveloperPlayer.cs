using System.Collections.Generic;
using Terraria.ModLoader.x64bit.Core;

namespace Terraria.ModLoader.Default.Developer
{
	internal class DeveloperPlayer : ModPlayer
	{
		public override bool CloneNewInstances => true;

		public override bool Autoload(ref string name) 
			=> Core64.vanillaMode;

		public static DeveloperPlayer GetPlayer(Player player)
			=> player.GetModPlayer<DeveloperPlayer>();

		public AndromedonEffect AndromedonEffect;

		public override void Initialize() {
			AndromedonEffect = new AndromedonEffect();
		}

		public override void ResetEffects() {
			AndromedonEffect?.ResetEffects();
		}

		public override void UpdateDead() {
			AndromedonEffect?.UpdateDead();
		}

		public override void PostUpdate() {
			AndromedonEffect?.UpdateEffects(player);
		}

		public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
			AndromedonEffect?.UpdateAura(player);
		}

		public override void ModifyDrawLayers(List<PlayerLayer> layers) {
			AndromedonEffect?.ModifyDrawLayers(mod, player, layers);
		}
	}
}
