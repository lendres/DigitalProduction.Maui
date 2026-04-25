namespace DigitalProduction.Maui.Storage;

public partial class SaveFilePicker
{
	async public partial Task<string?> PickAsync(PickOptions options)
	{
		return await PickAsync(options, string.Empty);
	}

	public partial Task<string?> PickAsync(PickOptions options, string suggestedFileName)
	{
		return new Task<string?>(() => "");
	}
}