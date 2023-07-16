namespace su.Modules;

[RegisterModule(1)]
public class OmegaJump : Module
{
	private static float origJumpForce = float.NaN;

	private bool Enabled;

	protected override void Initialize()
	{
		Name = "Omega Jump";
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

		if (float.IsNaN(origJumpForce))
		{
			origJumpForce = PlayerMovement.Instance.jumpForce;
		}

		if (!Enabled)
		{
			if (PlayerMovement.Instance.jumpForce != origJumpForce)
			{
				PlayerMovement.Instance.jumpForce = origJumpForce;
			}
			return;
		}


		PlayerMovement.Instance.jumpForce = origJumpForce * 2;
	}

}
