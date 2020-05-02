using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.Engine;
using Terraria.ModLoader.UI;
using Terraria.Utilities;

namespace Terraria.ModLoader.x64bit.Core
{
	class Core64
	{
		/// <summary>
		/// Boolean that will allow you to switch between vanilla and 64bit mode, so you can play with vanilla friends!
		/// </summary>
		internal static bool vanillaMode;

		internal static readonly string vanillaVersion = "Terraria" + 194;

		internal static bool betaMode = false;

		internal static void LoadVanillaPath() {
			
			Main.WorldPath = Path.Combine(Main.SavePath, "Worlds");
			Main.PlayerPath = Path.Combine(Main.SavePath, "Players");
		}

		internal static void LoadModdedPath() {
			Main.WorldPath = Path.Combine(Main.SavePath, "ModLoader" , "Worlds");
			Main.PlayerPath = Path.Combine(Main.SavePath, "ModLoader" ,"Players");
		}

		internal static void DrawPatreon(SpriteBatch sb, int num109, int num110, int num111, bool hasFocus, Color color12) {
			if (!betaMode) return;
			if (Main.menuMode == 10002 && vanillaMode) {
				Main.menuMode = 0;
			}

			string patreonShortURL = ((!vanillaMode) ? "Switch to vanilla mode" : "Switch to TML");
			bool showPatreon = Main.menuMode == 0;
			string architecture = $"(Running in {((Environment.Is64BitProcess) ? 64.ToString() : 32.ToString())} bit mode)";
			string GoG = GoGVerifier.IsGoG ? "GoG" : "Steam";
			string drawVersion;
			if (vanillaMode) {
				drawVersion = Main.versionNumber;
			} else {
				drawVersion = Main.versionNumber + Environment.NewLine + Terraria.ModLoader.ModLoader.versionedName + $" - {architecture} {GoG} {PlatformUtilities.RunningPlatform()}";
			}
			Vector2 origin3 = Main.fontMouseText.MeasureString(drawVersion);
			origin3.X *= 0.5f;
			origin3.Y *= 0.5f;
			Main.spriteBatch.DrawString(Main.fontMouseText, drawVersion, new Vector2(origin3.X + (float)num110 + 10f, (float)Main.screenHeight - origin3.Y - (float)num111 + 2f), color12, 0f, origin3, 1f, SpriteEffects.None, 0f);
			if (num109 == 4) {
				color12 = new Microsoft.Xna.Framework.Color(127, 191, 191, 76);
			}
			if (showPatreon) {
				Vector2 urlSize = Main.fontMouseText.MeasureString(patreonShortURL);
				Main.spriteBatch.DrawString(Main.fontMouseText, patreonShortURL, new Vector2((float)num110 + 10f, (float)Main.screenHeight - origin3.Y - 42f - (float)num111 + 2f), color12, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
				if (num109 == 4 && Main.mouseLeftRelease && Main.mouseLeft && new Microsoft.Xna.Framework.Rectangle((int) (num110 + 10f), (int) (Main.screenHeight - origin3.Y - 34f - num111 + 2f), (int)urlSize.X, (int)origin3.Y).Contains(new Microsoft.Xna.Framework.Point(Main.mouseX, Main.mouseY)) && hasFocus) {
					Main.PlaySound(SoundID.MenuOpen);
					vanillaMode = !vanillaMode;
					Main.SaveSettings();
					Interface.infoMessage.Show("You'll need to restart the game so that the necessary change can apply.", 0, null, "Restart", () => Environment.Exit(0));
				}
			}
		}
	}
}
