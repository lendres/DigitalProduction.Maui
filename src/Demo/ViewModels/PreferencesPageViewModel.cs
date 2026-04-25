using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Preferences =  DigitalProduction.Maui.Storage.Preferences;

namespace DigitalProduction.Demo.ViewModels;

public partial class PreferencesPageViewModel : BaseViewModel
{
	#region Construction

	public PreferencesPageViewModel()
	{
	}

	#endregion

	#region Commands

	[RelayCommand]
	void RunTests()
	{
		GetStringReturnsDefaultWhenKeyDoesNotExist();
		GetAndSetOfString();
	}

	#endregion

	#region Tests

	public void GetStringReturnsDefaultWhenKeyDoesNotExist()
	{
		Preferences.Remove();
		string value = Preferences.Get("");
		AssertEqual("", value);

		Preferences.Set("stringtest");
		value = Preferences.Get("");

		AssertEqual("", value);
	}

	public void GetAndSetOfString()
	{
		Preferences.Remove();
		string value = Preferences.Get("");
		AssertEqual("", value);

		Preferences.Set("stringtest");
		value = Preferences.Get("");

		AssertEqual("stringtest", value);
	}

	private void AssertEqual<T>(T expected, T actual, [CallerMemberName] string testName = "")
	{
		if (!EqualityComparer<T>.Default.Equals(expected, actual))
		{
			// Log test name that failed and the expected and actual values.
		}
	}

	#endregion
}