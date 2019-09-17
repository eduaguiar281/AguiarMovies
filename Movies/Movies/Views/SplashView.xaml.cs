using Xamarin.Forms;

namespace AguiarMovies.Views
{
    public partial class SplashView : ContentPage
    {
        public SplashView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}