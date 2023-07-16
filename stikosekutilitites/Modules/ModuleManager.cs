using System;
using System.Collections.Generic;
using System.Linq;

namespace su.Modules;

public class ModuleManager
{
	public Dictionary<int, List<Module>> Modules = new();

	public ModuleManager()
	{
		RegisterModules();
	}

	private void RegisterModules()
	{
		foreach (Type moduleType in RegisterModuleAttribute.FindModules())
		{
			try
			{
				Module module = (Module)Activator.CreateInstance(moduleType);

				if (!Modules.TryGetValue(module.WindowId, out List<Module> moduleList))
				{
					moduleList = new();
					Modules.Add(module.WindowId, moduleList);
				}

				moduleList.Add(module);
			} catch (Exception ex)
			{
				StikosekUtilities.Log.LogError($"Error in module \"{moduleType.FullName}\": {ex}");
			}
		}
	}

	public void ForEachModule(Action<Module> action)
	{
		foreach (Module module in Modules.Values.SelectMany(value => value))
		{
			try
			{
				action(module);
			} catch (Exception ex)
			{
				StikosekUtilities.Log.LogError($"Error in module \"{module.Name}\": {ex}");
			}
		}
	}

	public void OnGUI()
	{
		ForEachModule(module => module.OnGUI());
	}

	public void Update()
	{
		ForEachModule(module => module.Update());
	}

	public void FixedUpdate()
	{
		ForEachModule(module => module.FixedUpdate());
	}

}
