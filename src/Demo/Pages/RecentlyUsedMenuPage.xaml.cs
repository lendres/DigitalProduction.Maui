using CommunityToolkit.Maui.Views;
using DigitalProduction.Demo.ViewModels;
using DigitalProduction.Maui.Controls;

namespace DigitalProduction.Demo.Pages;

public partial class RecentlyUsedMenuPage : BasePage<RecentlyUsedMenuPageViewModel>
{
	public RecentlyUsedMenuPage(RecentlyUsedMenuPageViewModel viewModel) :
		base(viewModel)
	{
		InitializeComponent();
		viewModel.MenuHostingPage = this;
	}

	async void OnSettingsClicked(object? sender, EventArgs args)
	{
		RecentlyUsedSettingPage view = new(new RecentlyUsedSettingViewModel());
		_ = await Shell.Current.ShowPopupAsync(view);
	}

	private async void OnRecentPathClicked(object? sender, PathClickedEventArgs eventArgs)
	{
		await DisplayAlert("Menu Clicked", $"The path {eventArgs.Path}  was selected.", "OK");
	}
}