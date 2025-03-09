using CommunityToolkit.Maui.Storage;
using DigitalProduction.Maui.Storage;
using Microsoft.Maui.Storage;

namespace DigitalProduction.Maui.Storage;

public partial class SaveFilePicker
{
	public partial Task<string?> PickAsync(PickOptions options, string suggestedFileName)
	{
        //var folderPicker = await FolderPicker.Default.PickAsync();
        //if (folderPicker != null)
        //{
        //    return Path.Combine(folderPicker.Path, suggestedFileName);
        //}
        //return null;
		return new Task<string?>(() => "");
	}
}