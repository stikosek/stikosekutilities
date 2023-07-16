using UnityEngine;

namespace su.Modules;

[RegisterModule(4)]
public class Hover : Module
{
	private bool Enabled;

	protected override void Initialize()
	{
		Name = "Hover";
		WindowId = WindowIDs.Movement.ToInt();
	}

	public override void OnRender()
	{
		Toggle(Name, ref Enabled);
	}

	public override void Update()
	{
		if (!InGame)
			return;

		if (!Enabled)
			return;

		PlayerMovement.Instance.GetRb().velocity = new Vector3(0f, 1f, 0f);
	}

}
