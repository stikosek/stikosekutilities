using HarmonyLib;
using System.Reflection;

namespace su.Patches;

[HarmonyPatch(typeof(PlayerStatus))]
public static class PlayerStatusPatch
{
	public static bool GodMode;

	[Obfuscation(Exclude = true)]
	[HarmonyPatch("HandleDamage")]
	[HarmonyPrefix]
	public static bool HandleDamage(PlayerStatus __instance)
	{
		if (GodMode)
		{
			ClientSend.PlayerHp(__instance.maxHp, __instance.maxHp);
		}

		return !GodMode;
	}

}