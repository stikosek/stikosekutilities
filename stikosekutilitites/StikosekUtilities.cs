using BepInEx;
using HarmonyLib;
using su.Modules;
using su.Utils;
using System.Reflection;
using UnityEngine;
using BepInEx.Logging;
using System.Collections.Generic;

namespace su;

[BepInPlugin("stikosek_stikosekutilites_1.2", "stikosekutilities 1.2", "1.2.0")]
public class StikosekUtilities : BaseUnityPlugin
{

	public static StikosekUtilities Instance { get; private set; }
	internal static ManualLogSource Log;
	public Harmony HarmonyInstance { get; private set; }

	public ModuleManager moduleManager;
	public List<Window> windows;

	public bool MenuShown = true;

	public KeyCode MenuBind = KeyCode.RightShift;

	public void Awake()
    {
		Instance = this;
		Log = Logger;

		HarmonyInstance = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "su");

		moduleManager = new();
		windows = new()
		{
			new Window()
			{
				WindowId = WindowIDs.Player.ToInt(),
				Title = "Player",
				WindowRect = new Rect(210f, 20f, 150f, 200f),
				RenderAction = RenderWindow
			},
			new Window()
			{
				WindowId = WindowIDs.Movement.ToInt(),
				Title = "Movement",
				WindowRect = new Rect(50f, 20f, 150f, 180f),
				RenderAction = RenderWindow
			},
			new Window()
			{
				WindowId = WindowIDs.World.ToInt(),
				Title = "World",
				WindowRect = new Rect(940f, 20f, 200f, 180f),
				RenderAction = RenderWindow
			},
			new Window()
			{
				WindowId = WindowIDs.Exploit.ToInt(),
				Title = "Exploit",
				WindowRect = new Rect(730f, 20f, 200f, 240f),
				RenderAction = RenderWindow
			},
			new Window()
			{
				WindowId = WindowIDs.PlayerList.ToInt(),
				Title = "PlayerList",
				WindowRect = new Rect(370f, 20f, 350f, 200f),
				RenderAction = RenderWindow
			},
			new Window()
			{
				WindowId = WindowIDs.PowerupSpawner.ToInt(),
				Title = "Powerups",
				WindowRect = new Rect(560f, 270f, 440, 260),
				RenderAction = RenderWindow
			},
			new Window()
			{
				WindowId = WindowIDs.ItemSpawner.ToInt(),
				Title = "Items",
				WindowRect = new Rect(50f, 270f, 500, 300),
				RenderAction = RenderWindow
			},
			new Window()
			{
				WindowId = WindowIDs.MobSpawner.ToInt(),
				Title = "MobSpawner",
				WindowRect = new Rect(1010f, 270f, 180f, 460f),
				RenderAction = RenderWindow
			}
		};

		WelcomeScreen.MenuBind = MenuBind;
		WelcomeScreen.Draw = true;
	}

	public void RenderWindow(int windowId)
	{
		if (!moduleManager.Modules.ContainsKey(windowId))
			return;

		moduleManager.Modules[windowId].Do(mod => mod.OnRender());
	}

	public void Update()
	{
		if (WelcomeScreen.Draw)
		{
			return;
		}

		HandleInput();
		moduleManager.Update();
	}

	public void FixedUpdate()
	{
		if (WelcomeScreen.Draw)
			return;

		moduleManager.FixedUpdate();
	}

	private void HandleInput()
	{
		if (!Input.anyKey || !Input.anyKeyDown)
			return;

        if (!Input.GetKeyDown(MenuBind))
            return;

		MenuShown = !MenuShown;

		if (MenuShown && !Cursor.visible)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			return;
		}
		if (!MenuShown && Cursor.visible)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		
	}

	public void OnGUI()
	{
		if (WelcomeScreen.Draw)
		{
			WelcomeScreen.OnGUI();
			return;
		}

		DrawingUtilities.DrawText("stikosekutilities V1.3 [stikosek.xyz]", new Rect(Screen.width / 2 - 170, 0f, 400f, 40f), 20, Color.cyan);

		GUI.backgroundColor = Color.white;
		GUI.contentColor = Color.green;

		if (MenuShown)
		{
			DrawingUtilities.DrawFullScreenColor(new Color(0, 0, 0, 0.7f));
			windows.Do(window => window.OnGui());
		}

		moduleManager.OnGUI();
	}

}