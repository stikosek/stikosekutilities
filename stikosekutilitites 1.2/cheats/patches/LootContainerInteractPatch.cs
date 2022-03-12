using HarmonyLib;

namespace stikosekutilitites_1._2.cheats
{
    [HarmonyPatch(typeof(LootContainerInteract))]
    public static class LootContainerInteractPatch
    {

        [HarmonyPatch(nameof(LootContainerInteract.Interact))]
        [HarmonyPrefix]
        private static void Interact(LootContainerInteract __instance)
        {
            if (Player.freechests)
            {
                // this is a shitty way todo it but for some reason the good way didnt work for me lol
                __instance.price = -1;
            }
        }

    }
}
