using BepInEx;
using HarmonyLib;
using stikosekutilitites_1._2.gui;
using stikosekutilitites_1._2.utils;
using System.Collections.Generic;
using UnityEngine;

namespace stikosekutilitites_1._2
{

    [BepInPlugin("stikosek_stikosekutilites_1.2", "stikosekutilities 1.2", "1.2.0")]
    public class Plugin : BaseUnityPlugin
    {
        public void Start()
        {
            WelcomeScreen.Draw = true;

            Harmony harmony = new Harmony("stikosek_stikosekutilites_1.2");
            harmony.PatchAll();
        }

        public void Update()
        {
            if (PlayerMovement.Instance == null)
                return;

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                MainGuiStructure.MainLock = !MainGuiStructure.MainLock;
                if (MainGuiStructure.MainLock && !Cursor.visible)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    return;
                }
                if (!MainGuiStructure.MainLock && Cursor.visible)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                cheats.patches.PlayerStatusPatch.DoTheH();
                cheats.patches.PlayerStatusPatch.Used = true;
            }

            cheats.Player.Update();
            cheats.Movement.Update();
        }

        public void OnGUI()
        {
            WelcomeScreen.OnGUI();

            GUI.backgroundColor = Color.white;
            GUI.contentColor = Color.green;

            DrawingUtilities.DrawText("stikosekutilities V1.2 [stikosek.xyz]", new Rect(Screen.width / 2 - 170, 0f, 400f, 40f), 20, Color.cyan);

            if (PlayerMovement.Instance == null)
                return;

            if (MainGuiStructure.MainLock)
            {
                MainGuiStructure.SuPlayerRect = GUI.Window(1, MainGuiStructure.SuPlayerRect, new GUI.WindowFunction(MainGuiStructure.SuDrawPlayer), "Player");


                MainGuiStructure.SuExploitRect = GUI.Window(2, MainGuiStructure.SuExploitRect, new GUI.WindowFunction(MainGuiStructure.SuDrawExploit), "Exploit");


                MainGuiStructure.SuServerRect = GUI.Window(3, MainGuiStructure.SuServerRect, new GUI.WindowFunction(MainGuiStructure.SuDrawServer), "Player actions");


                MainGuiStructure.SuItemRect = GUI.Window(4, MainGuiStructure.SuItemRect, new GUI.WindowFunction(MainGuiStructure.SuDrawItem), "Item spawning");


                MainGuiStructure.SuPowerRect = GUI.Window(5, MainGuiStructure.SuPowerRect, new GUI.WindowFunction(MainGuiStructure.SuDrawPower), "Powerup spawning");


                MainGuiStructure.SuMobRect = GUI.Window(6, MainGuiStructure.SuMobRect, new GUI.WindowFunction(MainGuiStructure.SuDrawMob), "Mob spawning [HOST]");


                MainGuiStructure.SuMovementRect = GUI.Window(7, MainGuiStructure.SuMovementRect, new GUI.WindowFunction(MainGuiStructure.SuDrawMovement), "Movement");


                MainGuiStructure.SuWorldRect = GUI.Window(8, MainGuiStructure.SuWorldRect, new GUI.WindowFunction(MainGuiStructure.SuDrawWorld), "World");


                MainGuiStructure.SuEspRect = GUI.Window(9, MainGuiStructure.SuEspRect, new GUI.WindowFunction(MainGuiStructure.SuDrawEsp), "Esp's");
            }


            if (MainGuiStructure.playeresp)
            {

                foreach (KeyValuePair<int, PlayerManager> player in GameManager.players)
                {
                    //In-Game Position
                    Vector3 pivotPos = player.Value.onlinePlayer.transform.position; //Pivot point NOT at the feet, at the center
                    Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - 1f; //At the feet
                    Vector3 playerHeadPos; playerHeadPos.x = pivotPos.x; playerHeadPos.z = pivotPos.z; playerHeadPos.y = pivotPos.y + 2f; //At the head

                    //Screen Position
                    Vector3 w2s_footpos = Camera.main.WorldToScreenPoint(playerFootPos);
                    Vector3 w2s_headpos = Camera.main.WorldToScreenPoint(playerHeadPos);

                    if (w2s_footpos.z > 0f)
                    {
                        GUIStyle stylee = new GUIStyle
                        {
                            alignment = TextAnchor.MiddleCenter
                        };
                        w2s_footpos.z = w2s_footpos.y + Screen.height;
                        GUI.Label(new Rect(w2s_headpos.x, Screen.height - w2s_headpos.y, 0f, 0f), "Player", stylee);
                        EspStuff.DrawBoxESP(w2s_footpos, w2s_headpos, Color.red);
                    }
                }

            }

            if (MainGuiStructure.resourceesp)
            {

                foreach (HitableRock res in cheats.patches.PlayerStatusPatch.Rarray)
                {

                    float distance = Vector3.Distance(PlayerStatus.Instance.transform.position, res.transform.position);

                    if (distance > 300f)
                        continue;

                    //In-Game Position
                    Vector3 pivotPos = res.transform.position; //Pivot point NOT at the feet, at the center
                    Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - 2f; //At the feet
                    Vector3 playerHeadPos; playerHeadPos.x = pivotPos.x; playerHeadPos.z = pivotPos.z; playerHeadPos.y = pivotPos.y + 2f; //At the head

                    //Screen Position
                    Vector3 w2s_footpos = Camera.main.WorldToScreenPoint(playerFootPos);
                    Vector3 w2s_headpos = Camera.main.WorldToScreenPoint(playerHeadPos);

                    if (w2s_footpos.z > 0f)
                    {
                        GUIStyle styleh = new GUIStyle
                        {
                            alignment = TextAnchor.MiddleCenter
                        };
                        w2s_footpos.z = w2s_footpos.y + Screen.height;
                        GUI.Label(new Rect(w2s_headpos.x, Screen.height - w2s_headpos.y, 0f, 0f), res.entityName, styleh);
                        Color espcolor = Color.blue;
                        switch (res.entityName)
                        {

                            case "Coal":
                                espcolor = Color.black;
                                break;
                            case "Iron":
                                espcolor = Color.gray;
                                break;
                            case "Mithril":
                                espcolor = Color.blue;
                                break;
                            case "Gold":
                                espcolor = Color.yellow;
                                break;
                            case "Adamantite":
                                espcolor = Color.green;
                                break;
                            case "Ruby":
                                espcolor = Color.magenta;
                                break;
                            case "Obamium":
                                espcolor = Color.magenta;
                                break;
                        }

                        EspStuff.DrawBoxESP(w2s_footpos, w2s_headpos, espcolor);
                    }
                }
            }

        }

    }


}