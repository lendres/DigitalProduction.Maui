namespace DigitalProduction.Maui.Controls;

public class PathClickedEventArgs : EventArgs
{
	public PathClickedEventArgs(string path)
	{
		Path = path;
	}

	public string Path { get; }
}