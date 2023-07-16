using su.Patches;

namespace su.Modules.impl.Player;

[RegisterModule(4)]
public class InstantKill : Module
{
    private bool Enabled;

    protected override void Initialize()
    {
        Name = "Instant Kill";
        WindowId = WindowIDs.Player.ToInt();
    }

    public override void OnRender()
    {
        if (Toggle(Name, ref Enabled))
        {
            HitableMobPatch.InstaKill = Enabled;
        }
    }

}
