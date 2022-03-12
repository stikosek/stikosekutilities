using UnityEngine;
using static stikosekutilitites_1._2.utils.DrawingUtilities;

namespace stikosekutilitites_1._2.utils
{
    public static class WelcomeScreen
    {
        public static bool Draw;

        private static bool init;

        public static void OnGUI()
        {
            if (!Draw)
                return;

            if (!init)
            {
                init = true;
            }

            Event e = Event.current;

            if (e != null && e.isKey)
            {
                if (Input.GetKeyDown(e.keyCode))
                {
                    Draw = false;

                    return;
                }
            }

            DrawWelcome();
        }

        private static void DrawWelcome()
        {
            if (!Draw) return;

            //Black out
            DrawFullScreenColor(new Color(0, 0, 0, 0.3f));

            //Position Calculation
            const float divider = 2f;
            Resolution res = Screen.currentResolution;

            float x = (res.width - res.width / divider) / 2f;
            float y = (res.height - res.height / divider) / 2f;

            Rect rect = new Rect(x, y, res.width / divider, res.height / divider);

            //Draw middle rect
            DrawColor(new Color(0, 1, 0, 0.6f), rect);

            #region WaterMark

            string waterMark = "<b>Stikosek's stikosekutilities 1.2</b>";

            Rect waterMarkRect = CenteredTextRect(waterMark, 40);
            waterMarkRect.y -= (rect.y / 1.6f);

            GUI.Label(waterMarkRect, waterMark, GetTextStyle(40, Color.black));

            #endregion

            #region Press any Key to continue

            string continueText = "<i><b>Press any Key to continue...</b></i>";

            Rect continueRect = CenteredTextRect(continueText, 40);
            continueRect.y += (rect.y / 1.6f);

            GUI.Label(continueRect, continueText, GetTextStyle(40, Color.black));

            #endregion

            DrawCenteredText(
            "Welcome to Stikosek's stikosekutilities 1.2" + "\n" +

            "To open the ClickGUI press \"Right-Shift\" " + "\n" +
            "while being InGame!", 40, Color.white);

        }

    }
}
