using System.Reflection;

namespace su.Modules.impl.Player;

[RegisterModule(7)]
public class Reach : Module
{
    private static bool Enabled;

    protected override void Initialize()
    {
        Name = "Reach";
        WindowId = WindowIDs.Player.ToInt();
    }

    public override void OnRender()
    {
        Toggle(Name, ref Enabled);
    }

    [Obfuscation(Exclude = true)]
    public static float GetMaxRange()
    {
        if (Enabled)
            return 9999f;
        else
            return 1.2f + Hotbar.Instance.currentItem.attackRange + PlayerStatus.Instance.currentChunkArmorMultiplier;
    }

}
