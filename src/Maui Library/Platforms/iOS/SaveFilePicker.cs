namespace DigitalProduction.Maui.Storage;

public partial class SaveFilePicker
{
	async public partial Task<string?> PickAsync(PickOptions options)
	{
		return await PickAsync(options, string.Empty);
	}

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