namespace su.Modules;

[RegisterModule(3)]
public class Speed : Module
{
	private bool Enabled;
	private float Multiplier = 1f;

	private float OriginalMultiplier = float.NaN;

	protected override void Initialize()
	{
		Name = "Speed";
		WindowId = WindowIDs.Movement.ToInt();
	}

	public override void OnRender()
	{
		Toggle(Name, ref Enabled);
		HorizontalSlider(null, 1, 5000, ref Multiplier);
	}

	public override void Update()
	{
		if (!InGame)
			return;

		if (float.IsNaN(OriginalMultiplier))
			OriginalMultiplier = PlayerStatus.Instance.currentSpeedArmorMultiplier;

		if (Enabled)
		{
			PlayerStatus.Instance.currentSpeedArmorMultiplier = Multiplier;
		}
		else
		{
			PlayerStatus.Instance.currentSpeedArmorMultiplier = OriginalMultiplier;
		}
	}

}
