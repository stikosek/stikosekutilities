namespace su;

public enum WindowIDs
{
	Player = 0,
	Movement = 1,
	World = 2,
	Exploit = 3,
	PlayerList = 4,
	PowerupSpawner = 5,
	ItemSpawner = 6,
	MobSpawner = 7
}

public static class WindowIDsExtension
{
	public static int ToInt(this WindowIDs windowId) { return (int)windowId; }
}