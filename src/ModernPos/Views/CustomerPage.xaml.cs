using ModernPos.ViewModels;

namespace ModernPos.Views;

public partial class CustomerPage : ContentPage
{
	public CustomerPage(CustomerViewModel viewModel)
	{
		InitializeComponent();
		
		BindingContext = viewModel;
	}
}