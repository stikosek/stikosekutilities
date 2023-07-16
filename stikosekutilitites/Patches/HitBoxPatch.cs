using HarmonyLib;
using su.Modules.impl.Player;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace su.Patches;

[HarmonyPatch(typeof(HitBox))]
public class HitBoxPatch
{
	[Obfuscation(Exclude = true)]
	[HarmonyPatch(nameof(HitBox.UseHitbox))]
	[HarmonyTranspiler]
	private static IEnumerable<CodeInstruction> UseHitbox(IEnumerable<CodeInstruction> instructions)
	{
		return new CodeMatcher(instructions)
			.MatchForward(false,
				new CodeMatch(OpCodes.Ldc_R4, 1.2f),
				new CodeMatch(OpCodes.Ldloc_0),
				new CodeMatch(OpCodes.Ldfld),
				new CodeMatch(OpCodes.Add),
				new CodeMatch(OpCodes.Ldsfld),
				new CodeMatch(OpCodes.Ldfld),
				new CodeMatch(OpCodes.Add))
			.RemoveInstructions(7)
			.Insert(new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Reach), nameof(Reach.GetMaxRange))))
			.InstructionEnumeration();
	}

}
