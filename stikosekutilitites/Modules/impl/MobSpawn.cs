using UnityEngine;

namespace su.Modules;

[RegisterModule]
public class MobSpawn : Module
{
	private Vector2 ScrollPosition = new();

	protected override void Initialize()
	{
		Name = "Mob Spawner";
		WindowId = WindowIDs.MobSpawner.ToInt();
	}

	public override void OnRender()
	{
		if (MobSpawner.Instance == null || !InGame || !LocalClient.serverOwner)
		{
			GUILayout.Label("Load into a game as the lobby owner to see all mobs");
			return;
		}

		ScrollPosition = GUILayout.BeginScrollView(ScrollPosition);

		foreach (MobType mob in MobSpawner.Instance.allMobs)
		{
			if (!GUILayout.Button(mob.name))
				continue;

			MobSpawner.Instance.ServerSpawnNewMob(MobManager.Instance.GetNextId(), mob.id, PlayerMovement.Instance.GetRb().position, 1f, 1f);
		}
		
		GUILayout.EndScrollView();
	}


}
