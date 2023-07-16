using System;
using System.Linq;
using UnityEngine;

namespace su.Modules;

[RegisterModule]
public class PlayerList : Module
{
	private PlayerManager SelectedPlayer = null;

	private Vector3 ScrollPosition = new();

	protected override void Initialize()
	{
		Name = "PlayerList";
		WindowId = WindowIDs.PlayerList.ToInt();
	}

	private void RenderPlayers()
	{
		PlayerManager[] players = GameManager.players.Values.ToArray();
		for (int i = 0; i < players.Length; i++)
		{
			if (i % 3 == 0)
			{
				if (i != 0)
					GUILayout.EndHorizontal();

				GUILayout.BeginHorizontal();
			}

			PlayerManager player = players[i];

			if (!GUILayout.Button(player.username, GUILayout.Width(100)))
				continue;

			SelectedPlayer = player;
		}
		GUILayout.EndHorizontal();
	}

	public override void OnRender()
	{
		GUILayout.BeginHorizontal();

		GUILayout.BeginVertical(GUILayout.Width(110));
		ScrollPosition = GUILayout.BeginScrollView(ScrollPosition);

		if (InGame)
			RenderPlayers();

		GUILayout.EndScrollView();
		GUILayout.EndVertical();

		GUIStyle centeredText = new GUIStyle(GUI.skin.label)
		{
			font = Resources.GetBuiltinResource<Font>("Arial.ttf"),
			alignment = TextAnchor.MiddleCenter,
		};

		GUILayout.BeginVertical(GUI.skin.box, GUILayout.ExpandHeight(true));

		GUILayout.Label("Player Actions", centeredText);
		GUILayout.Label("Selected: " + (SelectedPlayer == null ? "" : SelectedPlayer.username));

		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Kill [HOST]"))
		{
			try
			{
				ServerSend.HitPlayer(LocalClient.instance.myId, 69420, 0f, SelectedPlayer.id, 1, SelectedPlayer.transform.position);
			} catch(Exception) {}

			ClientSend.PlayerHit(69420, SelectedPlayer.id, 69420, 1, SelectedPlayer.transform.position);
		}

		if (GUILayout.Button("Kick [HOST]"))
		{
			ServerSend.DisconnectPlayer(SelectedPlayer.id);
		}

		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();

		if (GUILayout.Button("Cage"))
		{
			Cage();
		}

		if (GUILayout.Button("MultiCage"))
		{
			for (int i = 0; i < 10; i++)
			{
				Cage();
			}
		}

		if (GUILayout.Button("TP to Player"))
		{
			PlayerMovement.Instance.GetRb().position = SelectedPlayer.transform.position;
		}

		GUILayout.EndHorizontal();
		GUILayout.EndVertical();

		GUILayout.EndHorizontal();

		GUILayout.Label("Thanks to Farliam for the cage code :)");
	}

	private void Cage()
	{
		Vector3 position = SelectedPlayer.transform.position;

		Vector3 top = position + new Vector3(0, 5, 0);
		Vector3 bottom = position - new Vector3(0, 2, 0);

		Vector3 left = position - new Vector3(3.5f, -1.5f);
		Vector3 right = left + new Vector3(7, 0, 0);

		Vector3 back = position - new Vector3(0, -1.5f, 3.5f);
		Vector3 front = back + new Vector3(0, 0, 7);

		ClientSend.RequestBuild(35, top, 0);
		ClientSend.RequestBuild(35, bottom, 0);
		ClientSend.RequestBuild(41, left, 90);
		ClientSend.RequestBuild(41, right, 90);
		ClientSend.RequestBuild(41, back, 180);
		ClientSend.RequestBuild(41, front, 180);
	}

}
