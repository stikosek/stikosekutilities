namespace su.Modules;

[RegisterModule(2)]
public class InfiniteFood : Module
{
	private bool Enabled;

	protected override void Initialize()
	{
		Name = "Infinite Food";
		WindowId = WindowIDs.Player.ToInt();
	}

	public override void OnRender()
	{
		if (Toggle(Name, ref Enabled))
		{
			PlayerStatus.Instance.hunger = PlayerStatus.Instance.maxHunger;
		}
	}

	public override void Update()
	{
		if (!InGame)
			return;

		if (!Enabled)
			return;

		PlayerStatus.Instance.hunger = PlayerStatus.Instance.maxHunger;
	}

}
