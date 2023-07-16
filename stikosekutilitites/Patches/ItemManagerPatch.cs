using HarmonyLib;
using System.Reflection;

namespace su.Patches;

[HarmonyPatch(typeof(ItemManager))]
public static class ItemManagerPatch
{
	private static bool Init;
	public static ItemManager DontDestroyInstance;

	[Obfuscation(Exclude = true)]
	[HarmonyPatch(nameof(ItemManager.Awake))]
	[HarmonyPostfix]
	private static void Awake(ItemManager __instance)
	{
		if (Init)
			return;

		DontDestroyInstance = __instance;

		Init = true;
	}

}
