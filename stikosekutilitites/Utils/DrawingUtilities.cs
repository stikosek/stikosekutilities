using UnityEngine;

namespace su.Utils;

public class DrawingUtilities
{
    public static GUIStyle GetTextStyle(int fontSize, Color textColor, string fontFile = "Arial.ttf")
    {
        GUIStyle style = new GUIStyle(GUI.skin.label)
        {
            font = Resources.GetBuiltinResource<Font>(fontFile),
            fontSize = fontSize,
            alignment = TextAnchor.MiddleCenter,
        };

        if (textColor != Color.clear)
            style.normal.textColor = textColor;

        return style;
    }

    public static GUIStyle GetTextStyle(int fontSize)
    {
        return GetTextStyle(fontSize, Color.clear);
    }

    public static Rect CenteredTextRect(string text, int fontSize)
    {
        GUIStyle style = new GUIStyle(GUI.skin.label)
        {
            font = Resources.GetBuiltinResource<Font>("Arial.ttf"),
            fontSize = fontSize,
            alignment = TextAnchor.MiddleCenter,
        };

        Vector2 size = style.CalcSize(new GUIContent(text));
        float textWidth = size.x * 2;
        float textHeight = size.y * 2;

        return new Rect(Screen.currentResolution.width / 2 - textWidth / 2, Screen.currentResolution.height / 2 - size.y,
            textWidth, textHeight);
    }

    private static Rect CalcTextSize(float x, float y, GUIStyle style, string text)
    {
        Vector2 size = style.CalcSize(new GUIContent(text));
        float textWidth = size.x * 2;
        float textHeight = size.y * 2;

        return new Rect(x, y, textWidth, textHeight);
    }

    public static void DrawText(string text, float x, float y, int fontSize, Color textColor)
    {
        GUIStyle style = GetTextStyle(fontSize, textColor);

        GUI.Label(CalcTextSize(x, y, style, text), text, style);
    }

    public static void DrawText(string text, Rect pos, int fontSize, Color textColor)
    {
        GUIStyle style = GetTextStyle(fontSize, textColor);

        GUI.Label(pos, text, style);
    }

    public static void DrawCenteredText(string text, int fontSize, Color textColor)
    {
        DrawText(text, CenteredTextRect(text, fontSize), fontSize, textColor);
    }

    /// <summary>
    /// Draw a Color at a location
    /// </summary>
    /// <param name="color"></param>
    /// <param name="rect"></param>
    public static void DrawColor(Color color, Rect rect)
    {
        GUI.DrawTexture(rect, ColoredTexture(color));
    }

    public static Texture2D ColoredTexture(Color color)
    {
        Texture2D tex = new Texture2D(1, 1);

        tex.SetPixel(1, 1, color);

        tex.wrapMode = TextureWrapMode.Repeat;
        tex.Apply();

        return tex;
    }

    /// <summary>
    /// Draws a Color fullscreen
    /// </summary>
    /// <param name="color"></param>
    public static void DrawFullScreenColor(Color color)
    {
        Texture2D tex = new Texture2D(1, 1);

        tex.SetPixel(1, 1, color);

        GUI.Box(new Rect(-20, -20, Screen.width + 100, Screen.height + 100), tex);
    }

    public string GetToggleText(string name, bool state)
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

    public static void DrawWindowBackground(Color top, Color rest, Rect rect, int TopBarThickness, string Title)
    {
        /*
        //Draw main background
        DrawColor(rest, new Rect(0, TopBarThickness, rect.width, rect.height - TopBarThickness));

        //Draw top bar
        DrawColor(top, new Rect(0, 0, rect.width, TopBarThickness));

        DrawText(Title, new Rect(0, 0, rect.width, TopBarThickness), TopBarThickness - 3, Color.black);
        */

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
}
