using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ModernPos.Services;
using ModernPos.Views;

namespace ModernPos.ViewModels;

public partial class MainViewModel : ObservableObject
{
	private readonly IThemeService _themeService;
	
	[ObservableProperty]
	private bool _isDarkTheme = true;
	
	public string ThemeButtonLabel => IsDarkTheme ? "Light Theme" : "Dark Theme";
	
	public MainViewModel(IThemeService themeService)
	{
		_themeService = themeService;
	}
	
	[RelayCommand]
	private async Task NavigateCustomerAsync()
	{
		await Shell.Current.GoToAsync(nameof(CustomerPage));
	}
	
	[RelayCommand]
	private void ToggleTheme()
	{
		var theme = IsDarkTheme ? AppTheme.Dark : AppTheme.Light;
		
		_themeService.ApplyTheme(theme);
	}

	partial void OnIsDarkThemeChanged(bool value)
	{
		var theme = IsDarkTheme ? AppTheme.Dark : AppTheme.Light;
		
		_themeService.ApplyTheme(theme);
		
		OnPropertyChanged(nameof(ThemeButtonLabel));
	}
}