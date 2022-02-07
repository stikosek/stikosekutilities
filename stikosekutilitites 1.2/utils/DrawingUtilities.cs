using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace stikosekutilitites_1._2.utils
{
    public class DrawingUtilities
    {
        public string getToggleText(string name, bool state)
        {
            string text;
            if (state)
            {
                text = name + " <color=gray>[</color><color=lime>ENABLED</color><color=gray>]</color>";
            }
            else
            {
                text = name + " <color=gray>[</color><color=red>DISABLED</color><color=gray>]</color>";
            }


            return text;
        }

        public static void DrawColor(Color color, Rect rect)
        {
            Texture2D tex = new Texture2D(1, 1);

            tex.SetPixel(1, 1, color);

            tex.wrapMode = TextureWrapMode.Repeat;
            tex.Apply();

            GUI.DrawTexture(rect, tex);
        }

        public static void DrawWindowBackground(Color top, Color rest, Rect rect, int TopBarThickness, string Title)
        {
            return;

            //Draw main background
            DrawColor(rest, new Rect(0, TopBarThickness, rect.width, rect.height - TopBarThickness));

            //Draw top bar
            DrawColor(top, new Rect(0, 0, rect.width, TopBarThickness));

            DrawText(Title, new Rect(0, 0, rect.width, TopBarThickness), TopBarThickness - 3, Color.black);


        }

        public static void DrawButtonToggle(Rect rect, Color border, Color rest, string NormalText)
        {
            // Draw Button
            DrawColor(border, rect);
            // Draw Button text


            DrawText(NormalText, new Rect(rect.x + 5, rect.y + 5, rect.width - 10, rect.height - 10), 15, Color.white);


            // Draw toggle border
            DrawColor(border, new Rect(5, 5, rect.width - 10, rect.height - 10));

        }
        public static void DrawText(string text, Rect pos, int fontSize, Color textColor)
        {
            GUIStyle style = GetTextStyle(fontSize, textColor);

            GUI.Label(pos, text, style);
        }

        public static GUIStyle GetTextStyle(int fontSize, Color textColor)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label)
            {
                font = Resources.GetBuiltinResource<Font>("Arial.ttf"),
                fontSize = fontSize,
                alignment = TextAnchor.MiddleLeft,
            };

            style.normal.textColor = textColor;

            return style;
        }
    }
}
