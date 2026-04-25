using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Preferences =  DigitalProduction.Maui.Storage.Preferences;

namespace DigitalProduction.Demo.ViewModels;

public partial class PreferencesPageViewModel : BaseViewModel
{
	#region Fields

	private readonly List<string> _testErrors = new();

	#endregion

	#region Construction

	public PreferencesPageViewModel()
	{
	}

	#endregion

	#region Properties

	[ObservableProperty]
	public partial string TestResults { get; set; } = "Tests have not been run.";

	#endregion

	#region Commands

	[RelayCommand]
	void RunTests()
	{
		GetStringReturnsDefaultWhenKeyDoesNotExist();
		GetAndSetOfString();
		GetAndSetOfBool();
		GetAndSetOfInt();
		GetAndSetOfDouble();
		GetAndSetOfFloat();
		GetAndSetOfLong();
		GetAndSetOfDateTime();
		GetAndSetOfDateTimeOffset();
		ContainsKeyReturnsTrueAfterSet();
		RemoveDeletesPreference();
		ClearDeletesAllPreferences();
		GetAndSetOfInstance();

		UpdateTestResults();
	}

	#endregion

	#region Tests


	public void GetStringReturnsDefaultWhenKeyDoesNotExist()
	{
		Preferences.Remove();
		string value = Preferences.Get("");
		AssertEqual("", value);
	}

	public void GetAndSetOfString()
	{
		Preferences.Remove();
		Preferences.Set("stringtest");
		string value = Preferences.Get("");
		AssertEqual("stringtest", value);
	}

	public void GetAndSetOfBool()
	{
		Preferences.Remove();
		Preferences.Set(true);
		bool value = Preferences.Get(false);
		AssertEqual(true, value);
	}

	public void GetAndSetOfInt()
	{
		Preferences.Remove();
		Preferences.Set(123);
		int value = Preferences.Get(0);
		AssertEqual(123, value);
	}

	public void GetAndSetOfDouble()
	{
		Preferences.Remove();
		Preferences.Set(123.456);
		double value = Preferences.Get(0.0);
		AssertEqual(123.456, value);
	}

	public void GetAndSetOfFloat()
	{
		Preferences.Remove();
		Preferences.Set(123.456f);
		float value = Preferences.Get(0.0f);
		AssertEqual(123.456f, value);
	}

	public void GetAndSetOfLong()
	{
		Preferences.Remove();
		Preferences.Set(123456789L);
		long value = Preferences.Get(0L);
		AssertEqual(123456789L, value);
	}

	public void GetAndSetOfDateTime()
	{
		Preferences.Remove();
		DateTime expected = new(2026, 4, 25, 10, 30, 0, DateTimeKind.Local);
		Preferences.Set(expected);
		DateTime actual = Preferences.Get(DateTime.MinValue);
		AssertEqual(expected, actual);
	}

	public void GetAndSetOfDateTimeOffset()
	{
		Preferences.Remove();
		DateTimeOffset expected = new(2026, 4, 25, 10, 30, 0, TimeSpan.FromHours(-5));
		Preferences.Set(expected);
		DateTimeOffset actual = Preferences.Get(DateTimeOffset.MinValue);
		AssertEqual(expected, actual);
	}

	public void ContainsKeyReturnsTrueAfterSet()
	{
		Preferences.Remove();
		Preferences.Set("stringtest");
		bool containsKey = Preferences.ContainsKey();
		AssertEqual(true, containsKey);
	}

	public void RemoveDeletesPreference()
	{
		Preferences.Set("stringtest");
		Preferences.Remove();

		bool containsKey	= Preferences.ContainsKey();
		string value		= Preferences.Get("");

		AssertEqual(false, containsKey);
		AssertEqual("", value);
	}

	public void ClearDeletesAllPreferences()
	{
		Preferences.Set("stringtest");
		Preferences.Clear();

		bool containsKey	= Preferences.ContainsKey();
		string value		= Preferences.Get("");

		AssertEqual(false, containsKey);
		AssertEqual("", value);
	}

	public void GetAndSetOfInstance()
	{
		Preferences.Remove();

		Person expected = new()
		{
			Name	= "Test Name",
			Age		= 123,
		};

		Preferences.SetInstance(expected);
		Person actual = Preferences.GetInstance<Person>();

		AssertEqual(expected.Name, actual.Name);
		AssertEqual(expected.Age, actual.Age);
	}

	private void AssertEqual<T>(T expected, T actual, [CallerMemberName] string testName = "")
	{
		if (!EqualityComparer<T>.Default.Equals(expected, actual))
		{
			_testErrors.Add($"Test: {testName}. Expected: {expected}. Actual: {actual}.");
		}
	}

	private void UpdateTestResults()
	{
		if (_testErrors.Count == 0)
		{
			TestResults = "All preference tests passed.";
			return;
		}

		StringBuilder stringBuilder = new();

		stringBuilder.AppendLine($"{_testErrors.Count} preference test error(s):");
		stringBuilder.AppendLine();

		foreach (string testError in _testErrors)
		{
			stringBuilder.AppendLine(testError);
		}

		TestResults = stringBuilder.ToString();
	}

	#endregion
}