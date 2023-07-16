using HarmonyLib;
using su.Modules.impl.Player;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace su.Patches;

[HarmonyPatch(typeof(UseInventory))]
public static class UseInventoryPatch
{

	[Obfuscation(Exclude = true)]
	[HarmonyPatch(nameof(UseInventory.Use))]
	[HarmonyTranspiler]
	private static IEnumerable<CodeInstruction> Use(IEnumerable<CodeInstruction> instructions)
	{
		return new CodeMatcher(instructions)
			.MatchForward(true,
				new CodeMatch(OpCodes.Ldstr, ""),
				new CodeMatch(OpCodes.Stloc_1),
				new CodeMatch(OpCodes.Ldarg_0),
				new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(UseInventory), nameof(UseInventory.currentItem))),
				new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(InventoryItem), nameof(InventoryItem.attackSpeed))))
			.Advance(-2)
			.RemoveInstructions(3)
			.Insert(new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(FastTool), nameof(FastTool.GetAttackSpeed))))
			.InstructionEnumeration();
	}

}
