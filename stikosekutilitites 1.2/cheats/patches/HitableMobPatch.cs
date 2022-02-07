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
    public class HitableMobPatch                             
    {


		[HarmonyPatch(typeof(HitableMob), "Hit")]
		[HarmonyPrefix]
		private static void Prefix(HitableMob __instance, ref int damage, ref float sharpness)
		{
			if (cheats.Player.instakill)
			{
				damage = 69420;
				sharpness = 69420;
				
			}
		}

	}
}
