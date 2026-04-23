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

	#region Interface Functions for Primitive Types

	#region Getters

    public static string Get(string defaultValue, [CallerMemberName] string propertyName = "")
    {
        return Get<string>(defaultValue, propertyName);
    }

    public static bool Get(bool defaultValue, [CallerMemberName] string propertyName = "")
    {
        return Get<bool>(defaultValue, propertyName);
    }

    public static int Get(int defaultValue, [CallerMemberName] string propertyName = "")
    {
        return Get<int>(defaultValue, propertyName);
    }

    public static double Get(double defaultValue, [CallerMemberName] string propertyName = "")
    {
        return Get<double>(defaultValue, propertyName);
    }

    public static float Get(float defaultValue, [CallerMemberName] string propertyName = "")
    {
        return Get<float>(defaultValue, propertyName);
    }

    public static long Get(long defaultValue, [CallerMemberName] string propertyName = "")
    {
        return Get<long>(defaultValue, propertyName);
    }

    public static DateTime Get(DateTime defaultValue, [CallerMemberName] string propertyName = "")
    {
        return Get<DateTime>(defaultValue, propertyName);
    }

    public static DateTimeOffset Get(DateTimeOffset defaultValue, [CallerMemberName] string propertyName = "")
    {
        return Get<DateTimeOffset>(defaultValue, propertyName);
    }

	#endregion

	#region Setters

    public static void Set(string value, [CallerMemberName] string propertyName = "")
    {
        Set<string>(value, propertyName);
    }

    public static void Set(bool value, [CallerMemberName] string propertyName = "")
    {
        Set<bool>(value, propertyName);
    }

    public static void Set(int defaultValue, [CallerMemberName] string propertyName = "")
    {
        Set<int>(defaultValue, propertyName);
    }

    public static void Set(double defaultValue, [CallerMemberName] string propertyName = "")
    {
        Set<double>(defaultValue, propertyName);
    }

    public static void Set(float defaultValue, [CallerMemberName] string propertyName = "")
    {
        Set<float>(defaultValue, propertyName);
    }

    public static void Set(long defaultValue, [CallerMemberName] string propertyName = "")
    {
        Set<long>(defaultValue, propertyName);
    }

    public static void Set(DateTime defaultValue, [CallerMemberName] string propertyName = "")
    {
        Set<DateTime>(defaultValue, propertyName);
    }

	public static void Set(DateTimeOffset defaultValue, [CallerMemberName] string propertyName = "")
	{
		Set<DateTimeOffset>(defaultValue, propertyName);
	}

	#endregion

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

    private static T Get<T>(T defaultValue, string propertyName)
    {
        return Microsoft.Maui.Storage.Preferences.Default.Get(propertyName, defaultValue);
    }

    private static void Set<T>(T? value, string propertyName)
    {
        Microsoft.Maui.Storage.Preferences.Default.Set(propertyName, value);
    }

	#endregion
}