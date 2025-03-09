using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Maui.Views;
using DigitalProduction.Demo.ViewModels;
using DigitalProduction.Maui.Storage;

namespace DigitalProduction.Demo.Pages;

public partial class SaveFilePickerPage : BasePage<SaveFilePickerPageViewModel>
{
	public SaveFilePickerPage(SaveFilePickerPageViewModel viewModel) :
		base(viewModel)
	{
		InitializeComponent();
	}

	async void OnBrowseForFile(object sender, EventArgs eventArgs)
	{
		PickOptions pickOptions	= new() { PickerTitle="Select a Location for File Saving", FileTypes=CreateFilePickerFileType() };
		string? result          = await BrowseForFile(pickOptions);

		if (result != null)
		{
			SaveFileEntry.Text = result;
		}
	}

	public async Task<string?> BrowseForFile(PickOptions options)
	{
		try
		{
			return await BindingContext.SaveFilePicker.PickAsync(options, "New File Name.txt");
		}
		catch
		{
			// The user canceled or something went wrong.
		}

		return null;
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