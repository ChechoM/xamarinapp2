using Xamarin.Forms;

namespace AppParqueadero
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Startup.Initialize();
            MainPage = Startup.Resolve<AppShell>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}