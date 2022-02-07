using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using HarmonyLib;

namespace stikosekutilitites_1._2.cheats
{
	[HarmonyPatch]
    public class PlayerMovementPatch                             
    {


		[HarmonyPatch(typeof(PlayerMovement), "Jump")]
		[HarmonyPrefix]
		private static void Prefix(PlayerMovement __instance)
		{
			if (cheats.Movement.omegajump)
			{
				if (__instance.grounded)
				{

					PlayerMovement.Instance.GetRb().AddForce(Vector3.up * 20f, ForceMode.Impulse);


				}

			}
		}

	}
}
