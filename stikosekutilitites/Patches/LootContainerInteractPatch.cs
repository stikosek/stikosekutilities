using HarmonyLib;
using System.Reflection;

namespace su.Patches;

[HarmonyPatch(typeof(LootContainerInteract))]
public static class LootContainerInteractPatch
{

	public static bool NoCoins = false;

	[Obfuscation(Exclude = true)]
	[HarmonyPatch(nameof(LootContainerInteract.Interact))]
	[HarmonyPostfix]
	private static void Interact(LootContainerInteract __instance)
	{
		if (NoCoins)
		{
			ClientSend.PickupInteract(__instance.GetId());
		}
	}

}