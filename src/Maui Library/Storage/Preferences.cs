using DigitalProduction.Xml.Serialization;
using System.Runtime.CompilerServices;

namespace DigitalProduction.Maui.Storage;

public static class Preferences
{
	#region Instances

	public static T GetInstance<T>([CallerMemberName] string propertyName = "") where T : new()

	{
		string serializedSettings = Get("", propertyName);
		if (string.IsNullOrEmpty(serializedSettings))
		{
			return new T();
		}
		else
		{
			return Serialization.DeserializeObjectFromString<T>(serializedSettings)!;
		}
    }

    public static void SetInstance<T>(T? value, [CallerMemberName] string propertyName = "")
    {
        string serializedSettings = Serialization.SerializeObjectToString(value);
		Set(serializedSettings, propertyName);
    }

	#endregion

	#region Checking and Removal

	public static bool ContainsKey([CallerMemberName] string propertyName = "") =>
			Microsoft.Maui.Storage.Preferences.Default.ContainsKey(propertyName);

	public static void Remove([CallerMemberName] string propertyName = "")
	{
		Microsoft.Maui.Storage.Preferences.Default.Remove(propertyName);
	}

	public static void Clear()
	{
		Microsoft.Maui.Storage.Preferences.Default.Clear();
	}

	#endregion

	#region Template Functions

    public static T Get<T>(T defaultValue, [CallerMemberName] string propertyName = "")
    {
        return Microsoft.Maui.Storage.Preferences.Default.Get(propertyName, defaultValue);
    }

    public static void Set<T>(T? value,  [CallerMemberName] string propertyName = "")
    {
        Microsoft.Maui.Storage.Preferences.Default.Set(propertyName, value);
    }

	#endregion
}