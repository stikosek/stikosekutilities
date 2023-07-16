using HarmonyLib;
using System;
using System.Reflection;

namespace su.Patches;

[HarmonyPatch(typeof(GameManager))]
public static class GameManagerPatch
{
	public static Action OnStartGame;

	[Obfuscation(Exclude = true)]
	[HarmonyPatch(nameof(GameManager.StartGame))]
	[HarmonyPostfix]
	public static void StartGame()
	{
		OnStartGame?.Invoke();
	}

}
