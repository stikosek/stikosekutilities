using su.Patches;

namespace su.Modules.impl.Player;

[RegisterModule(3)]
public class InstantMine : Module
{

    private bool Enabled;

    protected override void Initialize()
    {
        Name = "Instant Mine";
        WindowId = WindowIDs.Player.ToInt();
    }

    public override void OnRender()
    {
        if (Toggle(Name, ref Enabled))
        {
            HitableResourcePatch.InstaMine = Enabled;
        }
    }

}
