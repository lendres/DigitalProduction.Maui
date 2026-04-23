using Xunit;
using Preferences =  DigitalProduction.Maui.Storage.Preferences;

namespace DigitalProduction.UnitTests;

public class PreferencesTests
{
	public class TestSettings
	{
		public string Name { get; set; } = "";
		public int Age { get; set; }
	}

	[Fact]
	public void GetStringReturnsDefaultWhenKeyDoesNotExist()
	{
		Preferences.Remove();
		string value = Preferences.Get("");
		Assert.Equal("", value);

		Preferences.Set("stringtest");
		value = Preferences.Get("");

		Assert.Equal("", value);
	}

	[Fact]
	public void GetAndSetOfString()
	{
		Preferences.Remove();
		string value = Preferences.Get("");
		Assert.Equal("", value);

		Preferences.Set("stringtest");
		value = Preferences.Get("");

		Assert.Equal("", value);
	}


}