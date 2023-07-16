using su.Patches;
using System.Linq;
using UnityEngine;

namespace su.Modules;

[RegisterModule]
public class ItemSpawner : Module
{
	private bool DropItems;
	private int SpawnAmount = 1;
	private Vector2 ScrollPosition = new();

	protected override void Initialize()
	{
		Name = "Item Spawner";
		WindowId = WindowIDs.ItemSpawner.ToInt();
	}

	public override void OnRender()
	{
		if (ItemManagerPatch.DontDestroyInstance == null || !InGame)
		{
			GUILayout.Label("Load into a game to see all items");
			return;
		}

		ScrollPosition = GUILayout.BeginScrollView(ScrollPosition);

		InventoryItem[] items = ItemManagerPatch.DontDestroyInstance.allItems.Values.ToArray();
		for (int i = 0; i < items.Length; i++)
		{
			if (i % 7 == 0)
			{
				if (i != 0)
					GUILayout.EndHorizontal();

				GUILayout.BeginHorizontal();
			}

			InventoryItem item = items[i];

			if (!GUILayout.Button(item.sprite.texture, GUILayout.Width(60), GUILayout.Height(60)))
				continue;


			if (DropItems)
			{
				ClientSend.DropItem(item.id, SpawnAmount);
			} else
			{
				item.amount = SpawnAmount;
				InventoryUI.Instance.AddItemToInventory(item);
			}
		}
		GUILayout.EndHorizontal(); 
		GUILayout.EndScrollView();

		GUILayout.BeginHorizontal();

		GUILayout.Label("Spawn Amount");

		IntInput(null, 1, 1000, ref SpawnAmount, GUILayout.Width(150));

		float floatSpawnAmount = SpawnAmount;
		if (HorizontalSlider(null, 1, 1000, ref floatSpawnAmount))
		{
			SpawnAmount = Mathf.RoundToInt(floatSpawnAmount);
		}

		GUILayout.EndHorizontal();

		Toggle("Drop Item(s)", ref DropItems);

	}


}
