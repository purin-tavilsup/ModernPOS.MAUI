using ModernPos.Views;

namespace ModernPos;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		
		Routing.RegisterRoute(nameof(CustomerPage), typeof(CustomerPage));
		// Register more pages here later
	}
}