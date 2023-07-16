using System;
using System.Collections.Generic;
using UnityEngine;

namespace su.Utils;

public class KeyCodeFormatter
{
	private static Dictionary<KeyCode, string> keyNames;

	public static Dictionary<KeyCode, string> KeyNames
	{
		get
		{
			if (keyNames == null)
			{
				Init();
			}
			return keyNames;
		}
	}

	private static void Init()
	{
		keyNames = new Dictionary<KeyCode, string>();

		foreach (KeyCode k in Enum.GetValues(typeof(KeyCode)))
		{
			if (!keyNames.ContainsKey(k))
				keyNames.Add(k, Enum.GetName(typeof(KeyCode), k));
		}

		// replace Alpha0, Alpha1, .. and Keypad0... with "0", "1", ...
		for (int i = 0; i < 10; i++)
		{
			keyNames[(KeyCode)((int)KeyCode.Alpha0 + i)] = i.ToString();
			keyNames[(KeyCode)((int)KeyCode.Keypad0 + i)] = "Num " + i.ToString();
		}

		keyNames[KeyCode.CapsLock] = "Caps";
		keyNames[KeyCode.ScrollLock] = "Scroll";
		keyNames[KeyCode.RightShift] = "Right-Shift";
		keyNames[KeyCode.RightControl] = "Right-Control";
		keyNames[KeyCode.LeftShift] = "Left-Shift";
		keyNames[KeyCode.LeftControl] = "Left-Control";
		keyNames[KeyCode.Escape] = "Esc";
		keyNames[KeyCode.UpArrow] = "Up";
		keyNames[KeyCode.DownArrow] = "Down";
		keyNames[KeyCode.LeftArrow] = "Left";
		keyNames[KeyCode.RightArrow] = "Right";
	}
}