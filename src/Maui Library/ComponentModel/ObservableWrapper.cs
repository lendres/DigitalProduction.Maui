using CommunityToolkit.Mvvm.ComponentModel;
using DigitalProduction.ComponentModel;
using System.Xml.Serialization;

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
public partial class ObservableWrapper<T> : ObservableObject, INotifyModifiedChanged
{
	#region Fields

	/// <summary>
	/// Occurs when data in the object is modified.  Used, for example, to enable/disable the a Save button based on whether the object
	/// has been modified and needs to be saved.
	/// </summary>
	public event ModifiedChangedEventHandler? ModifiedChanged;

	private bool _modified = false;

	#endregion

	#region Construction

	public ObservableWrapper()
	{
	}

	public ObservableWrapper(T? value)
	{
		Value		= value;
		Modified	= false;
	}

	#endregion

	#region Properties

	/// <summary>
	/// The value being wrapped. Changes to this value will set Modified to true, which can be used to enable/disable a Save button
	/// or perform other actions when the value changes.
	/// </summary>
	[ObservableProperty]
	public partial T? Value { get; set; }

	/// <summary>
	/// Specifies if changes have been made since the last save.
	/// </summary>
	[XmlIgnore()]
	public bool Modified
	{
		get => _modified;

		protected set
		{
			if (_modified != value)
			{
				_modified = value;
				ModifiedChanged?.Invoke(this, value);
			}
		}
	}

	#endregion

	#region Methods

	/// <summary>
	/// Captures changes to the Value property and sets Modified to true when the value changes.
	/// </summary>
	/// <param name="value">The new value.</param>
	partial void OnValueChanged(T? value)
	{
		Modified = true;
	}

	/// <summary>
	/// Marks the object as saved, which sets Modified to false.  Override this method to perform
	/// any necessary actions to save the object, such as writing to disk.
	/// </summary>
	public virtual void Save()
	{
		Modified = false;
	}

	/// <summary>
	/// Converts the value to a string for display purposes.  Override this method to provide a custom
	/// string representation of the value. By default, it will call ToString() on the value, or return
	/// an empty string if the value is null.
	/// </summary>
	/// <returns>The Value as a string or an empty string if the value is null.</returns>
	public override string ToString()
	{
		return Value?.ToString() ?? "";
	}

	#endregion
}