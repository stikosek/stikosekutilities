using System.Linq;
using UnityEngine;

namespace su.Modules;

public class Module
{
	protected bool InGame => PlayerMovement.Instance != null;

	public string Name { get; protected set; }
	public string Description { get; protected set; }

	public int WindowId { get; protected set; }

	public Module()
	{
		Initialize();
	}

	protected virtual void Initialize() { }

	public virtual void OnRender() { }

	public virtual void OnGUI() { }

	public virtual void Update() { }

	public virtual void FixedUpdate() { }

	protected bool IntInput(string text, int min, int max, ref int valueRef, params GUILayoutOption[] layoutOptions)
	{
		if (valueRef < min)
			valueRef = min;

		if (valueRef > max)
			valueRef = max;

		GUILayout.BeginHorizontal();

		if (text != null)
			GUILayout.Label(text);

		string newText = GUILayout.TextField(valueRef.ToString(), layoutOptions);

		if (!newText.All(char.IsNumber))
		{
			newText = valueRef.ToString();
		}

		int newValue = int.Parse(newText);

		GUILayout.EndHorizontal();

		if (newValue != valueRef)
		{
			valueRef = newValue;
			return true;
		}

		return false;
	}

	protected bool Toggle(string text, ref bool valueRef, params GUILayoutOption[] layoutOptions)
	{
		bool newValue = GUILayout.Toggle(valueRef, text, layoutOptions);

		if (newValue != valueRef)
		{
			valueRef = newValue;
			return true;
		}

		return false;
	}

	protected bool HorizontalSlider(string label, float min, float max, ref float valueRef, params GUILayoutOption[] layoutOptions)
	{
		if (valueRef < min)
			valueRef = min;

		if (valueRef > max)
			valueRef = max;

		GUILayout.BeginHorizontal();

		if (label != null)
			GUILayout.Label(label);

		float newValue = GUILayout.HorizontalSlider(valueRef, min, max, layoutOptions);

		GUILayout.EndHorizontal();

		if (newValue != valueRef)
		{
			valueRef = newValue;
			return true;
		}

		return false;
	}

}
