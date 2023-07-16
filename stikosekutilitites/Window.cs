using System;
using UnityEngine;

namespace su;

public class Window
{
	public int WindowId;
	public Rect WindowRect;
	public string Title;

	public bool Scrollbar;
	public Vector2 ScrollPosition = Vector2.zero;

	public Action<int> RenderAction = delegate { };

	public bool Shown = true;

	public void OnGui()
	{
		if (!Shown)
			return;

		WindowRect = GUI.Window(WindowId, WindowRect, (GUI.WindowFunction)RenderWindow, Title);
		WindowRect.x = Mathf.Clamp(WindowRect.x, 0, Screen.currentResolution.width - WindowRect.width);
		WindowRect.y = Mathf.Clamp(WindowRect.y, 0, Screen.currentResolution.height - WindowRect.height);
	}

	private static bool IsOffscreen(Rect rect)
	{
		Rect screenRect = new Rect(0, 0, Screen.currentResolution.width, Screen.currentResolution.height);

		return !(screenRect.xMin <= rect.xMin
			&& screenRect.yMin <= rect.yMin
			&& screenRect.xMax >= rect.xMax
			&& screenRect.yMax >= rect.yMax);
	}

	public void PositionWindowY(Rect otherWindowRect, float distance)
	{
		Rect newWindowRect = new(WindowRect);
		newWindowRect.y = otherWindowRect.y;
		newWindowRect.x = otherWindowRect.x + otherWindowRect.width + distance;

		if (IsOffscreen(newWindowRect))
		{
			newWindowRect.x = distance;
			newWindowRect.y = otherWindowRect.y + WindowRect.height + distance;
		}

		WindowRect = newWindowRect;
	}

	private void RenderWindow(int id)
	{
		if (Scrollbar)
			ScrollPosition = GUILayout.BeginScrollView(ScrollPosition);

		RenderAction.Invoke(id);

		if (Scrollbar)
			GUILayout.EndScrollView();

		GUI.DragWindow(new Rect(0, 0, 10000, 20));
	}

}
