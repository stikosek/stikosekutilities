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
            if (Player.instakill)
            {
                damage = 69420;
                sharpness = 69420;
            }
        }

    }
}
