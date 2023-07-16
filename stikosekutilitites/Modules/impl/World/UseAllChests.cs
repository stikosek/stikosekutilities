using UnityEngine;

namespace su.Modules;

[RegisterModule(1)]
public class UseAllChests : Module
{
	protected override void Initialize()
	{
		Name = "Use all Chests";
		WindowId = WindowIDs.World.ToInt();
	}

	public override void OnRender()
	{
		if (GUILayout.Button("Use all Chests"))
		{
			foreach (LootContainerInteract Container in Object.FindObjectsOfType<LootContainerInteract>())
			{
				ClientSend.PickupInteract(Container.GetId());
			}
		}

	}

}
