namespace DigitalProduction.Maui.Services;

public class DialogService : IDialogService
{
	public Page? HostingPage { get; set; }

	public void ShowMessage(string title, string message, string closeButtonText)
	{
		System.Diagnostics.Debug.Assert(HostingPage != null, "The HostingPage property must be set before calling ShowMessage.");
		HostingPage.DisplayAlert(title, message, closeButtonText);
	}
}