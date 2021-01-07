using PokeDex.View;

using Xamarin.Forms;

namespace PokeDex {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new PokeCollectionPage());
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
