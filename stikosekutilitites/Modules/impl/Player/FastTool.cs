using System.Reflection;

namespace su.Modules.impl.Player;

[RegisterModule(6)]
public class FastTool : Module
{
    private static bool Enabled;

    protected override void Initialize()
    {
        Name = "Fast Tool";
        WindowId = WindowIDs.Player.ToInt();
    }

    public override void OnRender()
    {
        Toggle(Name, ref Enabled);
    }

    [Obfuscation(Exclude = true)]
    public static float GetAttackSpeed()
    {
        if (Enabled)
            return 99f;
        else
            return UseInventory.Instance.currentItem.attackSpeed;
    }

}
