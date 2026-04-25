using DigitalProduction.Demo.ViewModels;

namespace DigitalProduction.Demo.Pages;

public class StorageGalleryPage(IDeviceInfo deviceInfo, StorageGalleryViewModel galleryViewModel) :
	BaseGalleryPage<StorageGalleryViewModel>("Controls", deviceInfo, galleryViewModel)
{
}