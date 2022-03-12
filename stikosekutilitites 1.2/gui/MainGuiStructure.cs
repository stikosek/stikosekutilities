using Steamworks;
using Steamworks.Data;
using stikosekutilitites_1._2.utils;
using System.Linq;
using UnityEngine;

namespace stikosekutilitites_1._2.gui
{
    public class MainGuiStructure
    {
        public static bool Playerui;
        public static bool PlayerActionsui;
        public static bool MobSpawningui;
        public static bool ItemSpawnningui;
        public static bool PowerupSpawningui;
        public static bool Exploitui;

        public static bool Activated;

        public static UnityEngine.Color topcolor = UnityEngine.Color.blue;
        public static UnityEngine.Color restcolor = UnityEngine.Color.black;
        public static int fontsize = 20;

        public static void SuDrawPlayer(int windowID)
        {
            utils.DrawingUtilities.DrawWindowBackground(topcolor, restcolor, SuPlayerRect, fontsize, "Player");
            int SuPlayerButtonsXValue = 10;

            cheats.Player.godmode = GUI.Toggle(new Rect(SuPlayerButtonsXValue, 20f, 150f, 20f), cheats.Player.godmode, "Godmode");
            cheats.Player.stamina = GUI.Toggle(new Rect(SuPlayerButtonsXValue, 40f, 150f, 20f), cheats.Player.stamina, "Infinite stamina");
            cheats.Player.food = GUI.Toggle(new Rect(SuPlayerButtonsXValue, 60f, 150f, 20f), cheats.Player.food, "infinite food");
            cheats.Player.instamine = GUI.Toggle(new Rect(SuPlayerButtonsXValue, 80f, 150f, 20f), cheats.Player.instamine, "Instant mine");
            cheats.Player.instakill = GUI.Toggle(new Rect(SuPlayerButtonsXValue, 100f, 150f, 20f), cheats.Player.instakill, "Instant kill");
            cheats.Player.freechests = GUI.Toggle(new Rect(SuPlayerButtonsXValue, 120f, 150f, 20f), cheats.Player.freechests, "Free chests");


            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
        }

        public static void SuDrawMovement(int windowID)
        {
            DrawingUtilities.DrawWindowBackground(topcolor, restcolor, SuMovementRect, fontsize, "Movement");
            int SuPlayerButtonsXValue = 10;


            cheats.Movement.flight = GUI.Toggle(new Rect(SuPlayerButtonsXValue, 20f, 150f, 20f), cheats.Movement.flight, "Flight");
            cheats.Movement.omegajump = GUI.Toggle(new Rect(SuPlayerButtonsXValue, 40f, 150f, 20f), cheats.Movement.omegajump, "Omega jump");
            cheats.Movement.noclip = GUI.Toggle(new Rect(SuPlayerButtonsXValue, 60f, 150f, 20f), cheats.Movement.noclip, "No clip");
            cheats.Movement.speed = GUI.Toggle(new Rect(SuPlayerButtonsXValue, 80f, 150f, 20f), cheats.Movement.speed, "Speed");
            cheats.Movement.hover = GUI.Toggle(new Rect(SuPlayerButtonsXValue, 100f, 150f, 20f), cheats.Movement.hover, "Hover");
            cheats.Movement.clicktp = GUI.Toggle(new Rect(SuPlayerButtonsXValue, 120f, 150f, 20f), cheats.Movement.clicktp, "Click tp");

            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
        }

        public static void SuDrawServer(int windowID)
        {
            DrawingUtilities.DrawWindowBackground(topcolor, restcolor, SuServerRect, fontsize, "Player actions");
            int playerselectid = 0;

            PlayerManager[] array = UnityEngine.Object.FindObjectsOfType<PlayerManager>();
            for (int i = 0; i < array.Length; i++)
            {
                int SuPlayersButY = i * 20 + 20;
                if (GUI.Button(new Rect(20f, (float)SuPlayersButY, 100f, 20f), array[i].username))
                {
                    playerselectid = i;
                }
            }
            GUI.Box(new Rect(140f, 20f, 200f, 160f), "Player actions");
            GUI.Label(new Rect(10f, 180f, 250f, 20f), "Thanks to Farliam for the cage code :)");
            GUI.Label(new Rect(150f, 40f, 70f, 20f), "Selected:");
            if (array[playerselectid].username == Object.FindObjectOfType<PlayerManager>().username)
            {
                GUI.Label(new Rect(210f, 40f, 50f, 20f), "yourself [E]");
            }
            else
            {
                GUI.Label(new Rect(210f, 40f, 50f, 20f), array[playerselectid].username);
            }

            if (GUI.Button(new Rect(150f, 60f, 90f, 30f), "Kill[HOST]"))
            {
                ServerSend.HitPlayer(LocalClient.instance.myId, 69420, 0f, array[playerselectid].id, 1, array[playerselectid].transform.position);
            }

            if (GUI.Button(new Rect(150f, 90f, 90f, 30f), "Kick[HOST]"))
            {
                ServerSend.DisconnectPlayer(array[playerselectid].id);
            }

            if (GUI.Button(new Rect(240f, 90f, 90f, 30f), "Cage"))
            {
                Vector3 position = array[playerselectid].transform.position;
                position.y += 5f;
                Vector3 vector = position;
                Vector3 beuh = position;
                beuh.y -= 7f;
                vector.x -= 3.5f;
                vector.y -= 3.5f;
                Vector3 pos = vector;
                pos.x += 7f;
                Vector3 vector2 = position;
                vector2.y -= 3.5f;
                vector2.z -= 3.5f;
                Vector3 pos2 = vector2;
                pos2.z += 7f;
                ClientSend.RequestBuild(35, position, 0);
                ClientSend.RequestBuild(35, beuh, 0);
                ClientSend.RequestBuild(41, vector, 90);
                ClientSend.RequestBuild(41, pos, 90);
                ClientSend.RequestBuild(41, vector2, 180);
                ClientSend.RequestBuild(41, pos2, 180);
            }

            if (GUI.Button(new Rect(240f, 60f, 90f, 30f), "Tp me-player"))
            {
                PlayerMovement.Instance.GetRb().position = array[playerselectid].transform.position;
            }

            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
        }

        public static bool muckchat = false;
        public static bool advertize = false;

        public static void SuDrawExploit(int windowID)
        {
            DrawingUtilities.DrawWindowBackground(topcolor, restcolor, SuExploitRect, fontsize, "Exploit");

            muckchat = GUI.Toggle(new Rect(10f, 30f, 100f, 30f), muckchat, "Fuck chat?");

            if (muckchat)
            {
                ChatBox.Instance.SendMessage("The FitnessGram PACER Test is a multistage aerobic capacity test that progress" +
                    "ively gets more difficult as it continues. The test is used to measure a student's aerobic capacity as part of the FitnessGram assessm" +
                    "ent. Students run back and forth as many times as they can, each lap signaled by a beep sound.");
            }

            if (GUI.Button(new Rect(10f, 60f, 180f, 30f), "Unlock all advancments"))
            {
                foreach (Achievement achievement in SteamUserStats.Achievements)
                {
                    achievement.Trigger(true);
                }
                SteamUserStats.StoreStats();
            }

            if (GUI.Button(new Rect(10f, 90f, 180f, 30f), "Reset all advancments"))
            {
                SteamUserStats.ResetAll(true);
            }

            if (advertize = GUI.Toggle(new Rect(100f, 30f, 180f, 30f), advertize, "Advertize?"))
            {
                ChatBox.Instance.AppendMessage(0, string.Concat(new string[]
                {
                "<color=green>stikosekutilities</color> <b><color=red>Best muck hack</color></b>"
                }), "");

                ClientSend.SendChatMessage(string.Concat(new string[]
                {
                "<color=green>stikosekutilities</color> <b><color=red>Best muck hack</color></b>"
                }));
            }

            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
        }

        public static float itemamount = 1;
        public static Vector2 scrollpos = new Vector2();
        public static int currentiid;

        public static void SuDrawItem(int windowID)
        {
            DrawingUtilities.DrawWindowBackground(topcolor, restcolor, SuItemRect, fontsize, "Item spawner");
            itemamount = GUI.VerticalSlider(new Rect(460f, 50f, 50f, 230f), itemamount, 1000f, 1f);
            ItemManager ItemManager = ItemManager.Instance;
            GUI.Label(new Rect(450f, 40f, 60f, 20f), itemamount.ToString());
            GUI.Label(new Rect(450f, 20f, 60f, 20f), "Amount:");
            scrollpos = GUI.BeginScrollView(new Rect(10f, 20f, 440f, 270f), scrollpos, new Rect(0f, 0f, 440f, 1500f), false, true);

            int x = 0;
            int y = 0;
            for (int i = 0; i < ItemManager.allScriptableItems.Count(); i++)
            {
                InventoryItem item = ItemManager.allScriptableItems[i];
                if (GUI.Button(new Rect(x, y, 60, 60), item.sprite.texture))
                {
                    item.amount = (int)itemamount;
                    InventoryUI.Instance.AddItemToInventory(item);

                }

                if (x > 359)
                {
                    x = 0;
                    y += 60;
                }
                else
                {
                    x += 60;
                }

            }


            GUI.EndScrollView();
            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
        }

        public static float PowerupAmount = 1;
        public static int SuCurrentPwrId;

        public static void SuDrawPower(int windowID)
        {
            DrawingUtilities.DrawWindowBackground(topcolor, restcolor, SuPowerRect, fontsize, "Powerup spawner");

            for (int i = 0; i < 1; i++)
            {
                SuCurrentPwrId = 0;
                for (int j = 0; j < 4; j++)
                {
                    float SuPwrY = (j * 60 + 20);
                    for (int k = 0; k < 7; k++)
                    {
                        float SuPwrX = (k * 60 + 10);
                        if (SuCurrentPwrId < 25 && GUI.Button(new Rect(SuPwrX, SuPwrY, 60f, 60f), cheats.patches.PlayerStatusPatch.SuPwrSprites[SuCurrentPwrId].texture))
                        {
                            int num = (int)PowerupAmount;
                            for (int l = 0; l < num; l++)
                            {
                                PowerupInventory.Instance.AddPowerup(ItemManager.Instance.allPowerups[SuCurrentPwrId].name, ItemManager.Instance.allPowerups[SuCurrentPwrId].id, ItemManager.Instance.GetNextId());
                            }
                        }
                        SuCurrentPwrId++;
                    }
                }
                SuCurrentPwrId = 0;
            }
            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
        }

        public static void SuDrawMob(int windowID)
        {
            DrawingUtilities.DrawWindowBackground(topcolor, restcolor, SuMobRect, fontsize, "Mob spawner");

            for (int i = 0; i < 17; i++)
            {
                if (GUI.Button(new Rect(10f, i * 20f + 20f, 160f, 20f), MobSpawner.Instance.allMobs[i].name))
                {
                    MobSpawner.Instance.ServerSpawnNewMob(MobManager.Instance.GetNextId(), MobSpawner.Instance.allMobs[i].id, PlayerMovement.Instance.GetRb().position, 1f, 1f, Mob.BossType.None, -1);
                }
            }

            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
        }

        public static void SuDrawWorld(int windowID)
        {
            DrawingUtilities.DrawWindowBackground(topcolor, restcolor, SuWorldRect, fontsize, "World");
            if (GUI.Button(new Rect(10f, 20f, 180f, 30f), "Destroy all trees"))
            {
                foreach (HitableTree Tree in GameObject.FindObjectsOfType<HitableTree>())
                {
                    Tree.Hit(9999, 9999, 1, Vector3.zero, 1);
                }
            }

            if (GUI.Button(new Rect(10f, 50f, 180f, 30f), "Destroy all rocks"))
            {
                foreach (HitableRock Rock in GameObject.FindObjectsOfType<HitableRock>())
                {
                    Rock.Hit(9999, 9999, 1, Vector3.zero, 1);
                }
            }

            if (GUI.Button(new Rect(10f, 80f, 180f, 30f), "Destroy all resources"))
            {
                foreach (HitableResource Resource in GameObject.FindObjectsOfType<HitableResource>())
                {
                    Resource.Hit(9999, 9999, 1, Vector3.zero, 1);
                }
            }

            if (GUI.Button(new Rect(10f, 110f, 180f, 30f), "Use all chests"))
            {
                foreach (LootContainerInteract Container in GameObject.FindObjectsOfType<LootContainerInteract>())
                {
                    ClientSend.PickupInteract(Container.GetId());
                }
            }

            if (GUI.Button(new Rect(10f, 140f, 180f, 30f), "Use all shrines"))
            {
                foreach (ShrineInteractable Shrine in GameObject.FindObjectsOfType<ShrineInteractable>())
                {
                    Shrine.Interact();
                }
            }


            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
        }

        public static bool playeresp = false;
        public static bool resourceesp = false;
        public static bool structureesp = false;

        public static void SuDrawEsp(int windowID)
        {
            DrawingUtilities.DrawWindowBackground(topcolor, restcolor, SuEspRect, fontsize, "Esp's");
            playeresp = GUI.Toggle(new Rect(10, 20, 180, 20), playeresp, "Player ESP");
            resourceesp = GUI.Toggle(new Rect(10, 40, 180, 20), resourceesp, "Mineral ESP");

            GUI.Label(new Rect(10, 60, 180, 20), "Esp's are resource intensive.");

            GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
        }

        /*
		public void DrawSettings(int windowID)
		{
			utils.DrawingUtilities.DrawWindowBackground(topcolor, restcolor, SettingsRect, 15, "Cheat settings");
			//Select text color shit
			GUI.Label(new Rect(5, 20, 100, 20), "Text color:", );

			if (GUI.Button(new Rect(105, 20, 20, 20), "red")) { Vars.textColor = Color.red; Vars.RainbowText = false; }
			utils.DrawingUtilities.DrawGui.DrawColor(Color.red, new Rect(105, 20, 20, 20));
			if (GUI.Button(new Rect(125, 20, 20, 20), "green")) { Vars.textColor = Color.green; Vars.RainbowText = false; }
			utils.DrawingUtilities.DrawGui.DrawColor(Color.green, new Rect(125, 20, 20, 20));
			if (GUI.Button(new Rect(145, 20, 20, 20), "blue")) { Vars.textColor = Color.cyan; Vars.RainbowText = false; }
			utils.DrawingUtilities.DrawGui.DrawColor(Color.cyan, new Rect(145, 20, 20, 20));
			if (GUI.Button(new Rect(165, 20, 20, 20), "yellow" )) { Vars.textColor = Color.yellow; Vars.RainbowText = false; }
			utils.DrawingUtilities.DrawGui.DrawColor(Color.yellow, new Rect(165, 20, 20, 20));
			if (GUI.Button(new Rect(185, 20, 20, 20), "rainbow" )) { Vars.textColor = Vars.currentrainbowcolor; Vars.RainbowText = true; }
			utils.DrawingUtilities.DrawGui.DrawColor(Vars.currentrainbowcolor, new Rect(185, 20, 20, 20));

			//Select top color shit

			GUI.Label(new Rect(5, 45, 100, 20), "Top color:", );

			if (GUI.Button(new Rect(105, 45, 20, 20), "red" )) { topcolor = Color.red; Vars.RainbowTop = false; }
			utils.DrawingUtilities.DrawGui.DrawColor(Color.red, new Rect(105, 45, 20, 20));
			if (GUI.Button(new Rect(125, 45, 20, 20), "green" )) { topcolor = Color.green; Vars.RainbowTop = false; }
			utils.DrawingUtilities.DrawGui.DrawColor(Color.green, new Rect(125, 45, 20, 20));
			if (GUI.Button(new Rect(145, 45, 20, 20), "blue")) { topcolor = Color.cyan; Vars.RainbowTop = false; }
			utils.DrawingUtilities.DrawGui.DrawColor(Color.cyan, new Rect(145, 45, 20, 20));
			if (GUI.Button(new Rect(165, 45, 20, 20), "yellow")) { topcolor = Color.yellow; Vars.RainbowTop = false; }
			utils.DrawingUtilities.DrawGui.DrawColor(Color.yellow, new Rect(165, 45, 20, 20));
			if (GUI.Button(new Rect(185, 45, 20, 20), "rainbow")) { topcolor = Vars.currentrainbowcolor; Vars.RainbowTop = true; }
			utils.DrawingUtilities.DrawGui.DrawColor(Vars.currentrainbowcolor, new Rect(185, 45, 20, 20));


			//Select background color shit

			GUI.Label(new Rect(5, 70, 100, 20), "back color:", );

			if (GUI.Button(new Rect(105, 70, 20, 20), "black", )) { restcolor = Color.black; }
			utils.DrawingUtilities.DrawGui.DrawColor(Color.black, new Rect(105, 70, 20, 20));
			if (GUI.Button(new Rect(125, 70, 20, 20), "blue", )) { restcolor = Color.blue; }
			utils.DrawingUtilities.DrawGui.DrawColor(Color.blue, new Rect(125, 70, 20, 20));
			if (GUI.Button(new Rect(145, 70, 20, 20), "Gray", )) { restcolor = Color.gray; }
			utils.DrawingUtilities.DrawGui.DrawColor(Color.gray, new Rect(145, 70, 20, 20));
			if (GUI.Button(new Rect(165, 70, 20, 20), "magenta", )) { restcolor = Color.magenta; }
			utils.DrawingUtilities.DrawGui.DrawColor(Color.magenta, new Rect(165, 70, 20, 20));
			if (GUI.Button(new Rect(185, 70, 20, 20), "white", )) { restcolor = Color.white; }
			utils.DrawingUtilities.DrawGui.DrawColor(Color.white, new Rect(185, 70, 20, 20));




			GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));

		}
		*/

        public static bool MainLock;

        public static Rect SuMovementRect = new Rect(50f, 20f, 150f, 160f);

        public static Rect SuPlayerRect = new Rect(210f, 20f, 150f, 160f);

        public static Rect SuServerRect = new Rect(360f, 20f, 350f, 200f);

        public static Rect SuExploitRect = new Rect(720f, 20f, 200f, 150f);

        public static Rect SuWorldRect = new Rect(920f, 20f, 200f, 180f);

        public static Rect SuItemRect = new Rect(50f, 230f, 500f, 300f);

        public static Rect SuPowerRect = new Rect(560f, 230f, 440f, 260f);

        public static Rect SuMobRect = new Rect(1110f, 230f, 180f, 370f);

        public static Rect SuEspRect = new Rect(50f, 540f, 200f, 90f);

        public static Rect SettingsRect = new Rect(260, 540, 210, 135);

    }
}
