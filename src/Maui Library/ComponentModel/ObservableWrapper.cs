using CommunityToolkit.Mvvm.ComponentModel;

namespace DigitalProduction.Maui.ComponentModel;

/// <summary>
/// Maui XAML does not support binding to a value type directly, so we need to wrap it in an observable object. This class provides a simple way to do that.
/// XAML does not handle type parameters well, so we need to create a separate class for each type we want to wrap. This is a bit of a workaround, but it
/// works well enough for our purposes.
/// </summary>
public partial class ObservableString : ObservableWrapper<string>
{
	public ObservableString() { }
	public ObservableString(string value) : base(value) { }
}

public partial class ObservableInt : ObservableWrapper<int>
{
	public ObservableInt() { }
	public ObservableInt(int value) : base(value) { }
}

public partial class ObservableDouble : ObservableWrapper<double>
{
	public ObservableDouble() { }
	public ObservableDouble(double value) : base(value) { }
}

public partial class ObservableFloat : ObservableWrapper<float>
{
	public ObservableFloat() { }
	public ObservableFloat(float value) : base(value) { }
}

/// <summary>
/// Base class for wrapping a value in an observable object. This is useful for binding to a value that may change and needs to notify the UI of changes.
/// </summary>
/// <typeparam name="T">Type.</typeparam>
public partial class ObservableWrapper<T> : ObservableObject
{
	#region Fields
	#endregion

	#region Construction

	public ObservableWrapper()
	{
	}

	public ObservableWrapper(T? value)
	{
		Value = value;
	}

	#endregion

	#region Properties

	[ObservableProperty]
	public partial T? Value { get; set; }

	#endregion

	#region Methods

	public override string ToString()
	{
		return Value?.ToString() ?? "";
	}

	#endregion
}