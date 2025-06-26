using System.ComponentModel;

namespace DigitalProduction.Maui.Controls;

/// <summary>
/// Button that is the default on the form (button activated if "enter" is pressed).
/// 
/// The "Description" attribute can be accessed using Reflection to get a string representing the enumeration type.
/// </summary>
public enum MessageBoxYesNoToAllDefaultButton
{
	/// <summary>Button 1.</summary>
	[Description("Button 1")]
	Button1,

	/// <summary>Button 2.</summary>
	[Description("Button 2")]
	Button2,

	/// <summary>Button 3.</summary>
	[Description("Button 3")]
	Button3,

	/// <summary>Button 4.</summary>
	[Description("Button 4")]
	Button4,

	/// <summary>Button 5.</summary>
	[Description("Button 5")]
	Button5,

} // End enum.