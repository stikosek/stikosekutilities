using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace stikosekutilitites_1._2.cheats.patches
{
    [HarmonyPatch]
    internal class PlayerStatusPatch
    {
        public static List<Sprite> SuItemSprites = new List<Sprite>();
        public static List<Sprite> SuPwrSprites = new List<Sprite>();
        public static HitableRock[] Rarray;

        public static bool Used = false;

        [HarmonyPatch(typeof(PlayerStatus), "Awake")]
        [HarmonyPostfix]
        private static void Postfix()
        {
            DoTheH();
        }

        public static void RefreshEsp()
        {
            Rarray = Object.FindObjectsOfType(typeof(HitableRock)) as HitableRock[];
        }

        public static void DoTheH()
        {
            RefreshEsp();
            if (Used)
                return;

            for (int i = 0; i < 152; i++)
            {

                SuItemSprites.Add(Object.FindObjectOfType<ItemManager>().allItems[i].sprite);
            }
            for (int j = 0; j < ItemManager.Instance.allPowerups.Count; j++)
            {
                SuPwrSprites.Add(Object.FindObjectOfType<ItemManager>().allPowerups[j].sprite);

            }
        }

    }
}
