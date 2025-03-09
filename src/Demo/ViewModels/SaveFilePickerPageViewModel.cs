using CommunityToolkit.Mvvm.ComponentModel;
using DigitalProduction.Maui.Storage;

namespace DigitalProduction.Demo.ViewModels;

public partial class SaveFilePickerPageViewModel : BaseViewModel
{
	#region Fields

	private ISaveFilePicker _saveFilePicker = DigitalProduction.Maui.Services.ServiceProvider.GetService<ISaveFilePicker>();

	#endregion

	#region Construction

	public SaveFilePickerPageViewModel()
	{
	}

	#endregion

	#region Properties

	// Input file.
	[ObservableProperty]
	public partial string		SaveFile { get; set; }							= string.Empty;

	public ISaveFilePicker		SaveFilePicker { get => _saveFilePicker; }

	#endregion

}