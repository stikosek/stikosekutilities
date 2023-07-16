using UnityEngine;

namespace su.Modules;

[RegisterModule(2)]
public class UseAllShrines : Module
{
	protected override void Initialize()
	{
		Name = "Use all Shrines";
		WindowId = WindowIDs.World.ToInt();
	}

	public override void OnRender()
	{
		if (GUILayout.Button("Use all Shrines"))
		{
			foreach (ShrineInteractable Shrine in Object.FindObjectsOfType<ShrineInteractable>())
			{
				Shrine.Interact();
			}
		}

	}

}
