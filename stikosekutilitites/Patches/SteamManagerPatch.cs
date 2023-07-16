using HarmonyLib;
using System;
using System.Reflection;

namespace su.Patches;

[HarmonyPatch(typeof(SteamManager))]
public static class SteamManagerPatch
{

	public static Action OnLeaveLobby;

	[Obfuscation(Exclude = true)]
	[HarmonyPatch(nameof(SteamManager.leaveLobby))]
	public static void LeaveLobby()
	{
		OnLeaveLobby?.Invoke();
	}

}
