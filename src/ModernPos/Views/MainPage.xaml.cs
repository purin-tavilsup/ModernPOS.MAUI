﻿using ModernPos.ViewModels;

namespace ModernPos.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		
		BindingContext = viewModel;
	}
}