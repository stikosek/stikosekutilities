using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace su.Patches;

[HarmonyPatch(typeof(HitableResource))]
public static class HitableResourcePatch
{

	public static bool InstaMine;

	[Obfuscation(Exclude = true)]
	[HarmonyPatch(nameof(HitableResource.Hit))]
	[HarmonyPrefix]
	private static void Prefix(HitableResource __instance, ref int damage, ref float sharpness, int hitEffect, Vector3 pos, int hitWeaponType)
	{
		if (InstaMine)
		{
			// Changes parameters to gain more damage
			damage = __instance.maxHp;
			sharpness = damage;
		}
	}

}
