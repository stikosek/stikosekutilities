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
    public class HitableResourcePatch
    {

        [HarmonyPatch(typeof(HitableResource), "Hit")]
        [HarmonyPrefix]
        private static void Prefix(HitableResource __instance, ref int damage, ref float sharpness, int hitEffect, Vector3 pos, int hitWeaponType)
        {
            patches.PlayerStatusPatch.RefreshEsp();
            if (cheats.Player.instamine)
            {
                // Changes parameters to gain more damage
                damage = __instance.maxHp;
                sharpness = damage;
            }
        }

    }
}
