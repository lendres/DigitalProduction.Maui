using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Maui.Views;
using DigitalProduction.Demo.ViewModels;
using DigitalProduction.Maui.Storage;

namespace DigitalProduction.Demo.Pages;

public partial class SaveFilePickerPage : BasePage<SaveFilePickerPageViewModel>
{
	#region Fields

	private ISaveFilePicker _saveFilePicker = DigitalProduction.Maui.Services.ServiceProvider.GetService<ISaveFilePicker>();

	#endregion

	public SaveFilePickerPage(SaveFilePickerPageViewModel viewModel) :
		base(viewModel)
	{
		InitializeComponent();
	}

	async void OnBrowseWithDefaultFile(object sender, EventArgs eventArgs)
	{
		PickOptions pickOptions	= new() { FileTypes=CreateFilePickerFileType() };
		string? result          = await _saveFilePicker.PickAsync(pickOptions, "New File Name.txt");

		if (result != null)
		{
			SaveFileEntry1.Text = result;
		}
	}

	async void OnBrowseWithOutDefaultFile(object sender, EventArgs eventArgs)
	{
		PickOptions pickOptions	= new() { FileTypes=CreateFilePickerFileType() };
		string? result          = await _saveFilePicker.PickAsync(pickOptions);

		if (result != null)
		{
			SaveFileEntry2.Text = result;
		}
	}

	private static FilePickerFileType CreateFilePickerFileType()
	{
		return new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
		{
			{ DevicePlatform.iOS, ["public.plain-text", "public.text"] },
			{ DevicePlatform.macOS, ["public.plain-text", "public.text"] },
			{ DevicePlatform.Android, ["text/plain"] },
			{ DevicePlatform.WinUI, [".txt", ".text"] },
		});
	}
}