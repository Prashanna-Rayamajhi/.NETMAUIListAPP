using PracticeAPP.ViewModels;

namespace PracticeAPP
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }

        
    }

}
