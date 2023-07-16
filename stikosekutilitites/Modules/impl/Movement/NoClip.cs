using UnityEngine;

namespace su.Modules;

[RegisterModule(2)]
public class NoClip : Module
{
	private bool Enabled;

	protected override void Initialize()
	{
		Name = "No clip";
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
		{
			PlayerMovement.Instance.GetPlayerCollider().enabled = true;
			return;
		}

		PlayerMovement.Instance.GetPlayerCollider().enabled = false;
	}

}
