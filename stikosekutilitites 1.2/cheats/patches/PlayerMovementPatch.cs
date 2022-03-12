using HarmonyLib;
using UnityEngine;

namespace stikosekutilitites_1._2.cheats
{
    [HarmonyPatch]
    public class PlayerMovementPatch
    {

        [HarmonyPatch(typeof(PlayerMovement), "Jump")]
        [HarmonyPrefix]
        private static void Prefix(PlayerMovement __instance)
        {
            if (Movement.omegajump)
            {
                if (__instance.grounded)
                {
                    PlayerMovement.Instance.GetRb().AddForce(Vector3.up * 20f, ForceMode.Impulse);
                }

            }
        }

    }
}
