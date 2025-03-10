using Microsoft.UI.Xaml;
using Windows.Storage.Pickers;
using Windows.Storage;
using DigitalProduction.Maui.Storage;
using Microsoft.Maui.Storage;

namespace DigitalProduction.Maui.Storage;

public partial class SaveFilePicker
{
	async public partial Task<string?> PickAsync(PickOptions options)
	{
		return await PickAsync(options, string.Empty);
	}

	async public partial Task<string?> PickAsync(PickOptions options, string suggestedFileName)
	{
		FileSavePicker savePicker = new()
		{
			SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
			SuggestedFileName = suggestedFileName
		};

		// Set file type filters if provided.
		if (options.FileTypes != null)
		{
			IEnumerable<string>? fileExtensions = options.FileTypes.Value;
			if (fileExtensions != null)
			{
				foreach (string extension in fileExtensions)
				{
					savePicker.FileTypeChoices.Add($"{extension} File", [extension]);
				}
			}
		}

		// Get the MAUI application window.
		Microsoft.Maui.Controls.Application? mauiApp = Microsoft.Maui.Controls.Application.Current;
		if ((mauiApp?.Windows.FirstOrDefault())?.Handler?.PlatformView is not Microsoft.UI.Xaml.Window window)
		{
			return null;
		}

		// Get the HWND handle for the window.
		nint hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

		// Initialize the picker with the window handle.
		WinRT.Interop.InitializeWithWindow.Initialize(savePicker, hwnd);

		StorageFile file = await savePicker.PickSaveFileAsync();

		// Ensure the user selected a valid file name.
		if (file == null || string.IsNullOrWhiteSpace(file.Path) || !Path.HasExtension(file.Path))
		{
			return null;
		}

		return file.Path;
	}
}