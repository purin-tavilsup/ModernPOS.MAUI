namespace ModernPos.Services;

public class ThemeService : IThemeService
{
	public void ApplyTheme(AppTheme appTheme)
	{
		if (Microsoft.Maui.Controls.Application.Current is not null)
		{
			Microsoft.Maui.Controls.Application.Current.UserAppTheme = appTheme;
		}

		// Optional: Save to preferences so it persists
		Preferences.Set("AppTheme", appTheme.ToString());
	}
}