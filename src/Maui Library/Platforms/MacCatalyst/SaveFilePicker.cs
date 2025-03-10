using AppKit;
using Foundation;

namespace DigitalProduction.Maui.Storage;

public partial class SaveFilePicker
{
	async public partial Task<string?> PickAsync(PickOptions options)
	{
		return await PickAsync(options, string.Empty);
	}

	public partial Task<string?> PickAsync(PickOptions options, string suggestedFileName)
	{
        //var panel = new NSSavePanel()
        //{
        //    Title = "Save File",
        //    NameFieldStringValue = suggestedFileName
        //};

        //if (panel.RunModal() == 1) // OK pressed
        //{
        //    return Task.FromResult(panel.Url?.Path);
        //}
        //return Task.FromResult<string?>(null);
		return new Task<string?>(() => "");
	}
}