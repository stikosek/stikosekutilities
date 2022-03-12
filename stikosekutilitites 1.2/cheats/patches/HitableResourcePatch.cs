using HarmonyLib;
using UnityEngine;

namespace stikosekutilitites_1._2.cheats
{
    [HarmonyPatch]
    public class HitableResourcePatch
    {

        [HarmonyPatch(typeof(HitableResource), "Hit")]
        [HarmonyPrefix]
        private static void Prefix(HitableResource __instance, ref int damage, ref float sharpness, int hitEffect, Vector3 pos, int hitWeaponType)
        {
            patches.PlayerStatusPatch.RefreshEsp();
            if (Player.instamine)
            {
                // Changes parameters to gain more damage
                damage = __instance.maxHp;
                sharpness = damage;
            }
        }

    }
}
