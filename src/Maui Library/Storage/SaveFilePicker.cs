
namespace DigitalProduction.Maui.Storage;

public partial class SaveFilePicker : ISaveFilePicker
{
	public partial Task<string?> PickAsync(PickOptions options);
	public partial Task<string?> PickAsync(PickOptions options, string suggestedFileName);
}