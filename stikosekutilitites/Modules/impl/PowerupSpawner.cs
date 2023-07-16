using su.Patches;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace su.Modules;

[RegisterModule]
public class PowerupSpawner : Module
{
	private int SpawnAmount = 1;
	private Vector2 ScrollPosition = new();

	protected override void Initialize()
	{
		Name = "Powerup Spawner";
		WindowId = WindowIDs.PowerupSpawner.ToInt();
	}

	private IEnumerator AddPowerups(Powerup powerup, int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			try
			{
				PowerupInventory.Instance.AddPowerup(powerup.name, powerup.id, ItemManagerPatch.DontDestroyInstance.GetNextId());
			} catch(Exception) { }
			yield return new WaitForFixedUpdate();
		}
	}

	public override void OnRender()
	{
		if (ItemManagerPatch.DontDestroyInstance == null || !InGame)
		{
			GUILayout.Label("Load into a game to see all powerups");
			return;
		}

		ScrollPosition = GUILayout.BeginScrollView(ScrollPosition);

		Powerup[] powerups = ItemManagerPatch.DontDestroyInstance.allPowerups.Values.ToArray();
		for (int i = 0; i < powerups.Length; i++)
		{
			if (i % 6 == 0)
			{
				if (i != 0)
					GUILayout.EndHorizontal();

				GUILayout.BeginHorizontal();
			}

			Powerup powerup = powerups[i];

			if (!GUILayout.Button(powerup.sprite.texture, GUILayout.Width(60), GUILayout.Height(60)))
				continue;

			StikosekUtilities.Instance.StartCoroutine(AddPowerups(powerup, SpawnAmount));
		}
		GUILayout.EndHorizontal(); 
		GUILayout.EndScrollView();

		GUILayout.BeginHorizontal();

		GUILayout.Label("Spawn Amount");

		IntInput(null, 1, 100, ref SpawnAmount, GUILayout.Width(150));

		float floatSpawnAmount = SpawnAmount;
		if (HorizontalSlider(null, 1, 100, ref floatSpawnAmount))
		{
			SpawnAmount = Mathf.RoundToInt(floatSpawnAmount);
		}

		GUILayout.EndHorizontal();

	}


}
