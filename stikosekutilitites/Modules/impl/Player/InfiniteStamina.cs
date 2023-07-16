namespace su.Modules;

[RegisterModule(1)]
public class InfiniteStamina : Module
{
	private bool Enabled;

	protected override void Initialize()
	{
		Name = "Infinite Stamina";
		WindowId = WindowIDs.Player.ToInt();
	}

	public override void OnRender()
	{
		if (Toggle(Name, ref Enabled))
		{
			PlayerStatus.Instance.stamina = PlayerStatus.Instance.maxStamina;
		}
	}

	public override void Update()
	{
		if (!InGame)
			return;

		if (!Enabled)
			return;

		PlayerStatus.Instance.stamina = PlayerStatus.Instance.maxStamina;
	}

}
