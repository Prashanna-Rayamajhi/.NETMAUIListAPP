using PracticeAPP.ViewModels;

namespace PracticeAPP.Views;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}