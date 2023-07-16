using UnityEngine;

namespace su.Modules;

[RegisterModule(5)]
public class ClickTP : Module
{
	private bool Enabled;

	protected override void Initialize()
	{
		Name = "Click tp";
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

		if (!Input.GetKeyDown(KeyCode.Mouse1))
			return;

		PlayerMovement.Instance.GetRb().position = FindTpPos();
	}

	private static Vector3 FindTpPos()
	{
		Transform playerCam = PlayerMovement.Instance.playerCam;

		if (!Physics.Raycast(playerCam.position, playerCam.forward, out RaycastHit raycastHit, 1500f))
			return Vector3.zero;
		
		Vector3 b = Vector3.zero;
		if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			b = Vector3.one;
		}

		return raycastHit.point + b;
	}

}
