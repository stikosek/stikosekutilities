using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace stikosekutilitites_1._2
{

    [BepInPlugin("stikosek_stikosekutilites_1.2","stikosekutilities 1.2", "1.2.0")]
    public class Plugin : BaseUnityPlugin
    {

		
		
        public void Start()
        {
            Harmony harmony = new Harmony("stikosek_stikosekutilites_1.2");
            harmony.PatchAll();



		
		



        }

		public void Update()
        {
			if (Input.GetKeyDown(KeyCode.RightShift))
			{
				gui.MainGuiStructure.MainLock = !gui.MainGuiStructure.MainLock;
				if (gui.MainGuiStructure.MainLock && !Cursor.visible)
				{
					Cursor.visible = true;
					Cursor.lockState = CursorLockMode.None;
					return;
				}
				if (!gui.MainGuiStructure.MainLock && Cursor.visible)
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
			GUI.backgroundColor = UnityEngine.Color.white;
			GUI.contentColor = UnityEngine.Color.green;
			utils.DrawingUtilities.DrawText("stikosekutilities V1.2 [stikosek.xyz]", new Rect(Screen.width/2 - 170, 0f, 400f, 40f), 20, Color.cyan);

           


			if (PlayerMovement.Instance != null)
			{


				if (gui.MainGuiStructure.MainLock)
				{


					gui.MainGuiStructure.SuPlayerRect = GUI.Window(1, gui.MainGuiStructure.SuPlayerRect, new GUI.WindowFunction(gui.MainGuiStructure.SuDrawPlayer), "Player");


					gui.MainGuiStructure.SuExploitRect = GUI.Window(2, gui.MainGuiStructure.SuExploitRect, new GUI.WindowFunction(gui.MainGuiStructure.SuDrawExploit), "Exploit");


					gui.MainGuiStructure.SuServerRect = GUI.Window(3, gui.MainGuiStructure.SuServerRect, new GUI.WindowFunction(gui.MainGuiStructure.SuDrawServer), "Player actions");


					gui.MainGuiStructure.SuItemRect = GUI.Window(4, gui.MainGuiStructure.SuItemRect, new GUI.WindowFunction(gui.MainGuiStructure.SuDrawItem), "Item spawning");


					gui.MainGuiStructure.SuPowerRect = GUI.Window(5, gui.MainGuiStructure.SuPowerRect, new GUI.WindowFunction(gui.MainGuiStructure.SuDrawPower), "Powerup spawning");


					gui.MainGuiStructure.SuMobRect = GUI.Window(6, gui.MainGuiStructure.SuMobRect, new GUI.WindowFunction(gui.MainGuiStructure.SuDrawMob), "Mob spawning [HOST]");


					gui.MainGuiStructure.SuMovementRect = GUI.Window(7, gui.MainGuiStructure.SuMovementRect, new GUI.WindowFunction(gui.MainGuiStructure.SuDrawMovement), "Movement");


					gui.MainGuiStructure.SuWorldRect = GUI.Window(8, gui.MainGuiStructure.SuWorldRect, new GUI.WindowFunction(gui.MainGuiStructure.SuDrawWorld), "World");


					gui.MainGuiStructure.SuEspRect = GUI.Window(9, gui.MainGuiStructure.SuEspRect, new GUI.WindowFunction(gui.MainGuiStructure.SuDrawEsp), "Esp's");
				}


				if (gui.MainGuiStructure.playeresp)
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
							GUI.Label(new Rect(w2s_headpos.x, (float)Screen.height - w2s_headpos.y, 0f, 0f), "Player", stylee);
							gui.EspStuff.DrawBoxESP(w2s_footpos, w2s_headpos, UnityEngine.Color.red);
						}
					}

				}

				if (gui.MainGuiStructure.resourceesp)
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
							GUI.Label(new Rect(w2s_headpos.x, (float)Screen.height - w2s_headpos.y, 0f, 0f), res.entityName, styleh);
							Color espcolor = Color.blue;
							switch (res.entityName){
								
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

							gui.EspStuff.DrawBoxESP(w2s_footpos, w2s_headpos, espcolor);
						}
					}

				}

			}
			// yo wtf

		}

	}


}