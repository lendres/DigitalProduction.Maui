namespace DigitalProduction.Maui.Storage;

public interface ISaveFilePicker
{
    Task<string?> PickAsync(PickOptions options, string suggestedFileName);
}