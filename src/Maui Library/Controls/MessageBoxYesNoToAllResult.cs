using System.ComponentModel;

namespace DigitalProduction.Maui.Controls;

/// <summary>
/// Results of a MessageBoxYesNoToAll dialog box.
/// 
/// The "Description" attribute can be accessed using Reflection to get a string representing the enumeration type.
/// </summary>
public enum MessageBoxYesNoToAllResult
{
	/// <summary>Yes.</summary>
	[Description("Yes")]
	Yes,

	/// <summary>Yes to All button was pushed.</summary>
	[Description("Yes to All")]
	YesToAll,

	/// <summary>No button was pushed.</summary>
	[Description("No")]
	No,

	/// <summary>No to All button was pushed.</summary>
	[Description("No to All")]
	NoToAll,

	/// <summary>Cancel button was pushed.</summary>
	[Description("Cancel")]
	Cancel

} // End enum.