using su.Patches;

namespace su.Modules;

[RegisterModule(5)]
public class FreeChests : Module
{
	private bool Enabled;

	protected override void Initialize()
	{
		Name = "Free Chests";
		WindowId = WindowIDs.Player.ToInt();
	}

	public override void OnRender()
	{
		if (Toggle(Name, ref Enabled))
		{
			LootContainerInteractPatch.NoCoins = Enabled;
		}
	}
}
