using DigitalProduction.Demo.Models;

namespace DigitalProduction.Demo.ViewModels;

public partial class StorageGalleryViewModel() : BaseGalleryViewModel(
[
	SectionModel.Create<PreferencesPageViewModel>("Preferences", "Manage application preferences."),
]);