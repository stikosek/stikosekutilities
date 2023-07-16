using su.Patches;

namespace su.Modules;

[RegisterModule(0)]
public class GodMode : Module
{
	private bool Enabled;

	protected override void Initialize()
	{
		Name = "GodMode";
		WindowId = WindowIDs.Player.ToInt();
	}

	public override void OnRender()
	{
		if (Toggle(Name, ref Enabled))
		{
			PlayerStatusPatch.GodMode = Enabled;

			PlayerStatus.Instance.hp = PlayerStatus.Instance.maxHp;
			PlayerStatus.Instance.shield = PlayerStatus.Instance.maxShield;
		}
	}

	public override void Update()
	{
		if (!InGame)
			return;

		if (!Enabled)
			return;

		PlayerStatus.Instance.hp = PlayerStatus.Instance.maxHp;
		PlayerStatus.Instance.shield = PlayerStatus.Instance.maxShield;
	}

}
