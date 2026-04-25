using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Maui.Views;
using DigitalProduction.Demo.ViewModels;
using DigitalProduction.Maui.Storage;

namespace DigitalProduction.Demo.Pages;

public partial class PreferencesPage : BasePage<PreferencesPageViewModel>
{
	#region Fields

	#endregion

	#region Construction

	public PreferencesPage(PreferencesPageViewModel viewModel) :
		base(viewModel)
	{
		InitializeComponent();
	}

	#endregion
}