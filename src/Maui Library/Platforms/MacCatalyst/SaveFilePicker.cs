using AppKit;
using Foundation;

namespace DigitalProduction.Maui.Storage;

public partial class SaveFilePicker
{
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