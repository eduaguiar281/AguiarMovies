using Xamarin;
using Xamarin.Forms.Platform.WPF;

namespace AguiarMovies.WPF
{
	public partial class MainWindow : FormsApplicationPage
	{
		public MainWindow()
		{
			InitializeComponent();
			Xamarin.Forms.Forms.Init();
			FormsMaps.Init(string.Empty);
			LoadApplication(new AguiarMovies.App());
		}
	}
}
