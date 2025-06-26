using System.ComponentModel;

namespace DigitalProduction.Maui.Controls;

/// <summary>
/// Buttons shown on a MessageBoxYesNoToAll dialog box.
/// 
/// The "Description" attribute can be accessed using Reflection to get a string representing the enumeration type.
/// </summary>
public enum MessageBoxYesNoToAllButtons
{
	/// <summary>Yes, Yes to All, No.</summary>
	YesToAllNo,

	/// <summary>Yes to All, No, Cancel.</summary>
	YesToAllNoCancel,

	/// <summary>Yes, No, No to All.</summary>
	YesNoToAll,

	/// <summary>Yes, No, No to All, Cancel.</summary>
	YesNoToAllCancel,

	/// <summary>Yes, Yes to All, No, No to All.</summary>
	YesToAllNoToAll,

	/// <summary>Yes, Yes to All, No, No to All, Cancel.</summary>
	YesToAllNoToAllCancel

} // End enum.