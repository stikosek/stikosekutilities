using UnityEngine;

namespace su.Modules;

[RegisterModule(0)]
public class Destroyer : Module
{
	protected override void Initialize()
	{
		Name = "Destroyer";
		WindowId = WindowIDs.World.ToInt();
	}

	public override void OnRender()
	{
		if (GUILayout.Button("Destroy all Trees"))
		{
			Destroy<HitableTree>();
		}

		if (GUILayout.Button("Destroy all Rocks"))
		{
			Destroy<HitableRock>();
		}

		if (GUILayout.Button("Destroy all Resources"))
		{
			Destroy<HitableResource>();
		}

		if (GUILayout.Button("Destroy all Mobs"))
		{
			Destroy<HitableMob>();
		}
	}

	private static void Destroy<T>() where T : Hitable
	{
		foreach (Hitable hitable in Object.FindObjectsOfType<T>())
		{
			hitable.Hit(hitable.maxHp, hitable.maxHp, 1, Vector3.zero, 1);
		}
	}

}
