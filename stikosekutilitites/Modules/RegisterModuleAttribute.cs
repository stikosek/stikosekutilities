using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace su.Modules;

[AttributeUsage(AttributeTargets.Class)]
public class RegisterModuleAttribute : Attribute
{
	[Obfuscation(Exclude = true)]
	public int Priority = -1;

	public RegisterModuleAttribute() { }


	public RegisterModuleAttribute(int priority)
	{
		Priority = priority;
	}

	public static List<Type> FindModules()
	{
		return Assembly.GetExecutingAssembly()
			.GetTypes()
			.Where(t => t.IsSubclassOf(typeof(Module)) && t.GetCustomAttribute<RegisterModuleAttribute>() != null)
			.OrderBy(t => t.GetCustomAttribute<RegisterModuleAttribute>().Priority)
			.ToList();
	}
}
